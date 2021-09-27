using BasicCRUD.Entities.Concrete.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCRUD.Business.Utilities.Logger
{
    public interface ILoggerManager
    {
        Task WriteLog(AppLog appLog);
    }
}
