using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VatakorTestCaseAPI.Data;
using VatakorTestCaseAPI.DTOs;
using VatakorTestCaseAPI.Interface;
using VatakorTestCaseAPI.Models;
using VitakorTestCaseAPI.DTOs;

namespace VatakorTestCaseAPI.Service
{
    public class UserService : IUser
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public UserService(DataContext context,
                           IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Сервис для регистрации и авторизации пользователей
        /// Если юзер пустой, значит что-то пошло не так
        /// </summary>
        /// <param name="authorizationModel"></param>
        /// <returns></returns>
        public async Task<UserModelDTO> Login(AuthorizationModel authorizationModel)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == authorizationModel.Email);
            if (user == null)
            {
                return new UserModelDTO();
            }
            if (user.Password != authorizationModel.Password)
            {
                return new UserModelDTO();
            }
            UserModelDTO model = _mapper.Map<UserModelDTO>(user);
            return model;
        }
        /// <summary>
        /// Аналагично с логином, пустой = что-то не так
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<UserModelDTO> Registration(RegistrationDTO user)
        {
            if (await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email) != null)
            {
                return new UserModelDTO();
            }
            var newUser = _mapper.Map<User>(user);
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return await Login(new AuthorizationModel() { Email = newUser.Email, Password = newUser.Password });
        }
    }
}
