using DataModel.Models.Duty;

namespace Services.UseCases.AddElem
{
    using DataModel;

    /// <summary>
    /// Добавляет смену в базу данных в соответствующую таблицу (Duties).
    /// </summary>
    public class AddDuty
    {
        /// <summary>
        /// Выполнить действие, подразумеваемое в описании Обьекта.
        /// </summary>
        /// <param name="duty">Информация о смене.</param>
        /// <returns>Идентификатор добавленного элемента.</returns>
        public int TryExecute(DutyModel duty)
        {
            if (duty.Start == null)
                throw new UseCaseException("Дата начала смены не может быть пустой.");
            
            if (duty.Finish == null)
                throw new UseCaseException("Дата конца смены не может быть пустой.");
            
            if (duty.LinkerId <= 0)
                throw new UseCaseException("Идентификатор линкера не может быть пустым.");

            using (var db = new DataContext())
            {
                var addedElem = db.Duties.Add(duty);
                db.SaveChanges();
                return addedElem.Entity.Id;
            }
        }
    }
}