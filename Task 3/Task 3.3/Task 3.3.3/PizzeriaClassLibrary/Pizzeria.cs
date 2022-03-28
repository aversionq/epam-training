using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaClassLibrary
{
    public class Pizzeria
    {
        private static List<PizzaTypes> _orders;
        private static List<bool> _doneOrders;

        public enum PizzaTypes : byte
        {
            // None = 0,
            Pepperoni = 1,
            Hawaiian = 2,
            Margarita = 3,
            FourCheese = 4,
            MeatPizza = 5
        }
        
        public Pizzeria(string name)
        {
            CurrentOrderNum = 0;
            this.Name = name;
            _orders = new List<PizzaTypes>();
            _doneOrders = new List<bool>();
        }

        public string Name { get; private set; }

        internal static void TakeOrder(PizzaTypes pizza)
        {
            _orders.Add(pizza);
            _doneOrders.Add(false);
            CookPizza();
        }

        public void PrintMenu()
        {
            Console.WriteLine($"Welcome to the '{this.Name}'!" + Environment.NewLine
                + "Here is our menu:");
            foreach (var item in PizzaTypes.GetNames(typeof(PizzaTypes)))
            {
                Console.WriteLine($"{item}");
            }
        }

        internal static int CurrentOrderNum { get; private set; }

        internal static bool CheckOrder(int orderNum)
        {
            if (_doneOrders[orderNum])
            {
                OrderReadyMessage(orderNum);
                return true;
            }
            else
            {
                OrderNotReadyMessage(orderNum);
                return false;
            }
        }

        internal static int GiveOrderNumber()
        {
            return CurrentOrderNum++;
        }

        static async private void CookPizza()
        {
            await Task.Delay(2000);
            _doneOrders[CurrentOrderNum - 1] = true;
        }

        private static void OrderReadyMessage(int orderNum)
        {
            Console.WriteLine($"Order number {orderNum + 1}, your pizza " +
                $"{_orders[orderNum]} is ready! Bon appetit" + Environment.NewLine);
        }

        private static void OrderNotReadyMessage(int orderNum)
        {
            Console.WriteLine($"Order number {orderNum + 1}, your pizza " +
                $"{_orders[orderNum]} is not ready yet...");
        }
    }
}
