using System.Collections.Generic;
using System.Threading.Tasks;
using GanbariGate.Models;
using SQLite;

namespace GanbariGate.Services
{
    public abstract class BaseSQLiteDataStore<T> : IDataStore<T> where T : BaseEntity, new()
    {
        private readonly SQLiteAsyncConnection _connection;

        protected BaseSQLiteDataStore()
        {
            _connection = DbContext.CreateAsyncConnection();
            _connection.CreateTableAsync<T>().Wait();
        }

        public async Task<bool> AddItemAsync(T item)
        {
            var count = await _connection.InsertAsync(item);
            return count == 1;
        }

        public async Task<bool> UpdateItemAsync(T item)
        {
            var count = await _connection.UpdateAsync(item);
            return count == 1;
        }

        public async Task<bool> DeleteItemAsync(long id)
        {
            var count = await _connection.DeleteAsync<T>(id);
            return count == 1;
        }

        public async Task<T> GetItemAsync(long id)
        {
            var count = await _connection.GetAsync<T>(id);
            return count;
        }

        public async Task<IEnumerable<T>> GetItemsAsync()
        {
            var result = await _connection.Table<T>().ToArrayAsync();
            return result;
        }
    }
}