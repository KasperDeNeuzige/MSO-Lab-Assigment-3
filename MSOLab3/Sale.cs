using System;

namespace Lab3
{
    public class Sale
    {
        Ticket ticket;
        int amount;

        public Sale (UIInfo uiinfo, int amount = 1)
        {
            //this.ticket = new Ticket;
            this.amount = amount;
            ticket = new Ticket(uiinfo.From, uiinfo.To, uiinfo.Discount, uiinfo.Class, uiinfo.Way);
            Payment payment = new Payment(totalPrice(), uiinfo.Payment);
        }

        float totalPrice()
        {
            //foreach (Ticket t in tickets)
            return ticket.ticketPrice;
        }

        void logSale(string result)
        {//log this sale in the vending machines database
            //dB.log(ticket, amount, DateTime.Today, result);
        }

        void cancelSale()
        {
            logSale("Sale unsuccessful");
        }

        void completeSale()
        {

        }
    }
}
