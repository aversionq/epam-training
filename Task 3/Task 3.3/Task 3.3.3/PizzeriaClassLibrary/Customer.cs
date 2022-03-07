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

        public void MakeOrder(Pizzeria.PizzaTypes pizza)
        {
            OrderNum = Pizzeria.GiveOrderNumber();
            onOrder += Pizzeria.TakeOrder;
            onOrder(pizza);
            WaitForPizza();
        }

        private void WaitForPizza()
        {
            if (!Pizzeria.CheckOrder(OrderNum))
            {
                Thread.Sleep(1500);
                WaitForPizza();
            }
            else
            {
                return;
            }
        }

        private event Action<Pizzeria.PizzaTypes> onOrder;  // Событие заказа.
    }
}
