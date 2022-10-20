using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1_Producto
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
                ProductProduced r = new ProductProduced("J", 100, 6);
                ProductImported p = new ProductImported("R", 2100, 8);
            try
            {
                p.PricePurchase = -100;

                r.Show();
                p.Show();
                r.Show();
                
               

            }
            //hjghjghj
            //yjyjty
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Out Of Memory, please use a number in the range >0 and <1000000\n");
            }

            r.Show();
            p.Show();
            
        }
    }
}
