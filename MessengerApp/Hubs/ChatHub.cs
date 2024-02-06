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
			await Clients.Caller.SendAsync("selfMsg", message);
			await Clients.Others.SendAsync("msgRcv", user, message);

		}

		public async Task ShareImage(string user, string imageData)
		{
			//await Clients.All.SendAsync("receive", user, message);
			await Clients.Caller.SendAsync("imgRcv", user, imageData);
			await Clients.Others.SendAsync("imgRcv", user, imageData);

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
