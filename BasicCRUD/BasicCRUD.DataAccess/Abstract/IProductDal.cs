using BasicCRUD.Core.DataAccess;
using BasicCRUD.Entities.Concrete.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCRUD.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
    }
}
