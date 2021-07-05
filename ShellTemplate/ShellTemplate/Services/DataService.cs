using System;
using System.Collections.Generic;
using System.Text;
using ShellTemplate.Services;
using SQLite;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using ShellTemplate.Models;

[assembly: Dependency(typeof(DataService))]
namespace ShellTemplate.Services
{
    
    public class DataService : IDataService
    {
        //  Create Database Connection
        SQLiteAsyncConnection db;

        async Task Init()
        {
            if (db != null)
                return;

            //  Get path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, Constants.DBName);

            db = new SQLiteAsyncConnection(databasePath, Constants.Flags, true);

            //  Create tables
            await db.CreateTableAsync<User>();
        }

        public async Task UpdateUser(int id, string email, string password, string image)
        {
            var user = await GetUser(id);

            if (user != null)
            {
                user.Email = email;
                user.Pass = password;
                user.Image = image;

                await db.UpdateAsync(user);
            }
        }
        public async Task SaveUser(string name, string email, string password, string regdate)
        {
            var user = new User
            {
                Name = name,
                Email = email,
                Pass = password,
                RegDate = regdate
            };

            var id = await db.InsertAsync(user);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            await Init();

            var user = await db.Table<User>().ToListAsync();
            return user;
        }

        public async Task<User> GetUser(int id)
        {
            await Init();

            var user = await db.Table<User>().FirstOrDefaultAsync(c => c.Id == id);
            return user;
        }

     
        public async Task RemoveUser(int id)
        {
            await Init();

            await db.DeleteAsync<User>(id);
        }

        public async Task<User> CheckUserExists(string email)
        {
            await Init();

            try
            {
                var p = db.Table<User>();
                var result = p.Where(x => x.Email == email).FirstOrDefaultAsync();

                return await result;    
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> ValidateLogin(string email, string password)
        {
            await Init();

            try
            {
                var p = db.Table<User>();
                var result = p.Where(x => x.Email == email && x.Pass == password).FirstOrDefaultAsync();

                return await result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }   
    }
}
