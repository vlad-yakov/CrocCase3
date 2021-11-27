using DataModel;

namespace Services.UseCases.RemoveElem
{
    public class RemoveProject
    {
        public void TryExecute(int projectId)
        {
            using (DataContext db = new DataContext())
            {
                var project = db.Projects.Find(projectId);

                if (project == null)
                    throw new UseCaseException("Не удалось найти элемент по заданному идентификатору.");

                project.Deleted = true;
                db.Update(project);
                db.SaveChanges();
            }
        }
    }
}