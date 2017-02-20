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

	}
}