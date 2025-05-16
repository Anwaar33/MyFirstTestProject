using MyFirstTestProject.Classes;
using System.Collections.Generic;

namespace MyFirstTestProject.Services
{
    public interface IPersonService
    {
        List<PersonData> GetAllPersons();
        PersonData GetPersonById(int id);
        bool SavePersonInfo(List<PersonData> personInfos);
        bool UpdatePersonInfo(PersonData personInfo);
        bool DeletePersonInfo(int id);
    }
}
