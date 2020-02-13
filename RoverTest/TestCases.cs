using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoverBusiness;

namespace RoverTest
{
    [TestClass]
    public class TestCases
    {
        [TestMethod]
        public void RoverTestCase1()
        {
            RoverEngine rover = new RoverEngine(5,5);
            rover.setPosition(1, 2, 1);
            rover.processCommands("LMLMLMLMM");
            string position = rover.getPosition();
            Assert.AreEqual(position, "1 3 N");
        }

        [TestMethod]
        public void RoverTestCase2()
        {
            RoverEngine rover = new RoverEngine(5,5);
            rover.setPosition(3, 3, 2);
            rover.processCommands("MMRMMRMRRM");
            string position = rover.getPosition();
            Assert.AreEqual(position, "5 1 E");
        }
    }
}
