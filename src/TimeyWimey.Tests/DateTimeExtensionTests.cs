using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeyWimey;
using TimeyWimey.Abstractions;

namespace TimeyWimey.Tests
{
	[TestClass]
	public class DateTimeExtensionTests
	{

		[TestMethod]
		public void DateTime_ChangeKind_ChangesKind()
		{
			var time = new DateTime(2016, 03, 17, 13, 0, 0, DateTimeKind.Unspecified);
			var utcExpected = new DateTime(2016, 03, 17, 13, 0, 0, DateTimeKind.Utc);
			var localExpected = new DateTime(2016, 03, 17, 13, 0, 0, DateTimeKind.Local);

			var actual = time.ChangeKind(DateTimeKind.Utc);
			Assert.AreEqual(utcExpected, actual);

			actual = time.ChangeKind(DateTimeKind.Local);
			Assert.AreEqual(localExpected, actual);
		}

		[TestMethod]
		public void DateTime_ChangeKind_DoesNothingWhenKindMatches()
		{
			var time = new DateTime(2016, 03, 17, 13, 0, 0, DateTimeKind.Local);
			var localExpected = new DateTime(2016, 03, 17, 13, 0, 0, DateTimeKind.Local);

			var actual = time.ChangeKind(DateTimeKind.Local);
			Assert.AreEqual(localExpected, actual.ChangeKind(DateTimeKind.Local));
		}

		#region IsFuture

		[TestMethod]
		public void DateTime_IsFuture_ReturnsTrueForFutureDate()
		{
			Assert.AreEqual(true, DateTime.Now.AddHours(1).IsFuture());
		}

		[TestMethod]
		public void DateTime_IsFuture_ReturnsFalseForNow()
		{
			Assert.AreEqual(false, DateTime.Now.IsFuture());
		}

		[TestMethod]
		public void DateTime_IsFuture_ReturnsFalseForPast()
		{
			Assert.AreEqual(false, DateTime.Now.AddDays(-1).IsFuture());
		}

		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void DateTime_IsFuture_ThrowsOnNullClock()
		{
			Assert.AreEqual(false, DateTime.Now.AddDays(-1).IsFuture(null));
		}

		[TestMethod]
		public void DateTime_IsFuture_CustomClock_ReturnsTrueForFutureDate()
		{
			var mockClock = new MockClock();
			mockClock.SetTime(new DateTimeOffset(2017, 02, 21, 22, 39, 00, DateTimeOffset.Now.Offset), false);

			var testTime = new DateTime(2017, 02, 21, 22, 40, 00);
			Assert.AreEqual(true, testTime.IsFuture(mockClock));
		}

		[TestMethod]
		public void DateTime_IsFuture_CustomClock_ReturnsFalseForNow()
		{
			var mockClock = new MockClock();
			mockClock.SetTime(new DateTimeOffset(2017, 02, 21, 22, 39, 00, DateTimeOffset.Now.Offset), false);

			var testTime = new DateTime(2017, 02, 21, 22, 39, 00);
			Assert.AreEqual(false, testTime.IsFuture(mockClock));
		}

		[TestMethod]
		public void DateTime_IsFuture_CustomClock_ReturnsFalseForPast()
		{
			var mockClock = new MockClock();
			mockClock.SetTime(new DateTimeOffset(2017, 02, 21, 22, 39, 00, DateTimeOffset.Now.Offset), false);

			var testTime = new DateTime(2017, 02, 21, 22, 00, 00);
			Assert.AreEqual(false, testTime.IsFuture(mockClock));
		}

		#endregion

		#region IsPast

		[TestMethod]
		public void DateTime_IsPast_ReturnsFalseForFutureDate()
		{
			Assert.AreEqual(false, DateTime.Now.AddHours(1).IsPast());
		}

		[TestMethod]
		public void DateTime_IsPast_ReturnsFalseForNow()
		{
			Assert.AreEqual(false, DateTime.Now.IsPast());
		}

		[TestMethod]
		public void DateTime_IsPast_ReturnsTrueForPast()
		{
			Assert.AreEqual(true, DateTime.Now.AddDays(-1).IsPast());
		}

		[ExpectedException(typeof(ArgumentNullException))]
		[TestMethod]
		public void DateTime_IsPast_ThrowsOnNullClock()
		{
			Assert.AreEqual(false, DateTime.Now.AddDays(-1).IsPast(null));
		}

		[TestMethod]
		public void DateTime_IsPast_CustomClock_ReturnsFalseForFutureDate()
		{
			var mockClock = new MockClock();
			mockClock.SetTime(new DateTimeOffset(2017, 02, 21, 22, 39, 00, DateTimeOffset.Now.Offset), false);

			var testTime = new DateTime(2017, 02, 21, 22, 40, 00);
			Assert.AreEqual(false, testTime.IsPast(mockClock));
		}

		[TestMethod]
		public void DateTime_IsPast_CustomClock_ReturnsFalseForNow()
		{
			var mockClock = new MockClock();
			mockClock.SetTime(new DateTimeOffset(2017, 02, 21, 22, 39, 00, DateTimeOffset.Now.Offset), false);

			var testTime = new DateTime(2017, 02, 21, 22, 39, 00);
			Assert.AreEqual(false, testTime.IsPast(mockClock));
		}

		[TestMethod]
		public void DateTime_IsPast_CustomClock_ReturnsTrueForPast()
		{
			var mockClock = new MockClock();
			mockClock.SetTime(new DateTimeOffset(2017, 02, 21, 22, 39, 00, DateTimeOffset.Now.Offset), false);

			var testTime = new DateTime(2017, 02, 21, 22, 00, 00);
			Assert.AreEqual(true, testTime.IsPast(mockClock));
		}

		#endregion

		#region Truncation

		[TestMethod]
		public void DateTime_TruncateToSeconds_DoesNothingWhenMillsecondsZero()
		{
			var d = new DateTime(2017, 05, 29, 13, 23, 57, 0, DateTimeKind.Local);
			Assert.AreEqual(new DateTime(2017, 05, 29, 13, 23, 57, 0, DateTimeKind.Local), d.TruncateToSeconds());
		}

		[TestMethod]
		public void DateTime_TruncateToSeconds_RemovesMilliseconds()
		{
			var d = new DateTime(2017, 05, 29, 13, 23, 57, 432, DateTimeKind.Local);
			Assert.AreEqual(new DateTime(2017, 05, 29, 13, 23, 57, 0, DateTimeKind.Local), d.TruncateToSeconds());
		}

		[TestMethod]
		public void DateTime_TruncateToMinutes_DoesNothingWhenSecondsAndMillsecondsZero()
		{
			var d = new DateTime(2017, 05, 29, 13, 23, 0, 0, DateTimeKind.Local);
			Assert.AreEqual(new DateTime(2017, 05, 29, 13, 23, 0, 0, DateTimeKind.Local), d.TruncateToMinutes());
		}

		[TestMethod]
		public void DateTime_TruncateToMinutes_RemovesSecondsAndMilliseconds()
		{
			var d = new DateTime(2017, 05, 29, 13, 23, 57, 432, DateTimeKind.Local);
			Assert.AreEqual(new DateTime(2017, 05, 29, 13, 23, 0, 0, DateTimeKind.Local), d.TruncateToMinutes());
		}

		[TestMethod]
		public void DateTime_TruncateToHours_DoesNothingWhenMinutesSecondsAndMillsecondsZero()
		{
			var d = new DateTime(2017, 05, 29, 13, 0, 0, 0, DateTimeKind.Local);
			Assert.AreEqual(new DateTime(2017, 05, 29, 13, 0, 0, 0, DateTimeKind.Local), d.TruncateToHours());
		}

		[TestMethod]
		public void DateTime_TruncateToMinutes_RemovesMinutesSecondsAndMilliseconds()
		{
			var d = new DateTime(2017, 05, 29, 13, 23, 57, 432, DateTimeKind.Local);
			Assert.AreEqual(new DateTime(2017, 05, 29, 13, 0, 0, 0, DateTimeKind.Local), d.TruncateToHours());
		}

		#endregion

	}
}