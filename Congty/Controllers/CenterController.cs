using Congty.Data;
using Congty.Models;
using Microsoft.AspNetCore.Mvc;

namespace Congty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CenterController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CenterController(DataContext dataContext) {
            _dataContext = dataContext;
        }
        [HttpGet]
        public IActionResult GetAll() {
            var listCenter = _dataContext.Centers.ToList();
            return Ok(listCenter);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var listCenter = _dataContext.Centers.SingleOrDefault(ce => ce.Id == id);
            if (listCenter != null) {
                return Ok(listCenter);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult CreateNew(CenterEditModel model) {
            try
            {
                var center = new Center
                {
                    Name = model.Name
                };
                _dataContext.Add(center);
                _dataContext.SaveChanges();
                return Ok(center);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, CenterEditModel model)
        {
            var center = _dataContext.Centers.SingleOrDefault(ce => ce.Id == id);
            if (center != null)
            {
                center.Name = model.Name;
                _dataContext.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("id")]
        public IActionResult DeleteById(int id)
        {
            try
            {
                var center = _dataContext.Centers.SingleOrDefault(ce => ce.Id == id);
                if (center == null)
                {
                    return NotFound();
                }
                _dataContext.Centers.Remove(center);
                _dataContext.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
