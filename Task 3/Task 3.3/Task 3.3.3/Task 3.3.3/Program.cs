using System;
using System.Threading;
using PizzeriaClassLibrary;

namespace Task_3._3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer();
            Customer customer2 = new Customer();

            Pizzeria pizzeria = new Pizzeria("Cool pizzeria name");
            pizzeria.PrintMenu();
            Console.WriteLine();

            Thread.Sleep(3000);
            customer1.MakeOrder(Pizzeria.PizzaTypes.Hawaiian);

            Thread.Sleep(1000);
            customer2.MakeOrder(Pizzeria.PizzaTypes.FourCheese);

            Thread.Sleep(3000);
            customer1.MakeOrder(Pizzeria.PizzaTypes.Pepperoni);
        }
    }
}
