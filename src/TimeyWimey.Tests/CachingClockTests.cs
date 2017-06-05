using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TimeyWimey.Abstractions;

namespace TimeyWimey.Tests
{
	[TestClass]
	public class CachingClockTests
	{

		[TestMethod]
		[ExpectedException(typeof(System.ArgumentNullException))]
		public void CachingClock_Constructor_ThrowsOnNullInnerClock()
		{
			var clock = new CachingClock(null);
		}

		[TestMethod]
		[ExpectedException(typeof(System.ArgumentOutOfRangeException))]
		public void CachingClock_Constructor_ThrowsOnNegativeCacheInterval()
		{
			var clock = new CachingClock(new SystemClock(), -1);
		}

		[TestMethod]
		public void CachingClock_Constructor_AllowsZeroCacheInterval()
		{
			var clock = new CachingClock(new SystemClock(), 0);
		}

		[TestMethod]
		public void CachingClock_CachesTime()
		{
			var clock = new CachingClock(new SystemClock());

			var time = clock.Now;
			System.Threading.Thread.Sleep(16);
			var time2 = clock.Now;

			Assert.AreEqual(time, time2);
		}

		[TestMethod]
		public void CachingClock_RefreshesCachedTime()
		{
			var clock = new CachingClock(new SystemClock());

			var time = clock.Now;
			System.Threading.Thread.Sleep(1001);
			var time2 = clock.Now;

			Assert.AreNotEqual(time, time2);
		}

		[TestMethod]
		public void CachingClock_UsesCacheInterval()
		{
			var clock = new CachingClock(new SystemClock(), 2000);

			var time = clock.Now;
			System.Threading.Thread.Sleep(1000);
			var time2 = clock.Now;
			System.Threading.Thread.Sleep(1001);
			var time3 = clock.Now;

			Assert.AreEqual(time, time2);
			Assert.AreNotEqual(time, time3);
			Assert.AreNotEqual(time2, time3);
		}

		[TestMethod]
		public void CachingClock_DisposesInnerClock()
		{
			var innerClock = new DisposableMockClock();
			using (var clock = new CachingClock(innerClock, 2000))
			{
			}
			Assert.IsTrue(innerClock.IsDisposed);
		}

		[TestMethod]
		public void CachingClock_BubblesAdjustedEvent()
		{
			bool eventRaised = false;
			var innerClock = new DisposableMockClock();
			using (var signal = new ManualResetEvent(false))
			{
				using (var clock = new CachingClock(innerClock, 2000))
				{
					clock.Adjusted += (s, e) =>
					{
						eventRaised = true;
						signal.Set();
					};

					innerClock.RaisesAdjustedEvent();
					signal.WaitOne(1000);
				}
			}
			Assert.IsTrue(eventRaised);
		}

	}

	public class DisposableMockClock : ClockBase, IDisposable
	{
		private bool _IsDisposed;

		public override DateTimeOffset Now => DateTimeOffset.Now;

		public void RaisesAdjustedEvent()
		{
			base.OnAdjusted();
		}

		public void Dispose()
		{
			_IsDisposed = true;
		}

		public bool IsDisposed
		{
			get { return _IsDisposed; }
		}
	}
}