using System;
using System.Collections.Generic;
using System.Linq;
using DataModel;
using DataModel.Models;
using Services.Models;

namespace Services.UseCases.GetElem
{
    public class GetAllUsers
    {
        public IEnumerable<UserModel> TryExecute()
        {
            var result = new List<UserModel>();
            using (DataContext db = new DataContext())
            {
                try
                {
                    var userElems = db.Users.ToList();
                    result.AddRange(userElems);
                }
                catch (Exception e)
                {
                    ////todo
                }
            }
            
            // var result = new SuccessMessage
            // {
            //     Success = true
            // };

            return result;
        }

    }
}