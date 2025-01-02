using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApi.DataSimulation;
using StudentApi.Model;

namespace StudentApi.Controllers
{
	//[Route("api/[controller]")]
	[Route("api/Students")]
	[ApiController]
	public class StudentAPIController : ControllerBase
	{
		[HttpGet]
		public ActionResult<IEnumerable<Student>> GetAllStudents()
		{
			return Ok(StudentDataSimulation.StudentsList);
		}
	}
}
