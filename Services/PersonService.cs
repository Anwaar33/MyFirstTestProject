using MyFirstTestProject.Classes;
using MyFirstTestProject.RepositoryDefinition;
using System.Collections.Generic;

namespace MyFirstTestProject.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public List<PersonData> GetAllPersons()
        {
            return _personRepository.GetAllPersons();
        }

        public PersonData GetPersonById(int id)
        {
            return _personRepository.GetPersonById(id);
        }

        public bool SavePersonInfo(List<PersonData> personInfos)
        {
            return _personRepository.SavePersonInfo(personInfos);
        }

        public bool UpdatePersonInfo(PersonData personInfo)
        {
            return _personRepository.updatePersonInfo(personInfo);
        }

        public bool DeletePersonInfo(int id)
        {
            return _personRepository.deletePersonInfo(id);
        }
    }
}
