using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    class ICardPaymentAdapter : Payment
    {
        ICard card;
        public ICardPaymentAdapter(UIPayment type)
        {
            if (type == UIPayment.CreditCard)
                card = new CreditCard();
            else if (type == UIPayment.DebitCard)
                card = new DebitCard();
            else
                return;
        }

        public override bool PaymentSucceeded(float price)
        {
            card.Connect();
            int id = card.BeginTransaction(price);
            if (card.EndTransaction(id)) { card.Disconnect(); return true; }
            card.CancelTransaction(id);
            return false;
        }
    }
}
