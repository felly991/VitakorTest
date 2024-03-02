using VatakorTestCaseAPI.DTOs;
using VitakorTestCaseAPI.DTOs;

namespace VatakorTestCaseAPI.Interface
{
    public interface IUser
    {
        public Task<UserModelDTO> Registration(RegistrationDTO user);
        public Task<UserModelDTO> Login(AuthorizationModel authorizationModel);
    }
}
