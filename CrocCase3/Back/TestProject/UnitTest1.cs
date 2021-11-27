using DataModel.Models;
using DataModel.Models.User;
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
                FullName = "Vlad",
                Email = "@gmail.com"
            };

            var addElem = new AddUser();
            addElem.TryExecute(user);
        }
    }
}