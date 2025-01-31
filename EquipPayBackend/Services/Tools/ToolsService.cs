﻿using AutoMapper;
using EquipPayBackend.Models;
//using LinqToDB;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace EquipPayBackend.Services.Tools
{
    public class ToolsService : IToolsService
    {
        //private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public ToolsService( IMapper mapper, IConfiguration configuration)
        {
            //_context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        public string[] ReturnArrayofCommaSeparatedStrings(string inputString)
        {
            string[] strings = {

        };
            if (string.IsNullOrEmpty(inputString))
            {
                return strings;
            }

            string[] separatedStrings = inputString.Split(',');
            return separatedStrings;
        }
        public int CalculateAge(DateTime birthDate)
        {
            DateTime currentDate = DateTime.Today;
            int age = currentDate.Year - birthDate.Year;

            if (currentDate.Month < birthDate.Month ||
                (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
            {
                age--;
            }

            return age;
        }
        public DateTime CalculateDOB(int age)
        {
            DateTime currentDate = DateTime.Today;
            int year = currentDate.Year - age;
            DateTime dob = new DateTime(year, 1, 1);
            return dob;
        }

        public void CreatePasswordHash(string Password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
            }
        }
        public bool VerifyPasswordHash(string Password, byte[] PasswordHash, byte[] PasswordSalt)
        {
            using (var hmac = new HMACSHA512(PasswordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
                return computeHash.SequenceEqual(PasswordHash);
            }
        }
        public string CreateToken(UserAccount UA, UserInfo usr)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, AssignRole(usr)),
                new Claim(ClaimTypes.Name, usr.UserFullName.ToString()),
                new Claim(ClaimTypes.Rsa, UA.Role.RoleID.ToString()),
                new Claim(ClaimTypes.Sid, UA.UserID.ToString()),
                //new Claim(ClaimTypes.Role, UA.Role.RoleName)
                //new Claim(ClaimTypes.Role, UA.Role.RoleID.ToString()), // Convert to string
                //new Claim(ClaimTypes.NameIdentifier, UA.EmployeeId.ToString()) // Convert to string
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1), // Set expiry to future DateTime
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        private string AssignRole(UserInfo user)
        {
            Console.WriteLine($"User Role: -------------{user.UserAccount.Role.RoleName}");


            return user.IsCurrentlyActive == true ? user.UserAccount.Role.RoleName : "UnauthorizedUserAccount";
        }


    }
}
