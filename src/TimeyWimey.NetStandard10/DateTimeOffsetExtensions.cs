using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeyWimey
{
	/// <summary>
	/// Extensions for the <see cref="DateTimeOffset"/> type.
	/// </summary>
	public static class DateTimeOffsetExtensions
	{

		#region IsFuture

		/// <summary>
		/// Returns true if <paramref name="time"/> references a time in the future.
		/// </summary>
		/// <remarks>
		/// <para>This compares <paramref name="time"/> to <see cref="System.DateTimeOffset.Now"/>.</para>
		/// </remarks>
		/// <param name="time">The <see cref="System.DateTimeOffset"/> to check.</param>
		/// <returns>True if the specified date and time is in the future, otherwise false.</returns>
		public static bool IsFuture(this DateTimeOffset time)
		{
			return time > DateTimeOffset.Now;
		}

		/// <summary>
		/// Returns true if <paramref name="time"/> references a time in the future.
		/// </summary>
		/// <remarks>
		/// <para>This compares <paramref name="time"/> to <see cref="System.DateTimeOffset.Now"/>.</para>
		/// </remarks>
		/// <param name="time">The <see cref="System.DateTimeOffset"/> to check.</param>
		/// <param name="clock">A <see cref="Abstractions.IClock"/> implementation used to obtain the current time.</param>
		/// <returns>True if the specified date and time is in the future, otherwise false.</returns>
		public static bool IsFuture(this DateTimeOffset time, Abstractions.IClock clock)
		{
			if (clock == null) throw new ArgumentNullException(nameof(clock));

			return time > clock.Now;
		}

		#endregion

		#region IsPast

		/// <summary>
		/// Returns true if <paramref name="time"/> references a time in the past.
		/// </summary>
		/// <remarks>
		/// <para>This compares <paramref name="time"/> to <see cref="System.DateTimeOffset.Now"/>.</para>
		/// </remarks>
		/// <param name="time">The <see cref="System.DateTimeOffset"/> to check.</param>
		/// <returns>True if the specified date and time is in the future, otherwise false.</returns>
		public static bool IsPast(this DateTimeOffset time)
		{
			return time < DateTimeOffset.Now;
		}

		/// <summary>
		/// Returns true if <paramref name="time"/> references a time in the past.
		/// </summary>
		/// <remarks>
		/// <para>This compares <paramref name="time"/> to <see cref="System.DateTimeOffset.Now"/>.</para>
		/// </remarks>
		/// <param name="time">The <see cref="System.DateTimeOffset"/> to check.</param>
		/// <param name="clock">A <see cref="Abstractions.IClock"/> implementation used to obtain the current time.</param>
		/// <returns>True if the specified date and time is in the future, otherwise false.</returns>
		public static bool IsPast(this DateTimeOffset time, Abstractions.IClock clock)
		{
			if (clock == null) throw new ArgumentNullException(nameof(clock));

			return time < clock.Now;
		}

		#endregion

		#region Truncation

		/// <summary>
		/// Returns a new <see cref="DateTimeOffset"/> value equivalent to the one provided but with a zero millsecond component.
		/// </summary>
		/// <param name="value">The <see cref="DateTimeOffset"/> value to truncate.</param>
		/// <returns>A new <see cref="DateTimeOffset"/> missing the millseconds component of <paramref name="value"/>.</returns>
		public static DateTimeOffset TruncateToSeconds(this DateTimeOffset value)
		{
			if (value.Millisecond == 0) return value;

			return value.Subtract(TimeSpan.FromMilliseconds(value.Millisecond));
		}

		/// <summary>
		/// Returns a new <see cref="DateTimeOffset"/> value equivalent to the one provided but with zero second and millsecond components.
		/// </summary>
		/// <param name="value">The <see cref="DateTimeOffset"/> value to truncate.</param>
		/// <returns>A new <see cref="DateTimeOffset"/> missing the seconds and millseconds components of <paramref name="value"/>.</returns>
		public static DateTimeOffset TruncateToMinutes(this DateTimeOffset value)
		{
			if (value.Second + value.Millisecond == 0) return value;

			return value.Subtract(TimeSpan.FromMilliseconds((value.Second * 1000) + value.Millisecond));
		}

		/// <summary>
		/// Returns a new <see cref="DateTimeOffset"/> value equivalent to the one provided but with zero minute, second, and millsecond components.
		/// </summary>
		/// <param name="value">The <see cref="DateTimeOffset"/> value to truncate.</param>
		/// <returns>A new <see cref="DateTimeOffset"/> missing the minutes, seconds and millseconds components of <paramref name="value"/>.</returns>
		public static DateTimeOffset TruncateToHours(this DateTimeOffset value)
		{
			if (value.Minute + value.Second + value.Millisecond == 0) return value;

			return value.Subtract(TimeSpan.FromMilliseconds((value.Minute * 60000) + (value.Second * 1000) + value.Millisecond));
		}

		#endregion

	}
}