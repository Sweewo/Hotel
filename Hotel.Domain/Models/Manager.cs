namespace Hotel.Domain.Models
{
    public class Manager : User
    {
        public int Salary { get; set; }

        public Manager(User user) : base(user)
        {
            UserType = Enums.UserType.Manager;
        }

        public Manager() { }
    }
}
