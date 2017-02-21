using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeyWimey.Abstractions
{
	/// <summary>
	/// A <see cref="IClock"/> implementation whose time is provided externally, allowing the returned time to be controlled during automated testing.
	/// </summary>
	/// <seealso cref="IClock"/>
	public class MockClock : ClockBase
	{
		private DateTimeOffset _Now;

		/// <summary>
		/// Sets the 
		/// </summary>
		/// <param name="time">The time to change the clock to.</param>
		/// <param name="raiseAdjustedEvent">Pass true to raise the <see cref="IClock.Adjusted"/> event after the time is changed, otherwise false.</param>
		public void SetTime(DateTimeOffset time, bool raiseAdjustedEvent)
		{
			_Now = time;
			if (raiseAdjustedEvent)
				OnAdjusted();
		}

		/// <summary>
		/// Returns the time last provided via <see cref="SetTime(DateTimeOffset, bool)"/>.
		/// </summary>
		public override DateTimeOffset Now
		{
			get
			{
				return _Now;
			}
		}
	}
}