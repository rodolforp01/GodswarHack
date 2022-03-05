using System.Runtime.InteropServices;

namespace GodswarHack.AutoSavyFolder
{
    public class MemoryFunc
    {
        #region
        [DllImport("kernel32.dll", EntryPoint = "OpenProcess")]
        public static extern int OpenProcess(int access, int nothing, int pid);

        [DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory")]
        public static extern bool ReadProcessMemory(int handle, int memoryaddr, ref int buffer, int ssize, ref int last);

        [DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory")]
        public static extern bool ReadProcessMemory(int handle, int memoryaddr,  byte[] buffer, int ssize, ref int last);
        [DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory")]
        public static extern bool ReadProcessMemory(int handle, int memoryaddr, ref byte buffer, int ssize, ref int last);

        [DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory")]
        public static extern bool WriteProcessMemory(int handle, int memoryaddr, ref byte buffer, int ssize, int last);

        [DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory")]
        public static extern bool WriteProcessMemory(int handle, int memoryaddr, ref int buffer, int ssize, int last);

        [DllImport("kernel32.dll", EntryPoint = "CloseHandle")]
        public static extern bool CloseHandle(int handle);
        #endregion

        //get the last address
        public static int Last_Addr(int memory, int[] offsets)
        {
            int handle = return_handle();
            int buffer = memory; //this is the memory address
            int last = 0;

            for (int i = 0; i < offsets.Length; ++i)
            {
                ReadProcessMemory(handle, buffer, ref buffer, sizeof(int), ref last);
                buffer += offsets[i];
            }
            CloseHandle(handle);
            return buffer;
        }
        //returns the handle of the selected windows
        public static int return_handle()
        {
            int handle = OpenProcess(2035711, 0, (int)RPbox.Form1.Processididid.SelectedItem);
            if (handle == 0)
                System.Windows.Forms.MessageBox.Show("Invalid handle");

            return handle;
            
            
        }
        
        

    }
}
