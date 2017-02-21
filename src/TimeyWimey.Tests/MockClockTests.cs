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
	public class MockClockTests
	{
		[TestMethod]
		public void MockClock_SetTime_ChangesNow()
		{
			var expected = new DateTimeOffset(2017, 02, 21, 21, 44, 00, DateTimeOffset.Now.Offset);
			var clock = new MockClock();
			clock.SetTime(expected, false);
			Assert.AreEqual(expected, clock.Now);
			System.Threading.Thread.Sleep(1000);
			Assert.AreEqual(expected, clock.Now);
		}

		[TestMethod]
		public void MockClock_SetTime_RaisesAdjustedEvent()
		{
			var testTime = new DateTimeOffset(2017, 02, 21, 21, 44, 00, DateTimeOffset.Now.Offset);
			var expected = true;
			var eventRaised = false;
			var clock = new MockClock();
			clock.Adjusted += (sender, args) => eventRaised = true;

			clock.SetTime(testTime, true);
			Assert.AreEqual(expected, eventRaised);
		}

		[TestMethod]
		public void MockClock_SetTime_DoesNotRaiseAdjustedEvent()
		{
			var testTime = new DateTimeOffset(2017, 02, 21, 21, 44, 00, DateTimeOffset.Now.Offset);
			var expected = false;
			var eventRaised = false;
			var clock = new MockClock();
			clock.Adjusted += (sender, args) => eventRaised = true;

			clock.SetTime(testTime, false);
			Assert.AreEqual(expected, eventRaised);
		}

	}
}