using StudentApi.Model;

namespace StudentApi.DataSimulation
{
	public class StudentDataSimulation
	{
		public static readonly List<Student> StudentsList = new List<Student>
		{
			new  Student {Id = 1, Name = "Ali Osama", Age = 20, Grade = 28},
			new  Student {Id = 2, Name = "Alex Mark", Age = 20, Grade = 33},
			new  Student {Id = 3, Name = "Ahmed Samer", Age = 20, Grade = 90},
			new  Student {Id = 4, Name = "Nadia Khalid", Age = 20, Grade = 88}
		};
	}
}
