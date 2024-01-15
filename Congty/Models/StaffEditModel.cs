using Congty.Data;
using Congty.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace congty.Models
{
    public class StaffEditModel 
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public float Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}
