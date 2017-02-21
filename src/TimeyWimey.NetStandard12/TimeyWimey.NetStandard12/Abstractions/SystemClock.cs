using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeyWimey.Abstractions
{
	/// <summary>
	/// A <see cref="IClock"/> based on the system hardware clock, via <see cref="System.DateTimeOffset.Now"/>.
	/// </summary>
	/// <remarks>
	/// <para>This implementation does NOT raise the <see cref="IClock.Adjusted"/> event, as Net Standard does not provide an event or notification of clock changes.</para>
	/// </remarks>
	public class SystemClock : ClockBase
	{
		/// <summary>
		/// Returns the current date and time according to the system clock (equivalent to <see cref="System.DateTimeOffset.Now"/>.
		/// </summary>
		public override DateTimeOffset Now
		{
			get
			{
				return System.DateTimeOffset.Now;
			}
		}
	}
}