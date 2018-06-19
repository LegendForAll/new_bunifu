using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using System.Net;
namespace Temporary_Server
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			//
			// TODO: Add code to start application here
			//

            // Khởi tạo kênh liên lạc với remote Object.
			HttpChannel channel = new HttpChannel(9090);

            ChannelServices.RegisterChannel(channel);
            IPHostEntry IP = Dns.GetHostByName(Dns.GetHostName().ToString());
            string IP_temp = IP.AddressList[0].ToString();

            Console.WriteLine("Da khoi dong Server! (Server IP: " + IP_temp + ")");
            Console.WriteLine("History: ");

            // Ở đây sẽ sử dụng Singleton để duy trì trạng thái với nhiều kết nối Client 
			RemotingConfiguration.RegisterWellKnownServiceType(Type.GetType("Temporary_Server.Server"),"Server",WellKnownObjectMode.Singleton); // Cho Server chat thuong           
			Console.ReadLine();
		}
	}
}