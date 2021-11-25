using System;
using System.Collections.Generic;
using System.Linq;
using DataModel;
using DataModel.Models;
using DataModel.Models.Project;
using Services.Models;

namespace Services.UseCases.GetElem
{
    public class GetAllProjects
    {
        public IEnumerable<ProjectModel> TryExecute()
        {
            var result = new List<ProjectModel>();
            using (DataContext db = new DataContext())
            {
                try
                {
                    var projectElems = db.Projects.ToList();
                    result.AddRange(projectElems);
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