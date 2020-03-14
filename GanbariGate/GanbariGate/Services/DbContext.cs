using System;
using System.IO;
using SQLite;

namespace GanbariGate.Services
{
    public class DbContext
    {
        public static SQLiteConnection CreateConnection()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "testDB.db3");
            
            var db = new SQLiteConnection(path);

            return db;
        }
        
        public static SQLiteAsyncConnection CreateAsyncConnection()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "testDB.db3");
            
            var db = new SQLiteAsyncConnection(path);

            return db;
        }
    }
}