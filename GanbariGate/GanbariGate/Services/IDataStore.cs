using System.Collections.Generic;
using System.Threading.Tasks;
using GanbariGate.Models;

namespace GanbariGate.Services
{
    public interface IDataStore<T> where T : BaseEntity
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(long id);
        Task<T> GetItemAsync(long id);
        Task<IEnumerable<T>> GetItemsAsync();
    }
}
