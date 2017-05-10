using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeyWimey
{
	/// <summary>
	/// Provides extensions to numeric types (such as int, long, double) to convert to a <see cref="TimeSpan"/> value.
	/// </summary>
	public static class NumberToTimespanExtensions
	{

		#region Integer

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing the specified number of milliseconds.
		/// </summary>
		/// <param name="milliseconds">The number of milliseconds in the time span.</param>
		/// <returns>A <see cref="TimeSpan"/>.</returns>
		public static TimeSpan Milliseconds(this int milliseconds)
		{
			return TimeSpan.FromMilliseconds(milliseconds);
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing the specified number of seconds.
		/// </summary>
		/// <param name="seconds">The number of seconds in the time span.</param>
		/// <returns>A <see cref="TimeSpan"/>.</returns>
		public static TimeSpan Seconds(this int seconds)
		{
			return TimeSpan.FromSeconds(seconds);
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing the specified number of minutes.
		/// </summary>
		/// <param name="minutes">The number of minutes in the time span.</param>
		/// <returns>A <see cref="TimeSpan"/>.</returns>
		public static TimeSpan Minutes(this int minutes)
		{
			return TimeSpan.FromMinutes(minutes);
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing the specified number of hours.
		/// </summary>
		/// <param name="hours">The number of hours in the time span.</param>
		/// <returns>A <see cref="TimeSpan"/>.</returns>
		public static TimeSpan Hours(this int hours)
		{
			return TimeSpan.FromHours(hours);
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing the specified number of days.
		/// </summary>
		/// <param name="days">The number of days in the time span.</param>
		/// <returns>A <see cref="TimeSpan"/>.</returns>
		public static TimeSpan Days(this int days)
		{
			return TimeSpan.FromDays(days);
		}

		#endregion

		#region Long

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing the specified number of milliseconds.
		/// </summary>
		/// <param name="milliseconds">The number of milliseconds in the time span.</param>
		/// <returns>A <see cref="TimeSpan"/>.</returns>
		public static TimeSpan Milliseconds(this long milliseconds)
		{
			return TimeSpan.FromMilliseconds(milliseconds);
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing the specified number of seconds.
		/// </summary>
		/// <param name="seconds">The number of seconds in the time span.</param>
		/// <returns>A <see cref="TimeSpan"/>.</returns>
		public static TimeSpan Seconds(this long seconds)
		{
			return TimeSpan.FromSeconds(seconds);
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing the specified number of minutes.
		/// </summary>
		/// <param name="minutes">The number of minutes in the time span.</param>
		/// <returns>A <see cref="TimeSpan"/>.</returns>
		public static TimeSpan Minutes(this long minutes)
		{
			return TimeSpan.FromMinutes(minutes);
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing the specified number of hours.
		/// </summary>
		/// <param name="hours">The number of hours in the time span.</param>
		/// <returns>A <see cref="TimeSpan"/>.</returns>
		public static TimeSpan Hours(this long hours)
		{
			return TimeSpan.FromHours(hours);
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing the specified number of days.
		/// </summary>
		/// <param name="days">The number of days in the time span.</param>
		/// <returns>A <see cref="TimeSpan"/>.</returns>
		public static TimeSpan Days(this long days)
		{
			return TimeSpan.FromDays(days);
		}

		#endregion

		#region Double

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing the specified number of milliseconds.
		/// </summary>
		/// <param name="milliseconds">The number of milliseconds in the time span.</param>
		/// <returns>A <see cref="TimeSpan"/>.</returns>
		public static TimeSpan Milliseconds(this double milliseconds)
		{
			return TimeSpan.FromMilliseconds(milliseconds);
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing the specified number of seconds.
		/// </summary>
		/// <param name="seconds">The number of seconds in the time span.</param>
		/// <returns>A <see cref="TimeSpan"/>.</returns>
		public static TimeSpan Seconds(this double seconds)
		{
			return TimeSpan.FromSeconds(seconds);
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing the specified number of minutes.
		/// </summary>
		/// <param name="minutes">The number of minutes in the time span.</param>
		/// <returns>A <see cref="TimeSpan"/>.</returns>
		public static TimeSpan Minutes(this double minutes)
		{
			return TimeSpan.FromMinutes(minutes);
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing the specified number of hours.
		/// </summary>
		/// <param name="hours">The number of hours in the time span.</param>
		/// <returns>A <see cref="TimeSpan"/>.</returns>
		public static TimeSpan Hours(this double hours)
		{
			return TimeSpan.FromHours(hours);
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing the specified number of days.
		/// </summary>
		/// <param name="days">The number of days in the time span.</param>
		/// <returns>A <see cref="TimeSpan"/>.</returns>
		public static TimeSpan Days(this double days)
		{
			return TimeSpan.FromDays(days);
		}

		#endregion

		#region Float

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing the specified number of milliseconds.
		/// </summary>
		/// <param name="milliseconds">The number of milliseconds in the time span.</param>
		/// <returns>A <see cref="TimeSpan"/>.</returns>
		public static TimeSpan Milliseconds(this float milliseconds)
		{
			return TimeSpan.FromMilliseconds(milliseconds);
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing the specified number of seconds.
		/// </summary>
		/// <param name="seconds">The number of seconds in the time span.</param>
		/// <returns>A <see cref="TimeSpan"/>.</returns>
		public static TimeSpan Seconds(this float seconds)
		{
			return TimeSpan.FromSeconds(seconds);
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing the specified number of minutes.
		/// </summary>
		/// <param name="minutes">The number of minutes in the time span.</param>
		/// <returns>A <see cref="TimeSpan"/>.</returns>
		public static TimeSpan Minutes(this float minutes)
		{
			return TimeSpan.FromMinutes(minutes);
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing the specified number of hours.
		/// </summary>
		/// <param name="hours">The number of hours in the time span.</param>
		/// <returns>A <see cref="TimeSpan"/>.</returns>
		public static TimeSpan Hours(this float hours)
		{
			return TimeSpan.FromHours(hours);
		}

		/// <summary>
		/// Returns a <see cref="TimeSpan"/> representing the specified number of days.
		/// </summary>
		/// <param name="days">The number of days in the time span.</param>
		/// <returns>A <see cref="TimeSpan"/>.</returns>
		public static TimeSpan Days(this float days)
		{
			return TimeSpan.FromDays(days);
		}

		#endregion

	}
}