using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeyWimey
{
	/// <summary>
	/// Represents a span of time between specified by a start and end date.
	/// </summary>
	/// <remarks>
	/// <para>DateTimeRange instances are compared and sorted by their <see cref="Start"/> property, if the values are equal then they are compared by their <see cref="End"/> property. Values with the same start and end values are equal.</para>
	/// </remarks>
	public struct DateTimeRange : IEquatable<DateTimeRange>, IComparable<DateTimeRange>
	{

		#region Fields

		private DateTime _Start;
		private DateTime _End;
		private TimeSpan _Length;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new <see cref="DateTimeRange"/> instance from two <see cref="DateTime"/> values.
		/// </summary>
		/// <remarks>
		/// <para>The <paramref name="start"/> must be less than or equal to <paramref name="end"/>, otherwise an <see cref="ArgumentException"/> will be thrown. To create an instance without worrying about the order of the date arguments, use <see cref="Create(DateTime, DateTime)"/>.</para>
		/// </remarks>
		/// <param name="start">The date and time at which this date range starts.</param>
		/// <param name="end">The date and time at which this date range ends.</param>
		public DateTimeRange(DateTime start, DateTime end)
		{
			if (end < start) throw new ArgumentException(nameof(end) + " cannot be less than " + nameof(start), nameof(end));

			_Start = start;
			_End = end;
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Returns the date and time this date range starts at.
		/// </summary>
		public DateTime Start { get { return _Start; } }

		/// <summary>
		/// Returns the date and time this date range ends at.
		/// </summary>
		public DateTime End { get { return _End; } }

		/// <summary>
		/// Returns the length of the range as a <see cref="System.TimeSpan"/> instance.
		/// </summary>
		public TimeSpan Length
		{
			get
			{
				if (_Length == TimeSpan.Zero)
					_Length = End.Subtract(Start);

				return _Length;
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Returns true if both the start and end properties of <paramref name="other"/> fall within this date range, or if <paramref name="other"/> is equal to this date range.
		/// </summary>
		/// <param name="other">Another <see cref="DateTimeRange"/> to compare to.</param>
		/// <returns>True if this range specified by this instance contains the range specified by <paramref name="other"/>.</returns>
		public bool Contains(DateTimeRange other)
		{
			return Start <= other.Start
				&& End >= other.End;
		}

		/// <summary>
		/// Returns true if the date and time specified by <paramref name="moment"/> falls within the range specified by this instance, otherwise false.
		/// </summary>
		/// <param name="moment">A <see cref="DateTime"/> instance to check.</param>
		/// <returns>True if the date and time specified by <paramref name="moment"/> falls within the range specified by this instance, otherwise false.</returns>
		public bool Contains(DateTime moment)
		{
			return Start <= moment
				&& End >= moment;
		}

		/// <summary>
		/// Returns true if any part of the range specified by this instance overlaps with the range specified by <paramref name="other"/>.
		/// </summary>
		/// <param name="other">Another <see cref="DateTimeRange"/> instance to compare to.</param>
		/// <returns>True if the ranges of the specified instances overlap, otherwise false.</returns>
		public bool Overlaps(DateTimeRange other)
		{
			return (Start >= other.Start && Start <= other.End)
				|| (other.Start >= Start && other.Start <= End)
				|| (End >= other.Start && End <= other.End)
				|| (other.Start >= End && other.End <= End);
		}

		/// <summary>
		/// Creates a new <see cref="DateTimeRange"/> instance from two dates, using the earliest date as the start value.
		/// </summary>
		/// <remarks>
		/// <para>This method is different to the <see cref="DateTimeRange(DateTime, DateTime)"/> constructor as it will not throw if <paramref name="dateTime1"/> is greater than <paramref name="dateTime2"/>.
		/// Instead, the earliest date is used for the <see cref="DateTimeRange.Start"/> and the later value for <see cref="DateTimeRange.End"/>.</para>
		/// </remarks>
		/// <param name="dateTime1">A <see cref="DateTime"/> instance to use for the <see cref="DateTimeRange"/>.</param>
		/// <param name="dateTime2">A <see cref="DateTime"/> instance to use for the <see cref="DateTimeRange"/>.</param>
		/// <returns>A new <see cref="DateTimeRange"/> using the two <see cref="System.DateTime"/> values provided.</returns>
		public static DateTimeRange Create(DateTime dateTime1, DateTime dateTime2)
		{
			if (dateTime1 <= dateTime2)
				return new DateTimeRange(dateTime1, dateTime2);

			return new DateTimeRange(dateTime2, dateTime1);
		}

		/// <summary>
		/// Creates a new <see cref="DateTimeRange"/> instance using the <see cref="Start"/> value of this instance and a new value for <see cref="End"/>.
		/// </summary>
		/// <param name="end">A <see cref="DateTime"/> to use as the <see cref="End"/> value for the new instance.</param>
		/// <returns>A new <see cref="DateTimeRange"/> instance.</returns>
		public DateTimeRange EndAt(DateTime end)
		{
			return new DateTimeRange(Start, end);
		}

		/// <summary>
		/// Creates a new <see cref="DateTimeRange"/> instance using the <see cref="End"/> value of this instance and a new value for <see cref="Start"/>.
		/// </summary>
		/// <param name="start">A <see cref="DateTime"/> to use as the <see cref="Start"/> value for the new instance.</param>
		/// <returns>A new <see cref="DateTimeRange"/> instance.</returns>
		public DateTimeRange StartAt(DateTime start)
		{
			return new DateTimeRange(start, End);
		}

		#endregion

		#region Overrides

		/// <summary>
		/// Returns a hash code based on the <see cref="Start"/> and <see cref="End"/> values.
		/// </summary>
		/// <returns>An integer containing the hashcode for this instance.</returns>
		public override int GetHashCode()
		{
			unchecked // Overflow is fine, we want it to wrap
			{
				int hash = 17;

				hash = hash * 23 + Start.GetHashCode();
				hash = hash * 23 + End.GetHashCode();

				return hash;
			}
		}

		/// <summary>
		/// Returns true if two instances are considered equal. Equality is checked by comparing the <see cref="Start"/> and <see cref="End"/> properties.
		/// </summary>
		/// <param name="obj">A value to compare this instance to. If the value is null or not another <see cref="DateTimeRange"/> the result will be false.</param>
		/// <returns>True if <paramref name="obj"/> is considered equal to this instance.</returns>
		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (!(obj is DateTimeRange)) return false;

			return Equals((DateTimeRange)obj);
		}

		#endregion

		#region IEquatable Members

		/// <summary>
		/// Returns true if two instances are considered equal. Equality is checked by comparing the <see cref="Start"/> and <see cref="End"/> properties.
		/// </summary>
		/// <param name="other">Another <see cref="DateTimeRange"/> to compare this instance to.</param>
		/// <returns>True if <paramref name="other"/> is considered equal to this instance.</returns>
		public bool Equals(DateTimeRange other)
		{
			return Start == other.Start
				&& End == other.End;
		}

		#endregion

		#region IComparable

		/// <summary>
		/// Compares this instance with another <see cref="DateTimeRange"/> instance. If the instances are equal, returns zero. If this instance is less than <paramref name="other"/> then -1 one is returned.
		/// If this instance is greater than <paramref name="other"/> then 1 one is returned.
		/// </summary>
		/// <remarks>
		/// <para>Comparions are performed first on the <see cref="Start"/> properties, if they are equal then a comparison is performed on the <see cref="End"/> properties.</para>
		/// </remarks>
		/// <param name="other">A <see cref="DateTimeRange"/> to compare to this instance.</param>
		/// <returns>An integer containing the result of the comparions. -1 for less than, 0 for equal, and 1 for greater than.</returns>
		public int CompareTo(DateTimeRange other)
		{
			if (other.Start == Start && other.End == End) return 0;

			var retVal = Start.CompareTo(other.Start);
			if (retVal == 0)
				retVal = End.CompareTo(other.End);

			return retVal;
		}

		#endregion

		#region Operator Overloads

		/// <summary>
		/// Peforms an equality check, equivalent to calling <see cref="Equals(DateTimeRange)"/>.
		/// </summary>
		/// <param name="range1">A <see cref="DateTimeRange"/> instance to compare.</param>
		/// <param name="range2">A <see cref="DateTimeRange"/> instance to compare.</param>
		/// <returns>True if the instances are considered equal.</returns>
		public static bool operator ==(DateTimeRange range1, DateTimeRange range2)
		{
			return range1.Equals(range2);
		}

		/// <summary>
		/// Peforms an inequality check, equivalent to calling !<see cref="Equals(DateTimeRange)"/>.
		/// </summary>
		/// <param name="range1">A <see cref="DateTimeRange"/> instance to compare.</param>
		/// <param name="range2">A <see cref="DateTimeRange"/> instance to compare.</param>
		/// <returns>True if the instances are considered unequal.</returns>
		public static bool operator !=(DateTimeRange range1, DateTimeRange range2)
		{
			return !range1.Equals(range2);
		}

		/// <summary>
		/// Peforms an comparison, equivalent to; <see cref="CompareTo(DateTimeRange)"/> &lt; 0.
		/// </summary>
		/// <param name="range1">A <see cref="DateTimeRange"/> instance to compare.</param>
		/// <param name="range2">A <see cref="DateTimeRange"/> instance to compare.</param>
		/// <returns>True if the <paramref name="range1"/> is considered less than <paramref name="range2"/>.</returns>
		public static bool operator < (DateTimeRange range1, DateTimeRange range2)
		{
			return range1.CompareTo(range2) < 0;
		}

		/// <summary>
		/// Peforms an comparison, equivalent to; <see cref="CompareTo(DateTimeRange)"/> &gt; 0.
		/// </summary>
		/// <param name="range1">A <see cref="DateTimeRange"/> instance to compare.</param>
		/// <param name="range2">A <see cref="DateTimeRange"/> instance to compare.</param>
		/// <returns>True if the <paramref name="range1"/> is considered greater than <paramref name="range2"/>.</returns>
		public static bool operator > (DateTimeRange range1, DateTimeRange range2)
		{
			return range1.CompareTo(range2) > 0;
		}

		#endregion

	}
}