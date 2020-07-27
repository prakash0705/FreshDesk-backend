using System;
using System.Collections.Generic;
using System.Text;
using FreshDesk.Entities.Models;
using FreshDesk.Entities.Request;
using FreshDesk.Repository.DTO;

namespace FreshDesk.Repository.Repository
{
    public interface IRegisterRepository
    {
        bool CreateAccount(AddRegisterRequest request);
        List<LoginDTO> LoginAccount(AddLoginRequest request);
        bool CheckCredentials(AddLoginRequest request);
        bool CheckEmailExist(AddRegisterRequest request);
    }
}
