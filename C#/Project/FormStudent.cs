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
    public partial class FormStudent : Form
    {
        public FormStudent()
        {
            InitializeComponent();

        }

        List<Course> lstCourse = new List<Course>();
        List<Student> stud = new List<Student>();
        Student s1 = null;
        bool bNew = false;

        private void FormStudent_Load(object sender, EventArgs e)
        {
            lstCourse = (List<Course>)this.Tag;
            foreach(Course c in lstCourse)
            {
                lstAvailCourses.Items.Add(c.CourseNum);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (bNew)
            {

                s1.StuID = txtStudentID.Text;
                if (txtEarnedHours.Text != "")
                {
                    if (int.TryParse(txtEarnedHours.Text, out int resHrs))
                    {
                        s1.TotEarnHrs = resHrs;
                    }
                    else
                    {
                        MessageBox.Show("Must enter a integer value");
                        txtEarnedHours.Text = "";
                        txtEarnedHours.Select();
                    }
                }
            
                foreach (Course c in s1.CoursesEnrolled)
                {
                    if (lstSelCourses.SelectedIndex != -1)
                    {
                        if (c.CourseNum == lstSelCourses.SelectedItem.ToString()) // This can be not selected, but can update too
                        {
                            for (int i = 0; i < c.CourseWrks.Count; i++)
                            {

                                if (lstCourseWrk.SelectedIndex != -1)
                                {
                                    if (c.CourseWrks.Keys[i] == lstCourseWrk.SelectedItem.ToString())
                                    {
                                        string strCrsWrk = c.CourseWrks.Keys[i];
                                        if (int.TryParse(txtMarks.Text, out int resScores))
                                        {
                                            if (resScores >= 0 && resScores <= 100)
                                            {
                                                c.CourseWrks[strCrsWrk] = resScores;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Score must be between 0 and 100");
                                                txtMarks.Text = "";
                                                txtMarks.Select();
                                            }
                                            
                                        }
                                        else
                                        {
                                            MessageBox.Show("Must enter an integer value between 0 and 100");
                                            txtMarks.Text = "";
                                            txtMarks.Select();
                                        }
                                    }
                                }
                            }
                            
                        }
                    }
                }

                stud.Add(s1);
                lstStudentID.Items.Add(s1.StuID);
                bNew = false;
            }
            else
            {
                foreach (Student ExStd in stud)
                {
                    if (ExStd.StuID == txtStudentID.Text)
                    {
                        foreach (Course c in ExStd.CoursesEnrolled)
                        {
                            if (lstSelCourses.SelectedIndex != -1)
                            {
                                if (c.CourseNum == lstSelCourses.SelectedItem.ToString()) // This can be not selected, but can update too
                                {
                                    for (int i = 0; i < c.CourseWrks.Count; i++)
                                    {

                                        if (lstCourseWrk.SelectedIndex != -1)
                                        {
                                            if (c.CourseWrks.Keys[i] == lstCourseWrk.SelectedItem.ToString())
                                            {
                                                string strCrsWrk = c.CourseWrks.Keys[i];
                                                if (int.TryParse(txtMarks.Text, out int resScores))
                                                {
                                                    if (resScores >= 0 && resScores <= 100)
                                                    {
                                                        c.CourseWrks[strCrsWrk] = resScores;
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Score must be between 0 and 100");
                                                        txtMarks.Text = "";
                                                        txtMarks.Select();
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Must enter an integer value between 0 and 100");
                                                    txtMarks.Text = "";
                                                    txtMarks.Select();
                                                }
                                            }
                                        }
                                    }
                                   
                                }
                            }
                        }
                    }
                }
            }
            
            UpdateCourseGrade();
            txtStudentID.Text = "";
            txtEarnedHours.Text = "";
            lstSelCourses.Items.Clear();
            lstCourseWrk.Items.Clear();
            txtMarks.Text = "";
            lstAvailCourses.ClearSelected();
            lstStudentID.ClearSelected();
            lstSelCourses.ClearSelected();
            lblGrade.Text = "Course Grade: ";
        }

        private void btnUpdScore_Click(object sender, EventArgs e)
        {

            if (bNew)
            {
                for (int i = 0; i < s1.CoursesEnrolled.Count; i++)
                {
                    if (lstSelCourses.SelectedIndex != -1)
                    {
                        if (s1.CoursesEnrolled[i].CourseNum == lstSelCourses.SelectedItem.ToString())
                        {
                            for (int j = 0; j < s1.CoursesEnrolled[i].CourseWrks.Count; j++)
                            {
                                if (lstCourseWrk.SelectedIndex != -1)
                                {
                                    if (s1.CoursesEnrolled[i].CourseWrks.Keys[j] == lstCourseWrk.SelectedItem.ToString())
                                    {
                                        string strCrsWrk = s1.CoursesEnrolled[i].CourseWrks.Keys[j];
                                        if (int.TryParse(txtMarks.Text, out int resScores))
                                        {
                                            if (resScores >= 0 && resScores <= 100)
                                            {
                                                s1.CoursesEnrolled[i].CourseWrks[strCrsWrk] = resScores;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Score must be between 0 and 100");
                                                txtMarks.Text = "";
                                                txtMarks.Select();
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Must enter an integer value between 0 and 100");
                                            txtMarks.Text = "";
                                            txtMarks.Select();
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please select a course work");
                                    txtMarks.Text = "";   
                                }

                            }
                        }
                    }
                }
            }
            else
            {
                foreach (Student ExStd in stud)
                {
                    if (ExStd.StuID == txtStudentID.Text)
                    {
                        for (int i = 0; i < ExStd.CoursesEnrolled.Count; i++)
                        {
                            if (ExStd.CoursesEnrolled[i].CourseNum == lstSelCourses.SelectedItem.ToString())
                            {
                                for (int j = 0; j < ExStd.CoursesEnrolled[i].CourseWrks.Count; j++)
                                {
                                    if (lstCourseWrk.SelectedIndex != -1)
                                    {
                                        if (ExStd.CoursesEnrolled[i].CourseWrks.Keys[j] == lstCourseWrk.SelectedItem.ToString())
                                        {
                                            string strCrsWrk = ExStd.CoursesEnrolled[i].CourseWrks.Keys[j];
                                            if (int.TryParse(txtMarks.Text, out int resScores))
                                            {

                                                if (resScores >= 0 && resScores <= 100)
                                                {
                                                    ExStd.CoursesEnrolled[i].CourseWrks[strCrsWrk] = resScores;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Score must be between 0 and 100");
                                                    txtMarks.Text = "";
                                                    txtMarks.Select();
                                                }
                                            }

                                            else
                                            {
                                                MessageBox.Show("Must enter an integer value between 0 and 100");
                                                txtMarks.Text = "";
                                                txtMarks.Select();
                                            }
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("Please select a course work");
                                        txtMarks.Text = "";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
            UpdateCourseGrade();
        }

        public void UpdateCourseGrade()
        {
            int nCoursetotal = 0, nTotalWrks = 0;
            double CrsGrade = 0.0;
            string strGrade = "";
            if (bNew)
            {
                foreach (Course c in s1.CoursesEnrolled)
                {
                    if (lstSelCourses.SelectedIndex != -1)
                    {
                        if (c.CourseNum == lstSelCourses.SelectedItem.ToString())
                        {
                            foreach (KeyValuePair<string, int> kvp in c.CourseWrks)
                            {
                                if (kvp.Value != 0)
                                {
                                    nCoursetotal += kvp.Value;
                                    nTotalWrks++;
                                }
                            }

                            if (nCoursetotal > 0)
                            {
                                CrsGrade = (nCoursetotal / (nTotalWrks * 100.00)) * 100;
                                if (CrsGrade >= 90 && CrsGrade <= 100)
                                {
                                    strGrade = "A";
                                    lblGrade.Text = "Course Grade: A";
                                }
                                if (CrsGrade >= 80 && CrsGrade <= 89)
                                {
                                    strGrade = "B";
                                    lblGrade.Text = "Course Grade: B";
                                }
                                if (CrsGrade >= 70 && CrsGrade <= 79)
                                {
                                    strGrade = "C";
                                    lblGrade.Text = "Course Grade: C";
                                }
                                if (CrsGrade >= 60 && CrsGrade <= 69)
                                {
                                    strGrade = "D";
                                    lblGrade.Text = "Course Grade: D";
                                }
                                if (CrsGrade >= 0 && CrsGrade <= 59)
                                {
                                    strGrade = "F";
                                    lblGrade.Text = "Course Grade: F";
                                }
                            }
                            c.CourseGrade = strGrade;
                        }
                    }
                }
            }
            else
            {
                foreach (Student s in stud)
                {
                    if (txtStudentID.Text.ToString() == s.StuID)
                    {
                        foreach (Course c in s.CoursesEnrolled)
                        {
                            if (lstSelCourses.SelectedIndex != -1)
                            {
                                if (c.CourseNum == lstSelCourses.SelectedItem.ToString())
                                {
                                    foreach (KeyValuePair<string, int> kvp in c.CourseWrks)
                                    {
                                        if (kvp.Value != 0)
                                        {
                                            nCoursetotal += kvp.Value;
                                            nTotalWrks = nTotalWrks + 1;
                                        }
                                    }

                                    if (nCoursetotal > 0)
                                    {
                                        CrsGrade = (nCoursetotal / (nTotalWrks * 100.00)) * 100;
                                        if (CrsGrade >= 90 && CrsGrade <= 100)
                                        {
                                            strGrade = "A";
                                            lblGrade.Text = "Course Grade: A";
                                        }
                                        if (CrsGrade >= 80 && CrsGrade <= 89)
                                        {
                                            strGrade = "B";
                                            lblGrade.Text = "Course Grade: B";
                                        }
                                        if (CrsGrade >= 70 && CrsGrade <= 79)
                                        {
                                            strGrade = "C";
                                            lblGrade.Text = "Course Grade: C";
                                        }
                                        if (CrsGrade >= 60 && CrsGrade <= 69)
                                        {
                                            strGrade = "D";
                                            lblGrade.Text = "Course Grade: D";
                                        }
                                        if (CrsGrade >= 0 && CrsGrade <= 59)
                                        {
                                            strGrade = "F";
                                            lblGrade.Text = "Course Grade: F";
                                        }
                                    }
                                    c.CourseGrade = strGrade;
                                }
                            }
                        }
                    }
                }
            }
            
            
        }


        private void btnMoveright_Click(object sender, EventArgs e)
        {
            MoveAvailtoSel();
        }

        private void lstSelCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstCourseWrk.Items.Clear();
            txtMarks.Text = "";
            if (bNew)
            {
                foreach (Course c in s1.CoursesEnrolled)
                {
                    if (lstSelCourses.SelectedIndex != -1)
                    {
                        if (c.CourseNum == lstSelCourses.SelectedItem.ToString())
                        {
                            foreach (KeyValuePair<string, int> kvp in c.CourseWrks)
                            {
                                lstCourseWrk.Items.Add(kvp.Key);

                            }
                            lblGrade.Text = "Course Grade: " + c.CourseGrade;
                        }
                    }
                }
            }
            else
            {
                foreach (Student s in stud)
                {
                    if (txtStudentID.Text.ToString() == s.StuID)
                    {
                        foreach (Course c in s.CoursesEnrolled)
                        {
                            if (lstSelCourses.SelectedIndex != -1)
                            {
                                if (c.CourseNum == lstSelCourses.SelectedItem.ToString())
                                {
                                    foreach (KeyValuePair<string, int> kvp in c.CourseWrks)
                                    {
                                        lstCourseWrk.Items.Add(kvp.Key);

                                    }
                                    lblGrade.Text = "Course Grade: " + c.CourseGrade;
                                }
                            }
                        }
                    }
                }
            }
            
        }
        
        private void lstCourseWrk_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMarks.Select();


            if (bNew)
            {
                foreach (Course c in s1.CoursesEnrolled)
                {
                    if (lstSelCourses.SelectedIndex != -1)
                    {
                        if (c.CourseNum == lstSelCourses.SelectedItem.ToString())
                        {
                            foreach (KeyValuePair<string, int> kvp in c.CourseWrks)
                            {
                                if (kvp.Key == lstCourseWrk.SelectedItem.ToString())
                                {
                                    txtMarks.Text = kvp.Value.ToString();
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (lstStudentID.SelectedIndex != -1)
                {
                    foreach (Student t in stud)
                    {
                        if (t.StuID == lstStudentID.SelectedItem.ToString())
                        {
                            for (int i = 0; i < t.CoursesEnrolled.Count; i++)
                            {
                                if (t.CoursesEnrolled[i].CourseNum == lstSelCourses.SelectedItem.ToString())
                                {
                                    foreach (KeyValuePair<string, int> kvp in t.CoursesEnrolled[i].CourseWrks)
                                    {
                                        if (lstCourseWrk.SelectedItem.ToString() == kvp.Key)
                                        {
                                            txtMarks.Text = kvp.Value.ToString();
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
            

        }

        private void lstStudentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstStudentID.SelectedIndex != -1)
            {
                lstAvailCourses.ClearSelected();
                lstSelCourses.Items.Clear();
                lstCourseWrk.Items.Clear();
                lblGrade.Text = "Course Grade: ";
                txtMarks.Text = "";
                bNew = false;

                foreach (Student t in stud)
                {
                
                    if (lstStudentID.SelectedItem.ToString() == t.StuID)
                    {
                        txtStudentID.Text = lstStudentID.SelectedItem.ToString();
                        txtEarnedHours.Text = t.TotEarnHrs.ToString();
                       foreach(Course c in t.CoursesEnrolled)
                        {
                            lstSelCourses.Items.Add(c.CourseNum);

                        }
                    }

                }
            }
        }

        private void btndelSel_Click(object sender, EventArgs e)
        {
            string crsNum = "";
            if (lstSelCourses.SelectedIndex != -1)
            {
                lstCourseWrk.Items.Clear();
                crsNum = lstSelCourses.SelectedItem.ToString();
                lstSelCourses.Items.RemoveAt(lstSelCourses.SelectedIndex);
                
                if (bNew)
                {
                    for (int i = 0; i < s1.CoursesEnrolled.Count; i++)
                    {
                        if (s1.CoursesEnrolled[i].CourseNum == crsNum)
                        {
                            s1.CoursesEnrolled.RemoveAt(i);
                        }
                    }
                }
                else
                {
                    foreach (Student t in stud)
                    {
                        if (lstStudentID.SelectedIndex != -1)
                        {
                            if (lstStudentID.SelectedItem.ToString() == t.StuID)
                            {
                                for (int i = 0; i < t.CoursesEnrolled.Count; i++)
                                {
                                    if (t.CoursesEnrolled[i].CourseNum == crsNum)
                                    {
                                        t.CoursesEnrolled.RemoveAt(i);
                                    }
                                }
                            }
                        }
                    }
                }

                lblGrade.Text = "";
            }
        }

       
        private void btndeleteStd_Click(object sender, EventArgs e)
        {
            if (lstStudentID.SelectedIndex != -1)
            {

                foreach (Student t in stud)
                {
                    string stdID = lstStudentID.SelectedItem.ToString();
                    if (stdID == t.StuID)
                    {
                        stud.Remove(t);
                        lstStudentID.Items.RemoveAt(lstStudentID.SelectedIndex);
                        txtStudentID.Text = "";
                        txtEarnedHours.Text = "";
                        lstSelCourses.Items.Clear();
                        lstCourseWrk.Items.Clear();
                        txtMarks.Text = "";
                        lstAvailCourses.ClearSelected();
                        lstStudentID.ClearSelected();
                        lstSelCourses.ClearSelected();
                        lblGrade.Text = "Course Grade: ";
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Select Student ID to delete");
            }
        }

        private void FormStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormSummary frmSmry = new FormSummary();
            frmSmry.StudSummary = stud;
            frmSmry.CourseSmry = lstCourse;
            frmSmry.ShowDialog();
        }

        private void lstAvailCourses_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MoveAvailtoSel();
        }

        private void MoveAvailtoSel()
        {
            if (lstAvailCourses.SelectedIndex != -1)
            {
                int iSelCourses = lstSelCourses.Items.Count;
                if (iSelCourses < 5)
                {
                    bool bexsitingCourse = false;
                    foreach (var listBoxItem in lstSelCourses.Items)
                    {
                        if (lstAvailCourses.SelectedItem.ToString() == listBoxItem.ToString())
                            bexsitingCourse = true;
                    }
                    if (!bexsitingCourse)
                    {
                        lstSelCourses.Items.Add(lstAvailCourses.SelectedItem);
                            foreach (Course c in lstCourse)
                            {
                                if (c.CourseNum == lstAvailCourses.SelectedItem.ToString())
                                {
                                    s1.CoursesEnrolled.Add(new Course( c ));
                                }
                            }
                    }
                    else
                        MessageBox.Show("Course already Selected");
                }
                else
                {
                    MessageBox.Show("Can add Max 5 Courses. Remove Existing Course to continue");
                }


            }
        }

        private void txtStudentID_Leave(object sender, EventArgs e)
        {
            if (txtStudentID.Text != "" && !lstStudentID.Items.Contains(txtStudentID.Text))
            {
                s1 = new Student();
                bNew = true;
                s1.StuID = txtStudentID.Text;
                txtEarnedHours.Text = "";
                lstSelCourses.Items.Clear();
                lstCourseWrk.Items.Clear();
                txtMarks.Text = "";
                lstAvailCourses.ClearSelected();
                lstStudentID.ClearSelected();
                lstSelCourses.ClearSelected();
                lblGrade.Text = "Course Grade: ";
            }
        }

        private void txtEarnedHours_Leave(object sender, EventArgs e)
        {
            if (txtEarnedHours.Text != "")
            {
                if (int.TryParse(txtEarnedHours.Text, out int resTot))
                {
                    if (s1 != null)
                    {
                        s1.TotEarnHrs = resTot;
                    }
                }
                else
                {
                    MessageBox.Show("Must enter a integer value");
                    txtEarnedHours.Text = "";
                    txtEarnedHours.Select();
                }
            }
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
