using System;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using GodswarHack.AutoSavyFolder;

namespace GodswarHack
{
    
    public partial class AutoSavy : Form 
    {
        
        public AutoSavy()
        {
            InitializeComponent();
            
        }
        private void SealPet()
        {
            //soon
            Character.Open_first_wind();
            Character.Open_Second_Wind();
            sleep(400);
            for(; ; )
            {
                debugger("sealing pet");
                if (Character.isFirstWin_Open())
                {
                    RPbox.Form1.click(54, 194);  // pet opt to seal it
                    sleep(600);
                    SendKeys.SendWait("b"); //close the windows
                    sleep(600);
                    RPbox.Form1.click(476, 166); // select seal opt
                    sleep(600);
                    RPbox.Form1.click(788, 221); // ok buton
                    sleep(600);
                    RPbox.Form1.click(485, 155); // seal pet opt
                    sleep(600);
                    RPbox.Form1.click(788, 221); //ok btn
                    sleep(600);
                    SendKeys.SendWait("b"); //open the windows
                    sleep(600);
                    selectPet2();
                    break;
                }
                else
                    sleep(800);
            }
        }
        //this function selects the next pet after sealing the previous
        private void selectPet2()
        {
            Character.openPetTAB(true);
            RPbox.Form1.click(369, 494); // first slot
            sleep(300);
            RPbox.Form1.click(386, 576); // carry
            sleep(300);
            RPbox.Form1.click(456, 578); //detals
            sleep(1200);
            rb.Text = "RB:" + " " + Character.currentRB();
            lvl.Text = "Lv: " + " " + Character.PetLevel();
            left.Text = "left: " + " " + Character.LeftRB();
            Character.currentpetEXP(); // update the pet exp variable
            rb.Refresh();
            lvl.Refresh();
            left.Refresh();
            Character.openPetTAB(false);
            sleep(25);
            Character.detailsTAB(false);
            Character.previous_left = 15;
        }
        //check the pet
        private void CheckPet(int slot)
        {
            switch(slot)
            {
                case 1:
                    debugger("on checkpet func");
                    int counter = 0;
                    while (!Character.isPetOpen())
                    {
                        counter++;
                        debugger("opening pet on checkpet" + " " + counter.ToString());
                        RPbox.Form1.SendKey("l");
                        sleep(800);
                    }
                    sleep(300);
                    Open_Pet_CheckIt();
                    //rather than sleeping, this is better method
                    for(; ; )
                    {
                        //the first time we run the loop previous lvl will be 0;
                        if (Character.previous_lv == 0 && Character.previous_left == 0)
                        {
                            sleep(1700);
                            Open_Pet_CheckIt();
                            sleep(300);
                            break;
                        }
                        else if (Character.previous_lv != 0 && Character.previous_left != 0 && Character.previous_lv != Character.currentLevel && Character.previous_left != Character.currentleft)
                        {
                            return;
                        }
                        else
                        {
                            debugger("checkPetFunc Else");
                            //the loop ends up updating everytime
                            sleep(300);
                            Character.PetLevel();//we call the function to update when things are not met
                            Character.LeftRB();
                            return;

                        }
                            
                    }
                    break;

            }
        }

        private void Open_Pet_CheckIt()
        {
            Character.detailsTAB(false);
            sleep(200);
            Character.openPetTAB(true);
            sleep(250);
            RPbox.Form1.click(370, 490);
            sleep(100);
            RPbox.Form1.click(456, 578);
            sleep(250);
            Character.openPetTAB(false);
            rb.Text = "RB:" + " " + Character.currentRB();
            lvl.Text = "Lv: " + " " + Character.PetLevel();
            left.Text = "left: " + " " + Character.LeftRB();
            Character.currentpetEXP(); // update the pet exp variable
            rb.Refresh();
            lvl.Refresh();
            left.Refresh();
            Character.Pet_stats_update();
            sleep(25);
            Character.detailsTAB(false);
            sleep(25);
        }
        //lvl up the pet
        private void selectPet(int whichpet)
        {
            switch(whichpet)
            {
                case 1:
                    Character.detailsTAB(true);
                    sleep(25);
                    Character.level_up();
                    sleep(25);
                    Character.detailsTAB(false);
                    sleep(300);
                    break;

            }
        }
        private void MakeRB()
        {
            while (!Character.isPetOpen())
            {
                debugger("opening pet");
                RPbox.Form1.SendKey("l");
                sleep(1000);
            }
            MakeRB2();   
            
        }
        //actually clicling on the windows
        private void MakeRB2()
        {
            Character.Open_first_wind();
            Character.Open_Second_Wind();
            sleep(500);
            for (; ; )
            {
                if (Character.isFirstWin_Open())
                {
                    RPbox.Form1.click(54, 194); // first win pet opt pet raising
                    sleep(600);
                    SendKeys.SendWait("b"); //close bag
                    RPbox.Form1.click(495, 118); //secondwin rb opt
                    sleep(600);
                    RPbox.Form1.click(788, 221); //second win click the ok button
                    sleep(600);
                    RPbox.Form1.click(493, 210); // pet rb opt
                    sleep(600);
                    RPbox.Form1.click(788, 221); //click the ok button
                    sleep(25);
                    SendKeys.SendWait("b"); //open bag
                    sleep(600);
                    indexInv("spirit");
                    sleep(600);
                    RPbox.Form1.click(317, 599); //click to make rb pet
                    sleep(600);
                    RPbox.Form1.click(347, 166); // close rb windows
                    debugger("FINISHED rb");
                    break;

                } 
                else
                {
                    sleep(700);
                }
            }
        }
        //procedure to make pet 60rb change name pls
        private void Procedure(int pet) // will always be pet slot 1
        {
            CheckPet(pet);
            //TODO it has to check if wh is opened
            debugger("in the procedure func");
            if (Character.currentLevel != 120 && Character.petEXP < 230000000)
            {
                Character.open_wh_1();
                sleep(200);
                Character.useMD5();
                sleep(200);
                Character.close_wh();
                sleep(200);
                selectPet(pet);
                sleep(200);
                Character.PetLevel();
                sleep(25);
            }
            else if (Character.currentRBB >= 30 && Character.currentleft == 0 && Character.currentRBB < 60)
            {
                RPbox.Form1.SendKey("l");
                indexInv("rebirth30");
                RPbox.Form1.SendKey("l");
                Character.previous_lv = 0;
            }
            else if (Character.currentleft == 0 && Character.currentRBB < 30)
            {
                RPbox.Form1.SendKey("l");
                indexInv("spring");
                RPbox.Form1.SendKey("l");
                Character.previous_lv = 0;

            }
            else if (Character.currentLevel == 120 && Character.currentleft > 0)
            {
                MakeRB();
                //code here
            }
            else if (Character.currentLevel < 120 && Character.petEXP > 230000000)
            {
                //lvl up pet
                selectPet(1);
               //code here
            }
            else if (Character.currentLevel == 120 && Character.currentRBB == 60 && Character.currentleft == 0)
            {
                //seal pet and continue with the other
                debugger("pet 60 rb already :)");
                SealPet();
                Character.currentLevel = 1;
                Character.currentleft = 0;
                Character.currentRBB = 0;
                sleep(300);
            }
            else
            {
                Procedure(1);
                sleep(1000);
            }
        }
        //first function to be called
        private void StartRB60()
        {

            Character.previous_lv = 0;
            Character.previous_left = 0;

            for (; ; )
            {
                //we need to store the pet rb as integer value to compare it
                if (slot1.Checked)
                {
                    debugger(" on first function");
                    //process
                    Procedure(1);
                    Character.Open_first_wind();
                    
                }
                else
                    MessageBox.Show("Please check the pet slot");
                sleep(400);
            }
        }
        //start autorb 
        private  void AutoRB60(object sender, EventArgs e)
        {
            //first thread that will allow us to do 1 task
            Thread r60 = new Thread(() => { 
                    StartRB60();
                    sleep(300);
            });
            r60.IsBackground = true;
            r60.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            r60.Start();


            //code to stop the app
            Thread two = new Thread(() =>
            {
                while (true)
                {
                    if ((System.Windows.Input.Keyboard.GetKeyStates(System.Windows.Input.Key.X) & System.Windows.Input.KeyStates.Down) > 0)
                    {
                        r60.Abort();
                        break;
                    }
                    else
                        sleep(100);
                }

            });
            two.SetApartmentState(ApartmentState.STA);
            two.Start();
            

        }
        private void debugger(string text)
        {
            Debugin.AppendText(Environment.NewLine + text);
            Debugin.Refresh();
        }
        //setup
        private void SetupFuncc(object sender, EventArgs e)
        {
            Thread me = new Thread(setup);
            me.IsBackground = true;
            me.SetApartmentState(ApartmentState.STA);
            CheckForIllegalCrossThreadCalls = false;
            me.Start();
        }
        private void setup()
        {
            debugger("going to the location.....");
            if (!Character.isCharLocated())
                RPbox.Form1.gotoLoc(68, -131);
            first_setup();
            sleep(300);
            Second_setUp();
            sleep(300);
            debugger("All set.... Press AutoRB60..button.....");
            setupPet();
            sleep(200);
            Character.Open_first_wind();
            Character.Open_Second_Wind();
        }
        public void setupPet()
        {
            debugger("setup pet");
            RPbox.Form1.SendKey("p");
            sleep(200);
            while (!Character.isPet_tab())
            {
                sleep(500);
            }
            RPbox.Form1.DragMouse(221, 171, 457, 364);
            sleep(200);
            RPbox.Form1.click(369, 494); // first slot
            sleep(300);
            RPbox.Form1.click(386, 576); //carry pet
            sleep(300);
            RPbox.Form1.click(454, 576); //details tab
            sleep(300);
            Character.detailsTAB(false);
            sleep(25);
            Character.openPetTAB(false);
            sleep(300);
            
        }
        private static void sleep(int x)
        {
            Application.DoEvents();
            Thread.Sleep(x);
            
        }
        //sets up character windows
        public void  first_setup()
        {
            
            while (!Character.isCharLocated())
            {
                debugger("Checking if character is at the NPC....");
                Thread.Sleep(1500);
                if (Character.isCharLocated())
                {
                    debugger("Char located......");
                    Thread.Sleep(500);
                    debugger("organizing........");
                    RPbox.Form1.aActivateWind();
                    sleep(300);
                    RPbox.Form1.SendKey("b");
                    Thread.Sleep(500);
                    RPbox.Form1.click(551, 497);
                    Thread.Sleep(500);
                    RPbox.Form1.DragMouse(619, 131, 63, 211); //second win drag
                    Thread.Sleep(500);
                    RPbox.Form1.DragMouse(613, 137, 723, 253); //first wind drag
                    Thread.Sleep(500);
                    RPbox.Form1.click(664, 593); //stall
                    Thread.Sleep(500);
                    RPbox.Form1.click(301, 400); //set stall on
                    Thread.Sleep(500);
                    RPbox.Form1.click(317, 70); //close stall
                    Thread.Sleep(500);
                    break;
                }
            }
            return;
        }
        //Sets up gw windows
        public  void Second_setUp()
        {
            debugger("Organizing Npc Windows.....");
            RPbox.Form1.click(394, 262); //clicks the npc
            Thread.Sleep(200);
            RPbox.Form1.click(394, 262); //again to make sure
            sleep(400);
            int counter1 = 0;
            for(; ; )
            {
                sleep(5);
                debugger("Checking if the first windows is open.....");
                if (Character.isFirstWin_Open())
                    break;
                else
                {
                    ++counter1;
                    sleep(800);
                    if (counter1 > 2)
                        Character.Open_first_wind();
                }
            }
            //drag the windows to the stage
            RPbox.Form1.DragMouse(288, 301, 186, 163);
            sleep(300);
            //click on pet merging opt
            RPbox.Form1.click(51, 191);
            sleep(300);
            //Click ok

            int counter2 = 0;
            //checker for second windows
            for (; ; )
            {
                sleep(5);
                debugger("Checking if the second windows is open.....");
                if (Character.isSecondWin_Open())
                    break;
                else
                {
                    sleep(800);
                    ++counter2;
                    if (counter2 > 2)
                        Character.Open_Second_Wind();
                }
                    
            }

            //drag the second windows to the side
            RPbox.Form1.DragMouse(405, 310, 534, 212);
            sleep(200);

        }
        //FIXME function plox
        private void indexInv(string item)
        {
            
            RPbox.Form1.aActivateWind();
            Thread.Sleep(300);
            int startPosX = 610; // increase this by 30 until 6 times
            int startPosy = 432; //after 6 times increase this by 30
            restartItem();
            RPbox.Form1.setCursor(startPosX, startPosy);
            patchBUG();
            //we are going to restart the index 4 times which is 4 inventory rows
            for (int a = 0; a < 4; ++a)
            {
                
                //on each row we are going to index 5 times 
                for (int i = 0; i < 6; ++i)
                {
                    
                    //compare the object
                    string me = returnItem();
                    debugger(me);
                    switch(item)
                    {
                        case "spirit":
                            if(me.IndexOf("Rebirth") == 0)
                            {
                                int count = 0;
                                while (true)
                                {
                                    debugger("using spirit");
                                    //spawm left clicks
                                    RPbox.Form1.Rclick(startPosX, startPosy);
                                    ++count;
                                    if(count > 6)
                                    {
                                        return;
                                    }
                                    
                                    
                                }
                            }
                            debugger("not found");
                            break;
                        //if it has 30 rbs more
                        case "rebirth30":
                            if(me.IndexOf("Juice") == 0)
                            {
                                for (int count = 0; ; ++count)
                                {
                                    debugger("using juice");
                                    RPbox.Form1.Rclick(startPosX, startPosy);

                                    if (count > 10)
                                        return;
                                    sleep(800);
                                }
                                
                            }
                            debugger("juice not found");
                            break;

                            //if it has less than 30
                        case "spring":
                            if(me.IndexOf("Spring") == 0)
                            {
                                int count = 0;
                                while(true)
                                {
                                    debugger("using spring water");
                                    //code here spawm left clicks
                                    RPbox.Form1.Rclick(startPosX, startPosy);
                                    sleep(800);
                                    ++count;
                                    if (count > 10)
                                        return;
                                }
                            }
                            break;

                        default:
                            debugger("im not reading sht");
                            break;
                    }
                    //lets change the startpos by 30 to iterate 6 times
                    startPosX += 30;

                    RPbox.Form1.setCursor(startPosX, startPosy);
                    sleep(100);
                }
                startPosX = 610;
                startPosy += 30;
                RPbox.Form1.setCursor(startPosX, startPosy);
                sleep(100);
                
            }

        }
        private void patchBUG()
        {
            
            string me = returnItem();
            sleep(25);
            if (me.IndexOf("Rebirth Spirit") == 0)
            {
                debugger("found");
                //methods here
                return;
            }
        }
        private string returnItem()
        {
            byte[] me = new byte[31];
            int last = 0;
            MemoryFunc.ReadProcessMemory(MemoryFunc.return_handle(),MemoryFunc.Last_Addr(MemoryAndOffsets.item_addr, MemoryAndOffsets.item_offsets), me, me.Length, ref last);
            string text = Encoding.Unicode.GetString(me).ToString();
            return text;
        }
        private void restartItem()
        {
            int val = (int)Items.GW_Item.morning_5;
            MemoryFunc.WriteProcessMemory(MemoryFunc.return_handle(), MemoryFunc.Last_Addr(MemoryAndOffsets.item_addr, MemoryAndOffsets.item_offsets), ref val, sizeof(int), 0);
        }
        private void mouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                RPbox.Form1.ReleaseCapture();
                RPbox.Form1.SendMessage(Handle, (uint)RPbox.Form1.WM_NCLBUTTONDOWN, RPbox.Form1.HT_CAPTION, 0);
                
            }
        }
        //close form
        private void button1_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
        }     
        private void AutoSavy_Load(object sender, EventArgs e)
        {
            debugger("please check the pet slot before starting");
        }






        //pet name of the current pe
    }
}
