using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace GodswarHack
{
    public partial class OpenRB
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int WriteProcessMemory(int handle, int addr, ref byte buff, int bytes, int b2tes);

        //open rb addr with its offsets
        public static int addr = 0x01576220;
        public static int[] offsets = { 0x50, 0x1C4, 0x54, 0x50, 0x164, 0xD8, 0x10D };

        //rebirth panel address
        public static int final_addr()
        {
            int handle = RPbox.Form1.OpenProcess(2035711, 0, Conversions.ToInteger(RPbox.Form1.Processididid.SelectedItem));
            //important part here never use global variables to read assign them to a var within the scope to modify it
            int buffer = addr;
            int reference = 0;
            for (int i = 0; i < offsets.Length; ++i)
            {
                //we need to store it on the buffer, then read it so that it indexes through the memory
                RPbox.Form1.ReadProcessMemory_2(handle, buffer, ref buffer, sizeof(int), ref reference);
                buffer += offsets[i];
              
            }
            return buffer;
        }


        //returns the right memory address of the rb panel on ender54
        public static void RB_ADDR(bool stage)
        {
            int finaladdress = final_addr();
            int handle = RPbox.Form1.OpenProcess(2035711, 0, Conversions.ToInteger(RPbox.Form1.Processididid.SelectedItem));

            if (stage)
            {
                byte bytesToWrite = 1;
                WriteProcessMemory(handle, finaladdress, ref bytesToWrite, sizeof(int), 0);
            }
            else
            {
                
                byte bytesToWrite = 0;
                WriteProcessMemory(handle, finaladdress, ref bytesToWrite, sizeof(int), 0);
            }

        }


    }
}
