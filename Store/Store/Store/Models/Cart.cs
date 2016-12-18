using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{

    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Gadget gadget, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Gadget.GadgetId == gadget.GadgetId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Gadget = gadget,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Gadget gadget)
        {
            lineCollection.RemoveAll(l => l.Gadget.GadgetId == gadget.GadgetId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Gadget.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Gadget Gadget { get; set; }
        public int Quantity { get; set; }
    }
}