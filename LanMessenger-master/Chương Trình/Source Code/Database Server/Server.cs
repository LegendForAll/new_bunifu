using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.IO;

using LanMessengerLib;

namespace Temporary_Server
{
	public class Server : MarshalByRefObject, LanMessengerLib.IServer
	{
		Database database = new Database();

		//Internal Class
		[Serializable]
		public class Letter
		{
			string from;
			string to;
			string message;
			
			public Letter(string from,string to,string message)
			{
				this.from=from;
				this.to=to;
				this.message=message;
			}

			public string From
			{
				get
				{
					return from;
				}
			}

			public string To
			{
				get
				{
					return to;
				}
			}
			public string Message
			{
				get
				{
					return message;
				}
			}
		}

		ArrayList letters = new ArrayList();
		

		//Constructor
		public Server()
		{
			database.Load();
		}

		//Methods
		public bool SignUp(string username,string password,string fullName, string IP)
		{
			return database.Add(username,password,fullName,IP);
		}

		public bool ChangePassword(string username,string curPassword,string newPassword)
		{
			return database.ChangePassword(username,curPassword,newPassword);
		}

		public bool SignIn(string username,string password,bool visible)
		{			
			return database.SignIn(username,password,visible);
		}

		public bool SignOut(string username)
		{
			return database.SignOut(username);
		}

		public bool IsLoggedIn(string username)
		{
			return database.IsLoggedIn(username);
		}

		public bool IsVisible(string username)
		{
			return database.IsVisible(username);
		}

        public void ChangeStatus(string username)
        {
            database.ChangeStatus(username);
        }

        public void ChangeDisplayName(string username, string displayName)
        {
            database.ChangeDisplayName(username, displayName);
        }

        public string GetfullName(string username)
        {
            return database.GetfullName(username);
        }

        public void SetIP(string username, string IP)
        {
            database.SetIP(username, IP);
        }

        public string GetIP(string username)
        {
            return database.GetIP(username);
        }

		public bool AddContact(string username,string contact)
		{
			return database.AddContact(username,contact);
		}

		public bool RemoveContact(string username,string contact)
		{
			return database.RemoveContact(username,contact);
		}

		public ArrayList GetContacts(string username)
		{
			return database.GetContacts(username);
		}

        private const int maxOfflineMessages = 100; // Giới hạn lượng tin nhắn offline tối đa

		public bool Send(string from,string to,string message)
		{
            // Kiểu tra sự tồn tại của đối tượng gửi.
			if(database.ContactExists(to)==false)
				return false;
            // Nếu bạn Chat đã đăng nhập thì gửi tin nhắn trực tiếp (kể cả ẩn nick)
			if(database.IsLoggedIn(to))
				letters.Add(new Letter(from,to,message));
			else
			{
                // Ngược lại, gửi tin nhắn Offline
				database.offlineMessages.Add(new Letter(from,to,message));
				if(database.offlineMessages.Count>maxOfflineMessages)
				{
					database.offlineMessages.RemoveAt(0);
				}
				//Console.WriteLine(database.Save());
                Console.WriteLine(DateTime.Now.ToString() + ": Da gui tin nhan Offline toi " + to);
			}
			return true;
		}		
		public ArrayList ReceiveOffline(string to)
		{
			int length=database.offlineMessages.Count;
			ArrayList offlines = new ArrayList();
			for(int i = 0; i < length; i++)
			{
				if((database.offlineMessages[i] as Letter).To==to)
				{
					offlines.Add(new LetterReceive((database.offlineMessages[i] as Letter).Message,(database.offlineMessages[i] as Letter).From));
					database.offlineMessages.RemoveAt(i);
					i--;
					length--;
					continue;
				}
			}
			return offlines;
		}
		public LetterReceive Receive(string to)
		{
			int length = letters.Count;
			for(int i =0;i<length;i++)
			{
				if(((Letter)letters[i]).To==to)
				{
					LetterReceive lr = new LetterReceive(((Letter)letters[i]).Message,((Letter)letters[i]).From);
					letters.RemoveAt(i);
					return lr;
				}
			}
			return new LetterReceive("","");
		}
	}
}