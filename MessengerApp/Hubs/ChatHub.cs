using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.Hubs
{
	public class ChatHub:Hub
	{
		public async Task Share(string user, string message)
		{
			//await Clients.All.SendAsync("receive", user, message);
			await Clients.Caller.SendAsync("receive", "-----", message);
			await Clients.Others.SendAsync("receive", user, message);

		}



		public override Task OnConnectedAsync()
		{



			return base.OnConnectedAsync();
		}

		public override Task OnDisconnectedAsync(Exception? exception)
		{
			return base.OnDisconnectedAsync(exception);
		}
	}
}
