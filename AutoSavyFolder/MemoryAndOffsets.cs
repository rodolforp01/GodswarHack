namespace GodswarHack.AutoSavyFolder
{
    public class MemoryAndOffsets
    {
        //wh memory and offsets
        
        public static int wh_Addr = 0x1576274;
        public static int[] wh_offsets = { 0x50, 0x164, 0x1E8, 0x10D };
        
        //char pos addr
       
        //FIXME i need to find a pointer for char postion and make it global
        public static int charpos_x = 0x00199850;
        
        //first wind addr
        public static int First_WindAddr = 0x015761F0;
        public static int[] First_WindOffs = { 0x50, 0x164, 0x180, 0x164, 0x34, 0x50, 0x10D };
        
        //second wind
        public static int Sec_WindAddr = 0x0157634C;
        public static int[] Sec_WindOffs = { 0x94, 0x50, 0x10D };
        
        //scrolling addr //allows scrolling  with the keyboard
        public static int scroll_arrowAddr = 0x01575F55;


        //read strings with the mouse memory addr
        public static int item_addr = 0x01576324;
        public static int[] item_offsets = { 0x8, 0x1CC, 0x50, 0x164, 0x28, 0x58, 0x0 };
        

        //current petRB
        public static int currentRB = 0x15AD088;
        public static int[] currentRBOffs = { 0x5C, 0x50, 0x164, 0xE8, 0x204,  0x4 };

        //petLevel check
        public static int petLevel = 0x015AD088;
        public static int[] petlevelOffs = { 0x5C, 0x50, 0x164, 0xB0, 0x58};

        //pet tab
        public static int pettab = 0x15763B4;
        public static int[] pettaboff = { 0x28, 0x50, 0x164, 0xC0, 0x10D };
        
        // pet addr
        public static int isPetOnAddr = 0x15AD104;
        public static int[] isPetOnOff = { 0x20, 0x50, 0x30};

        //pet details tab
        public static int detailsTab = 0x015AD088;
        public static int[] detailsOff = { 0x28, 0x50, 0x50, 0x164, 0x100, 0x50 , 0x10D };

        public static int leftrb = 0x015AD088;
        public static int[] leftRBoffs = { 0x2C, 0x50, 0x50, 0x164, 0xF0, 0x58};

        public static int petexp = 0x015AD088;
        public static int[] petexpOff = { 0x4, 0x1F4, 0x50, 0x164, 0xC4, 0x58, 0x0 };
        
    }
}
