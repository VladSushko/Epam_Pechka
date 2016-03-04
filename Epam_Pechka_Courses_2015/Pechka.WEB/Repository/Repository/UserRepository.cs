using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pechka.WEB.Models;
using Pechka.WEB.Repository.IRepository;
namespace Pechka.WEB.Repository.Repository
{
    public class UserRepository:IUserRepository
    {
        private  PechkaContext db=new PechkaContext();
        public bool ValidateUser(string email, string password)
        {
            bool isValid = false;

            using (db)
            {
                try
                {
                    User user = (from u in db.Users
                                 where u.Email == email && u.Password == password
                                 select u).FirstOrDefault();

                    if (user != null)
                    {
                        isValid = true;
                    }
                }
                catch
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        public User GetUserByEmail(string email)
        {
            using (db)
            {
                return db.Users.Where(u => u.Email == email).FirstOrDefault();
            }
        }
    }
}