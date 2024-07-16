﻿using EquipPayBackend.Models;
using System.ComponentModel.DataAnnotations;
namespace EquipPayBackend.DTOs.UserDTO
{
    public class AddUserDTO
    {
        public string UserFullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string UserGender { get; set; } = string.Empty;
        public string UserName { get; set; } = null!;
        public string Password { get; set; }
        public string RoleName { get; set; }
    }
}



