using Lab1_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repository
{
    public partial class DBRepository : IPImportedRepository
    {
        public ProductImported CreatePImported(string description, int id, float price_sale, float tax)
        {
            var pimported = new ProductImported(description, id, price_sale,tax);
            Add(pimported);
            return pimported;
        }

        public void UpdatePImported(ProductImported pimported)
        {
            Update(pimported);
        }
        public void DeletePImported(ProductImported pimported)
        {
            Delete(pimported);
        }

       public ProductImported FindPImported(string description)
        {
            return Get<ProductImported>(p=>p.Description == description).First();
        }

        public ProductImported GetPImported(int id)
        {
            return GetByID<ProductImported>(id);
        }

        public List<ProductImported> GetPImported()
        {
            return Get<ProductImported>();
        }

    }
}
