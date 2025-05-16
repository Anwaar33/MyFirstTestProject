using System.ComponentModel.DataAnnotations;
namespace MyFirstTestProject.Classes
{
    public class PersonData
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int Age { get; set; }
        public int Birthday { get; set; }
        public string? Email { get; set; }

    }
}
