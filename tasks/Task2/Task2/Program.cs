using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using Statements
using static System.Console;
using NUnit;
using Newtonsoft.Json;
//using System.ComponentModel;
/* Task 2
 * Author : Rainhardt Gabriel
 * Version : 0-0-0
 * Date : 13-05-18
 */
namespace Task3
{
    interface Game
    {
       void ChangeState();
    }
    public class Mission : Game // consists of one or more Tasks
    {

        /******************************** Attributes/ Fields *****************************/
        // the missions name
        private string _name;
        // points for achieving missions goals
        private decimal _points;
        // current activation state of mission 
        private Boolean _isactive;
        /* counter to check if mission has been activated before 
         * a mission should only be set to active if there is no other mission available
         * with a counter less than the current selected one
         */
        private int _activationcount = 0;
        // probably need to add Placement on Map maybe with 3dVector Struct?
        // maybe we can also get the missionname out of the file, but I need to figure out how, so not implemented yet
        /********************************* Properties ************************************/
        public Boolean State => _isactive;
        public string Name => _name;
        public int CountActive => _activationcount;
        public void ChangeState()
        {
            //only count up if the mission was active and is set inactive now.
            _activationcount += _isactive ? 1 : 0;
            _isactive = !_isactive;
        }
        public decimal Points {
            get
            {
                 return _points;
            }
            set
            {
                _points = value;
                // check after adding if _points has fallen underneath the floor
                if (_points <= 0) throw new Exception("points have fallen under allowed minimum");
                if (_points >= 100) throw new Exception("points are above allowed max");
            }
        }
        /********************************* Construcor ************************************/

        public Mission(string missionname, decimal points)
        {
            //alle Daten überprüfen die eingegeben werden.
            if (missionname == null || missionname.Length == 0)
            {
                throw new Exception("missing missionname");
            }
            if (points <= 0)
            {
                throw new Exception("missions must contain points at initialisation");
            }
            // initialise to default
            _isactive = false;
            // initialise with params
            _name = missionname;
            // set _points to points
            Points = points;
        }

    }
    public class SideMission : Game
    {
        // Fields
        private Boolean _isactive = false;
        private string _name;
        private Mission parent;
        //Method
        public string Name => _name;
        public string Parent_name => parent.Name;
        public void ChangeState()
        {
            if (parent.State == true) {
                _isactive = true;
            } else {
                _isactive = false;
            };
        }
        // Constructor
        public SideMission(string Taskname, Mission parent)
        {
            if(Taskname == null || Taskname.Length == 0)
            {
                throw new Exception("missing Sidemission name");
            }
            if (parent == null) throw new Exception(" SideMission missing parent Mission");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WriteLine("Creating 1st Object");
                Mission one = new Mission("Trollolololo", 10);
                WriteLine("Creating 2nd Object");
                Mission two = new Mission("Trallalala", 30);
                WriteLine("Creating 3rd Object");
                Mission three = new Mission("Mimimimimimi", 20);
                WriteLine("Print initialised objects");
                //needs refactoring with foreach loop
                WriteLine("Missionsname :" + one.Name +     "\t active :" + one.State +   " \t points: " + one.Points + "\tcount of previous activations :" + one.CountActive);
                WriteLine("Missionsname :" + two.Name +     "\t active :" + two.State +   " \t points: " + two.Points + "\tcount of previous activations :" + two.CountActive);
                WriteLine("Missionsname :" + three.Name +   "\t active :" + three.State + " \t points: " + three.Points + "\tcount of previous activations :" + three.CountActive);
                WriteLine("Changing state of two  for the first time. Number of previous activations should be 0");
                two.ChangeState();
                WriteLine("Print two");
                WriteLine("Missionsname :" + two.Name + " \t active :" + two.State + " \t points: " + two.Points + "\tcount of previous activations :" + two.CountActive);
                WriteLine("Change state for 10 times. Number of previous activations should be 5.");
                for (var i = 0; i < 10; i++) {
                    two.ChangeState();
                    two.Points += 1;
                    WriteLine("missionsname :" + two.Name + " \t active :" + two.State + " \t points: " + two.Points + "\tcount of previous activations :" + two.CountActive);
                };
                WriteLine("And add a negative number to points of two");
                two.Points += -20;
                WriteLine("missionsname :" + two.Name + " \t active :" + two.State + " \t points: " + two.Points + "\tcount of previous activations :" + two.CountActive);
                WriteLine("Let points fall to 0 or below");
                two.Points += -20;
                //we should not get here
                WriteLine("missionsname :" + two.Name + " \t active :" + two.State + " \t points: " + two.Points + "\tcount of previous activations :" + two.CountActive);
            }
            catch (Exception e)
            {
                WriteLine("error : " + e.Message);
            }
        }
    }
}
