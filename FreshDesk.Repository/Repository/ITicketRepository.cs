using FreshDesk.Entities.Models;
using FreshDesk.Repository.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using FreshDesk.Entities.Request;

namespace FreshDesk.Repository.Repository
{
    public interface ITicketRepository
    {
        List<ViewAllTicketDTO> ViewAllTickets(int id);
        bool AddTicket(AddTicketRequest request);
        bool UpdateTicket(UpdateTicketRequest request);
        List<ViewAllTicketDTO> SearchTicket(SearchTicketRequest request);
        bool DeleteTicket(DeleteTicketRequest request);
        List<ViewAllTicketDTO> ViewAllUserTickets();
        bool ChangeResponder(ChangeResponderRequest request);
    }
}
