using System;
using System.Collections.Generic;

namespace CommandPattern
{
    interface Order
    {
        public void Execute();
    }

    public class Stock
    {
        private string Name = "ABC";
        private int Quantity = 10;

        public void Buy()
        {
            Console.WriteLine("Stock [ Name: {0}  Quantity: {1} ] bought.", Name, Quantity);
        }
        public void Sell()
        {
            Console.WriteLine("Stock [ Name: {0}  Quantity: {1} ] sold.", Name, Quantity);
        }
    }

    class BuyStock : Order
    {
        private Stock abcStock;
        public BuyStock(Stock abcStock)
        {
            this.abcStock = abcStock;
        }
        public void Execute()
        {
            abcStock.Buy();
        }
    }

    class SellStock : Order
    {
        private Stock abcStock;
        public SellStock(Stock abcStock)
        {
            this.abcStock = abcStock;
        }
        public void Execute()
        {
            abcStock.Sell();
        }
    }

    class Broker
    {
        private List<Order> _orders = new List<Order>();

        public void TakeOrder(Order order)
        {
            _orders.Add(order);
        }

        public void PlaceOrders()
        {
            foreach(Order order in _orders)
            {
                order.Execute();
            }
            _orders.Clear();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stock abcStock = new Stock();

            BuyStock buyStockOrder = new BuyStock(abcStock);
            SellStock sellStockOrder = new SellStock(abcStock);

            Broker broker = new Broker();
            broker.TakeOrder(buyStockOrder);
            broker.TakeOrder(sellStockOrder);

            broker.PlaceOrders();
        }
    }
}

/*
Output:
Stock [ Name: ABC  Quantity: 10 ] bought.
Stock [ Name: ABC  Quantity: 10 ] sold.
*/