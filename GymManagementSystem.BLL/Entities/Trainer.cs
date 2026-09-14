using System;

namespace GymManagementSystem.BLL
{
    public class Trainer : Person
    {
        public int TrainerID { get; private set; }

        public bool IsActive { get; private set; }

        public Trainer(int trainerID, int personID, string firstName, string secondName, string thirdName, string lastName,
            string phoneNumber, DateTime birthDate, eGender gender, string area, bool isActive)
            : base(personID, firstName, secondName, thirdName, lastName, phoneNumber, birthDate, gender, area)
        {
            TrainerID = trainerID;
            IsActive = isActive;
        }

        public Trainer(string firstName, string secondName, string thirdName, string lastName, string phoneNumber,
            DateTime birthDate, eGender gender, string area, bool isActive)
            : base(firstName, secondName, thirdName, lastName, phoneNumber, birthDate, gender, area)
        {
            IsActive = isActive;
        }

        public void Update(string firstName, string secondName, string thirdName, string lastName, string phoneNumber,
            DateTime birthDate, eGender gender, string area)
        {
            UpdatePersonalInfo(firstName, secondName, thirdName, lastName, phoneNumber, birthDate, gender, area);
        }
    }
}