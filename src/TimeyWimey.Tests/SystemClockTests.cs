using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeyWimey.Abstractions;

namespace TimeyWimey.Tests
{
	[TestClass]
	public class SystemClockTests
	{

		[TestMethod]
		public void SystemClock_ReturnsCurrentTime()
		{
			//This test is rough/fragile since we can't control the clock, but it should be close enough and not break often.

			var clock = new SystemClock();
			var time = clock.Now;
			System.Threading.Thread.Sleep(1);
			var time2 = clock.Now;

			Assert.IsTrue(time2 > time, "Time did not change between requests");
			Assert.IsTrue(time2.Subtract(time).TotalSeconds < 1, "More than a second difference in time between subsequent calls");
		}
	}
}