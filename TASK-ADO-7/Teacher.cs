namespace TASK_ADO_7;

public class Teacher
{
    public int TeacherId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime EmploymentDate { get; set; }
    public decimal Premium { get; set; }
    public decimal Salary { get; set; }

    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public List<Group> Groups { get; set; }

    public List<Group> groups { get; set; }
}

