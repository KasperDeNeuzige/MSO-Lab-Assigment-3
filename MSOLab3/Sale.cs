using System;

namespace Lab3
{
    public class Sale
    {
        Ticket ticket;
        int amount;
        Payment payment;
        float totalSalePrice;

        public Sale (UIInfo uiinfo, int amount = 1)
        {
            this.amount = amount;
            // do this amount times if it is possible to order more tickets
            ticket = CreateTicket(uiinfo);
            payment = CreatePayment(uiinfo);

            float totalSalePrice = totalPrice();
            bool saleSucceeded = payment.PaymentSucceeded(totalSalePrice);

            if (saleSucceeded)
                ticket.printTicket();
            logSale(saleSucceeded);
        }

        Ticket CreateTicket(UIInfo uiinfo)
        {
            return ticket = new Ticket(uiinfo.From, uiinfo.To, uiinfo.Discount, uiinfo.Class, uiinfo.Way);
        }

        Payment CreatePayment(UIInfo uiinfo)
        {

            if (uiinfo.Payment == UIPayment.Cash)
                return new IKEAMyntPaymentAdapter();
            else
                return new ICardPaymentAdapter(uiinfo.Payment);
        }
        float totalPrice()
        {
            //Needs to change if it possible to get more than one ticket
            //foreach (Ticket t in tickets)
            return ticket.ticketPrice;
        }

        void logSale(bool saleSucceeded)
        {//log this sale in the vending machines database
            //dB.log(ticket, amount, DateTime.Today, result);
        }
    }
}
