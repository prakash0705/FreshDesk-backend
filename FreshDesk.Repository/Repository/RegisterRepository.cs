using FreshDesk.Entities.Models;
using FreshDesk.Entities.Request;
using FreshDesk.Repository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace FreshDesk.Repository.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        public readonly FreshDeskDbContext _db;
        public RegisterRepository(FreshDeskDbContext db)
        {
            this._db = db;
        }
        public bool CreateAccount(AddRegisterRequest request)
        {
                List<Register> values;
                values = _db.Registers.Where(a => a.Email == request.email).ToList();
                if(values.Count>0)
                {
                    return false;
                }
                else
                {
                    Register register = new Register
                    {
                        FirstName = request.firstname,
                        LastName = request.lastname,
                        Email = request.email,
                        Password = EncodePasswordToBase64(request.password),
                        Created = DateTime.Now,
                        LastModified = DateTime.Now
                    };
                    _db.Registers.Add(register);
                    _db.SaveChanges();
                    return true;
                }
        }
        

        public List<LoginDTO> LoginAccount(AddLoginRequest request)
        {
            List<LoginDTO> login = new List<LoginDTO>();
            var result = _db.Registers.Where(a => a.Email == request.email).FirstOrDefault();
            // authentication successful so generate jwt token
            //to hide the exact user id and sending new user id with secret number
            int secretNo = 5306;
            login.Add(new LoginDTO
            {
                 Id=secretNo+result.Id,
                 firstName = result.FirstName,
                 lastName=result.LastName,
                 email=result.Email,
                 token=GenerateToken(request.email)
                 
            });
           return login;
        }

        public bool CheckCredentials(AddLoginRequest request)
        {
            var encodePassword = EncodePasswordToBase64(request.password);
            var res = _db.Registers.Where(a => a.Email == request.email && a.Password==encodePassword).FirstOrDefault();

            if(res==null)
            {
                return true;
            }
            return false;
        }


        public bool CheckEmailExist(AddRegisterRequest request)
        {
            
            var res = _db.Registers.Where(a => a.Email == request.email).FirstOrDefault();

            if (res != null)
            {
                return true;
            }
            return false;
        }
        public string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        public string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
        public string GenerateToken(string email)
        {
            AppSettings settings;  
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("asdfghjkjhgfdw4567uioi87654321");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, email)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //storing the token in Secret attribute in AppSettings class for further authentication
            settings=new AppSettings()
            {
                Secret= tokenHandler.WriteToken(token)
            };
            return settings.Secret;
        }
    }
}
