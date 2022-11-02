using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_1
{
    public class Product
    {
        private string description;
        protected float price_purchase;
        protected float price_sale;

        public Product(string pDescription = "Default", float pPurchase = 0)
        {


            description = pDescription;
            price_purchase = pPurchase;
            CalculPrice();




        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public float PricePurchase
        {
            get { return price_purchase; }
            set
            {
                if (value < 0 || value > 1000000)
                {
                    throw new OutOfMemoryException();
                }
                price_purchase = value;
                CalculPrice();
            }
        }

        public float SalePrice
        {
            get { return price_sale; }

        }

        public virtual void CalculPrice()
        {
            price_sale = price_purchase * 2;

        }

        public static int Gain(int x, int y)
        {
            int result = x * y;
            return result;
        }



        public void Show()
        {
            Console.WriteLine("Description of the product: {0}\nPrice of purchase: {1}\nPrice of sale: {2}\n---------", description, price_purchase, price_sale);
        }
    }
}


