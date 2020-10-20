using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Subscribers.Contracts
{
    public interface IDatabaseSubscription
    {
        void Configure(string connectionString);
    }
}
