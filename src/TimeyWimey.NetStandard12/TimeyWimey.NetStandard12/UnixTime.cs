using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeyWimey
{
	/// <summary>
	/// Contains common date and time related constants.
	/// </summary>
	public static class UnixTime
	{

		#region Epochs

		/// <summary>
		/// Returns a <see cref="DateTime"/> instance representing 1st Jan 1970, the Unix epoch.
		/// </summary>
		public static readonly DateTime UnixEpoch = new DateTime(1970, 01, 01);

		/// <summary>
		/// Returns a <see cref="DateTimeOffset"/> instance representing 1st Jan 1970, the Unix epoch.
		/// </summary>
		public static readonly DateTimeOffset UnixEpochDateTimeOffset = new DateTimeOffset(1970, 01, 01, 0, 0, 0, DateTimeOffset.Now.Offset);

		#endregion

		#region TimeStamp to Date Time Type

		/// <summary>
		/// Returns a new <see cref="DateTime"/> instance representing the date &amp; time the specified timestamp represents.
		/// </summary>
		/// <param name="timestamp">A double value that is a unix timestamp.</param>
		/// <returns>A <see cref="DateTime"/> that is equivalent to the provided timestamp.</returns>
		public static DateTime ToDateTime(this double timestamp)
		{
			return UnixTime.UnixEpoch.AddSeconds(timestamp);
		}

		/// <summary>
		/// Returns a new <see cref="DateTimeOffset"/> instance representing the date &amp; time the specified timestamp represents.
		/// </summary>
		/// <param name="timestamp">A double value that is a unix timestamp.</param>
		/// <returns>A <see cref="DateTimeOffset"/> that is equivalent to the provided timestamp.</returns>
		public static DateTimeOffset ToDateTimeOffset(this double timestamp)
		{
			return UnixTime.UnixEpochDateTimeOffset.AddSeconds(timestamp);
		}

		/// <summary>
		/// Returns a new <see cref="DateTime"/> instance representing the date &amp; time the specified timestamp represents.
		/// </summary>
		/// <param name="timestamp">A long value that is a unix timestamp.</param>
		/// <returns>A <see cref="DateTime"/> that is equivalent to the provided timestamp.</returns>
		public static DateTime ToDateTime(this long timestamp)
		{
			return UnixTime.UnixEpoch.AddSeconds(timestamp);
		}

		/// <summary>
		/// Returns a new <see cref="DateTimeOffset"/> instance representing the date &amp; time the specified timestamp represents.
		/// </summary>
		/// <param name="timestamp">A long value that is a unix timestamp.</param>
		/// <returns>A <see cref="DateTimeOffset"/> that is equivalent to the provided timestamp.</returns>
		public static DateTimeOffset ToDateTimeOffset(this long timestamp)
		{
			return UnixTime.UnixEpochDateTimeOffset.AddSeconds(timestamp);
		}

		#endregion

		#region ToUnixTimestamp

		/// <summary>
		/// Converts the specified date &amp; time into a double value that represents an equivalent Unix timestamp.
		/// </summary>
		/// <param name="value">The date &amp; time to calculate the Unix timestamp for.</param>
		/// <returns>A double containing the number of seconds since the Unix epoch.</returns>
		public static double ToUnixTimestamp(this DateTime value)
		{
			return value.Subtract(UnixTime.UnixEpoch).TotalSeconds;
		}

		/// <summary>
		/// Converts the specified <see cref="System.DateTimeOffset"/> into a double value that represents an equivalent Unix timestamp.
		/// </summary>
		/// <param name="value">The <see cref="System.DateTimeOffset"/> to calculate the Unix timestamp for.</param>
		/// <returns>A double containing the number of seconds since the Unix epoch.</returns>
		public static double ToUnixTimestamp(this DateTimeOffset value)
		{
			return value.Subtract(UnixTime.UnixEpoch).TotalSeconds;
		}

		#endregion

	}
}