using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeyWimey.Tests
{
	[TestClass]
	public class TimeSpansTests
	{
		[TestMethod]
		public void EightHours_Returns8Hours()
		{
			Assert.AreEqual(8, TimeSpans.EightHours.TotalHours);
		}

		[TestMethod]
		public void EightMilliseconds_Returns8Milliseconds()
		{
			Assert.AreEqual(8, TimeSpans.EightMilliseconds.TotalMilliseconds);
		}

		[TestMethod]
		public void FifteenMilliseconds_Returns15Milliseconds()
		{
			Assert.AreEqual(15, TimeSpans.FifteenMilliseconds.TotalMilliseconds);
		}

		[TestMethod]
		public void FifteenMinutes_Returns15Minutes()
		{
			Assert.AreEqual(15, TimeSpans.FifteenMinutes.TotalMinutes);
		}

		[TestMethod]
		public void FifteenSeconds_Returns15Seconds()
		{
			Assert.AreEqual(15, TimeSpans.FifteenSeconds.TotalSeconds);
		}

		[TestMethod]
		public void FiveDays_Returns5Days()
		{
			Assert.AreEqual(5, TimeSpans.FiveDays.TotalDays);
		}

		[TestMethod]
		public void FiveHours_Returns5Hours()
		{
			Assert.AreEqual(5, TimeSpans.FiveHours.TotalHours);
		}

		[TestMethod]
		public void FiveHundredMillseconds_Returns500Milliseconds()
		{
			Assert.AreEqual(500, TimeSpans.FiveHundredMilliseconds.TotalMilliseconds);
		}

		[TestMethod]
		public void FiveMilliseconds_Returns5Milliseconds()
		{
			Assert.AreEqual(5, TimeSpans.FiveMilliseconds.TotalMilliseconds);
		}

		[TestMethod]
		public void FiveMinutes_Returns5Minutes()
		{
			Assert.AreEqual(5, TimeSpans.FiveMinutes.TotalMinutes);
		}

		[TestMethod]
		public void FiveSeconds_Returns5Seconds()
		{
			Assert.AreEqual(5, TimeSpans.FiveSeconds.TotalSeconds);
		}

		[TestMethod]
		public void FortyFiveMinutes_Returns45Minutes()
		{
			Assert.AreEqual(45, TimeSpans.FortyFiveMinutes.TotalMinutes);
		}

		[TestMethod]
		public void FortyFiveSeconds_Returns45Seconds()
		{
			Assert.AreEqual(45, TimeSpans.FortyFiveSeconds.TotalSeconds);
		}

		[TestMethod]
		public void FourteenDays_Returns14Days()
		{
			Assert.AreEqual(14, TimeSpans.FourteenDays.TotalDays);
		}

		[TestMethod]
		public void NinetyDays_Returns90Days()
		{
			Assert.AreEqual(90, TimeSpans.NinetyDays.TotalDays);
		}

		[TestMethod]
		public void OneDay_Returns1Day()
		{
			Assert.AreEqual(1, TimeSpans.OneDay.TotalDays);
		}

		[TestMethod]
		public void OneHour_Returns1Hour()
		{
			Assert.AreEqual(1, TimeSpans.OneHour.TotalHours);
		}

		[TestMethod]
		public void OneHundredAndTwentyDays_Returns120Days()
		{
			Assert.AreEqual(120, TimeSpans.OneHundredAndTwentyDays.TotalDays);
		}

		[TestMethod]
		public void OneHundredMilliseconds_Returns100Milliseconds()
		{
			Assert.AreEqual(100, TimeSpans.OneHundredMilliseconds.TotalMilliseconds);
		}

		[TestMethod]
		public void OneMillisecond_Returns1Millisecond()
		{
			Assert.AreEqual(1, TimeSpans.OneMillisecond.TotalMilliseconds);
		}

		[TestMethod]
		public void OneMinute_Returns1Minute()
		{
			Assert.AreEqual(1, TimeSpans.OneMinute.TotalMinutes);
		}

		[TestMethod]
		public void OneSecond_Returns1Seconds()
		{
			Assert.AreEqual(1, TimeSpans.OneSecond.TotalSeconds);
		}

		[TestMethod]
		public void SevenDays_Returns7Days()
		{
			Assert.AreEqual(7, TimeSpans.SevenDays.TotalDays);
		}

		[TestMethod]
		public void SixteenMilliseconds_Returns16Milliseconds()
		{
			Assert.AreEqual(16, TimeSpans.SixteenMilliseconds.TotalMilliseconds);
		}

		[TestMethod]
		public void SixtyDays_Returns60Days()
		{
			Assert.AreEqual(60, TimeSpans.SixtyDays.TotalDays);
		}

		[TestMethod]
		public void TenHours_Returns10Hours()
		{
			Assert.AreEqual(10, TimeSpans.TenHours.TotalHours);
		}

		[TestMethod]
		public void TenMilliseconds_Returns10Milliseconds()
		{
			Assert.AreEqual(10, TimeSpans.TenMilliseconds.TotalMilliseconds);
		}

		[TestMethod]
		public void TenMinutes_Returns10Minutes()
		{
			Assert.AreEqual(10, TimeSpans.TenMinutes.TotalMinutes);
		}

		[TestMethod]
		public void TenSeconds_Returns10Seconds()
		{
			Assert.AreEqual(10, TimeSpans.TenSeconds.TotalSeconds);
		}

		[TestMethod]
		public void ThirtyDays_Returns30Days()
		{
			Assert.AreEqual(30, TimeSpans.ThirtyDays.TotalDays);
		}

		[TestMethod]
		public void ThirtyMinutes_Returns30Minutes()
		{
			Assert.AreEqual(30, TimeSpans.ThirtyMinutes.TotalMinutes);
		}

		[TestMethod]
		public void ThirtyOneDays_Returns31Days()
		{
			Assert.AreEqual(31, TimeSpans.ThirtyOneDays.TotalDays);
		}

		[TestMethod]
		public void ThirtySeconds_Returns30Seconds()
		{
			Assert.AreEqual(30, TimeSpans.ThirtySeconds.TotalSeconds);
		}

		[TestMethod]
		public void ThreeDays_Returns3Days()
		{
			Assert.AreEqual(3, TimeSpans.ThreeDays.TotalDays);
		}

		[TestMethod]
		public void ThreeHours_Returns3Hours()
		{
			Assert.AreEqual(3, TimeSpans.ThreeHours.TotalHours);
		}

		[TestMethod]
		public void ThreeHundredAndSixtyFiveDays_Returns365Days()
		{
			Assert.AreEqual(365, TimeSpans.ThreeHundredAndSixtyFiveDays.TotalDays);
		}

		[TestMethod]
		public void ThreeMinutes_Returns3Minutes()
		{
			Assert.AreEqual(3, TimeSpans.ThreeMinutes.TotalMinutes);
		}

		[TestMethod]
		public void ThreeSeconds_Returns3Seconds()
		{
			Assert.AreEqual(3, TimeSpans.ThreeSeconds.TotalSeconds);
		}

		[TestMethod]
		public void TwelveHours_Returns12Hours()
		{
			Assert.AreEqual(12, TimeSpans.TwelveHours.TotalHours);
		}

		[TestMethod]
		public void TwentyFourHours_Returns24Hours()
		{
			Assert.AreEqual(24, TimeSpans.TwentyFourHours.TotalHours);
		}

		[TestMethod]
		public void TwentyMilliseconds_Returns20Milliseconds()
		{
			Assert.AreEqual(20, TimeSpans.TwentyMilliseconds.TotalMilliseconds);
		}

		[TestMethod]
		public void TwentyMinutes_Returns20Minutes()
		{
			Assert.AreEqual(20, TimeSpans.TwentyMinutes.TotalMinutes);
		}

		[TestMethod]
		public void TwentySeconds_Returns20Seconds()
		{
			Assert.AreEqual(20, TimeSpans.TwentySeconds.TotalSeconds);
		}

		[TestMethod]
		public void TwoDays_Returns2Days()
		{
			Assert.AreEqual(2, TimeSpans.TwoDays.TotalDays);
		}

		[TestMethod]
		public void TwoHours_Returns2Hours()
		{
			Assert.AreEqual(2, TimeSpans.TwoHours.TotalHours);
		}

		[TestMethod]
		public void TwoHundredAndFiftyMilliseconds_Returns250Milliseconds()
		{
			Assert.AreEqual(250, TimeSpans.TwoHundredAndFiftyMilliseconds.TotalMilliseconds);
		}

		[TestMethod]
		public void TwoMinutes_Returns2Minutes()
		{
			Assert.AreEqual(2, TimeSpans.TwoMinutes.TotalMinutes);
		}

		[TestMethod]
		public void TwoSeconds_Returns2Seconds()
		{
			Assert.AreEqual(2, TimeSpans.TwoSeconds.TotalSeconds);
		}

	}
}