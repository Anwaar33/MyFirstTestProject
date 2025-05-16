using MyFirstTestProject.Classes;
namespace MyFirstTestProject.RepositoryDefinition
{
    public interface IPersonRepository
    {
        public List<PersonData> GetAllPersons();

        public PersonData GetPersonById(int id);

        public bool SavePersonInfo(List<PersonData> PersonInfos);

        public bool updatePersonInfo(PersonData PersonInfo);

        public bool deletePersonInfo(int id);





    }
}
