using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Collections;

namespace LanMessengerChatRoomBase
{
    // Lớp cơ sở của ChatRoom
    public class SampleObject : MarshalByRefObject
    {

        Hashtable hTChatMsg = new Hashtable();
        ArrayList alOnlineUser = new ArrayList();
        private int key = 0;

        // Khi một contact tham gia Room
        public bool JoinToChatRoom(string name)
        {
            if (alOnlineUser.IndexOf(name) > -1)
                return false;
            else
            {
                alOnlineUser.Add(name);
                SendMsgToSvr(name + " in group!");
                return true;
            }

        }

        // Khi một contact rời Room
        public void LeaveChatRoom(string name)
        {
            alOnlineUser.Remove(name);
            SendMsgToSvr(name + " out group!");
        }
        
        // Những contact đang online
        public ArrayList GetOnlineUser()
        {
            return alOnlineUser;
        }
        
        public int CurrentKeyNo()
        {
            return key;
        }
        public void SendMsgToSvr(string chatMsgFromUsr)
        {
            //chatMsg = chatMsgFromUsr;
            hTChatMsg.Add(++key, chatMsgFromUsr);
        }
        public string GetMsgFromSvr(int lastKey)
        {
            if (key > lastKey)
                return hTChatMsg[lastKey + 1].ToString();
            else
                return "";
        }
    }
}
