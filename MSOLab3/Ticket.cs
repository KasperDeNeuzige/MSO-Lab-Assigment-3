using System;


namespace Lab3
{
    class Ticket
    {
        private string origin, dest;
        private DateTime dateValid;
        private UIDiscount discount; //enum
        private UIClass firstClass; //firstclass int
        private UIWay isReturn;
        private int tariefeenheden;
        public float ticketPrice;

        public Ticket(string origin, string dest, UIDiscount discount, UIClass firstClass, UIWay isReturn)
        {
            this.origin = origin;
            this.dest = dest;
            this.discount = discount;
            this.firstClass = firstClass;
            this.isReturn = isReturn;
            dateValid = DateTime.Today; // In UI geen optie voor datum onbekend.
            tariefeenheden = Tariefeenheden.getTariefeenheden (origin, dest);
            ticketPrice = calculatePrice();
        }

        private float calculatePrice()
        {//calculate the table column using class and discount, then get price from the pricing table
            int tableColumn = 0;
            if (firstClass == UIClass.FirstClass)
            {
                tableColumn = 3;
            }

            if (discount == UIDiscount.TwentyDiscount)
            {
                tableColumn += 1;
            }
            else if (discount == UIDiscount.FortyDiscount)
            {
                tableColumn += 2;
            }

            float finalPrice = PricingTable.getPrice(tariefeenheden, tableColumn);
            if (isReturn == UIWay.Return)
            {
                finalPrice *= 2;
            }
            return finalPrice;
        }

        public void printTicket()
        {//print this ticket
            //printer.printTicket(this);
        }
    }
}
