using System;
using DataModel;
using Services.Models;

namespace Services.UseCases.RemoveElem
{
    public class RemoveProject
    {
        public SuccessMessage TryExecute(int projectId)
        {
            using (DataContext db = new DataContext())
            {
                try
                {
                    var project = db.Projects.Find(projectId);
                    db.Projects.Remove(project);
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