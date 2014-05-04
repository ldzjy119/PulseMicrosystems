using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace PulseMicrosystemsMVC.Hubs
{
    public class FieldsHub : Hub
    {
        public void Send(string id, string message)
        {
            // Call the addValuesToFields method to update clients.
            Clients.All.addValuesToFields(id, message);
        }
    }
}