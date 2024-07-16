using System;

namespace final_qvizi4
{
    // Client კლასის განსაზღვრა კლიენტის ინფორმაციისთვის
    public class Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; } // Added birth date for age calculation

        // კონსტრუქტორი ველების ინიციალიზაციისთვის
        public Client(string firstName, string lastName, string personalNumber, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalNumber = personalNumber;
            BirthDate = birthDate;
        }
    }
}
