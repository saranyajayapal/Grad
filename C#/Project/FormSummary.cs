using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ass7
{
    public partial class FormSummary : Form
    {
        public List<Student> StudSummary { get; set; }
        public List<Course> CourseSmry { get; set; }
        string strMsg = "", strMsg1 = "";
        public FormSummary()
        {
            InitializeComponent();
        }

        public FormSummary(Object obj)
        {
            InitializeComponent();
        }
        private void FormSummary_Load(object sender, EventArgs e)
        {
            foreach (Course c in CourseSmry)
            {
                lstCourses.Items.Add(c.CourseNum);
            }
            foreach (Student t in StudSummary)
            {

                lstStudent.Items.Add(t.StuID);

            }
        }

        private void lstCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            strMsg = "";
            int ntotalStud = 0;
            foreach (Course c in CourseSmry)
            {
                if (lstCourses.SelectedIndex != -1)
                {
                    if (c.CourseNum == lstCourses.SelectedItem.ToString())
                    {
                        strMsg = "Course: " + "\t" + c.CourseNum + "\n" + "CourseWork: ";
                        foreach (KeyValuePair<string, int> kvp in c.CourseWrks)
                        {
                            strMsg += "\t" + kvp.Key;
                        }
                    }
                }
            }
            foreach(Student t in StudSummary)
            {
                foreach(Course c in t.CoursesEnrolled)
                {
                    if(c.CourseNum == lstCourses.SelectedItem.ToString())
                    {
                        ntotalStud++;
                    }
                }
            }
            strMsg += "\n"+"No. of Students: "+"\t" + ntotalStud;
            MessageBox.Show(strMsg);
        }

        private void lstStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            strMsg = "";
            strMsg1 = "";
            double GPA = 0.0;
            foreach (Student t in StudSummary)
            {
                if (lstStudent.SelectedIndex != -1)
                {
                    if (t.StuID == lstStudent.SelectedItem.ToString())
                    {
                        strMsg = "StudentID: " + t.StuID + "\n" + "Courses: ";
                        foreach (Course c in t.CoursesEnrolled)
                        {
                            strMsg1 += "\t" + c.CourseNum + "\t" + "Grade: " + c.CourseGrade + "\n";
                        }
                    }
                }
            }
            GPA = SemesterGPA();
            strMsg = strMsg + strMsg1 +"\n"+ "GPA: " + "\t" + GPA.ToString();
            MessageBox.Show(strMsg);
        }

        private double SemesterGPA()
        {
            double dPoint = 0.0, dTotal=0.0, SemesterGPA = 0.0;
            foreach (Student t in StudSummary)
            {
                if (lstStudent.SelectedIndex != -1)
                {
                    if (t.StuID == lstStudent.SelectedItem.ToString())
                    {
                        foreach (Course c in t.CoursesEnrolled)
                        {
                            if (c.CourseGrade == "A")
                                dPoint = 4.0 * 3;
                            if (c.CourseGrade == "B")
                                dPoint = 3.0 * 3;
                            if (c.CourseGrade == "C")
                                dPoint = 2.0 * 3;
                            if (c.CourseGrade == "D")
                                dPoint = 1.0 * 3;
                            if (c.CourseGrade == "F")
                                dPoint = 0.0 * 3;
                            dTotal = dTotal + dPoint;

                        }

                        SemesterGPA = dTotal / (3.0 * t.CoursesEnrolled.Count);
                    }
                }
            }
            return SemesterGPA;
        }

        private void FormSummary_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
