using Microsoft.EntityFrameworkCore;

namespace TASK_ADO_7;

internal class AuthorConText:DbContext
{
    public DbSet<Group> Groups { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Faculties> Faculties { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public AuthorConText()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Academy;Integrated Security=SSPI;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().Property(d => d.DepartmentId).IsRequired().HasColumnName("Id").ValueGeneratedOnAdd();
        modelBuilder.Entity<Department>().Property(d => d.Financing).IsRequired().HasColumnType("money");
        modelBuilder.Entity<Department>().Property(d => d.Financing).HasDefaultValue(0);
        modelBuilder.Entity<Department>().ToTable(d => d.HasCheckConstraint("CK_DP_Financing", "Financing >= 0"));
        modelBuilder.Entity<Department>().ToTable(d => d.HasCheckConstraint("CK_DP_Name", "Name != '' "));
        modelBuilder.Entity<Department>().Property(d => d.DepartmentName).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Department>().HasIndex(d => d.DepartmentName).IsUnique();
        //========================================================================================
        //========================================================================================
        //========================================================================================
       modelBuilder.Entity<Group>().Property(g => g.GROUPId).IsRequired().HasColumnName("Id").ValueGeneratedOnAdd();
        modelBuilder.Entity<Group>().Property(g => g.Name).IsRequired().HasMaxLength(10);
        modelBuilder.Entity<Group>().HasIndex(g => g.Name).IsUnique();
        modelBuilder.Entity<Group>().ToTable(g => g.HasCheckConstraint("CK_Group_Rating", "Rating >= 0 AND Rating <= 5"));
        modelBuilder.Entity<Group>().Property(g => g.Year).IsRequired();
        modelBuilder.Entity<Group>().ToTable(g => g.HasCheckConstraint("CK_Group_Year", "Year >= 1 AND Year <= 5"));
        modelBuilder.Entity<Group>().ToTable(g => g.HasCheckConstraint("CK_Group_Name", "Name != '' "));
        modelBuilder.Entity<Group>().HasMany(g => g.teachers).WithMany(t => t.groups);
        //========================================================================================
        //========================================================================================
        //========================================================================================
        modelBuilder.Entity<Student>().Property(s => s.StudentId).IsRequired().HasColumnName("Id").ValueGeneratedOnAdd();
        modelBuilder.Entity<Student>().Property(s => s.FirstName).IsRequired().HasColumnName("Name");
        modelBuilder.Entity<Student>().Property(s => s.LastName).IsRequired().HasColumnName("Surname");
        modelBuilder.Entity<Student>().ToTable(t => t.HasCheckConstraint("CK_ST_Name", "Name != '' "));
        modelBuilder.Entity<Student>().ToTable(t => t.HasCheckConstraint("CK_ST_Surname", "Surname != '' "));
        modelBuilder.Entity<Student>().HasOne(s => s.Group).WithMany(g => g.students).HasForeignKey(x => x.GroupId).HasConstraintName("FK_Groups").OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Student>().HasOne(s => s.Faculties).WithMany(f => f.Students).HasForeignKey(x => x.FacultyId).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_Faculites");
        //========================================================================================
        //========================================================================================
        //========================================================================================
        modelBuilder.Entity<Faculties>().Property(f => f.FacultyId).IsRequired().HasColumnName("Id").ValueGeneratedOnAdd();
        modelBuilder.Entity<Faculties>().Property(f => f.FacultyName).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<Faculties>().HasIndex(f => f.FacultyName).IsUnique();
        modelBuilder.Entity<Faculties>().ToTable(f => f.HasCheckConstraint("CK_DP_Name", "Name != '' "));
        //========================================================================================
        //========================================================================================
        //========================================================================================
        modelBuilder.Entity<Teacher>().Property(t => t.TeacherId).IsRequired().HasColumnName("Id").ValueGeneratedOnAdd();
        modelBuilder.Entity<Teacher>().Property(t => t.EmploymentDate).IsRequired().HasColumnType("datetime");
        modelBuilder.Entity<Teacher>().ToTable(t => t.HasCheckConstraint("CK_Teacher_Date", "EmploymentDate >= 1990/01/01 "));
        modelBuilder.Entity<Teacher>().Property(t => t.FirstName).IsRequired().HasColumnName("Name");
        modelBuilder.Entity<Teacher>().Property(t => t.Premium).IsRequired().HasDefaultValue(0).HasColumnType("money");
        modelBuilder.Entity<Teacher>().ToTable(t => t.HasCheckConstraint("CK_Teacher_Premium", "Premium >= 0"));
        modelBuilder.Entity<Teacher>().Property(t => t.Salary).IsRequired().HasColumnType("money");
        modelBuilder.Entity<Teacher>().ToTable(t => t.HasCheckConstraint("CK_Teacher_Salary", "Salary > 0"));
        modelBuilder.Entity<Teacher>().Property(t => t.LastName).IsRequired().HasColumnName("Surname");
        modelBuilder.Entity<Teacher>().ToTable(t => t.HasCheckConstraint("CK_Teacher_Name", "Name != '' "));
        modelBuilder.Entity<Teacher>().ToTable(t => t.HasCheckConstraint("CK_Teacher_Surname", "Surname != '' "));
        modelBuilder.Entity<Teacher>().HasOne(t => t.Department).WithMany(d => d.Teachers).HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_DP");


    }
}
