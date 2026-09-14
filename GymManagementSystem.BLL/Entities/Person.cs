using System;

namespace GymManagementSystem.BLL
{
    public class Person
    {
        public enum eGender { Male = 0, Female }
        public int PersonID { get; private set; }

        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string ThirdName { get; private set; }
        public string LastName { get; private set; }

        public string PhoneNumber { get; private set; }
        public DateTime BirthDate { get; private set; }
        public eGender Gender { get; private set; }
        public string Area { get; private set; }

        protected Person(int personID, string firstName, string secondName, string thirdName, string lastName,
           string phoneNumber, DateTime birthDate, eGender gender, string area)
        {
            PersonID = personID;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            Gender = gender;
            Area = area;
        }

        protected Person(string firstName, string secondName, string thirdName, string lastName, string phoneNumber,
            DateTime birthDate, eGender gender, string area)
        {
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            Gender = gender;
            Area = area;
        }

        public string FullName
        {
            get
            {
                string fullName = FirstName + " " + SecondName;

                if (!string.IsNullOrWhiteSpace(ThirdName))
                    fullName += " " + ThirdName;

                fullName += " " + LastName;

                return fullName;
            }
        }

        public bool IsMale()
        {
            return Gender == eGender.Male;
        }
        public bool IsFemale()
        {
            return Gender == eGender.Female;
        }

        public int GetAge()
        {
            int age = DateTime.Today.Year - BirthDate.Year;

            if (BirthDate.Date > DateTime.Today.AddYears(-age)) age--;

            return age;
        }

        public string GetGender()
        {
            return (IsMale() ? "Male" : (IsFemale() ? "Female" : "Unknown"));
        }

        public void UpdatePersonalInfo(string firstName, string secondName, string thirdName, string lastName,
            string phoneNumber, DateTime birthDate, eGender gender, string area)
        {
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;

            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            Gender = gender;
            Area = area;
        }
    }
}