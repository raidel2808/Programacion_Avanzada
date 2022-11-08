using Lab1_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
   public interface IPImportedRepository: IRepository
    {
        ProductImported CreatePImported(string description, int id, float price_sale, float tax);
        
        void UpdatePImported(ProductImported pimported);

        void DeletePImported(ProductImported pimported);
       
        ProductImported FindPImported(string description);

        ProductImported GetPImported(int id);

        List<ProductImported> GetPImported();

    }
}
