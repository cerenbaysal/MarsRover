using System;
using System.Collections.Generic;
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
            List<int> maxSize = new List<int>();
            maxSize.Add(5); maxSize.Add(5);
            RoverEngine rover = new RoverEngine(maxSize);
            rover.setPosition(1, 2, 1);
            rover.processCommands("LMLMLMLMM");
            string position = rover.getPosition();
            Assert.AreEqual(position, "1 3 N");
        }

        [TestMethod]
        public void RoverTestCase2()
        {
            List<int> maxSize = new List<int>();
            maxSize.Add(5); maxSize.Add(5);
            RoverEngine rover = new RoverEngine(maxSize);
            rover.setPosition(3, 3, 2);
            rover.processCommands("MMRMMRMRRM");
            string position = rover.getPosition();
            Assert.AreEqual(position, "5 1 E");
        }
    }
}
