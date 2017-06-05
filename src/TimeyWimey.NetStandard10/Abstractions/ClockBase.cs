using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeyWimey.Abstractions
{
	/// <summary>
	/// Base class for the <see cref="IClock"/> interface, providing some minimal reuse. Do not reference this class directly unless deriving your own clock type.
	/// </summary>
	/// <seealso cref="IClock"/>
	public abstract class ClockBase : IClock
	{
		/// <summary>
		/// Raised when a modification is made to clock time.
		/// </summary>
		/// <seealso cref="OnAdjusted"/>
		public event EventHandler<EventArgs> Adjusted;
		
		/// <summary>
		/// Returns the time as a <seealso cref="System.DateTimeOffset"/>.
		/// </summary>
		public abstract DateTimeOffset Now
		{
			get;
		}

		/// <summary>
		/// Raises the <see cref="Adjusted"/> event.
		/// </summary>
		/// <seealso cref="Adjusted"/>
		protected void OnAdjusted()
		{
			Adjusted?.Invoke(this, EventArgs.Empty);
		}
	}
}