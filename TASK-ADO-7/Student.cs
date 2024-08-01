namespace TASK_ADO_7;

public class Student
{
    public int StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int FacultyId { get; set; }
    public Faculties Faculties { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }
    public override string ToString()
    {
        return $"{StudentId}\t{FirstName}\t{LastName}";
    }


}
