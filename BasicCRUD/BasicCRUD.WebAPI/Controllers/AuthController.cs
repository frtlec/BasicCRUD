using BasicCRUD.Business.Abstract;
using BasicCRUD.Entities.Concrete.Dtos;
using BasicCRUD.WebAPI.Controllers.BasesController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicCRUD.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : CustomBaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult GetToken(UserLoginDto user)
        {
            return CreateActionResultInstance(_authService.GetToken(user));
        }
    }
}
