using System;
using System.Runtime.InteropServices;

namespace TrayBalloon
{
	public class TrayBalloon : IDisposable
	{
		private readonly TrayBalloonFrm Frm;

		private delegate void RunDialogHandler();

		private readonly static System.Collections.Queue CurrentlyVisible;

        static TrayBalloon()
        {
            CurrentlyVisible = 
                System.Collections.Queue.Synchronized(new System.Collections.Queue());
        }

		public TrayBalloon()
		{
			Frm = new TrayBalloonFrm();
		}

		public string Message
		{
			get
			{
                return Frm.Message;
			}

			set
			{
                Frm.Message = value;
			}
		}

        public bool UseOpacity
        {
            get
            {
                return Frm.UseOpacity;
            }
            set
            {
                Frm.UseOpacity = value;
            }
        }

        public bool TopMost
        {
            get
            {
                return Frm.TopMost;
            }
            set
            {
                Frm.TopMost = value;
            }
        }

        public bool LightWeight
        {
            get
            {
                return Frm.LightWeight;
            }
            set
            {
                Frm.LightWeight = value;
            }
        }

		public string Title
		{
			get
			{
                return Frm.Title;
			}

			set
			{
                Frm.Title = value;
			}
		}

        public string SoundLocation
        {
            get
            {
                return Frm.SoundLocation;
            }
            set
            {
                Frm.SoundLocation = value;
            }
        }

        public string BackgroundLocation
        {
            get
            {
                return Frm.BackgroundLocation;
            }
            set
            {
                Frm.BackgroundLocation = value;
            }
        }

		private static void Unregister()
		{
            lock (CurrentlyVisible)
            {
                CurrentlyVisible.Dequeue();
            }
		}

        private int GetFreeCount()
        {
            int Full = System.Windows.Forms.SystemInformation.WorkingArea.Height;
            return Full / Frm.Height;
        }

		private int RegisterAndStartingOffsetIndex()
		{
            lock (CurrentlyVisible)
			{
				CurrentlyVisible.Enqueue(Frm);

				if (CurrentlyVisible.Count <= 1)
					return 0;

                bool[] Poss = new bool[GetFreeCount()];
                for (int Idx = 0; Idx < Poss.Length; Idx++)
					Poss[Idx] = true;

				foreach (TrayBalloonFrm XFrm in CurrentlyVisible.ToArray())
				{
					if (!(XFrm == Frm))
                        if (XFrm.StartingOffsetIndex < Poss.Length)
						    Poss[XFrm.StartingOffsetIndex]  = false;
				}

                for (int Idx = 0; Idx < Poss.Length; Idx++)
					if (Poss[Idx] == true)
						return Idx;

				return Poss.Length - 1;
			}
		}

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int flags);

        private void RunDialog()
		{
			Frm.StartingOffsetIndex = RegisterAndStartingOffsetIndex();
            
            SetWindowPos(Frm.Handle, (IntPtr)(-1), 0, 0, 0, 0, 0x50);

            Frm.ShowDialog();
			Unregister();
		}

		public void Run()
		{
			RunDialogHandler RDH = new RunDialogHandler(RunDialog);
			RDH.BeginInvoke(null, null);
		}

		public void Run(string Message)
		{
			this.Message = Message;
			Run();
		}

        public void Run(string Title, string Message)
		{
            this.Title = Title;
			this.Message = Message;
			Run();
		}


        #region IDisposable Members

        public void Dispose()
        {
            Frm.Dispose();
        }

        #endregion
    }
}
