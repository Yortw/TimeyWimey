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
	public class UnixTimestampTests
	{

		#region DateConstants.UnixEpoch Tests

		[TestMethod]
		public void Unixtime_Epoch_Is01011970()
		{
			Assert.AreEqual(new DateTime(1970, 01, 01), UnixTime.UnixEpoch);
		}

		[TestMethod]
		public void Unixtime_Epoch_IsSingleton()
		{
			var firstRequest = UnixTime.UnixEpoch;
			Assert.AreEqual((object)firstRequest, (object)UnixTime.UnixEpoch);
		}

		[TestMethod]
		public void Unixtime_EpochOffset_Is01011970()
		{
			Assert.AreEqual(new DateTime(1970, 01, 01, 00, 00, 00), UnixTime.UnixEpochDateTimeOffset.DateTime);
			Assert.AreEqual(new DateTimeOffset(1970, 01, 01, 00, 00, 00, new DateTimeOffset(UnixTime.UnixEpoch).Offset), UnixTime.UnixEpochDateTimeOffset);
		}

		[TestMethod]
		public void Unixtime_EpochOffset_IsSingleton()
		{
			var firstRequest = UnixTime.UnixEpochDateTimeOffset;
			Assert.AreEqual((object)firstRequest, (object)UnixTime.UnixEpochDateTimeOffset);
		}

		#endregion

		#region ToUnixTimestamp Tests

		[TestMethod]
		public void UnixTime_ToUnixTimestamp_DateTime()
		{
			var timestamp = DateTime.ParseExact("20/02/2017 10:39:10.500 PM", "dd/MM/yyyy hh:mm:ss.fff tt", null).ToUnixTimestamp();
			Assert.AreEqual(1487630350.500, timestamp);
			
		}

		[TestMethod]
		public void UnixTime_ToUnixTimestamp_DateTimeOffset()
		{
			var timestamp = DateTimeOffset.ParseExact("20/02/2017 10:39:10.500 PM", "dd/MM/yyyy hh:mm:ss.fff tt", null).ToUnixTimestamp();
			Assert.AreEqual(1487630350.500, timestamp);
		}

		#endregion

		#region From Timestamp Tests

		[TestMethod]
		public void UnixTime_ToDateTime_Double()
		{
			double timestamp = 1487630350.500;
			var time = UnixTime.ToDateTime(timestamp);
			Assert.AreEqual(DateTime.ParseExact("20/02/2017 10:39:10.500 PM", "dd/MM/yyyy hh:mm:ss.fff tt", null), time);
		}
	
		[TestMethod]
		public void UnixTime_ToDateTimeOffset_Double()
		{
			double timestamp = 1487630350.500;
			var time = UnixTime.ToDateTimeOffset(timestamp);
			Assert.AreEqual(DateTime.ParseExact("20/02/2017 10:39:10.500 PM", "dd/MM/yyyy hh:mm:ss.fff tt", null), time);
		}

		[TestMethod]
		public void UnixTime_ToDateTime_Long()
		{
			long timestamp = 1487630350;
			var time = UnixTime.ToDateTime(timestamp);
			Assert.AreEqual(DateTime.ParseExact("20/02/2017 10:39:10 PM", "dd/MM/yyyy hh:mm:ss tt", null), time);
		}

		[TestMethod]
		public void UnixTime_ToDateTimeOffset_Long()
		{
			long timestamp = 1487630350;
			var time = UnixTime.ToDateTimeOffset(timestamp);
			Assert.AreEqual(DateTimeOffset.ParseExact("20/02/2017 10:39:10 PM", "dd/MM/yyyy hh:mm:ss tt", null), time);
		}

		#endregion

	}
}