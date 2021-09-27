using BasicCRUD.Core.DataAccess.EfCore;
using BasicCRUD.DataAccess.Abstract;
using BasicCRUD.DataAccess.Concrete.EfCore.Contexts;
using BasicCRUD.Entities.Concrete.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCRUD.DataAccess.Concrete.EfCore
{
    public class EfAppLogDal : EfEntityRepositoryBase<AppLog, BasicCrudContext>, IAppLogDal
    {
    }
}
