using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_1
{
    public abstract class Product
    {
        protected string description;
        protected int ID;
        public float price_purchase;
        protected float price_sale;
        

        public Product(string pDescription = "Default",int id=1234, float pPurchase = 0)
        {


            description = pDescription;
            ID = id;
            price_purchase = pPurchase;
            CalculPrice();




        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int id
        {
            get { return ID; }
            set { ID = value; }
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


