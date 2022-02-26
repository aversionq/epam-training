using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PizzeriaClassLibrary
{
    public class Customer
    {
        public int OrderNum { get; private set; }

        public void MakeOrder(Pizzeria pizzeria, Pizzeria.PizzaTypes pizza)
        {
            OrderNum = pizzeria.TakeOrder(pizza);
            WaitForPizza(pizzeria);
        }

        public void WaitForPizza(Pizzeria pizzeria)
        {
            if (!pizzeria.CheckOrder(OrderNum - 1))
            {
                Thread.Sleep(1500);
                WaitForPizza(pizzeria);
            }
            else
            {
                return;
            }
        }
    }
}
