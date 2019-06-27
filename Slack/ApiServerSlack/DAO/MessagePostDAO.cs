using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ApiServerSlack.Models;
using ApiServerSlack.Tools;
using Microsoft.EntityFrameworkCore;

namespace ApiServerSlack.DAO
{
    public class MessagePostDAO : IDataAccess<MessagePost, int>
    {
       

        public MessagePostDAO()
        {
           
        }

        public bool Create(MessagePost message)
        {
            try
            {
                DatabaseContext.Instance.MessagePosts.Add(message);
                if (DatabaseContext.Instance.SaveChanges() > 0)
                    return true;
                else
                    return false;

            }
            catch (DbUpdateException dbe)
            {

                //Prévoir StreamWriter en mode PROD
                Debug.WriteLine("source:" + dbe.Source + "\n trace:" + dbe.StackTrace + "\n message:" + dbe.Message);
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
                MessagePost message2delete = DatabaseContext.Instance.MessagePosts.FirstOrDefault(x => x.Id == id);
                if (message2delete == null)
                {
                    return false;
                }
                else
                {
                    DatabaseContext.Instance.MessagePosts.Remove(message2delete);
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

        public List<MessagePost> ListAll()
        {
            return DatabaseContext.Instance.MessagePosts.ToList();
        }

        public MessagePost Retrieve(int id)
        {
            return DatabaseContext.Instance.MessagePosts.FirstOrDefault(x => x.Id == id);
        }

        public MessagePost Retrieve(MessagePost t)
        {
            throw new NotImplementedException();
        }

        public bool Update(MessagePost message, int id)
        {
            try
            {
                MessagePost old2update = DatabaseContext.Instance.MessagePosts.FirstOrDefault(x => x.Id == id);
                if (old2update != null)
                {
                    old2update.Title = message.Title;
                    old2update.Content = message.Content;
                    

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
