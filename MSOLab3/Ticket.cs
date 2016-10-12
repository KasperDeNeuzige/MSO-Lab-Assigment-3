using System;


namespace Lab3
{
    public class Ticket
    {
        public string origin, dest;
        public float discount; //enum
        public bool firstClass, isReturn; //firstclass int
        public DateTime dateValid;
        int tariefeenheden;

        public Ticket(string origin, string dest, DateTime dateValid, float discount = 0, bool firstClass = false, bool isReturn = false)
        {
            this.origin = origin;
            this.dest = dest;
            this.discount = discount;
            this.firstClass = firstClass;
            this.isReturn = isReturn;
            this.dateValid = dateValid;
            tariefeenheden = Tariefeenheden.getTariefeenheden (origin, dest);
        }

        public float price()
        {//calculate the table column using class and discount, then get price from the pricing table
            int tableColumn = firstClass ? 3 : 6;
            tableColumn += (int)(discount * 5);
            float finalPrice = PricingTable.getPrice(tariefeenheden, tableColumn);
            if (isReturn) finalPrice *= 2; 
            return finalPrice;
        }

        public void printTicket()
        {//print this ticket
            //printer.printTicket(this);
        }
    }
}
