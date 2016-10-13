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
        private int tariefEenheden;
        // private Printer printer
        public float ticketPrice;

        public Ticket(string origin, string dest, UIDiscount discount, UIClass firstClass, UIWay isReturn)
        {
            this.origin = origin;
            this.dest = dest;
            this.discount = discount;
            this.firstClass = firstClass;
            this.isReturn = isReturn;
            dateValid = DateTime.Today; // In UI geen optie voor datum onbekend.

            tariefEenheden = Tariefeenheden.getTariefeenheden (origin, dest);
            int tableColumn = CalculateTableColumn();
            ticketPrice = CalculatePrice(tableColumn);
        }
        
        private int CalculateTableColumn()
        {
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

            return tableColumn;
        }

        private float CalculatePrice(int tableColumn)
        {//calculate the table column using class and discount, then get price from the pricing table
            

            float finalPrice = PricingTable.getPrice(tariefEenheden, tableColumn);
            if (isReturn == UIWay.Return)
            {
                finalPrice *= 2;
            }
            return finalPrice;
        }

        public void PrintTicket()
        {//print this ticket
            //printer.PrintTicket(this);
        }

        // We need the totalPrice for the credit card fee.
        public void PrintReceipt(float totalPrice)
        {
            //printer.printReceipt(this, totalPrice);
        }
    }
}
