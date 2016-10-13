using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    class MyntAdapter : Payment
    {
        IKEAMyntAtare2000 mynt;
        public MyntAdapter ()
        {
            mynt = new IKEAMyntAtare2000();
        }

        public override bool PaymentSucceeded(float price)
        {
            mynt.starta();
            mynt.betala((int)price * 100);
            mynt.stoppa();
            return true;
        }
    }
}
