﻿namespace VitakorTestCaseAPI.DTOs
{
    public class RegistrationDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdahy { get; set; } = DateTime.UtcNow;
    }
}
