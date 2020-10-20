using Dashboard.HubConfig;
using Dashboard.Subscribers.Contracts;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;

namespace Dashboard.Subscribers
{
    public class ProductSubscriber : IDatabaseSubscription
    {
        private bool disposedValue = false;
        private readonly IHubContext<ProductHub> _hubContext;
        private SqlTableDependency<Product> _tableDependency;

        public ProductSubscriber( IHubContext<ProductHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public void Configure(string connectionString)
        {
            _tableDependency = new SqlTableDependency<Product>(connectionString,
                                                               null,
                                                               null,
                                                               null,
                                                               null,
                                                               null,
                                                               DmlTriggerType.Update);
            _tableDependency.OnChanged += Changed;
            _tableDependency.OnError += TableDependency_OnError;
            _tableDependency.Start();

            //Console.WriteLine("Waiting for receiving notifications...");
        }

        private void TableDependency_OnError(object sender, ErrorEventArgs e)
        {
           // Console.WriteLine($"SqlTableDependency error: {e.Error.Message}");
        }

        private void Changed(object sender, RecordChangedEventArgs<Product> e)
        {
            if (e.ChangeType != ChangeType.None)
            {
                // TODO: manage the changed entity
                var changedEntity = e.Entity;
                _hubContext.Clients.All.SendAsync("UpdateCatalog");
            }
        }

        #region IDisposable

        ~ProductSubscriber()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _tableDependency.Stop();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
