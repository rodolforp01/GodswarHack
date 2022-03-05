using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GodswarHack
{
    public partial class AutoDCForm : Form
    {
       
        public const int WM_NCLBUTTONDOWN = 0xA1; //to be able to move the form
        public const int HT_CAPTION = 0x2; //here wit the above

        [DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory")]
        public static extern bool ReadProcessMemory_2(int handle, int address, ref int buffer, int numbytes, ref int last);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int WriteProcessMemory(int handle, int addr, string buff, int bytes,int b2tes);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr gWnd, int msg, int wParam, int lpad);

        public static bool running = true;

        
        
        public AutoDCForm()
        {
            InitializeComponent();
        }


        private void AutoDCForm_MouseDown(object sender, MouseEventArgs e)
        {
            
            if(e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN,HT_CAPTION,0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        //This is the startDC function
        private void StartDC(object sender, EventArgs e)
        {
            running = true;
            int handle = RPbox.Form1.OpenProcess(2035711, 0, GetPID());
            int address = 0x1576244;
            int value = 0;
            int bytestoRead = 0;
            ReadProcessMemory_2(handle, address, ref value, sizeof(int), ref bytestoRead);
            int offset1 = value + 0x50;
            ReadProcessMemory_2(handle, offset1, ref offset1, sizeof(int), ref bytestoRead);
            int offset2 = offset1 + 0x33C;
            ReadProcessMemory_2(handle, offset2, ref offset2, sizeof(int), ref bytestoRead);
            int offset3 = offset2 + 0x0;
            ReadProcessMemory_2(handle, offset3, ref offset3, sizeof(int), ref bytestoRead);
            int offset4 = offset3 + 0x40;
            ReadProcessMemory_2(handle, offset4, ref offset4, sizeof(int), ref bytestoRead);
            int offset5 = offset4 + 0x4;

            for (; ; )
            {

                Thread.Sleep(1200);
                for (int n = 0; n < richTextBox1.Lines.Length; n++)
                {

                    Interaction.AppActivate(GetPID());
                    WriteProcessMemory(handle, offset5, Conversions.ToString(richTextBox1.Lines[n]), 20, 0);
                    Thread.Sleep(500);
                    actions();
                    Thread.Sleep(100);
                    if(!running)
                    {
                        return;
                    }
                }
            }

        }

        

        private void actions()
        {
            IntPtr gw = Process.GetProcessById(GetPID()).MainWindowHandle;
            Rectangle geRect = default(Rectangle);

            RPbox.Form1.GetWindowRect(gw, ref geRect); //stores the window rect in geRect

            
            RPbox.Form1.SetCursorPos(geRect.X + 372, geRect.Y + 358);
            //Clicks Ok button after writing to memory
            RPbox.Form1.MouseEventFunc();
            Thread.Sleep(100);
            //Clicks the cancel button
            RPbox.Form1.SetCursorPos(geRect.X + 399, geRect.Y + 359);
            RPbox.Form1.MouseEventFunc();
            Thread.Sleep(1500);
            //Clicks password incorrect OK
            RPbox.Form1.SetCursorPos(geRect.X + 401, geRect.Y + 359);
            RPbox.Form1.MouseEventFunc();
            Thread.Sleep(500);
            //Clicks the login button
            RPbox.Form1.SetCursorPos(geRect.X + 403, geRect.Y + 413);
            RPbox.Form1.MouseEventFunc();
            Thread.Sleep(2500);
            if (atlantaSV.Checked && !fornaxSV.Checked)
            {
                //up sv
                RPbox.Form1.click(649, 280); //click up arrow
                
                RPbox.Form1.click(209, 278); //select atlanta server
                
                //clicks enter
                RPbox.Form1.SetCursorPos(geRect.X + 546, geRect.Y + 532);
                RPbox.Form1.MouseEventFunc();
               

            }
            else if (fornaxSV.Checked && !atlantaSV.Checked)
            {
                RPbox.Form1.click(644, 491); //click down arrow
                RPbox.Form1.click(559, 281); //selects fornax server
                
                //clicks enter
                RPbox.Form1.SetCursorPos(geRect.X + 546, geRect.Y + 532);
                RPbox.Form1.MouseEventFunc();
                
            }
            //checks if the server is bugged
            serverBugged();
          
        }

        //Just need to put some mouse events here and thats it
        private void backtoServerFunc()
        {
            
            IntPtr gw = Process.GetProcessById(GetPID()).MainWindowHandle;
            Rectangle gwrect = default(Rectangle);

            RPbox.Form1.GetWindowRect(gw, ref gwrect);
            Thread.Sleep(2000);
            //Cancels the server
            RPbox.Form1.SetCursorPos(gwrect.X + 236, gwrect.Y + 528);
            RPbox.Form1.MouseEventFunc();
            RPbox.Form1.MouseEventFunc();
            Thread.Sleep(1500);
            //Incorrect password ok
            RPbox.Form1.SetCursorPos(gwrect.X + 401, gwrect.Y + 359);
            RPbox.Form1.MouseEventFunc();
            //Clicks login
            RPbox.Form1.SetCursorPos(gwrect.X + 403, gwrect.Y + 413);
            RPbox.Form1.MouseEventFunc();
            Thread.Sleep(2000);
            //Clicks to enter the server
            if (atlantaSV.Checked && !fornaxSV.Checked)
            {
                //up sv
                RPbox.Form1.click(649, 280); //click up arrow
                
                RPbox.Form1.click(209,278); //select atlanta server
                
                //clicks enter
                RPbox.Form1.SetCursorPos(gwrect.X + 546, gwrect.Y + 532);
                RPbox.Form1.MouseEventFunc();
                
            }
            else if (fornaxSV.Checked && !atlantaSV.Checked)
            {
                RPbox.Form1.click(644, 491); //click down arrow
                
                RPbox.Form1.click(559, 281); //selects fornax server
                
                //clicks enter
                RPbox.Form1.SetCursorPos(gwrect.X + 546, gwrect.Y + 532);
                RPbox.Form1.MouseEventFunc();
               
            }
            
            serverBugged();
            
        }

        //server bugged check
        private void serverBugged()
        {
            int counter = 0;
            while (charInUse() != 1)
            {
                
                if (charInUse() == 0)
                {
                    Thread.Sleep(100);
                    counter++;
                    if (counter >= 50)
                    {
                        backtoServerFunc();
                        break;
                    }
                    if(!running)
                    {
                        return;
                    }

                }
            }

        }

        //understanding readprocess memory
        private int charInUse()
        {
            int handle = RPbox.Form1.OpenProcess(2035711, 0, GetPID());
            int baseAddr = 0x01576334;
            int value = 0;
            int last = 0;
            ReadProcessMemory_2(handle, baseAddr, ref value, sizeof(int), ref last);
            value = value + 0x44;
            ReadProcessMemory_2(handle, value, ref value, sizeof(int), ref last);
            value = value + 0x50;
            ReadProcessMemory_2(handle, value, ref value, sizeof(int), ref last);
            value = value + 0x1C8;
            ReadProcessMemory_2(handle, value, ref value, sizeof(int), ref last);
            value = value + 0x50;
            ReadProcessMemory_2(handle, value, ref value, sizeof(int), ref last);
            value = value + 0x1EC;
            ReadProcessMemory_2(handle, value, ref value, sizeof(int), ref last);
            value = value + 0x10D;
            ReadProcessMemory_2(handle, value, ref value, sizeof(int), ref last);

            //when value equals one
            if (value == -16776959)
                return 1;
            //when value equals zero
            if (value == -16776960)
                return 0;

            return 2;
        }
        //Gets the pID of the selectedProcess
        private static  int GetPID()
        {
            int pid = Conversions.ToInteger(RPbox.Form1.Processididid.SelectedItem);
            return pid;
            
        }

        void stopDC()
        {
            for (; ; )
            {
                Thread.Sleep(40);
                if (GodswarHack.KeyPressed.isPressed() == true)
                {
                    running = false;
                    Close();
                }
            }
        }

        private void AutoDCForm_Load(object sender, EventArgs e)
        {
            running = true;
            Thread me = new Thread(stopDC);
            me.SetApartmentState(ApartmentState.STA);
            me.IsBackground = true;
            CheckForIllegalCrossThreadCalls = false;
            me.Start();
            
        }

        //only 1 checkbox allowed
        
        private void atlantaSV_CheckedChanged(object sender, EventArgs e)
        {
            fornaxSV.Checked = false;
        }

        private void fornaxSV_CheckedChanged(object sender, EventArgs e)
        {
            atlantaSV.Checked = false;
        }
    }
}
