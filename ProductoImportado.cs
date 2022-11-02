using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1_Producto
{
      class ProductImported : Product
    {
        protected float tax;

        public ProductImported(string pDescription = "Default", float pPurchase = 0,float pTax=0) 
            : base(pDescription,pPurchase)
        {

            tax = pTax;
            CalculPrice();

            }

        public float Tax
        { 
            get { return tax; } 
            set { tax = value;
                CalculPrice(); } 
        }

        public override void CalculPrice()
        {
            
            price_sale = (price_purchase + tax) * 2;
        }

    }
}
