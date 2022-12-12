using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Project5.Models;

namespace Project5.Services
{
    public class UserService : IUserService
    {
        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Project5.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<User>();
            }
        }
        public async Task<int> AddUser(User userModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(userModel);
        }

        public async Task<int> UpdateUser(User userModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(userModel);
        }
        public async Task<int> DeleteUser(User userModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(userModel);
        }

        public async Task<User> GetUser(string email)
        {
            await SetUpDb();
            return await _dbConnection.Table<User>().Where(i => i.Email == email).FirstOrDefaultAsync();
            
        }
    }
}
