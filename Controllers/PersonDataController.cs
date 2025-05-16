using Microsoft.AspNetCore.Mvc;
using MyFirstTestProject.Classes;
using MyFirstTestProject.Services;

namespace MyFirstTestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonDataController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonDataController(IPersonService personService)
        {
            _personService = personService;
        }



        [HttpGet("GetAllPersons")]
        public IActionResult GetAllPersons()
        {
            var persons = _personService.GetAllPersons();

            //if (persons == null)
            //{
            //    return NotFound(new { message = "person not found." }); // 404 Not Found
            //}

            return Ok(persons); // 200 OK with data
        }


        [HttpGet("GetPersonById")]
        public IActionResult GetPersonById(int id)
        {
            var person = _personService.GetPersonById(id);

            if (person == null)
            {
                return NotFound(new { message = "Person not found." }); // 404 Not Found
            }

            return Ok(person); // 200 OK
        }


        [HttpDelete("DeletePersonInfoById/{id}")]
        public IActionResult DeletePersonInfo(int id)
        {
            bool isDeleted = _personService.DeletePersonInfo(id);

            if (!isDeleted)
            {
                return NotFound(new { message = $"Person with ID {id} not found." }); // 404
            }

            return Ok(new { message = $"Person with ID {id} deleted successfully." }); // 200
        }



        [HttpPost("SavePersonInfo")]
        public IActionResult SavePersonInfo(List<PersonData> personInfos)
        {
            if (personInfos == null)
            {
                return BadRequest(new { message = "Person data is required." }); // 400 Bad Request
            }

            bool isSaved = _personService.SavePersonInfo(personInfos);

            if (isSaved)
            {
                return Ok(new { message = "Person information saved successfully." }); // 200 OK
            }
            else
            {
                return StatusCode(500, new { message = "Failed to save person information." }); // 500 Internal Server Error
            }
        }

        [HttpPost("UpdatePersonInfo")]
        public IActionResult UpdatePersonInfo(PersonData personInfo)
        {
            bool isUpdated = _personService.UpdatePersonInfo(personInfo);

            if(!isUpdated)
            {
                return NotFound(new { message = "Person not found or update failed." }); // 404 Not Found
            }

            return Ok(new { message = "Person info updated successfully." }); // 200 OK
            
            
        }

       
    }
}  
