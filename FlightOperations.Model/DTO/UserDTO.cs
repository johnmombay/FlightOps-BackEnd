using System;
using System.Collections.Generic;
using System.Text;

namespace FlightOperations.Model.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public int PasswordAttempt { get; set; }
        public bool IsLockedOut { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool isDeleted { get; set; }

    }
}
