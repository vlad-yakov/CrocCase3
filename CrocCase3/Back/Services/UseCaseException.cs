using System;

namespace Services
{
    /// <summary>
    /// Ошибка, выбрасываемая при исполнении пользовательского сценария обращения к базе данных.
    /// </summary>
    public class UseCaseException : Exception
    {
        public UseCaseException()
        {
        }

        public UseCaseException(string message) : base(message)
        {
        }

        public UseCaseException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}