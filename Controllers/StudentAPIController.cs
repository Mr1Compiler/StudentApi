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
		[HttpGet("All", Name = "GetAllStudents")]
		public ActionResult<IEnumerable<Student>> GetAllStudents()
		{
			return Ok(StudentDataSimulation.StudentsList);
		}

		[HttpGet("Passed", Name = "GetPassedStudent")]
		public ActionResult<IEnumerable<Student>> GetPassedStudent()
		{
			var passedStudnts = StudentDataSimulation.StudentsList.Where(s => s.Grade >= 50).ToList();

			return Ok(passedStudnts);
		}

		[HttpGet("AvarageGrade", Name = "GetAvarageGrade")]
		public ActionResult<double> GetAvarageGrade()
		{

			//StudentDataSimulation.StudentsList.Clear(); //Testing the NotFound() method

			if (StudentDataSimulation.StudentsList.Count == 0)
			{
				return NotFound("No student found.");
			}
			var avarageGrade = StudentDataSimulation.StudentsList.Average(s => s.Grade);
			return Ok(avarageGrade);
		}
	}
}

