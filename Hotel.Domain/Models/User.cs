using Hotel.Domain.Enums;
using System.Collections.Generic;

namespace Hotel.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public UserType UserType { get; set; }
        public string AdditionalInfo { get; set; }
        public IList<Booking> Bookings { get; private set; } = new List<Booking>();

        public User(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Image = user.Image;
            UserType = user.UserType;
            AdditionalInfo = user.AdditionalInfo;
            Bookings = user.Bookings;
        }

        public User() { }
    }
}
