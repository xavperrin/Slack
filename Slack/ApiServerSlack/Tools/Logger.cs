using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApiServerSlack.DAO;
using ApiServerSlack.Models;

namespace ApiServerSlack.Tools
{
    public class Logger : ILogger
       
        
    {
        readonly User NOTFOUND = null;

        UserDAO dao = new UserDAO();
        public string LoginGetToken(User user)
        {
            MD5 md5 = MD5.Create();
           string hashedpassword = GetMd5Hash(md5, user.Password);
                
            User u = dao.Retrieve(user);
            if (u == NOTFOUND)
            {
                User restTokenUser = dao.Retrieve(user.Name);
                if (restTokenUser != NOTFOUND)
                {
                    restTokenUser.Token = default(string);
                    DatabaseContext.Instance.SaveChanges();
                }
                return default(string);
            }
            else
            {
                string token = GetMd5Hash(md5, Guid.NewGuid().ToString());
                u.Token = token;
                if (DatabaseContext.Instance.SaveChanges() > 0)
                {
                    return u.Token;
                }
                else
                {
                    //return null
                    return default(string);
                }
            }


            
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public string Login(string strName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
