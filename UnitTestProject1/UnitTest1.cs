using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mock<IDataAccess> fakeEmployeeDataAccess;
            BusinessLogic mbl;
        [TestInitialize]
        public void SetUp()
        {
            fakeEmployeeDataAccess = new Mock<IDataAccess>();
            fakeDataAccess.Setup(m => m.(It.IsAny<int>())).Returns("Argo");
            fakeDataAccess.Setup(m => m.GetMovieCategory(It.IsAny<int>())).Returns("Action");
            mbl = new MoviesBusinessLogic(fakeDataAccess.Object);
        }
        [TestMethod]
        public void PrintMovieShortInfo_Test_WithMoq()
        {
            //Arrange (Handled by Initialize)                
            //Act
            var printResult = mbl.PrintMovieShortInfo(5);
            //Assert
            Assert.AreEqual(printResult, "The Movie Argo with Category Action");
        }
    }
    }
}
