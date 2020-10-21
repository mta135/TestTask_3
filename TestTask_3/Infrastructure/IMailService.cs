using FlowerSaleStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerSaleStore.WebUI.Infrastructure
{
    public interface IMailService
    {
        void SendEmail(MailRequest mailRequest);
    }
}
