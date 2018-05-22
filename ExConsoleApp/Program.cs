using System;
using System.Net.NetworkInformation;
using System.Linq;

namespace ExConsoleApp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var p = new Ping ();
			foreach (int i in Enumerable.Range(1, 10)) {
				var reply = p.Send("www.google.com");
				if(reply.Status == IPStatus.Success){
					Console.WriteLine("Reply from {0}:bytes={1} time={2}ms TTL={3}"
						,reply.Address
						,reply.Buffer.Length
						,reply.RoundtripTime
						,reply.Options.Ttl);
				}
				else
				{
					Console.WriteLine("Ping faild ({0})", reply.Status);
				}

				p.Dispose();
			}
		}
	}
}
