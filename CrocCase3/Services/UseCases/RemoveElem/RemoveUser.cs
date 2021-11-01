using System;
using System.Collections.Generic;
using DataModel;
using DataModel.Models;
using Services.Models;

namespace Services.UseCases.RemoveElem
{
    public class RemoveUser
    {
        public SuccessMessage TryExecute(int userId)
        {
            using (DataContext db = new DataContext())
            {
                try
                {
                    var user = db.Users.Find(userId);
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ////todo
                }
            }
            
            var result = new SuccessMessage
            {
                Success = true
            };

            return result;
        }
    }
}