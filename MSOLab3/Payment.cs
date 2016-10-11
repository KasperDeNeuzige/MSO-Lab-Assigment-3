using System;


namespace Lab3
{
    public class Payment
    {
        bool saleSucceeded;

        public Payment(float price, UIPayment paymentType)
        {
            //while !saleSucceeded && !UIState.customerCancels
            switch (paymentType)
            {
                case UIPayment.CreditCard:
                    creditPayment(price);
                    break;
                case UIPayment.DebitCard:
                    debitPayment(price);
                    break;
                case UIPayment.Cash:
                    cashPayment(price);
                    break;
            }
        }

        void creditPayment(float price)
        {
            CreditCard c = new CreditCard();
            c.Connect();
            int ccid = c.BeginTransaction(price);
            c.EndTransaction(ccid);
            //handlefailure()
        }

        void debitPayment(float price)
        {
            DebitCard d = new DebitCard();
            d.Connect();
            int dcid = d.BeginTransaction(price);
            d.EndTransaction(dcid);
            //handlefailure()
        }

        void cashPayment(float price)
        {
            IKEAMyntAtare2000 coin = new IKEAMyntAtare2000();
            coin.starta();
            coin.betala((int)Math.Round(price * 100));
            coin.stoppa();
            //handlefailure()
        }

    }
}
