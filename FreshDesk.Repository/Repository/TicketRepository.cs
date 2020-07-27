using FreshDesk.Entities.Models;
using FreshDesk.Repository.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using FreshDesk.Entities.Request;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace FreshDesk.Repository.Repository
{
    public class TicketRepository : ITicketRepository
    {
        public readonly FreshDeskDbContext _db;
        public TicketRepository(FreshDeskDbContext db)
        {
            this._db = db;
        }

        public bool AddTicket(AddTicketRequest request)
        {
            int secretKey = 5306;
            request.UserId = request.UserId - secretKey;
            if (request!=null)
            {
                var result = _db.Tickets.Where(a => a.Title == request.title &&a.registerId==request.UserId).FirstOrDefault();
                if(result!=null)
                {
                    return false;
                }
                else
                {
                    Ticket ticket = new Ticket
                    {
                        Title = request.title,
                        Description = request.description,
                        Status = "open",
                        Priority = 2,
                        ResponderId = 0,
                        Created = DateTime.Now,
                        LastModified = DateTime.Now,
                        registerId = request.UserId
                    };
                    _db.Tickets.Add(ticket);
                    _db.SaveChanges();



                    var result1 = _db.Tickets.Where(a => a.registerId == request.UserId && a.Title == request.title && a.Description == request.description).FirstOrDefault();
                    //Adding all information to logs table

                    Logs logs = new Logs
                    {
                        Description = request.description,
                        Title = request.title,
                        LastModified = DateTime.Now,
                        ticketId = result1.Id,
                        registerId = request.UserId
                    };
                    _db.Logs.Add(logs);
                    _db.SaveChanges();
                    return true;
                }
               
            }
            return false;
        }

        public bool ChangeResponder(ChangeResponderRequest request)
        {
            if(request!=null)
            {
                var ticket = _db.Tickets.Where(a => a.registerId == request.userId && a.ResponderId==0).ToList();
                foreach (var item in ticket)
                {
                    item.ResponderId = request.responderId;
                    _db.SaveChanges();
                }
                return true;
            }
            return false;
        }

        public bool DeleteTicket(DeleteTicketRequest request)
        {
            if(request!=null)
            {
                var ticket = _db.Tickets.Where(a => a.Id == request.TicketId).FirstOrDefault();
                var UpdateLog = _db.Logs.Where(a => a.ticketId == ticket.Id).ToList();
                if(UpdateLog.Count!=0)
                {
                    foreach (var updateLog in UpdateLog)
                    {
                        Nullable<int> i = null;
                        updateLog.ticketId = i;
                        updateLog.LastModified = DateTime.Now;
                        //Remove the ticket reference in log table and save
                        _db.SaveChanges();

                    }
                    //remove the requested ticket
                    _db.Tickets.Remove(ticket);
                    _db.SaveChanges();
                    return true;

                }
               
            }
            return false;
        }

        public List<ViewAllTicketDTO> SearchTicket(SearchTicketRequest request)
        {
            List<ViewAllTicketDTO> allTickets = new List<ViewAllTicketDTO>();
            int secretKey = 5306;
            request.registerId = request.registerId - secretKey;
            if (!string.IsNullOrEmpty(request.title))
            {
                var result = _db.Tickets.Where(a => a.Title.Contains(request.title) && a.registerId == request.registerId).FirstOrDefault();
                if (result != null)
                {
                    List<int> responderArray = new List<int>();
                    List<string> responderName = new List<string>();

                    var Result = _db.Tickets.Include("register").Where(a => a.registerId == request.registerId).ToList();
                    foreach (var item in Result)
                    {
                        responderArray.Add(item.ResponderId);
                    }
                    foreach (var item in responderArray)
                    {
                        if (item != 0)
                        {
                            var dbResult = _db.Registers.Where(a => a.Id == item).FirstOrDefault();
                            responderName.Add(dbResult.FirstName + " " + dbResult.LastName);
                        }
                        else
                        {
                            responderName.Add("Not Assigned");
                        }

                    }


                    allTickets.Add(new ViewAllTicketDTO
                    {
                        Id = result.Id,
                        title = result.Title,
                        description = result.Description,
                        status = result.Status,
                        responderName = "Not Assigned",
                        created = result.Created,
                        lastModified = result.LastModified
                    });
                    return allTickets;
                }
                

            }
            else if(!string.IsNullOrEmpty(request.description))
            {
                var result = _db.Tickets.Where(a => a.Description.Contains(request.description) && a.registerId == request.registerId).FirstOrDefault();
                if (result != null)
                {
                    List<int> responderArray = new List<int>();
                    List<string> responderName = new List<string>();

                    var Result = _db.Tickets.Include("register").Where(a => a.registerId == request.registerId).ToList();
                    foreach (var item in Result)
                    {
                        responderArray.Add(item.ResponderId);
                    }
                    foreach (var item in responderArray)
                    {
                        if (item != 0)
                        {
                            var dbResult = _db.Registers.Where(a => a.Id == item).FirstOrDefault();
                            responderName.Add(dbResult.FirstName + " " + dbResult.LastName);
                        }
                        else
                        {
                            responderName.Add("Not Assigned");
                        }
                    }
                    allTickets.Add(new ViewAllTicketDTO
                    {
                        Id = result.Id,
                        title = result.Title,
                        description = result.Description,
                        status = result.Status,
                        responderName = "Not Assigned",
                        created = result.Created,
                        lastModified = result.LastModified
                    });
                    return allTickets;
                }
                
            }
            else if (request.ticketid != 0)
            {
                var result = _db.Tickets.Where(a => a.Id == request.ticketid && a.registerId == request.registerId).FirstOrDefault();
                if (result != null)
                {
                    List<int> responderArray = new List<int>();
                    List<string> responderName = new List<string>();

                    var Result = _db.Tickets.Include("register").Where(a => a.registerId == request.registerId).ToList();
                    foreach (var item in Result)
                    {
                        responderArray.Add(item.ResponderId);
                    }
                    foreach (var item in responderArray)
                    {
                        if (item != 0)
                        {
                            var dbResult = _db.Registers.Where(a => a.Id == item).FirstOrDefault();
                            responderName.Add(dbResult.FirstName + " " + dbResult.LastName);
                        }
                        else
                        {
                            responderName.Add("Not Assigned");
                        }
                    }
                    allTickets.Add(new ViewAllTicketDTO
                    {
                        Id = result.Id,
                        title = result.Title,
                        description = result.Description,
                        status = result.Status,
                        responderName = "Not Assigned",
                        created = result.Created,
                        lastModified = result.LastModified
                    });
                    return allTickets;
                }
            }
           return allTickets;
        }

        
        

        public bool UpdateTicket(UpdateTicketRequest request)
        {
            if(request!=null)
            {
                var ticket = _db.Tickets.Where(a => a.Id == request.Id).FirstOrDefault();
                if(ticket!=null)
                {
                    ticket.Title = string.IsNullOrEmpty(request.Title) ? ticket.Title : request.Title;
                    ticket.Description = string.IsNullOrEmpty(request.Description) ? ticket.Description : request.Description;
                    ticket.LastModified = DateTime.Now;
                    _db.SaveChanges();
                    Logs logs = new Logs
                    {
                        Title = string.IsNullOrEmpty(request.Title) ? ticket.Title : request.Title,
                        Description = string.IsNullOrEmpty(request.Description) ? ticket.Description : request.Description,
                        LastModified = DateTime.Now,
                        ticketId=request.Id,
                        registerId=ticket.registerId,
                    };
                    _db.Logs.Add(logs);
                    _db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public List<ViewAllTicketDTO> ViewAllTickets(int id)
        {
            List<ViewAllTicketDTO> AllTickets = new List<ViewAllTicketDTO>();
           
            int i=0,secretNumber = 5306;
            id =id - secretNumber;
            List<int> responderArray = new List<int>();
            List<string> responderName = new List<string>();

            var Result = _db.Tickets.Include("register").Where(a => a.registerId == id).ToList();
            foreach(var result in Result)
            {
                responderArray.Add(result.ResponderId);
            }
            foreach (var result in responderArray)
            {
                if(result!=0)
                {
                    var dbResult = _db.Registers.Where(a => a.Id == result).FirstOrDefault();
                    responderName.Add(dbResult.FirstName + " " + dbResult.LastName);
                }
                else
                {
                    responderName.Add("Not Assigned");
                }
                
            }
            foreach(var result in Result)
            {
                AllTickets.Add(new ViewAllTicketDTO
                {
                    Id=result.Id,
                    title=result.Title,
                    description=result.Description,
                    status=result.Status,
                    responderName=responderName[i],
                    //responderName=result.register.FirstName+" "+result.register.LastName,
                    created=result.Created,
                    lastModified=result.LastModified
                });
                i++;
            }
            i = 0;
            return AllTickets;
        }

        public List<ViewAllTicketDTO> ViewAllUserTickets()
        {
            int i = 0;
            List<ViewAllTicketDTO> list = new List<ViewAllTicketDTO>();
            var ticketData = _db.Tickets.ToList();
            if(ticketData.Count!=0)
            {
                List<int> responderArray = new List<int>();
                List<string> responderName = new List<string>();

                var Result = _db.Tickets.Include("register").ToList();
                foreach (var result in Result)
                {
                    responderArray.Add(result.ResponderId);
                }
                foreach (var result in responderArray)
                {
                    if (result != 0)
                    {
                        var dbResult = _db.Registers.Where(a => a.Id == result).FirstOrDefault();
                        responderName.Add(dbResult.FirstName + " " + dbResult.LastName);
                    }
                    else
                    {
                        responderName.Add("Not Assigned");
                    }

                }
                foreach (var result in ticketData)
                {
                    list.Add(new ViewAllTicketDTO
                    {
                        Id = result.Id,
                        title = result.Title,
                        description = result.Description,
                        status = result.Status,
                        responderName = responderName[i],
                        //responderName=result.register.FirstName+" "+result.register.LastName,
                        created = result.Created,
                        lastModified = result.LastModified
                    });
                    i++;
                }
                i = 0;
                return list;
            }

            return list;
        }
    }
}
