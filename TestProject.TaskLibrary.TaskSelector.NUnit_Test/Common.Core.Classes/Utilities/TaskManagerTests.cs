using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using TestProject.Common.Core.Classes.Utilities;
using TestProject.Common.Core.Interfaces;

namespace Tests.NUnit.TestProject.Common.Core.Classes.Utilities
{
    [TestFixture]
    public class TaskManagerTests
    {
        private TaskManager tskMgr;
        private string assemblyName = "TestProject.TaskLibrary";
        private IEnumerable<Type> runnableTypes;

        [SetUp]
        public void Setup()
        {
            //runnableTypes=MockRepository.GenerateMock<IRunnable>()
            tskMgr = MockRepository.GenerateMock<TaskManager>(assemblyName, runnableTypes);
            
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}