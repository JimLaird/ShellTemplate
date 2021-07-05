using System;
using System.Collections.Generic;
using System.Text;
using ShellTemplate.Models;
using System.Threading.Tasks;

namespace ShellTemplate.Services
{
    public interface IDataService
    {
        Task SaveUser(string name, string email, string password, string regdate);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task RemoveUser(int id);
        Task UpdateUser(int id, string email, string password, string image);
        Task<User> CheckUserExists(string email);
        Task<User> ValidateLogin(string email, string password);
    }
}
