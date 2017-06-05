using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeyWimey.Tests
{
	[TestClass]
	public class DateTimeRangeTests
	{

		#region Constructor Tests

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void DateTimeRange_Constructor_ThrowsOnToBeforeFrom()
		{
			var r = new DateTimeRange(DateTime.Now.Date.AddDays(1), DateTime.Now.Date);
		}

		[TestMethod]
		public void DateTimeRange_Constructor_ConstructsWithEqualFromAndTo()
		{
			var r = new DateTimeRange(DateTime.Now.Date, DateTime.Now.Date);
			Assert.AreEqual(DateTime.Now.Date, r.Start);
			Assert.AreEqual(DateTime.Now.Date, r.End);
		}

		[TestMethod]
		public void DateTimeRange_Constructor_ConstructsWithToAfterFrom()
		{
			var r = new DateTimeRange(DateTime.Now.Date, DateTime.Now.Date.AddDays(1));
			Assert.AreEqual(DateTime.Now.Date, r.Start);
			Assert.AreEqual(DateTime.Now.Date.AddDays(1), r.End);
		}

		#endregion

		#region Static Create Tests

		[TestMethod]
		public void DateTimeRange_Create_SwapsWhenToBeforeFrom()
		{
			var r = DateTimeRange.Create(DateTime.Now.Date.AddDays(1), DateTime.Now.Date);
			Assert.AreEqual(DateTime.Now.Date, r.Start);
			Assert.AreEqual(DateTime.Now.Date.AddDays(1), r.End);
		}

		[TestMethod]
		public void DateTimeRange_Create_ConstructsWhenFromAndToEqual()
		{
			var r = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			Assert.AreEqual(DateTime.Now.Date, r.Start);
			Assert.AreEqual(DateTime.Now.Date, r.End);
		}

		[TestMethod]
		public void DateTimeRange_Create_ConstructsWhenFromBeforeTo()
		{
			var r = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date.AddDays(1));
			Assert.AreEqual(DateTime.Now.Date, r.Start);
			Assert.AreEqual(DateTime.Now.Date.AddDays(1), r.End);
		}

		#endregion

		#region Static Start At Tests

		[TestMethod]
		public void DateTimeRange_StartAt_ChangesFrom()
		{
			var r = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			r = r.StartAt(DateTime.Now.Date.AddDays(-1));
			Assert.AreEqual(DateTime.Now.Date.AddDays(-1), r.Start);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void DateTimeRange_StartAt_ThrowsIfFromAfterTo()
		{
			var r = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			r.StartAt(DateTime.Now.Date.AddDays(1));
		}

		#endregion

		#region Static End At Tests

		[TestMethod]
		public void DateTimeRange_EndAt_ChangesTo()
		{
			var r = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			r = r.EndAt(DateTime.Now.Date.AddDays(1));
			Assert.AreEqual(DateTime.Now.Date.AddDays(1), r.End);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void DateTimeRange_EndAt_ThrowsIfStartToBeforeFrom()
		{
			var r = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			r.EndAt(DateTime.Now.Date.AddDays(-1));
		}

		#endregion

		#region Contains(DateTimeRange) Tests

		[TestMethod]
		public void DateTimeRange_Contains_ReturnsTrueWhenOtherInsideOuter()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date.AddDays(-1), DateTime.Now.Date.AddDays(1));
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			Assert.IsTrue(outer.Contains(inner));
		}

		[TestMethod]
		public void DateTimeRange_Contains_ReturnsTrueWhenOtherAndInsideEqual()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			Assert.IsTrue(outer.Contains(inner));
		}

		[TestMethod]
		public void DateTimeRange_Contains_ReturnsFalseWhenOtherNotInsideOuter()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date); 
			var inner = DateTimeRange.Create(DateTime.Now.Date.AddDays(-1), DateTime.Now.Date.AddDays(1));
			Assert.IsFalse(outer.Contains(inner));
		}

		[TestMethod]
		public void DateTimeRange_Contains_ReturnsFalseWhenNoOverlap()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			var inner = DateTimeRange.Create(UnixTime.UnixEpoch, UnixTime.UnixEpoch);
			Assert.IsFalse(outer.Contains(inner));
		}

		[TestMethod]
		public void DateTimeRange_Contains_ReturnsFalseWhenOverlappedButNotEncompassed()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			var inner = DateTimeRange.Create(DateTime.Now.Date.AddDays(-1), DateTime.Now.Date);
			Assert.IsFalse(outer.Contains(inner));
		}

		#endregion

		#region Contains(DateTime) Tests

		[TestMethod]
		public void DateTimeRange_Contains_TrueForContainedDateTime()
		{
			var r = new DateTimeRange(new DateTime(2017, 03, 1), new DateTime(2017, 03, 31));
			Assert.IsTrue(r.Contains(new DateTime(2017, 03, 10)));
		}

		[TestMethod]
		public void DateTimeRange_Contains_TrueForDateAndTimeEqualToStart()
		{
			var r = new DateTimeRange(new DateTime(2017, 03, 1), new DateTime(2017, 03, 31));
			Assert.IsTrue(r.Contains(new DateTime(2017, 03, 01)));
		}

		[TestMethod]
		public void DateTimeRange_Contains_TrueForDateAndTimeEqualToEnd()
		{
			var r = new DateTimeRange(new DateTime(2017, 03, 1), new DateTime(2017, 03, 31));
			Assert.IsTrue(r.Contains(new DateTime(2017, 03, 31)));
		}

		[TestMethod]
		public void DateTimeRange_Contains_FalseForContainedDateTime()
		{
			var r = new DateTimeRange(new DateTime(2017, 03, 1), new DateTime(2017, 03, 31));
			Assert.IsFalse(r.Contains(new DateTime(2017, 02, 10)));
		}

		#endregion

		#region Overlaps Tests

		[TestMethod]
		public void DateTimeRange_Overlaps_ReturnsTrueWhenInstancesAreEqual()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			Assert.IsTrue(outer.Overlaps(inner));
			Assert.IsTrue(inner.Overlaps(outer));
		}

		[TestMethod]
		public void DateTimeRange_Overlaps_ReturnsTrueWhenStartWithinOuter()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date.AddDays(1));
			var inner = DateTimeRange.Create(DateTime.Now.Date.AddHours(12), DateTime.Now.Date.AddDays(2));
			Assert.IsTrue(outer.Overlaps(inner));
			Assert.IsTrue(inner.Overlaps(outer));
		}

		[TestMethod]
		public void DateTimeRange_Overlaps_ReturnsTrueWhenEndWithinOuter()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date.AddDays(1));
			var inner = DateTimeRange.Create(DateTime.Now.Date.AddDays(-1), DateTime.Now.Date.AddHours(12));
			Assert.IsTrue(outer.Overlaps(inner));
			Assert.IsTrue(inner.Overlaps(outer));
		}

		[TestMethod]
		public void DateTimeRange_Overlaps_ReturnsFalseWhenInnerBeforeOuter()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			var inner = DateTimeRange.Create(DateTime.Now.Date.AddDays(-2), DateTime.Now.Date.AddDays(-1));
			Assert.IsFalse(outer.Overlaps(inner));
			Assert.IsFalse(inner.Overlaps(outer));
		}

		[TestMethod]
		public void DateTimeRange_Overlaps_ReturnsFalseWhenInnerAfterOuter()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			var inner = DateTimeRange.Create(DateTime.Now.Date.AddDays(1), DateTime.Now.Date.AddDays(2));
			Assert.IsFalse(outer.Overlaps(inner));
			Assert.IsFalse(inner.Overlaps(outer));
		}

		#endregion

		#region GetHashCode Tests		

		[TestMethod]
		public void DateTimeRange_GetHashCode_EquivalentInstancesGenerateSameCode()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			Assert.AreEqual(outer.GetHashCode(), inner.GetHashCode());
		}


		[TestMethod]
		public void DateTimeRange_GetHashCode_UnequalInstancesGenerateDifferentCode()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date.AddSeconds(1));
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			Assert.AreNotEqual(outer.GetHashCode(), inner.GetHashCode());
		}

		[TestMethod]
		public void DateTimeRange_GetHashCode_DoesNotOverflow()
		{
			var outer = DateTimeRange.Create(DateTime.MaxValue, DateTime.MaxValue);
			var inner = DateTimeRange.Create(DateTime.MaxValue, DateTime.MaxValue);
			Assert.AreEqual(outer.GetHashCode(), inner.GetHashCode());
		}

		#endregion

		#region Equality Tests

		#region Equals Tests		

		[TestMethod]
		public void DateTimeRange_Equals_EquivalentInstancesAreEqual()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			Assert.IsTrue(outer.Equals((object)inner));
			Assert.IsTrue(inner.Equals((object)outer));
		}

		[TestMethod]
		public void DateTimeRange_Equals_UnequalInstancesAreNotEqual()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date.AddSeconds(1));
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			Assert.IsFalse(outer.Equals((object)inner));
			Assert.IsFalse(inner.Equals((object)outer));
		}

		[TestMethod]
		public void DateTimeRange_Equals_NullIsUnequal()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date.AddSeconds(1));
			Assert.IsFalse(outer.Equals(null));
		}

		[TestMethod]
		public void DateTimeRange_Equals_NonDateTimeRangeIsUnequal()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date.AddSeconds(1));
			Assert.IsFalse(outer.Equals(new object()));
		}

		#endregion

		#region IEquatable<T>.Equals Tests		

		[TestMethod]
		public void DateTimeRange_IEquatableEquals_EquivalentInstancesAreEquivalent()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			Assert.IsTrue(((IEquatable<DateTimeRange>)outer).Equals(inner));
			Assert.IsTrue(((IEquatable<DateTimeRange>)inner).Equals(outer));
		}

		[TestMethod]
		public void DateTimeRange_IEquatableEquals_UnequalWhenToDifferent()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date.AddSeconds(1));
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			Assert.IsFalse(((IEquatable<DateTimeRange>)outer).Equals(inner));
			Assert.IsFalse(((IEquatable<DateTimeRange>)inner).Equals(outer));
		}

		[TestMethod]
		public void DateTimeRange_IEquatableEquals_UnequalWhenFromDifferent()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date.AddSeconds(1), DateTime.Now.Date);
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			Assert.IsFalse(((IEquatable<DateTimeRange>)outer).Equals(inner));
			Assert.IsFalse(((IEquatable<DateTimeRange>)inner).Equals(outer));
		}

		[TestMethod]
		public void DateTimeRange_IEquatableEquals_UnequalWhenFromAndToDifferent()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date.AddSeconds(1), DateTime.Now.Date.AddSeconds(1));
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			Assert.IsFalse(((IEquatable<DateTimeRange>)outer).Equals(inner));
			Assert.IsFalse(((IEquatable<DateTimeRange>)inner).Equals(outer));
		}

		#endregion

		#region EqualsOperator Tests

		[TestMethod]
		public void DateTimeRange_EqualsOperator_EquivalentInstancesAreEqual()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			Assert.IsTrue(outer == inner);
		}

		[TestMethod]
		public void DateTimeRange_EqualsOperator_UnequalInstancesReturnFalse()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date.AddSeconds(1));
			Assert.IsFalse(outer == inner);
		}

		#endregion

		#region NotEqualsOperator Tests

		[TestMethod]
		public void DateTimeRange_NotEqualsOperator_EquivalentInstancesReturnFalse()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			Assert.IsFalse(outer != inner);
		}

		[TestMethod]
		public void DateTimeRange_NotEqualsOperator_UnequalInstancesReturnTrue()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date.AddSeconds(1));
			Assert.IsTrue(outer != inner);
		}

		#endregion

		#endregion

		#region Comparison Tests

		#region CompareTo Tests		

		[TestMethod]
		public void DateTimeRange_CompareTo_ReturnsMinus1WithEarlierStart()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date.AddDays(-1), DateTime.Now.Date);
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			Assert.AreEqual(-1, outer.CompareTo(inner));
		}

		[TestMethod]
		public void DateTimeRange_CompareTo_ReturnsMinus1WithEarlierEnd()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date.AddDays(1));
			Assert.AreEqual(-1, outer.CompareTo(inner));
		}

		[TestMethod]
		public void DateTimeRange_CompareTo_Returns1WithLaterStart()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			var inner = DateTimeRange.Create(DateTime.Now.Date.AddDays(-1), DateTime.Now.Date);
			Assert.AreEqual(1, outer.CompareTo(inner));
		}

		[TestMethod]
		public void DateTimeRange_CompareTo_Returns1WithLaterEnd()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date.AddDays(1));
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			Assert.AreEqual(1, outer.CompareTo(inner));
		}

		[TestMethod]
		public void DateTimeRange_CompareTo_Returns0WhenEqual()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			Assert.AreEqual(0, outer.CompareTo(inner));
		}


		#endregion

		#region LessThan Operator

		[TestMethod]
		public void DateTimeRange_LessThanOperator_ReturnsTrueWithEarlierStart()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date.AddDays(-1), DateTime.Now.Date);
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			Assert.IsTrue(outer < inner);
		}

		[TestMethod]
		public void DateTimeRange_LessThanOperator_ReturnsTrueWithEarlierEnd()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date.AddDays(1));
			Assert.IsTrue(outer < inner);
		}

		#endregion

		#region GreaterThan Operator

		[TestMethod]
		public void DateTimeRange_GreaterThan_ReturnsTrueWithLaterStart()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date.AddDays(1), DateTime.Now.Date);
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			Assert.IsTrue(outer > inner);
		}

		[TestMethod]
		public void DateTimeRange_GreaterThan_ReturnsTrueWithLaterEnd()
		{
			var outer = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date.AddDays(1));
			var inner = DateTimeRange.Create(DateTime.Now.Date, DateTime.Now.Date);
			Assert.IsTrue(outer > inner);
		}

		#endregion

		#endregion

		#region Length Tests

		[TestMethod]
		public void DateTimeRange_Length_ReturnsZeroForSameStartAndEnd()
		{
			var r = new DateTimeRange(DateTime.Now.Date, DateTime.Now.Date);
			Assert.AreEqual(TimeSpan.Zero, r.Length);
		}

		[TestMethod]
		public void DateTimeRange_Length_ReturnsExpectedNonZeroLength()
		{
			var r = new DateTimeRange(DateTime.Now.Date, DateTime.Now.Date.AddDays(1));
			Assert.AreEqual(TimeSpan.FromDays(1), r.Length);
		}

		#endregion

	}
}