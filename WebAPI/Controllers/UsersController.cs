using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //IUserService _rentalService;
        //public UsersController(IUserService userService)
        //{
        //    _rentalService = userService;
        //}

        //[HttpPost("add")]
        //public IActionResult Add(User user)
        //{
        //    var result = _rentalService.Add(user);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
        //[HttpDelete("delete")]
        //public IActionResult Delete(User user)
        //{

        //    var result = _rentalService.Delete(user);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        //[HttpPut("update")]
        //public IActionResult Update(User user)
        //{
        //    var result = _rentalService.Update(user);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        //[HttpGet("getall")]
        //public IActionResult GetAll()
        //{
        //    var result = _rentalService.GetAll();
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        //[HttpGet("getbyid")]                               //https://localhost:44322/api/Users/getbyid?id=5 kullanımı bu şekilde 
        //public IActionResult GetById(int id)
        //{
        //    var result = _rentalService.GetById(id);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
    }
}

