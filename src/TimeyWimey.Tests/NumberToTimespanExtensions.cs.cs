using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeyWimey;

namespace TimeyWimey.Tests
{
	[TestClass]
	public class NumberToTimespanExtensions
	{

		#region Integer Tests

		[TestMethod]
		public void IntegerToMilliseconds_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1, 1.Milliseconds().TotalMilliseconds);
			Assert.AreEqual(4, 4.Milliseconds().TotalMilliseconds);
			Assert.AreEqual(10, 10.Milliseconds().TotalMilliseconds);

			Assert.AreEqual(-1, -1.Milliseconds().TotalMilliseconds);
			Assert.AreEqual(-4, -4.Milliseconds().TotalMilliseconds);
			Assert.AreEqual(-10, -10.Milliseconds().TotalMilliseconds);
		}

		[TestMethod]
		public void IntegerToSeconds_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1, 1.Seconds().TotalSeconds);
			Assert.AreEqual(4, 4.Seconds().TotalSeconds);
			Assert.AreEqual(10, 10.Seconds().TotalSeconds);

			Assert.AreEqual(-1, -1.Seconds().TotalSeconds);
			Assert.AreEqual(-4, -4.Seconds().TotalSeconds);
			Assert.AreEqual(-10, -10.Seconds().TotalSeconds);
		}

		[TestMethod]
		public void IntegerToMinutes_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1, 1.Minutes().TotalMinutes);
			Assert.AreEqual(4, 4.Minutes().TotalMinutes);
			Assert.AreEqual(10, 10.Minutes().TotalMinutes);

			Assert.AreEqual(-1, -1.Minutes().TotalMinutes);
			Assert.AreEqual(-4, -4.Minutes().TotalMinutes);
			Assert.AreEqual(-10, -10.Minutes().TotalMinutes);
		}

		[TestMethod]
		public void IntegerToHours_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1, 1.Hours().TotalHours);
			Assert.AreEqual(4, 4.Hours().TotalHours);
			Assert.AreEqual(10, 10.Hours().TotalHours);

			Assert.AreEqual(-1, -1.Hours().TotalHours);
			Assert.AreEqual(-4, -4.Hours().TotalHours);
			Assert.AreEqual(-10, -10.Hours().TotalHours);
		}

		[TestMethod]
		public void IntegerToDays_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1, 1.Days().TotalDays);
			Assert.AreEqual(4, 4.Days().TotalDays);
			Assert.AreEqual(10, 10.Days().TotalDays);

			Assert.AreEqual(-1, -1.Days().TotalDays);
			Assert.AreEqual(-4, -4.Days().TotalDays);
			Assert.AreEqual(-10, -10.Days().TotalDays);
		}

		#endregion

		#region Long Tests

		[TestMethod]
		public void LongToMilliseconds_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1L, 1L.Milliseconds().TotalMilliseconds);
			Assert.AreEqual(4L, 4L.Milliseconds().TotalMilliseconds);
			Assert.AreEqual(10L, 10L.Milliseconds().TotalMilliseconds);

			Assert.AreEqual(-1L, -1L.Milliseconds().TotalMilliseconds);
			Assert.AreEqual(-4L, -4L.Milliseconds().TotalMilliseconds);
			Assert.AreEqual(-10L, -10L.Milliseconds().TotalMilliseconds);
		}

		[TestMethod]
		public void LongToSeconds_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1L, 1L.Seconds().TotalSeconds);
			Assert.AreEqual(4L, 4L.Seconds().TotalSeconds);
			Assert.AreEqual(10L, 10L.Seconds().TotalSeconds);

			Assert.AreEqual(-1L, -1L.Seconds().TotalSeconds);
			Assert.AreEqual(-4L, -4L.Seconds().TotalSeconds);
			Assert.AreEqual(-10L, -10L.Seconds().TotalSeconds);
		}

		[TestMethod]
		public void LongToMinutes_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1L, 1L.Minutes().TotalMinutes);
			Assert.AreEqual(4L, 4L.Minutes().TotalMinutes);
			Assert.AreEqual(10L, 10L.Minutes().TotalMinutes);

			Assert.AreEqual(-1L, -1L.Minutes().TotalMinutes);
			Assert.AreEqual(-4L, -4L.Minutes().TotalMinutes);
			Assert.AreEqual(-10L, -10L.Minutes().TotalMinutes);
		}

		[TestMethod]
		public void LongToHours_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1L, 1L.Hours().TotalHours);
			Assert.AreEqual(4L, 4L.Hours().TotalHours);
			Assert.AreEqual(10L, 10L.Hours().TotalHours);

			Assert.AreEqual(-1L, -1L.Hours().TotalHours);
			Assert.AreEqual(-4L, -4L.Hours().TotalHours);
			Assert.AreEqual(-10L, -10L.Hours().TotalHours);
		}

		[TestMethod]
		public void LongToDays_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1L, 1L.Days().TotalDays);
			Assert.AreEqual(4L, 4L.Days().TotalDays);
			Assert.AreEqual(10L, 10L.Days().TotalDays);

			Assert.AreEqual(-1L, -1L.Days().TotalDays);
			Assert.AreEqual(-4L, -4L.Days().TotalDays);
			Assert.AreEqual(-10L, -10L.Days().TotalDays);
		}

		#endregion

		#region Double Tests

		[TestMethod]
		public void DoubleToMilliseconds_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1D, 1D.Milliseconds().TotalMilliseconds);
			Assert.AreEqual(4D, 4D.Milliseconds().TotalMilliseconds);
			Assert.AreEqual(10D, 10D.Milliseconds().TotalMilliseconds);

			Assert.AreEqual(-1D, -1D.Milliseconds().TotalMilliseconds);
			Assert.AreEqual(-4D, -4D.Milliseconds().TotalMilliseconds);
			Assert.AreEqual(-10D, -10D.Milliseconds().TotalMilliseconds);
		}

		[TestMethod]
		public void DoubleToSeconds_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1D, 1D.Seconds().TotalSeconds);
			Assert.AreEqual(4D, 4D.Seconds().TotalSeconds);
			Assert.AreEqual(10D, 10D.Seconds().TotalSeconds);

			Assert.AreEqual(-1D, -1D.Seconds().TotalSeconds);
			Assert.AreEqual(-4D, -4D.Seconds().TotalSeconds);
			Assert.AreEqual(-10D, -10D.Seconds().TotalSeconds);
		}

		[TestMethod]
		public void DoubleToMinutes_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1D, 1D.Minutes().TotalMinutes);
			Assert.AreEqual(4D, 4D.Minutes().TotalMinutes);
			Assert.AreEqual(10D, 10D.Minutes().TotalMinutes);

			Assert.AreEqual(-1D, -1D.Minutes().TotalMinutes);
			Assert.AreEqual(-4D, -4D.Minutes().TotalMinutes);
			Assert.AreEqual(-10D, -10D.Minutes().TotalMinutes);
		}

		[TestMethod]
		public void DoubleToHours_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1D, 1D.Hours().TotalHours);
			Assert.AreEqual(4D, 4D.Hours().TotalHours);
			Assert.AreEqual(10D, 10D.Hours().TotalHours);

			Assert.AreEqual(-1D, -1D.Hours().TotalHours);
			Assert.AreEqual(-4D, -4D.Hours().TotalHours);
			Assert.AreEqual(-10D, -10D.Hours().TotalHours);
		}

		[TestMethod]
		public void DoubleToDays_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1D, 1D.Days().TotalDays);
			Assert.AreEqual(4D, 4D.Days().TotalDays);
			Assert.AreEqual(10D, 10D.Days().TotalDays);

			Assert.AreEqual(-1D, -1D.Days().TotalDays);
			Assert.AreEqual(-4D, -4D.Days().TotalDays);
			Assert.AreEqual(-10D, -10D.Days().TotalDays);
		}

		#endregion

		#region Float Tests

		[TestMethod]
		public void FloatToMilliseconds_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1f, 1f.Milliseconds().TotalMilliseconds);
			Assert.AreEqual(4f, 4f.Milliseconds().TotalMilliseconds);
			Assert.AreEqual(10f, 10f.Milliseconds().TotalMilliseconds);

			Assert.AreEqual(-1f, -1f.Milliseconds().TotalMilliseconds);
			Assert.AreEqual(-4f, -4f.Milliseconds().TotalMilliseconds);
			Assert.AreEqual(-10f, -10f.Milliseconds().TotalMilliseconds);
		}

		[TestMethod]
		public void FloatToSeconds_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1f, 1f.Seconds().TotalSeconds);
			Assert.AreEqual(4f, 4f.Seconds().TotalSeconds);
			Assert.AreEqual(10f, 10f.Seconds().TotalSeconds);

			Assert.AreEqual(-1f, -1f.Seconds().TotalSeconds);
			Assert.AreEqual(-4f, -4f.Seconds().TotalSeconds);
			Assert.AreEqual(-10f, -10f.Seconds().TotalSeconds);
		}

		[TestMethod]
		public void FloatToMinutes_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1f, 1f.Minutes().TotalMinutes);
			Assert.AreEqual(4f, 4f.Minutes().TotalMinutes);
			Assert.AreEqual(10f, 10f.Minutes().TotalMinutes);

			Assert.AreEqual(-1f, -1f.Minutes().TotalMinutes);
			Assert.AreEqual(-4f, -4f.Minutes().TotalMinutes);
			Assert.AreEqual(-10f, -10f.Minutes().TotalMinutes);
		}

		[TestMethod]
		public void FloatToHours_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1f, 1f.Hours().TotalHours);
			Assert.AreEqual(4f, 4f.Hours().TotalHours);
			Assert.AreEqual(10f, 10f.Hours().TotalHours);

			Assert.AreEqual(-1f, -1f.Hours().TotalHours);
			Assert.AreEqual(-4f, -4f.Hours().TotalHours);
			Assert.AreEqual(-10f, -10f.Hours().TotalHours);
		}

		[TestMethod]
		public void FloatToDays_InitialisesTimeSpanCorrectly()
		{
			Assert.AreEqual(1f, 1D.Days().TotalDays);
			Assert.AreEqual(4f, 4D.Days().TotalDays);
			Assert.AreEqual(10f, 10D.Days().TotalDays);

			Assert.AreEqual(-1f, -1f.Days().TotalDays);
			Assert.AreEqual(-4f, -4f.Days().TotalDays);
			Assert.AreEqual(-10f, -10f.Days().TotalDays);
		}

		#endregion

	}
}