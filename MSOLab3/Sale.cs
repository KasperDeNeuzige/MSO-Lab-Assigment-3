using System;

namespace Lab3
{
    public class Sale
    {
        private Ticket ticket;
        private int amount;
        private Payment payment;
        private float totalSalePrice;

        public Sale (UIInfo uiinfo, int amount = 1)
        {
            this.amount = amount;
            // do this amount times if it is possible to order more tickets
            ticket = CreateTicket(uiinfo);
            payment = CreatePayment(uiinfo.Payment);

            float totalSalePrice = totalPrice(uiinfo.Payment);
            bool saleSucceeded = payment.PaymentSucceeded(totalSalePrice);

            if (saleSucceeded)
                ticket.printTicket();
            logSale(saleSucceeded);
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
            //Needs to change if it possible to get more than one ticket
            //foreach (Ticket t in tickets)
            float price = ticket.ticketPrice;
            if (p == UIPayment.CreditCard)
                price += .5f;
            return price;
        }

        void logSale(bool saleSucceeded)
        {//log this sale in the vending machines database
            //dB.log(ticket, amount, DateTime.Today, result);
        }
    }
}
