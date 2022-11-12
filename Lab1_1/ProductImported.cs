using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_1
{
   public class ProductImported : Product
    {
        public float tax;

        public ProductImported(string pDescription = "Default", int id = 1234, float pPurchase = 0, float pTax = 0)
            : base(pDescription,id,pPurchase)
        {

            tax = pTax;
            CalculPrice();

        }

        public float Tax
        {
            get { return tax; }
            set
            {
                tax = value;
                CalculPrice();
            }
        }

        public override void CalculPrice()
        {

            price_sale = (price_purchase + tax) * 2;
        }

    }
}
