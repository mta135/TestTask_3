using FlowerSalesStore.Domain.Entities;
using FlowerSaleStore.WebUI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace FlowerSaleStore.WebUI.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.session = session;
            return cart;
        }


        //[JsonIgnore]
        //public ISession Session { get; set; }


        private ISession session { get; set; }

        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            session.SetJson("Cart", this);
        }

        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            session.Remove("Cart");
        }
    }

}
