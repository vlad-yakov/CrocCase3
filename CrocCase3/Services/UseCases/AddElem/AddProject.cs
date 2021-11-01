using System;
using DataModel;
using DataModel.Models;
using Services.Models;

namespace Services.UseCases.AddElem
{
    public class AddProject
    {
        public SuccessMessage TryExecute(ProjectModel project)
        {
            using (DataContext db = new DataContext())
            {
                try
                {
                    db.Projects.Add(project);
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