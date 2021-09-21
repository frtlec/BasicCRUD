using BasicCRUD.Core.DataAccess.EfCore;
using BasicCRUD.Entities.Concrete.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCRUD.DataAccess.Concrete.EfCore
{

    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {

    }
}
