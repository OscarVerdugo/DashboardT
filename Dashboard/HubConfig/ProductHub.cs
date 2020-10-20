
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.HubConfig
{
    public class ProductHub : Hub
    {
        //public Task RegisterProduct(string productName, int quantity)
        //{
        //    _repo.RegisterProduct(productName, quantity);
        //    return Clients.All.InvokeAsync("UpdateCatalog", _repository.Products);
        //}

        //public async Task SellProduct(string product, int quantity)
        //{
        //    await _repository.SellProduct(product, quantity);
        //    await Clients.All.InvokeAsync("UpdateCatalog", _repository.Products);
        //}
    }
}
