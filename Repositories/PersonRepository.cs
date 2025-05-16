using Microsoft.EntityFrameworkCore;
using MyFirstTestProject.Classes;
using MyFirstTestProject.RepositoryDefinition;

namespace MyFirstTestProject.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        ApplicationDbContext _context;
        //private object?[]? Id;

        public PersonRepository(ApplicationDbContext applicationDbContext)
        {

            _context = applicationDbContext;
        }



        public bool deletePersonInfo(int id)
        {
            // Find the student record by its Id
            var student = _context.People.Find(id);

            // If the student doesn't exist, return false
            if (student == null)
            {
                return false;
            }

            // Remove the student from the DbSet
            _context.People.Remove(student);

            // Save the changes to the database
            _context.SaveChanges();

            // Return true indicating the deletion was successful
            return true;

        }

        public List<PersonData> GetAllPersons()
        {
            return _context.People.ToList();
        }

        public PersonData GetPersonById(int id)
        {
            return _context.People.Find(id);
        }

        public bool SavePersonInfo(List<PersonData> personInfos)
        {

            if (personInfos == null || personInfos.Count == 0)
                return false;

            try
            {
                _context.People.AddRange(personInfos);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                // Optionally, log the exception details here
                return false;
            }

        }

        public bool updatePersonInfo(PersonData personInfo)
        {
            // Check if the person exists in the database
            var existingPerson = _context.People.Find(personInfo.Id);

            // If the person doesn't exist, return false
            if (existingPerson == null)
            {
                return false;
            }

            try
            {
                // Update the properties of the existing person
                existingPerson.Name = personInfo.Name; // Full name (Name)

                existingPerson.Age = personInfo.Age;   // Age (can be calculated from Birthday, but assuming it's passed)
                existingPerson.Birthday = personInfo.Birthday; // Birthday year

                existingPerson.Email = personInfo.Email; // Email address

                // Mark the entity as modified
                _context.Entry(existingPerson).State = EntityState.Modified;

                // Save the changes to the database
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                // Optionally, log the exception details here
                return false;
            }
        }

    }
}
