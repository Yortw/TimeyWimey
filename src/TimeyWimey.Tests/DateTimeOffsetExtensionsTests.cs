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
	public class DateTimeOffsetExtensionsTests
	{

		#region IsFuture

		[TestMethod]
		public void DateTimeOffset_IsFuture_ReturnsTrueForFutureDate()
		{
			Assert.AreEqual(true, DateTimeOffset.Now.AddHours(1).IsFuture());
		}

		[TestMethod]
		public void DateTimeOffset_IsFuture_ReturnsFalseForNow()
		{
			Assert.AreEqual(false, DateTimeOffset.Now.IsFuture());
		}

		[TestMethod]
		public void DateTimeOffset_IsFuture_ReturnsFalseForPast()
		{
			Assert.AreEqual(false, DateTimeOffset.Now.AddDays(-1).IsFuture());
		}

		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void DateTimeOffset_IsFuture_ThrowsOnNullClock()
		{
			Assert.AreEqual(false, DateTimeOffset.Now.AddDays(-1).IsFuture(null));
		}

		[TestMethod]
		public void DateTimeOffset_IsFuture_CustomClock_ReturnsTrueForFutureDate()
		{
			var mockClock = new MockClock();
			mockClock.SetTime(new DateTimeOffset(2017, 02, 21, 22, 39, 00, DateTimeOffset.Now.Offset), false);

			var testTime = new DateTimeOffset(2017, 02, 21, 22, 40, 00, DateTimeOffset.Now.Offset);
			Assert.AreEqual(true, testTime.IsFuture(mockClock));
		}

		[TestMethod]
		public void DateTimeOffset_IsFuture_CustomClock_ReturnsFalseForNow()
		{
			var mockClock = new MockClock();
			mockClock.SetTime(new DateTimeOffset(2017, 02, 21, 22, 39, 00, DateTimeOffset.Now.Offset), false);

			var testTime = new DateTimeOffset(2017, 02, 21, 22, 39, 00, DateTimeOffset.Now.Offset);
			Assert.AreEqual(false, testTime.IsFuture(mockClock));
		}

		[TestMethod]
		public void DateTimeOffset_IsFuture_CustomClock_ReturnsFalseForPast()
		{
			var mockClock = new MockClock();
			mockClock.SetTime(new DateTimeOffset(2017, 02, 21, 22, 39, 00, DateTimeOffset.Now.Offset), false);

			var testTime = new DateTimeOffset(2017, 02, 21, 22, 00, 00, DateTimeOffset.Now.Offset);
			Assert.AreEqual(false, testTime.IsFuture(mockClock));
		}

		#endregion

		#region IsPast

		[TestMethod]
		public void DateTimeOffset_IsPast_ReturnsFalseForFutureDate()
		{
			Assert.AreEqual(false, DateTimeOffset.Now.AddHours(1).IsPast());
		}

		[TestMethod]
		public void DateTimeOffset_IsPast_ReturnsFalseForNow()
		{
			Assert.AreEqual(false, DateTimeOffset.Now.IsPast());
		}

		[TestMethod]
		public void DateTimeOffset_IsPast_ReturnsTrueForPast()
		{
			Assert.AreEqual(true, DateTimeOffset.Now.AddDays(-1).IsPast());
		}

		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void DateTimeOffset_IsPast_ThrowsOnNullClock()
		{
			Assert.AreEqual(false, DateTimeOffset.Now.AddDays(-1).IsPast(null));
		}

		[TestMethod]
		public void DateTimeOffset_IsPast_CustomClock_ReturnsFalseForFutureDate()
		{
			var mockClock = new MockClock();
			mockClock.SetTime(new DateTimeOffset(2017, 02, 21, 22, 39, 00, DateTimeOffset.Now.Offset), false);

			var testTime = new DateTimeOffset(2017, 02, 21, 22, 40, 00, DateTimeOffset.Now.Offset);
			Assert.AreEqual(false, testTime.IsPast(mockClock));
		}

		[TestMethod]
		public void DateTimeOffset_IsPast_CustomClock_ReturnsFalseForNow()
		{
			var mockClock = new MockClock();
			mockClock.SetTime(new DateTimeOffset(2017, 02, 21, 22, 39, 00, DateTimeOffset.Now.Offset), false);

			var testTime = new DateTimeOffset(2017, 02, 21, 22, 39, 00, DateTimeOffset.Now.Offset);
			Assert.AreEqual(false, testTime.IsPast(mockClock));
		}

		[TestMethod]
		public void DateTimeOffset_IsPast_CustomClock_ReturnsTrueForPast()
		{
			var mockClock = new MockClock();
			mockClock.SetTime(new DateTimeOffset(2017, 02, 21, 22, 39, 00, DateTimeOffset.Now.Offset), false);

			var testTime = new DateTimeOffset(2017, 02, 21, 22, 00, 00, DateTimeOffset.Now.Offset);
			Assert.AreEqual(true, testTime.IsPast(mockClock));
		}

		#endregion

		#region Truncation

		[TestMethod]
		public void DateTimeOffset_TruncateToSeconds_DoesNothingWhenMillsecondsZero()
		{
			var d = new DateTimeOffset(2017, 05, 29, 13, 23, 57, 0, TimeSpan.Zero);
			Assert.AreEqual(new DateTimeOffset(2017, 05, 29, 13, 23, 57, 0, TimeSpan.Zero), d.TruncateToSeconds());
		}

		[TestMethod]
		public void DateTimeOffset_TruncateToSeconds_RemovesMilliseconds()
		{
			var d = new DateTimeOffset(2017, 05, 29, 13, 23, 57, 432, TimeSpan.Zero);
			Assert.AreEqual(new DateTimeOffset(2017, 05, 29, 13, 23, 57, 0, TimeSpan.Zero), d.TruncateToSeconds());
		}

		[TestMethod]
		public void DateTimeOffset_TruncateToMinutes_DoesNothingWhenSecondsAndMillsecondsZero()
		{
			var d = new DateTimeOffset(2017, 05, 29, 13, 23, 0, 0, TimeSpan.Zero);
			Assert.AreEqual(new DateTimeOffset(2017, 05, 29, 13, 23, 0, 0, TimeSpan.Zero), d.TruncateToMinutes());
		}

		[TestMethod]
		public void DateTimeOffset_TruncateToMinutes_RemovesSecondsAndMilliseconds()
		{
			var d = new DateTimeOffset(2017, 05, 29, 13, 23, 57, 432, TimeSpan.Zero);
			Assert.AreEqual(new DateTimeOffset(2017, 05, 29, 13, 23, 0, 0, TimeSpan.Zero), d.TruncateToMinutes());
		}

		[TestMethod]
		public void DateTimeOffset_TruncateToHours_DoesNothingWhenMinutesSecondsAndMillsecondsZero()
		{
			var d = new DateTimeOffset(2017, 05, 29, 13, 0, 0, 0, TimeSpan.Zero);
			Assert.AreEqual(new DateTimeOffset(2017, 05, 29, 13, 0, 0, 0, TimeSpan.Zero), d.TruncateToHours());
		}

		[TestMethod]
		public void DateTimeOffset_TruncateToMinutes_RemovesMinutesSecondsAndMilliseconds()
		{
			var d = new DateTimeOffset(2017, 05, 29, 13, 23, 57, 432, TimeSpan.Zero);
			Assert.AreEqual(new DateTimeOffset(2017, 05, 29, 13, 0, 0, 0, TimeSpan.Zero), d.TruncateToHours());
		}

		#endregion

	}
}