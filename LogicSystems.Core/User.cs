using System;

namespace LogicSystems.Core
{
    public enum UserRole
    {
        Admin,
        Personnel,
        Customer
    }

    public class User
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public UserRole Role { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine(
                $"User: {Name} - {Email} - Role: {Role}"
            );
        }
    }
}