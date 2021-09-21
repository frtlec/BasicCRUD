using BasicCRUD.Core.DataAccess.EfCore;
using BasicCRUD.DataAccess.Abstract;
using BasicCRUD.DataAccess.Concrete.EfCore.Contexts;
using BasicCRUD.Entities.Concrete.DataModels;

namespace BasicCRUD.DataAccess.Concrete.EfCore
{

    public class EfProductDal : EfEntityRepositoryBase<Product, BasicCrudContext>, IProductDal
    {

    }
}
