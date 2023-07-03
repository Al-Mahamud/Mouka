using Mauka.Entities;
using Mouka.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouka.Services
{
    public class UserService
    {
        public User GetUser(int ID)
        {
            using (var context = new MoukaContext())
            {
                return context.Users.Find(ID);
            }
        }
        public List<User> GetUsers()
        {
            using (var context = new MoukaContext())
            {
                return context.Users.ToList();
            }
        }
        public void SaveUser(User user)
        {
            using (var context = new MoukaContext())
            {
                context.Users.Add(user);

                context.SaveChanges();
            }
        }

        public void UpdateUser(User user)
        {
            using (var context = new MoukaContext())
            {
                context.Entry(user).State = System.Data.Entity.EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void DeleteUser(int ID)
        {
            using (var context = new MoukaContext())
            {
                //context.Entry(category).State = System.Data.Entity.EntityState.Deleted;

                var user = context.Users.Find(ID);
                context.Users.Remove(user);

                context.SaveChanges();
            }
        }
        public bool AuthenticateUser(string email, string password)
        {
            var users = GetUsers(); // Assuming GetUsers returns a list of User objects

            foreach (var user in users)
            {
                if (user.Email == email && user.Password == password)
                {
                    return true; // Authentication successful
                }
            }

            return false; // Authentication failed
        }

    }
}
