namespace Congty.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public float Salary { get; set; }
        public Department Department { get; set; }
    }
}
