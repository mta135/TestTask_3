using FlowerSalesStore.Domain.Abstract;
using FlowerSalesStore.Domain.Data;
using FlowerSalesStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerSaleStore.WebUI.Infrastructure
{
    public class UserRepository : IUser
    {

        private readonly FlowerSaleStoreDbContext context;
        public UserRepository(FlowerSaleStoreDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> Users
        {
            get
            {
                return context.Users;
            }
        }

        public User FindUserByLoginAndPasswword(string login, string password)
        {
            User user = new User();
            user = Users.Where(u => u.Login.Equals(login) && u.Password.Equals(password)).FirstOrDefault();
            return user;
        } 


        public void InsertUser(User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
            }catch(Exception ex)
            {
                string exception = ex.ToString();
            }
        }
    }
}
