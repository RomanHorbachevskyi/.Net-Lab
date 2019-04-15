using System;
using NUnit.Framework;
using Rhino.Mocks;
using TestProject.Common.Core.Classes.Utilities;

namespace Tests.NUnit.TestProject.Common.Core.Classes.Utilities
{
    [TestFixture]
    public class AssemblyLoaderTests
    {
        private IAssemblyLoader _loader;

        private string _assemblyName =
            //@"d:\!_Documents_!\_EPAM_\_Training_\GIT\Repository_Template\
            //    .Net-Lab\TestProject.TaskLibrary\bin\Debug\netcoreapp2.1\
            //    TestProject.TaskLibrary.dll"; 
        "TestProject.TaskLibrary";

        // This attribute does not work!?
        [OneTimeSetUp]
        public void FixtureSetup()
        {
            _assemblyName = "TestProject.TaskLibrary";
        }




        [SetUp]
        public void Setup()
        {
            //MockRepository mocks = new MockRepository();
            //_loader = mocks.StrictMock<AssemblyLoader>(new object[] {_assemblyName});
            var mock = MockRepository.GenerateMock<IAssemblyLoader>();
            _loader =  mock;
            // AsmLoader.
            //_assemblyName = "TestProject.TaskLibrary";
            // How properly test constructors?
            //_loader = new AssemblyLoader();
            //_loader = AsmLoader; //AssemblyLoader(_assemblyName);
        }

        [Test]
        [TestCase("TestProject.TaskLibrary")]
        public void TestGetAssemblyName(string expected)
        {
            //AssemblyLoader __loader = new AssemblyLoader(_assemblyName);
            _loader.Expect(x => x.Init()).Repeat.Once();
            var actual = _loader.AssemblyName;
            Assert.AreEqual(expected, actual);
        }
    }

    public class MockAssemblyLoader:AssemblyLoader
    {

    }
}