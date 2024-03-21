using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.Entity
{
    public class User:_BaseEntity
    {
        public string Username { get;set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserRole { get; set; }
        //public string Password { get; set; }

        public byte[]PasswordHash { get; set; }
        public byte[]PasswordSalt { get; set; }

        public int PasswordAttempt { get; set; }
        public bool IsLockedOut { get; set; }
    }
}
