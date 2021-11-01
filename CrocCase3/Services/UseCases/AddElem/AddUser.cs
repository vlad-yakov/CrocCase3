namespace Services.UseCases.AddElem
{
    using System;
    using System.Collections.Generic;
    using DataModel;
    using DataModel.Models;
    using Models;

    public class AddUser
    {
        public SuccessMessage TryExecute(UserModel user)
        {
            using (DataContext db = new DataContext())
            {
                try
                {
                    db.Users.Add(user);
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