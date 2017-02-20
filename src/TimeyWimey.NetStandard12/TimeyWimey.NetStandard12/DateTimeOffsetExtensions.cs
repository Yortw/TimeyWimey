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

		/// <summary>
		/// Returns a new <see cref="DateTime"/> instance representing the date &amp; time the specified timestamp represents.
		/// </summary>
		/// <param name="timestamp">A double value that is a unix timestamp.</param>
		/// <returns>A <see cref="DateTime"/> that is equivalent to the provided timestamp.</returns>
		public static DateTime FromUnixTimestamp(this double timestamp)
		{
			return UnixTime.UnixEpoch.AddSeconds(timestamp);
		}

	}
}