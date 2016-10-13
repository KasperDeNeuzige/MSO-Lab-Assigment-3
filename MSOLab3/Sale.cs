using System;

namespace Lab3
{
    class Sale
    {
        private Ticket ticket;
        private int amount;
        private Payment payment;

        public Sale (UIInfo uiinfo, int amount = 1)
        {
            this.amount = amount;
            // do this amount times if it is possible to order more tickets
            ticket = CreateTicket(uiinfo);
            payment = CreatePayment(uiinfo.Payment);

            float totalSalePrice = totalPrice(uiinfo.Payment);
            bool saleSucceeded = payment.PaymentSucceeded(totalSalePrice);

            if (saleSucceeded)
                ticket.PrintTicket();
            logSale(ticket, totalSalePrice, saleSucceeded);
                        
            // CreateReceipt?
        }

        Ticket CreateTicket(UIInfo uiinfo)
        {
            return ticket = new Ticket(uiinfo.From, uiinfo.To, uiinfo.Discount, uiinfo.Class, uiinfo.Way);
        }

        Payment CreatePayment(UIPayment payment)
        {
            if (payment == UIPayment.Cash)
                return new IKEAMyntPaymentAdapter();
            else
                return new ICardPaymentAdapter(payment);
        }
        float totalPrice(UIPayment p)
        {
            float price = ticket.ticketPrice;
            if (p == UIPayment.CreditCard)
                price += .5f;
            return price;
        }

        void logSale(Ticket t, float totalPrice, bool result)
        {
            //dB.log(ticket, totalPrice, DateTime.Today, result);
        }
    }
}
