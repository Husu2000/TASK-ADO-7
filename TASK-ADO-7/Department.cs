namespace TASK_ADO_7;

public class Department
{
    public int DepartmentId { get; set; }
    public decimal Financing { get; set; }
    public string DepartmentName { get; set; }

    public List<Teacher> Teachers { get; set; }

    public override string ToString()
    {
        return $"{DepartmentName}";
    }
}
