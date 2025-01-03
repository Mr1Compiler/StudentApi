﻿using Microsoft.AspNetCore.Http;
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
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<IEnumerable<Student>> GetAllStudents()
		{
			if(StudentDataSimulation.StudentsList.Count == 0)
			{
				return NotFound("No student found.");
			}
			return Ok(StudentDataSimulation.StudentsList);
		}

		[HttpGet("Passed", Name = "GetPassedStudent")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<IEnumerable<Student>> GetPassedStudent()
		{
			var passedStudnts = StudentDataSimulation.StudentsList.Where(s => s.Grade >= 50).ToList();

			if(passedStudnts.Count == 0)
			{
				return NotFound("No student passed.");
			}

			return Ok(passedStudnts);
		}

		[HttpGet("AvarageGrade", Name = "GetAvarageGrade")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
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

		[HttpGet("{id}", Name ="GetStudentById")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<Student> GetStudentById(int id)
		{
			if(id <1)
			{
				return BadRequest("Id must be greater than 0.");
			}

			var student = StudentDataSimulation.StudentsList.FirstOrDefault(s => s.Id == id);
			if (student == null)
			{
				return NotFound($"Student with id {id} not found.");
			}
			return Ok(student);
		}
	}
}

