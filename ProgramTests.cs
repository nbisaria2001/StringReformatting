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
            var providedString = "id, name, location";// Enter the test string
            Program.ParseTheGivenString(providedString);
            string expected = string.Empty;
            string actual;
            actual = Program.ParseTheGivenString(providedString);
            Assert.AreEqual("id,location,name", actual);
        }              
    }
}