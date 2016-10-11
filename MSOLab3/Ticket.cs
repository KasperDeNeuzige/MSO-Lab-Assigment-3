using System;


namespace Lab3
{
    public class Ticket
    {
        public string origin, dest;
        public UIDiscount discount;
        public UIClass firstClass;
        public UIWay isReturn;
        // public DateTime dateValid;
        int tariefeenheden;
        public float ticketPrice;

        public Ticket(string origin, string dest, /*DateTime dateValid ,*/ UIDiscount discount, UIClass firstClass, UIWay isReturn)
        {
            this.origin = origin;
            this.dest = dest;
            this.discount = discount;
            this.firstClass = firstClass;
            this.isReturn = isReturn;
            //this.dateValid = dateValid;
            tariefeenheden = Tariefeenheden.getTariefeenheden (origin, dest);
            ticketPrice = price();
        }

        public float price()
        {//calculate the table column using class and discount, then get price from the pricing table
            int tableColumn = 0;
            if (firstClass == UIClass.FirstClass) { tableColumn = 3; }
            if (discount == UIDiscount.TwentyDiscount) { tableColumn += 1; }
            else if (discount == UIDiscount.FortyDiscount) { tableColumn += 2; }

            float finalPrice = PricingTable.getPrice(tariefeenheden, tableColumn);
            if (isReturn == UIWay.Return) { finalPrice *= 2; }
            return finalPrice;
        }

        public void printTicket()
        {//print this ticket
            //printer.printTicket(this);
        }
    }
}
