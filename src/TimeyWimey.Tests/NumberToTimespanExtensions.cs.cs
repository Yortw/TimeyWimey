using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeyWimey;

namespace TimeyWimey.Tests
{
	[TestClass]
	public class NumberToTimespanExtensions
	{

		#region Integer Tests

		[TestMethod]
		public void IntegerToMilliseconds_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1, 1.Milliseconds().TotalMilliseconds);
			Assert.AreEqual(4, 4.Milliseconds().TotalMilliseconds);
			Assert.AreEqual(10, 10.Milliseconds().TotalMilliseconds);

			Assert.AreEqual(-1, -1.Milliseconds().TotalMilliseconds);
			Assert.AreEqual(-4, -4.Milliseconds().TotalMilliseconds);
			Assert.AreEqual(-10, -10.Milliseconds().TotalMilliseconds);
		}

		[TestMethod]
		public void IntegerToSeconds_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1, 1.Seconds().TotalSeconds);
			Assert.AreEqual(4, 4.Seconds().TotalSeconds);
			Assert.AreEqual(10, 10.Seconds().TotalSeconds);

			Assert.AreEqual(-1, -1.Seconds().TotalSeconds);
			Assert.AreEqual(-4, -4.Seconds().TotalSeconds);
			Assert.AreEqual(-10, -10.Seconds().TotalSeconds);
		}

		[TestMethod]
		public void IntegerToMinutes_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1, 1.Minutes().TotalMinutes);
			Assert.AreEqual(4, 4.Minutes().TotalMinutes);
			Assert.AreEqual(10, 10.Minutes().TotalMinutes);

			Assert.AreEqual(-1, -1.Minutes().TotalMinutes);
			Assert.AreEqual(-4, -4.Minutes().TotalMinutes);
			Assert.AreEqual(-10, -10.Minutes().TotalMinutes);
		}

		[TestMethod]
		public void IntegerToHours_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1, 1.Hours().TotalHours);
			Assert.AreEqual(4, 4.Hours().TotalHours);
			Assert.AreEqual(10, 10.Hours().TotalHours);

			Assert.AreEqual(-1, -1.Hours().TotalHours);
			Assert.AreEqual(-4, -4.Hours().TotalHours);
			Assert.AreEqual(-10, -10.Hours().TotalHours);
		}

		[TestMethod]
		public void IntegerToDays_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1, 1.Days().TotalDays);
			Assert.AreEqual(4, 4.Days().TotalDays);
			Assert.AreEqual(10, 10.Days().TotalDays);

			Assert.AreEqual(-1, -1.Days().TotalDays);
			Assert.AreEqual(-4, -4.Days().TotalDays);
			Assert.AreEqual(-10, -10.Days().TotalDays);
		}

		#endregion

	}
}