using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRCourse
{
    public class BroadcastHub : Hub
    {
        public void Broadcast(string name , string message)
        {
            Clients.All.showmessage(name, message);

        }
    }
}