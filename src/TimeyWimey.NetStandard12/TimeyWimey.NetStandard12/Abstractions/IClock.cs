using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeyWimey.Abstractions
{
	/// <summary>
	/// Interface for components that can return the 'current time'. 
	/// </summary>
	/// <remarks>
	/// <para>By using an abstraction rather than directly accessing a method like <see cref="System.DateTime.Now"/> you can better implement date/time based tests. 
	/// You can also potentially change implementations between a regular system clock, an NTP adjusted, a clock with a manual offset or a clock reduces allocations when the time is requested (see CachingClock).</para>
	/// </remarks>
	public interface IClock
	{
		/// <summary>
		/// Occurs when the clock has been adjusted or signficantly altered, such as when the user sets the time or the time is synced to a server, but not on regular 'ticks' of the clock.
		/// </summary>
		event EventHandler<EventArgs> Adjusted;

		/// <summary>
		/// Returns the current time as a <see cref="DateTimeOffset"/>.
		/// </summary>
		DateTimeOffset Now { get; }
	}
}