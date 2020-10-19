using Dashboard.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.HubConfig
{
    public class ChartHub: Hub
    {
        public string GetConnectionId() => Context.ConnectionId;

        public async Task BroadcastChartData(List<ChartModel> data) => await Clients.All.SendAsync("broadcastchartdata", data);

        public async Task BroadcastChartDataToSpecific(List<ChartModel> data, string connectionId)
        => await Clients.Client(connectionId).SendAsync("broadcastchartdata", data);
    }
}
