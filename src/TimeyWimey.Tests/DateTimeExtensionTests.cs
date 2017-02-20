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
	public class DateTimeExtensionTests
	{

		[TestMethod]
		public void DateTime_ChangeKind_ChangesKind()
		{
			var time = new DateTime(2016, 03, 17, 13, 0, 0, DateTimeKind.Unspecified);
			var utcExpected = new DateTime(2016, 03, 17, 13, 0, 0, DateTimeKind.Utc);
			var localExpected = new DateTime(2016, 03, 17, 13, 0, 0, DateTimeKind.Local);

			var actual = time.ChangeKind(DateTimeKind.Utc);
			Assert.AreEqual(utcExpected, actual);

			actual = time.ChangeKind(DateTimeKind.Local);
			Assert.AreEqual(localExpected, actual);
		}
	}
}