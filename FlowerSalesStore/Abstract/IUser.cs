using FlowerSalesStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerSalesStore.Domain.Abstract
{
    public interface IUser
    {
        IEnumerable<User> Users { get; }
        void InsertUser(User user);
        User FindUserByLoginAndPasswword(string login, string password);


        // test
    }
}
