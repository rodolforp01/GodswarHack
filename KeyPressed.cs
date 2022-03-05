using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;


namespace GodswarHack
{
    public partial class KeyPressed
    {
       
        public KeyPressed()
        {
           
        }

        //a function to check if a key is pressed with an independent thread
        public static bool isPressed()
        {
           if ((Keyboard.GetKeyStates(Key.Z) & KeyStates.Down) > 0)
           {
                
                return true;
           }
           else
           {
              return false;
           }
        }
    }
}
