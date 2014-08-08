using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vulcan.Domain.OnlineMetrics;

namespace Vulcan.Domain.Tests
{
    [TestClass]
    public class WelfordStatsTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var onlineStats = new WelfordStats();
            var interfaceStats = new WelfordStats(); 
            //onlineStats.AddDataPoint(-23);
            interfaceStats.AddDataPoint(1234);
        }

    }
}
