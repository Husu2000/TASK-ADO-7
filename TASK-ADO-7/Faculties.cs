namespace TASK_ADO_7;

public class Faculties
{
    public int FacultyId { get; set; }
    public string FacultyName { get; set; }
    public List<Student> Students { get; set; }

    public override string ToString()
    {
        return FacultyName;
    }
}
