using System;

namespace GymManagementSystem.BLL
{
    public class Member : Person
    {
        public int MemberID { get; private set; }

        public string EmergencyPhone { get; private set; }
        public DateTime JoinDate { get; private set; }
        public bool IsActive { get; private set; }

        public Member(int memberID, int personID, string firstName, string secondName, string thirdName, string lastName,
            string phoneNumber, DateTime birthDate, eGender gender, string area, string emergencyPhone, DateTime joinDate,
            bool isActive)
            : base(personID, firstName, secondName, thirdName, lastName, phoneNumber, birthDate, gender, area)
        {
            MemberID = memberID;
            EmergencyPhone = emergencyPhone;
            JoinDate = joinDate;
            IsActive = isActive;
        }

        public Member(
            string firstName, string secondName, string thirdName, string lastName, string phoneNumber, DateTime birthDate,
            eGender gender, string area, string emergencyPhone, DateTime joinDate, bool isActive)
            : base(firstName, secondName, thirdName, lastName, phoneNumber, birthDate, gender, area)
        {
            EmergencyPhone = emergencyPhone;
            JoinDate = joinDate;
            IsActive = isActive;
        }

        public void Update(string firstName, string secondName, string thirdName, string lastName, string phoneNumber,
            DateTime birthDate, eGender gender, string area, string emergencyPhone, DateTime joinDate)
        {
            UpdatePersonalInfo(firstName, secondName, thirdName, lastName, phoneNumber, birthDate, gender, area);

            EmergencyPhone = emergencyPhone;
            JoinDate = joinDate;
        }
    }
}