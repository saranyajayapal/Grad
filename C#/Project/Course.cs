using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass7
{
    public class Course
    {
        static int count = 0;
        public SortedList<string, int> CourseWrks;

        public Course()
        {
            count++;
            CourseWrks = new SortedList<string, int>();
            
        }

        public Course(Course C1)
        {
            //Copy COurse Wrks here
            CourseWrks = new SortedList<string, int>();
            foreach (KeyValuePair<string, int> kvp in C1.CourseWrks)
            {
                CourseWrks.Add(kvp.Key, 0);
            }
            //Assign COurne num
            CourseNum = C1.CourseNum;
            //Assign Course Grade
            CourseGrade = C1.CourseGrade;

        }

        public string CourseNum { get; set; }
        public string CourseGrade { get; set; }
        
    }
}

