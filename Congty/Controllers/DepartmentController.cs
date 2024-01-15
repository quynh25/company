using congty.Models;
using Congty.Data;
using Congty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public DepartmentController(DataContext dataContext) {
            _dataContext = dataContext;
        }
        [HttpGet]
        public IActionResult GetALL() {
            var list = _dataContext.Departments.Include(d => d.Center).ToList();

            var result = list.Select(d => new
            {
                d.Id,
                d.Name,
                CenterId = d.Center != null ? d.Center.Id : (int?)null
            }).ToList();

            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id) { 
            var list = _dataContext.Departments.Include(d => d.Center).SingleOrDefault(x => x.Id == id);

            if(list == null)
            {
                return NotFound();
            }
            else
            {
                var result = new
                {
                    list.Id,
                    list.Name,
                    CenterId = list.Center != null ? list.Center.Id : (int?)null
                };
                return Ok(result);
            }
    
        }
        [HttpPost]
        public IActionResult Create(DepartmentEditModel model)
        {
            try
            {
                var department = new Department
                {
                    Name = model.Name,
                    CenterId = model.CenterId
                };

                _dataContext.Add(department);
                _dataContext.SaveChanges();

                return Ok(department);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public  IActionResult Update(int id, DepartmentEditModel model) {
            try
            {
                var list = _dataContext.Departments.Include(d => d.Center).SingleOrDefault(x => x.Id == id);
                if(list != null)
                {
                    list.Name = model.Name;
                    list.CenterId = model.CenterId;
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
        public IActionResult Delete(int id, DepartmentEditModel model)
        {
            try
            {
                var list = _dataContext.Departments.Include(d => d.Center).SingleOrDefault(x => x.Id == id);
                if(list != null)
                {
                    _dataContext.Departments.Remove(list);
                    _dataContext.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
     

    }
}
