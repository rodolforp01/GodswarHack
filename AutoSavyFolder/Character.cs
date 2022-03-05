using System.Text.RegularExpressions;
using System.Threading;
namespace GodswarHack.AutoSavyFolder
{
    class Character : MemoryFunc
    {
        public static int currentRBB = 0;
        public static int currentLevel = 0;
        public static int currentleft = 0;
        public static int petEXP = 0;

        public static int previous_lv = 0;
        public static int previous_left = 0;

        public static void openPetTAB(bool stage)
        {
            if(stage)
            {
                byte me = 1;
                int last = 0;
                Character.WriteProcessMemory(MemoryFunc.return_handle(), MemoryFunc.Last_Addr(MemoryAndOffsets.pettab,
                    MemoryAndOffsets.pettaboff), ref me, sizeof(int), last);
            }
            else
            {
                byte me = 0;
                int last = 0;
                Character.WriteProcessMemory(MemoryFunc.return_handle(), MemoryFunc.Last_Addr(MemoryAndOffsets.pettab,
                    MemoryAndOffsets.pettaboff), ref me, sizeof(int), last);
            }
        }
        public static bool isCharLocated()
        {
            float buffer = 0;
            int last = 0;
            RPbox.Form1.ReadProcessMemory(return_handle(),MemoryAndOffsets.charpos_x, ref buffer, 4, ref last);
            int a = (int)buffer;
            //if character is located
            if (a == 68)
                return true;
            return false;

        }
        public static bool isFirstWin_Open()
        {
            int last = 0;
            byte output = 0;
            ReadProcessMemory(return_handle(),Last_Addr(MemoryAndOffsets.First_WindAddr, MemoryAndOffsets.First_WindOffs), ref output, sizeof(int), ref last);
            int result = (int)output;

            if (result == 1)
                return true;
            return false;
            
        }
        public static bool isSecondWin_Open()
        {
            int last = 0;
            byte output = 0;
            ReadProcessMemory(return_handle(),Last_Addr(MemoryAndOffsets.Sec_WindAddr, MemoryAndOffsets.Sec_WindOffs), ref output, sizeof(int), ref last);
            int result = (int)output;
            if (result == 1)
                return true;
            return false; 
        }
        public static bool isPetOpen()
        {
            int last = 0;
            byte buff = 0;
            ReadProcessMemory(return_handle(),Last_Addr(MemoryAndOffsets.isPetOnAddr, MemoryAndOffsets.isPetOnOff), ref buff, sizeof(int), ref last);
            if ((int)buff == 1)
                return true;
            return false;
            
        }
        public static bool isPet_tab()
        {
            byte buff = 0;
            int last = 0;
            ReadProcessMemory(return_handle(),Last_Addr(MemoryAndOffsets.pettab, MemoryAndOffsets.pettaboff), ref buff, sizeof(int), ref last);
            if (buff == 1)
                return true;
            return false;

            
        }
        public static void useMD5()
        {
            int count = 0;
            for (; ; )
            {
                Thread.Sleep(4);
                RPbox.Form1.Rclick(554, 536);
                ++count;
                if(count > 225)
                {
                    break;
                }
            }
        }
        public static void level_up()
        {
            if (currentLevel == 120)
                return;
            int count = 0;
            for (; ; )
            {
                Thread.Sleep(2);
                RPbox.Form1.click(226, 442);
                PetLevel();
                if (currentLevel == 120)
                {
                    previous_lv = 125;
                    break;
                }
            }
            previous_left = 15;
            Thread.Sleep(25);
            
        }
        public static void Open_first_wind()
        {
            byte open = 1;
            int last = 0;
            WriteProcessMemory(return_handle(),Last_Addr(MemoryAndOffsets.First_WindAddr, MemoryAndOffsets.First_WindOffs), ref open, sizeof(int), last);
        }
        public static void Open_Second_Wind()
        {
            byte open = 1;
            int last = 0;
            WriteProcessMemory(return_handle(),Last_Addr(MemoryAndOffsets.Sec_WindAddr,MemoryAndOffsets.Sec_WindOffs), ref open, sizeof(int), last);
        }
        public static void open_wh_1()
        {
            int buff = 1;
            int last = 0;
            WriteProcessMemory(return_handle(), Last_Addr(MemoryAndOffsets.wh_Addr,MemoryAndOffsets.wh_offsets), ref buff, sizeof(int),  last);

        }
        public static void close_wh()
        {
            int buff = 0;
            int last = 0;
            WriteProcessMemory(return_handle(),Last_Addr(MemoryAndOffsets.wh_Addr,MemoryAndOffsets.wh_offsets), ref buff, sizeof(int), last);
        }
        public static string currentRB()
        {
            byte[] buffer = new byte[10];
            int last = 0;
            ReadProcessMemory(return_handle(),Last_Addr(MemoryAndOffsets.currentRB,MemoryAndOffsets.currentRBOffs), buffer, buffer.Length, ref last);
            string me = System.Text.Encoding.Unicode.GetString(buffer);
            string me2 = Regex.Match(me, @"\d+").Value; //find integers in a string but keep them as string
            if(me2 != "")
                currentRBB = System.Int32.Parse(me2); //convert the found integers(that are string XD) but lets make them real integers
            return me;
        }
        public static void OpenPet()
        {

        }
        public static string PetLevel()
        {
            byte[] buff = new byte[30];
            int last = 0;
            ReadProcessMemory(return_handle(), Last_Addr(MemoryAndOffsets.petLevel, MemoryAndOffsets.petlevelOffs),buff,buff.Length, ref last);
            string me = System.Text.Encoding.Unicode.GetString(buff);
            string findInt = Regex.Match(me, @"\d+").Value;
            if (findInt != "")
                currentLevel = System.Int32.Parse(findInt);
            return me;
        }
        public static string LeftRB()
        {
            byte[] data = new byte[10];
            int last = 0;
            ReadProcessMemory(return_handle(),Last_Addr(MemoryAndOffsets.leftrb, MemoryAndOffsets.leftRBoffs)
                   , data, data.Length, ref last);

            string dataString = System.Text.Encoding.Unicode.GetString(data);
            string findNumber = Regex.Match(dataString, @"\d+").Value;
            if (findNumber != "")
                currentleft = System.Int32.Parse(findNumber); //this is for the perpuse of converting a string to a integer

            return dataString;
        }
        public static void detailsTAB(bool open)
        {
            if(open)
            {
                byte me = 1;
                int last = 0;
                WriteProcessMemory(return_handle(),Last_Addr(MemoryAndOffsets.detailsTab, MemoryAndOffsets.detailsOff),ref me, sizeof(int), last);
                
            }
            else
            {
                byte me = 0;
                int last = 0;
                WriteProcessMemory(return_handle(), Last_Addr(MemoryAndOffsets.detailsTab, MemoryAndOffsets.detailsOff), ref me, sizeof(int), last);
                
            }  
        }
        public static void currentpetEXP()
        {
            byte[] me = new byte[30];
            int last = 0;
            ReadProcessMemory(return_handle(),Last_Addr(MemoryAndOffsets.petexp, MemoryAndOffsets.petexpOff), me, me.Length,ref last);
            string data = System.Text.Encoding.Unicode.GetString(me);
            string findInt = Regex.Match(data, @"\d+").Value;
            if (findInt != "")
                petEXP = System.Int32.Parse(findInt);
        }
        public static void Pet_stats_update()
        {
            previous_lv = currentLevel;
            previous_left = currentleft;
        }
    }
}
