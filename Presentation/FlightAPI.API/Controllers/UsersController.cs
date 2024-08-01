using FlightAPI.Application.Repositories;
using FlightAPI.Application.ViewModels.Users;
using FlightAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Crmf;
using System.Net;
using System.Net.Http.Headers;

namespace FlightAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {   
        readonly private IUserReadRepository _userReadRepository;
        readonly private IUserWriteRepository _userWriteRepository;

        public UsersController(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_userReadRepository.GetAll(false));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            return Ok(await _userReadRepository.GetByIdAsync(id,false));
        }


        [HttpPost]
        public async Task<IActionResult> Post(VM_User_Create model)
        {
             await _userWriteRepository.AddAsync(new()
            {
                UserName = model.UserName,
                Password = model.Password,
                Role = model.Role
            });
            await _userWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]

        public async Task<IActionResult> Put(VM_User_Update model)
        {
            User user = await _userReadRepository.GetByIdAsync(model.Id);
            user.UserName = model.UserName;
            user.Password = model.Password;
            await _userWriteRepository.SaveAsync();
            return Ok();
        }
        
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            await _userWriteRepository.RemoveAsync(id);
            await _userWriteRepository.SaveAsync();
            return Ok();
        }


   


    }
}
