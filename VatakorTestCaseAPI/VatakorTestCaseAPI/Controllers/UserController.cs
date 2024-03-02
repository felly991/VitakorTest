using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VatakorTestCaseAPI.DTOs;
using VatakorTestCaseAPI.Interface;
using VitakorTestCaseAPI.DTOs;


namespace VitakorTestCaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }
        [HttpPost("/login")]
        public Task<UserModelDTO> Login(AuthorizationModel model)
        {
            var result = _user.Login(model);
            if (result == null)
            {
                throw new Exception();
            }
            return result;
        }

        [HttpPost("/registration")]
        public Task<UserModelDTO> Registration(RegistrationDTO model)
        {
            var result = _user.Registration(model);
            if (result == null)
            {
                throw new Exception();
            }
            return result;
        }
    }
}
