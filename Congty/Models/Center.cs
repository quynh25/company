namespace Congty.Models
{
    public class Center
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
