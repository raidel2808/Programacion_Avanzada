using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1_Producto
{
     class ProductProduced : ProductImported
    {
        public float cost;

        public ProductProduced(string pDescription = "Default",
            float pPurchase = 0, float pTax = 0, float pCost=0)
            : base(pDescription, pPurchase, pTax)
        {
            cost = pCost;
            CalculPrice();
            
        }

        public float Cost
            { 
            get { return cost; } 
            set { cost = value;
                CalculPrice();
            } 
        }
        public override void CalculPrice()
        {
            
            price_sale = (price_purchase + tax + cost) * 2;
        }

       
    }
}
