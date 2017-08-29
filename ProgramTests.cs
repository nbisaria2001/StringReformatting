using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace FrontlineCodeChallenge_2017.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MainTest()
        {
            Program prg = new Program();
            var providedString = "(id,created,employee(id,firstname,employeeType(id), lastname),location)";// Enter the test string
            Program.ParseTheGivenString(providedString);
            string expected = string.Empty;
            string actual;
            actual = Program.ParseTheGivenString(providedString);
            Assert.AreEqual("created,employee,- employeeType,-- id,- firstname,- id,- lastname,id,location", actual);
        }              
    }
}