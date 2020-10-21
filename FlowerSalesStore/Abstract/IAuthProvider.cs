using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerSalesStore.Domain.Abstract
{
    public interface IAuthProvider
    {
        bool Authenticate(string UserName, string Password);
    }
}
