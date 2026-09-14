using System;

namespace GymManagementSystem.DTO
{
    public class PersonDTO
    {
        public int PersonID { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public byte Gender { get; set; }
        public string Area { get; set; }
    }
}