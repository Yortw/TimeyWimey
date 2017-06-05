using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeyWimey
{
	/// <summary>
	/// Provides access common time spans. Each time span is a single cached instance, reducing allocations.
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "TimeSpans", Justification="System.TimeSpan is cased this way, prefer this matches that casing even if it's wrong.")]
	public static class TimeSpans
	{

		#region Milliseconds

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing a single millsecond.
		/// </summary>
		public static readonly TimeSpan OneMillisecond = TimeSpan.FromMilliseconds(1);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing five millseconds.
		/// </summary>
		public static readonly TimeSpan FiveMilliseconds = TimeSpan.FromMilliseconds(5);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing eight millseconds.
		/// </summary>
		public static readonly TimeSpan EightMilliseconds = TimeSpan.FromMilliseconds(8);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing ten millseconds.
		/// </summary>
		public static readonly TimeSpan TenMilliseconds = TimeSpan.FromMilliseconds(10);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 15 millseconds.
		/// </summary>
		public static readonly TimeSpan FifteenMilliseconds = TimeSpan.FromMilliseconds(15);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 16 millseconds.
		/// </summary>
		public static readonly TimeSpan SixteenMilliseconds = TimeSpan.FromMilliseconds(16);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 20 millseconds.
		/// </summary>
		public static readonly TimeSpan TwentyMilliseconds = TimeSpan.FromMilliseconds(20);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 100 millseconds.
		/// </summary>
		public static readonly TimeSpan OneHundredMilliseconds = TimeSpan.FromMilliseconds(100);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 250 millseconds.
		/// </summary>
		public static readonly TimeSpan TwoHundredAndFiftyMilliseconds = TimeSpan.FromMilliseconds(250);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 500 millseconds.
		/// </summary>
		public static readonly TimeSpan FiveHundredMilliseconds = TimeSpan.FromMilliseconds(500);

		#endregion

		#region Seconds

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing a single second.
		/// </summary>
		public static readonly TimeSpan OneSecond = TimeSpan.FromSeconds(1);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing two seconds.
		/// </summary>
		public static readonly TimeSpan TwoSeconds = TimeSpan.FromSeconds(2);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing three seconds.
		/// </summary>
		public static readonly TimeSpan ThreeSeconds = TimeSpan.FromSeconds(3);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing five seconds.
		/// </summary>
		public static readonly TimeSpan FiveSeconds = TimeSpan.FromSeconds(5);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 10 seconds.
		/// </summary>
		public static readonly TimeSpan TenSeconds = TimeSpan.FromSeconds(10);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 15 seconds.
		/// </summary>
		public static readonly TimeSpan FifteenSeconds = TimeSpan.FromSeconds(15);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 20 seconds.
		/// </summary>
		public static readonly TimeSpan TwentySeconds = TimeSpan.FromSeconds(20);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 30 seconds.
		/// </summary>
		public static readonly TimeSpan ThirtySeconds = TimeSpan.FromSeconds(30);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 45 seconds.
		/// </summary>
		public static readonly TimeSpan FortyFiveSeconds = TimeSpan.FromSeconds(45);

		#endregion

		#region Minutes

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing a single minute.
		/// </summary>
		public static readonly TimeSpan OneMinute = TimeSpan.FromMinutes(1);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing two minutes.
		/// </summary>
		public static readonly TimeSpan TwoMinutes = TimeSpan.FromMinutes(2);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing three minutes.
		/// </summary>
		public static readonly TimeSpan ThreeMinutes = TimeSpan.FromMinutes(3);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing five minutes.
		/// </summary>
		public static readonly TimeSpan FiveMinutes = TimeSpan.FromMinutes(5);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 10 minutes.
		/// </summary>
		public static readonly TimeSpan TenMinutes = TimeSpan.FromMinutes(10);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 15 minutes.
		/// </summary>
		public static readonly TimeSpan FifteenMinutes = TimeSpan.FromMinutes(15);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 20 minutes.
		/// </summary>
		public static readonly TimeSpan TwentyMinutes = TimeSpan.FromMinutes(20);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 30 minutes.
		/// </summary>
		public static readonly TimeSpan ThirtyMinutes = TimeSpan.FromMinutes(30);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 45 minutes.
		/// </summary>
		public static readonly TimeSpan FortyFiveMinutes = TimeSpan.FromMinutes(45);

		#endregion

		#region Hours

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing a single hour.
		/// </summary>
		public static readonly TimeSpan OneHour = TimeSpan.FromHours(1);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing two hours.
		/// </summary>
		public static readonly TimeSpan TwoHours = TimeSpan.FromHours(2);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing three hours.
		/// </summary>
		public static readonly TimeSpan ThreeHours = TimeSpan.FromHours(3);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing five hours.
		/// </summary>
		public static readonly TimeSpan FiveHours = TimeSpan.FromHours(5);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing eight hours.
		/// </summary>
		public static readonly TimeSpan EightHours = TimeSpan.FromHours(8);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 10 hours.
		/// </summary>
		public static readonly TimeSpan TenHours = TimeSpan.FromHours(10);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 12 hours.
		/// </summary>
		public static readonly TimeSpan TwelveHours = TimeSpan.FromHours(12);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 24 hours.
		/// </summary>
		public static readonly TimeSpan TwentyFourHours = TimeSpan.FromHours(24);

		#endregion

		#region Days

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing a single day.
		/// </summary>
		public static readonly TimeSpan OneDay = TimeSpan.FromDays(1);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing two days.
		/// </summary>
		public static readonly TimeSpan TwoDays = TimeSpan.FromDays(2);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing three days.
		/// </summary>
		public static readonly TimeSpan ThreeDays = TimeSpan.FromDays(3);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing five days.
		/// </summary>
		public static readonly TimeSpan FiveDays = TimeSpan.FromDays(5);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing seven days.
		/// </summary>
		public static readonly TimeSpan SevenDays = TimeSpan.FromDays(7);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 14 hours.
		/// </summary>
		public static readonly TimeSpan FourteenDays = TimeSpan.FromDays(14);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 30 hours.
		/// </summary>
		public static readonly TimeSpan ThirtyDays = TimeSpan.FromDays(30);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 31 days.
		/// </summary>
		public static readonly TimeSpan ThirtyOneDays = TimeSpan.FromDays(31);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 60 days.
		/// </summary>
		public static readonly TimeSpan SixtyDays = TimeSpan.FromDays(60);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 90 days.
		/// </summary>
		public static readonly TimeSpan NinetyDays = TimeSpan.FromDays(90);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 120 days.
		/// </summary>
		public static readonly TimeSpan OneHundredAndTwentyDays = TimeSpan.FromDays(120);

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing 365 days.
		/// </summary>
		public static readonly TimeSpan ThreeHundredAndSixtyFiveDays = TimeSpan.FromDays(365);

		#endregion

	}
}