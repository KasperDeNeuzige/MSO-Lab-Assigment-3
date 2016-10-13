using System;


namespace Lab3
{
    public abstract class Payment
    {
        public Payment() { }

        public abstract bool PaymentSucceeded(float price);
    }
}
