using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_1
{
    public class Storehouse
    {
        private List<ProductImported> productImporteds;

        public int Count { get { return productImporteds.Count; } }

        public Storehouse()
        {
            productImporteds = new List<ProductImported>();
        }

        public Storehouse(List<ProductImported>productimporteds)
        {

            productImporteds = productimporteds;
        }

        public void AddProductImported(string description, int id, float price_purchase, float Tax)
        {
            var pimported= new  ProductImported(description, id, price_purchase, Tax);
            {

                pimported.tax = Tax;
               
            };
           
            productImporteds.Add(pimported);
        }

    }
}
