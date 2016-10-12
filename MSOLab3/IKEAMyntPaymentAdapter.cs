using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    class IKEAMyntPaymentAdapter : Payment
    {
        IKEAMyntAtare2000 c;
        public IKEAMyntPaymentAdapter ()
        {
            c = new IKEAMyntAtare2000();
        }

        public override bool PaymentSucceeded(float price)
        {
            c.starta();
            c.betala((int)price * 100);
            c.stoppa();
            return true;
        }
    }
}
