using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeyWimey.Abstractions
{
	/// <summary>
	/// Provides a <see cref="IClock"/> implementation that caches the result of another clock for short periods. 
	/// </summary>
	/// <remarks>
	/// <para>Some clock implementations may be allocation heavy or slow. Wrapping them in a caching clock can improve performance when finest precision is not required.</para>
	/// </remarks>
	/// <see cref="IClock"/>
	public class CachingClock : SystemClock, IDisposable
	{
		private IClock _InnerClock;
		private DateTimeOffset _CachedTime;
		private int _LastCheckedTimeMilliseconds;
		private int _CacheIntervalMilliseconds;

		/// <summary>
		/// Creates an instance wrapping the <see cref="IClock"/> instance specified by <paramref name="innerClock"/>.
		/// </summary>
		/// <remarks>
		/// <para>This constructor creates an instance where the current time is cached for at least one second between calls.</para>
		/// </remarks>
		/// <param name="innerClock">A <see cref="IClock"/> instance to use when updating the cached time.</param>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="innerClock"/> is null.</exception>
		public CachingClock(IClock innerClock) : this(innerClock, 1000)
		{
		}

		/// <summary>
		/// Creates an instance wrapping the <see cref="IClock"/> instance specified by <paramref name="innerClock"/>.
		/// </summary>
		/// <param name="innerClock">A <see cref="IClock"/> instance to use when updating the cached time.</param>
		/// <param name="cacheIntervalMilliseconds">The length of time, in milliseconds, to cache the time for. A value of zero is allowed and will effectively disable caching.</param>
		/// <exception cref="System.ArgumentNullException">Thrown if <paramref name="innerClock"/> is null.</exception>
		public CachingClock(IClock innerClock, int cacheIntervalMilliseconds) 
		{
			if (innerClock == null) throw new ArgumentNullException(nameof(innerClock));
			if (cacheIntervalMilliseconds < 0) throw new ArgumentOutOfRangeException(nameof(cacheIntervalMilliseconds));

			_CacheIntervalMilliseconds = cacheIntervalMilliseconds;
			_InnerClock = innerClock;
			_InnerClock.Adjusted += InnerClock_Adjusted;
		}

		/// <summary>
		/// Returns the current time from the wrapped clock, or a cached time if insufficient time has passed since the inner clock was last consulted.
		/// </summary>
		public override DateTimeOffset Now
		{
			get
			{
				// 'TickCount' actually returns milliseconds.
				if (Environment.TickCount - _LastCheckedTimeMilliseconds >= _CacheIntervalMilliseconds)
				{
					_CachedTime = _InnerClock.Now;
					_LastCheckedTimeMilliseconds = Environment.TickCount;
				}

				return _CachedTime;
			}
		}

		/// <summary>
		/// Disconnects this clock from the inner clock's <see cref="IClock.Adjusted"/> event.
		/// </summary>
		public void Dispose()
		{		
			try
			{
				Dispose(true);
			}
			finally
			{
				GC.SuppressFinalize(this);
			}
		}

		/// <summary>
		/// Disconnects this clock from the inner clock's <see cref="IClock.Adjusted"/> event.
		/// </summary>
		/// <param name="isDisposing">True if the instance is being explicitly disposed, otherwise false if it being disposed from a finalizer.</param>
		protected virtual void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				_InnerClock.Adjusted -= this.InnerClock_Adjusted;
			}
		}

		private void InnerClock_Adjusted(object sender, EventArgs e)
		{
			OnAdjusted();
		}
	}
}