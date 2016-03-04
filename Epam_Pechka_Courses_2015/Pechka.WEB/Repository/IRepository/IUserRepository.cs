using Pechka.WEB.Models;
namespace Pechka.WEB.Repository.IRepository
{
    interface IUserRepository
    {
        bool ValidateUser(string email, string password);
        User GetUserByEmail(string email);
    }
}