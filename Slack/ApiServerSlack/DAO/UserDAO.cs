using ApiServerSlack.Models;
using ApiServerSlack.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServerSlack.DAO
{
    public class UserDAO : IDataAccess<User, int>
    {
        private IServiceProvider serviceProvider;

        public UserDAO(IServiceProvider provider)
        {
            this.serviceProvider = provider;
        }

        public UserDAO()
        {

        }

        public bool Create(User user)
        {
            try {
                DatabaseContext.Instance.Users.Add(user);
                if (DatabaseContext.Instance.SaveChanges() > 0)
                    return true;
                else
                    return false;

            } catch (DbUpdateException dbe)
            {

                //Prévoir StreamWriter en mode PROD
                Debug.WriteLine("source:" + dbe.Source+"\n trace:" +dbe.StackTrace+"\n message:"+dbe.Message);
                return false;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("source:" + ex.Source + "trace:" + ex.StackTrace + "\n message:" + ex.Message);
                return false;

            }

        }

        public bool Delete(int id)
        {
            try
            {
                User user2delete = DatabaseContext.Instance.Users.FirstOrDefault(x => x.Id == id);
                if (user2delete == null)
                {
                    return false;
                }
                else
                {
                    DatabaseContext.Instance.Users.Remove(user2delete);
                    if (DatabaseContext.Instance.SaveChanges() > 0)
                        return true;
                    else return false;
                }
            }
            catch (ArgumentNullException anex)
            {
                Debug.WriteLine("source:" + anex.Source + "trace:" + anex.StackTrace + "\n message:" + anex.Message);
                return false;
            }
            catch (DbUpdateException dbe)
            {
                Debug.WriteLine("source:" + dbe.Source + "trace:" + dbe.StackTrace + "\n message:" + dbe.Message);
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("source:" + ex.Source + "trace:" + ex.StackTrace + "\n message:" + ex.Message);
                return false;
            }
        }

        public List<User> ListAll()
        {
            return DatabaseContext.Instance.Users.ToList();
        }

        public User Retrieve(int id)
        {
                return DatabaseContext.Instance.Users.Include("messageposts").FirstOrDefault(x => x.Id == id);   
        }

        public bool Update(User user, int id)
        {
            
            try
            {
                User old2update = DatabaseContext.Instance.Users.FirstOrDefault(x => x.Id == id);
                if (old2update != null)
                {
                    old2update.Name = user.Name;
                    old2update.Password = user.Password;
                    old2update.Token = user.Token;

                }
                if (DatabaseContext.Instance.SaveChanges() > 0)
                    return true;
                else return false;
            }
            catch (ArgumentNullException anex)
            {
                Debug.WriteLine("source:" + anex.Source + "trace:" + anex.StackTrace + "\n message:" + anex.Message);
                return false;
            }
            catch (DbUpdateException dbe)
            {
                //Prévoir StreamWriter en mode PROD
                Debug.WriteLine("source:" + dbe.Source + "\n trace:" + dbe.StackTrace + "\n message:" + dbe.Message);
                return false;
            }
        }
    }
}
