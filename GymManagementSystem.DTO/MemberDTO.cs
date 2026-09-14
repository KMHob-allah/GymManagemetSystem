using System;

namespace GymManagementSystem.DTO
{
    public class MemberDTO : PersonDTO
    {
        public int MemberID { get; set; }

        public string EmergencyPhone { get; set; }
        public DateTime JoinDate { get; set; }
        public bool IsActive { get; set; }
    }
}