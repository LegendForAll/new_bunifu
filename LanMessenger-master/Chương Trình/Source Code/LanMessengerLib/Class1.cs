using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

namespace LanMessengerLib
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	/// 
	[Serializable]
	public class LetterReceive
	{
		string message;
		string from;

		public LetterReceive(string message,string from)
		{
			this.message=message;
			this.from=from;
		}

		public string Message
		{
			get
			{
				return message;
			}
		}

		public string From
		{
			get
			{
				return from;
			}
		}
	}

	public interface IServer
	{
        // Cac thuoc tinh cua Global.server.xxx
		bool SignUp(string username,string password,string fullName,string IP);
		bool ChangePassword(string username,string curPassword,string newPassword);
		bool SignIn(string username,string password,bool visible);
		bool SignOut(string username);        
		bool IsVisible(string username);
		bool AddContact(string username,string contact);
		bool RemoveContact(string username,string contact);
        void ChangeStatus(string username);
        void ChangeDisplayName(string username, string displayName);
        string GetfullName(string username); // Display name
        string GetIP(string username); // Get Ip của 1 contact
        void SetIP(string username, string IP); // Ghi Ip của 1 contact
		ArrayList GetContacts(string username);

		bool Send(string from,string to,string message);
		LetterReceive Receive(string to);
		ArrayList ReceiveOffline(string to);
	}
}