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
        }

        double totalPrice()
        {
            return ticket.price() * amount;
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
