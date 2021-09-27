using BasicCRUD.Core.Utilities.Results;
using BasicCRUD.Core.Utilities.Security;
using BasicCRUD.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCRUD.Business.Abstract
{
    public interface IAuthService
    {
       Response<AccessToken> GetToken(UserLoginDto user);
    }
}
