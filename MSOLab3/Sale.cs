using System;

namespace Lab3
{
    class Sale
    {
        private Ticket ticket;        
        private Payment payment;
        private UIInfo uiInfo;
        // private DataBase db;

        public Sale (UIInfo uiInfo)
        {
            // Should adjust price and amount of tickets printed if amountTickets were gained from uiinfo            
            this.uiInfo = uiInfo;
            CreateTicket();
            CreatePayment();
            HandleSale();
        }

        private void HandleSale()
        {
            float totalSalePrice = TotalPrice();
            bool saleSucceeded = payment.PaymentSucceeded(totalSalePrice);

            if (saleSucceeded)
                ticket.PrintTicket();
            logSale(totalSalePrice, saleSucceeded);

            /* 
             * if(uiinfo.receiptRequested && saleSucceeded)              
             *     ticket.PrintReceipt(totalSalePrice)              
             */

            // UI.restart();
        }

        void CreateTicket()
        {
            ticket = new Ticket(uiInfo.From, uiInfo.To, uiInfo.Discount, uiInfo.Class, uiInfo.Way);
        }

        void CreatePayment()
        {
            if (uiInfo.Payment == UIPayment.Cash)
                payment = new MyntAdapter();
            else
                payment = new ICardPaymentAdapter(uiInfo.Payment);
        }

        float TotalPrice()
        {
            float price = ticket.ticketPrice;
            if (uiInfo.Payment == UIPayment.CreditCard)
                price += .5f;
            return price;
        }

        void logSale(float totalPrice, bool result)
        {
            //db.Log(ticket, totalPrice, saleDate, result);
        }
    }
}
