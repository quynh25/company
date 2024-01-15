using congty.Models;
using Congty.Data;
using Congty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace congty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public StaffController(DataContext dataContext) {
            _dataContext = dataContext;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var list = _dataContext.Staffs.Include(d => d.Department).ToList();
            var result = list.Select(d => new
            {
                d.Id,
                d.Name,
                d.Address,
                d.Phone,
                d.Salary,
                DepartmentId = d.Department != null ? d.Department.Id : (int?)null

            }).ToList();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var list = _dataContext.Staffs.Include(d => d.Department).SingleOrDefault(x => x.Id == id);
            if (list == null)
            {
                return NotFound();
            }
            else
            {
                var result =new
                {
                    list.Id,
                    list.Name,
                    list.Address,
                    list.Phone,
                    list.Salary,
                    DepartmentId = list.Department != null ? list.Department.Id : (int?)null

                };
                return Ok(result);
            }
        }


        [HttpPost]
        public ActionResult Create(StaffEditModel model) {
            try
            {
                var staff = new Staff {
                    Name = model.Name,
                    Address = model.Address,
                    Phone = model.Phone,
                    Salary = model.Salary,
                    DepartmentId = model.DepartmentId
                };
                _dataContext.Staffs.Add(staff);
                _dataContext.SaveChanges();
                return Ok(staff);
            }
            catch
            {
                return BadRequest();
            }
            
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, StaffEditModel model) {
            try
            {
                var list = _dataContext.Staffs.Include(d => d.Department).SingleOrDefault(x => x.Id == id);
                if(list != null)
                {
                    list.Name = model.Name;
                    list.Address = model.Address;
                    list.Phone = model.Phone;
                    list.Salary = model.Salary;
                    list.DepartmentId = model.DepartmentId;
                    _dataContext.SaveChanges();
                    return NoContent();
                }
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var list = _dataContext.Staffs.Include(d => d.Department).SingleOrDefault(x => x.Id == id);
                if(list != null)
                {
                    _dataContext.Staffs.Remove(list);
                    _dataContext.SaveChanges();
                    return Ok();
                }
                return NotFound();

            }
            catch { 
                return BadRequest();
            }
        }
    }
}
