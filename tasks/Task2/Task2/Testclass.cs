using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task3
{
    [TestFixture]
    class Test
    {
        [Test]
        public void Test_Mission_Name_has_Length_Zero()
        {
            Assert.Catch(() =>
                {
                    var x = new Task3.Mission("", 10);
                }
            );
        }
        [Test]
        public void Test_Mission_Name_is_null()
        {
            Assert.Catch(() =>
                {
                    var x = new Task3.Mission(null, 10);
                }
            );
        }
        [Test]
        public void Test_Mission_init_with_negative_Points()
        {
            Assert.Catch(() =>
                {
                    var x = new Task3.Mission("Missionstestname", -1);
                }
            );
        }
        [Test]
        public void Test_Mission_init_with_morethanmax_Points()
        {
            Assert.Catch(() =>
                { 
                    var x = new Task3.Mission("Missionstestname", 101);
                }
            );
        }
        [Test]
        public void Test_Mission_add_Points_to_over_max()
        {
            Assert.Catch(() =>
                {
                    var x = new Task3.Mission("Missionstestname", 99);
                    x.Points += 2;
                }
            );
        }
        [Test]
        public void Test_Mission_sub_Points_under_min()
        {
            Assert.Catch(() =>
                {
                    var x = new Task3.Mission("Missionstestname", 1);
                    x.Points -= 2;
                }
            );
        }
    }
}
