using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LanMessengerSendFile
{
    [Serializable]
    public class SendData
    {
        private int command;

        public int Command
        {
            get { return command; }
            set { command = value; }
        }

        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public byte[] FileData
        {
            get { return fileData; } 
            set { fileData = value; }
        }

        private byte[] fileData;

        public SendData(int command, string fileName = null, byte[] fileData = null)
        {
            this.command = command;
            this.fileName = fileName;
            this.fileData = fileData;
        }
    }

    public enum DataCommand
    {
        SEND_DATA,
        QUIT
    }
}
