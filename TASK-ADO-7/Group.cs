namespace TASK_ADO_7;

public class Group
{

    public int GROUPId { get; set; }

   public string Name { get; set; }

    public int Ratings { get; set; }

    public int Year { get; set; }

    public List<Teacher> teachers { get; set; }
   public List<Student> students { get; set; }

    public override string ToString()
    {
        return $"{GROUPId}{Name}{Ratings}{Year}";
    }

}
