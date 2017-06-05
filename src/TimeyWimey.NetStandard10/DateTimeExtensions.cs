using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeyWimey
{
	/// <summary>
	/// Extensions for the <see cref="DateTime"/> type.
	/// </summary>
	public static class DateTimeExtensions
	{

		/// <summary>
		/// Returns a <see cref="System.DateTime"/> instance with the <see cref="System.DateTime.Kind"/> property set to the specified value, but otherwise representing the same time as original.
		/// </summary>
		/// <remarks>
		/// <para>If the <paramref name="newKind"/> is the same as the kind property of <paramref name="value"/> then the value of <paramref name="value"/> is returned instead of a new instance.</para>
		/// <para>This method does NOT convert between timezones, if the datetime provided is 20/03/2016 13:00:00 then that will be the same value returned in the new instance, only the <see cref="System.DateTime.Kind"/> propery is changed.</para>
		/// </remarks>
		/// <param name="value">The <see cref="System.DateTime"/> to use as the basis for the new value.</param>
		/// <param name="newKind">The <see cref="System.DateTimeKind"/> value to use for the new instance.</param>
		/// <returns></returns>
		public static DateTime ChangeKind(this DateTime value, DateTimeKind newKind)
		{
			if (value.Kind == newKind) return value;

			return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, newKind);
		}


		#region IsFuture

		/// <summary>
		/// Returns true if <paramref name="time"/> references a time in the future.
		/// </summary>
		/// <remarks>
		/// <para>This compares <paramref name="time"/> to <see cref="System.DateTime.Now"/>.</para>
		/// </remarks>
		/// <param name="time">The <see cref="System.DateTime"/> to check.</param>
		/// <returns>True if the specified date and time is in the future, otherwise false.</returns>
		public static bool IsFuture(this DateTime time)
		{
			return time > DateTime.Now;
		}

		/// <summary>
		/// Returns true if <paramref name="time"/> references a time in the future.
		/// </summary>
		/// <remarks>
		/// <para>This compares <paramref name="time"/> to <see cref="System.DateTime.Now"/>.</para>
		/// </remarks>
		/// <param name="time">The <see cref="System.DateTime"/> to check.</param>
		/// <param name="clock">A <see cref="Abstractions.IClock"/> implementation used to obtain the current time.</param>
		/// <returns>True if the specified date and time is in the future, otherwise false.</returns>
		public static bool IsFuture(this DateTime time, Abstractions.IClock clock)
		{
			if (clock == null) throw new ArgumentNullException(nameof(clock));

			return time > clock.Now.DateTime;
		}

		#endregion

		#region IsPast

		/// <summary>
		/// Returns true if <paramref name="time"/> references a time in the past.
		/// </summary>
		/// <remarks>
		/// <para>This compares <paramref name="time"/> to <see cref="System.DateTime.Now"/>.</para>
		/// </remarks>
		/// <param name="time">The <see cref="System.DateTime"/> to check.</param>
		/// <returns>True if the specified date and time is in the future, otherwise false.</returns>
		public static bool IsPast(this DateTime time)
		{
			return time < DateTime.Now;
		}

		/// <summary>
		/// Returns true if <paramref name="time"/> references a time in the past.
		/// </summary>
		/// <remarks>
		/// <para>This compares <paramref name="time"/> to <see cref="System.DateTime.Now"/>.</para>
		/// </remarks>
		/// <param name="time">The <see cref="System.DateTime"/> to check.</param>
		/// <param name="clock">A <see cref="Abstractions.IClock"/> implementation used to obtain the current time.</param>
		/// <returns>True if the specified date and time is in the future, otherwise false.</returns>
		public static bool IsPast(this DateTime time, Abstractions.IClock clock)
		{
			if (clock == null) throw new ArgumentNullException(nameof(clock));

			return time < clock.Now.DateTime;
		}

		#endregion

		#region Truncation

		/// <summary>
		/// Returns a new <see cref="DateTime"/> value equivalent to the one provided but with a zero millsecond component.
		/// </summary>
		/// <param name="value">The <see cref="DateTime"/> value to truncate.</param>
		/// <returns>A new <see cref="DateTime"/> missing the millseconds component of <paramref name="value"/>.</returns>
		public static DateTime TruncateToSeconds(this DateTime value)
		{
			if (value.Millisecond == 0) return value;

			return value.Subtract(TimeSpan.FromMilliseconds(value.Millisecond));
		}

		/// <summary>
		/// Returns a new <see cref="DateTime"/> value equivalent to the one provided but with zero second and millsecond components.
		/// </summary>
		/// <param name="value">The <see cref="DateTime"/> value to truncate.</param>
		/// <returns>A new <see cref="DateTime"/> missing the seconds and millseconds components of <paramref name="value"/>.</returns>
		public static DateTime TruncateToMinutes(this DateTime value)
		{
			if (value.Second + value.Millisecond == 0) return value;

			return value.Subtract(TimeSpan.FromMilliseconds((value.Second * 1000) + value.Millisecond));
		}

		/// <summary>
		/// Returns a new <see cref="DateTime"/> value equivalent to the one provided but with zero minute, second, and millsecond components.
		/// </summary>
		/// <param name="value">The <see cref="DateTime"/> value to truncate.</param>
		/// <returns>A new <see cref="DateTime"/> missing the minutes, seconds and millseconds components of <paramref name="value"/>.</returns>
		public static DateTime TruncateToHours(this DateTime value)
		{
			if (value.Minute + value.Second + value.Millisecond == 0) return value;

			return value.Subtract(TimeSpan.FromMilliseconds((value.Minute * 60000) + (value.Second * 1000) + value.Millisecond));
		}

		#endregion

	}
}