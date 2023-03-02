using api.EfCore;
using api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
   
    [ApiController]
    public class EmployeesApiController : ControllerBase
    {
        private readonly DbHelper _db;
        public EmployeesApiController(DataContext dataContext)
        {
            _db = new DbHelper(dataContext);
        }

        // GET: api/<EmployeesApi>

        [HttpGet]
        [Route("api/[controller]/GetEmployees")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<EmployeesModel> data = _db.GetEmployees();
               

                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type,data));
            }
            catch (Exception ex) {
               
                return BadRequest(ResponseHandler.GetExpceptionResponse(ex));
            }
        }

        // GET api/<EmployeesApi>/5
        [HttpGet]
        [Route("api/[controller]/GetEmployeeById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
              EmployeesModel data = _db.GetEmployeeById(id);


                if (data != null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
               
                return BadRequest(ResponseHandler.GetExpceptionResponse(ex));
            }
        }

        // POST api/<EmployeesApi>
        [HttpPost]
        [Route("api/[controller]/SaveEmployee")]
        public IActionResult Post([FromBody] EmployeesModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveEmployees(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExpceptionResponse(ex));
            }
        }

        // PUT api/<EmployeesApi>/5
        [HttpPut]
        [Route("api/[controller]/UpdateEmployee")]
        public IActionResult Put([FromBody] EmployeesModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveEmployees(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExpceptionResponse(ex));
            }
        }

        // DELETE api/<EmployeesApi>/5  
        [HttpDelete]
        [Route("api/[controller]/DeleteEmployee/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteEmployee(id);

                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));

            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExpceptionResponse(ex));
            }
        }
    }
}
