using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FreshDesk.Entities.Request;
using FreshDesk.Repository.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FreshDesk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TicketController : ControllerBase
    {
        private readonly IRegisterRepository repository;
        private readonly ITicketRepository ticketRepository;
        private readonly IContactRepository contactRepository;
        public TicketController(IRegisterRepository repository,ITicketRepository ticketRepository,IContactRepository contactRepository)
        {
            this.repository = repository;
            this.ticketRepository = ticketRepository;
            this.contactRepository = contactRepository;
          
        }
        [EnableCors]
        [HttpPost("register")]
        public IActionResult AddAccount(AddRegisterRequest request)
        {
            if(request==null)
            {
                return BadRequest(new { message = "Please check your input" });
            }
            if(repository.CheckEmailExist(request))
            {
                return Conflict(new { message = "Email already exists" });
            }
            return Ok(repository.CreateAccount(request));
        }
        [EnableCors] 
        [HttpPost("login")]
        public IActionResult LoginAccount(AddLoginRequest request)
        {
            if(request==null)
            {
                return BadRequest(new { message="Please check your input" });
            }
            if(repository.CheckCredentials(request))
            {
                return Unauthorized(new { message="Incorrect Email or password"});
            }
            
            return Ok(repository.LoginAccount(request));
        }
        [EnableCors]
        [HttpGet("viewticket")]
        public IActionResult ViewTicket(int id)
        {
            if(id==0)
            {
                return BadRequest(new { message = "Please check your input" });
            }
           return Ok(ticketRepository.ViewAllTickets(id));
        }
        [EnableCors]
        [HttpPost("addticket")]
        public IActionResult AddTicket(AddTicketRequest request)
        {
            if(request==null)
            {
                return BadRequest(new { message = "Please check your input" });
            }
            return Ok(ticketRepository.AddTicket(request));
        }
        [EnableCors]
        [HttpPut("updateticket")]
        public IActionResult UpdateTicket(UpdateTicketRequest request)
        {
            if(request==null)
            {
                return BadRequest(new { message = "Please check your input" });
            }
            return Ok(ticketRepository.UpdateTicket(request));
        }
        [EnableCors]
        [HttpPost("deleteticket")]
        public IActionResult DeleteTicket(DeleteTicketRequest request)
        {
            if(request==null)
            {
                return BadRequest();
            }
            return Ok(ticketRepository.DeleteTicket(request));
        }
        [EnableCors]
        [HttpPut("searchticket")]
        public IActionResult SearchTicket(SearchTicketRequest request)
        {
            if(request==null)
            {
                return BadRequest();
            }
            return Ok(ticketRepository.SearchTicket(request));
        }


        [EnableCors]
        [HttpGet("viewcontact")]
        public IActionResult ViewContact(int id)
        {
            return Ok(contactRepository.ViewContact(id));
        }
        [EnableCors]
        [HttpPost("addcontact")]
        public IActionResult AddContact(AddContactRequest request)
        {
            if(request==null)
            {
                return BadRequest(new { message = "Please check your input" });
            }
            return Ok(contactRepository.AddContact(request));
        }
        [EnableCors]
        [HttpPut("updatecontact")]
        public IActionResult UpdateContact(UpdateContactRequest request)
        {
            if(request==null)
            {
                return BadRequest();
            }
            return Ok(contactRepository.UpdateContact(request));
        }
        [EnableCors]
        [HttpPost("deletecontact")]
        public IActionResult DeleteContact(DeleteContactRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { message = "Please check the input" });
            }
            return Ok(contactRepository.DeleteContact(request));
        }
        [EnableCors]
        [HttpGet("viewalluserstickets")]
        public IActionResult ViewAllUsers()
        {
            return Ok(ticketRepository.ViewAllUserTickets());
        }
        [EnableCors]
        [HttpPost("changeresponder")]
        public IActionResult ChangeResponder(ChangeResponderRequest request)
        {
            if(request==null)
            {
                return BadRequest();
            }
            return Ok(ticketRepository.ChangeResponder(request));
        }
        
    }
}
