using System;

namespace Hotel.Domain.Models
{
    public class Guest : User
    {
        public DateTime RegisterDate { get; set; }

        public Guest(User user) : base(user)
        {
            UserType = Enums.UserType.Guest;
        }

        public Guest() { }

    }
}
