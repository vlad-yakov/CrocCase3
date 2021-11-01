using DataModel.Models;
using NUnit.Framework;
using Services.UseCases.AddElem;
using Services.UseCases.RemoveElem;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var user = new UserModel
            {
                FullName = "Anton",
                Email = "@gmail.com"
            };

            var addElem = new RemoveUser();
            addElem.TryExecute(1);
        }
    }
}