using BasicCRUD.DataAccess.Abstract;
using BasicCRUD.Entities.Concrete.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCRUD.Business.Utilities.Logger
{
    public class LoggerManager : ILoggerManager
    {
        private readonly IAppLogDal _appLogDal;

        public LoggerManager(IAppLogDal appLogDal)
        {
            _appLogDal = appLogDal;
        }

        public async Task WriteLog(AppLog appLog)
        {
           await _appLogDal.Add(appLog);
        }
    }
}
