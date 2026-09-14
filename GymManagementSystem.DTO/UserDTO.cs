using System;

namespace GymManagementSystem.DTO
{
    public class UserDTO : PersonDTO
    {
        public int UserID { get; set; }

        public int RoleID { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }

        public bool IsActive { get; set; }
    }
}