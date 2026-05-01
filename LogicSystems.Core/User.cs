using System;

namespace LogicSystems.Core
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"User: {Name} - {Email}");
        }
    }
}