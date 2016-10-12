using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    class ICardPaymentAdapter : Payment
    {
        ICard c;
        public ICardPaymentAdapter(UIPayment type)
        {
            if (type == UIPayment.CreditCard)
                c = new CreditCard();
            else if (type == UIPayment.DebitCard)
                c = new DebitCard();
            else
                return;
        }

        public override bool PaymentSucceeded(float price)
        {
            c.Connect();
            int id = c.BeginTransaction(price);
            if (c.EndTransaction(id)) { c.Disconnect(); return true; }
            c.CancelTransaction(id);
            return false;
        }
    }
}
