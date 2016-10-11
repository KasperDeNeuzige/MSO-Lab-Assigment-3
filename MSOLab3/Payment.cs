using System;


namespace Lab3
{
    public abstract class Payment
    {
        public Payment()
        {
            //while !saleSucceeded && !UIState.customerCancels
            /*switch (paymentType)
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
            }*/
        }

        public abstract void HandlePayment(float price);
    }
}
