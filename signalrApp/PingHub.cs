using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace signalrApp
{
    public class PingHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.addMessage(message + DateTime.Now);
        }
    }
}