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

        public override void HandlePayment(float price)
        {
            c.starta();
            c.betala((int)price * 100);
            c.starta();
        }
    }
}
