namespace Congty.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Center Center { get; set; }
        public ICollection<Staff> Staffs { get; set;}
    }
}
