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
    public partial class FormCourse : Form
    {
        //SortedList<string, string> CourseWrks = new SortedList<string, string>();
        List<Course> AllCourses = new List<Course>();
        Course c = null;

        public FormCourse()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnAddCrseWrk_Click(object sender, EventArgs e)
        {
            if (txtCNum.Text != "")
             {

                if (txtCWrk.Text != "")
                {
                    bool bExisting = false;
                    foreach (var item in lstCourseWrk.Items)
                    {
                        if (txtCWrk.Text == item.ToString())
                        {
                            bExisting = true;
                            lblMsg.Text = "Must enter a Unique name for Course work";
                            break;
                        }
                    }
                    if (!bExisting)
                    {
                        lstCourseWrk.Items.Add(txtCWrk.Text);
                        txtCWrk.Text = "";
                        txtCWrk.Focus();
                    }
                }
                else
                {
                    lblMsg.Text = "Must enter a value for CourseWorks";
                }
            }
            else{
                MessageBox.Show("Course Number cannot be Empty");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Course once saved cannot be updated again. Please make sure all course works are added", "Confirm", MessageBoxButtons.OKCancel);
            if (txtCNum.Text != "")
            {
                if (dialogResult == DialogResult.OK)
                {
                      c.CourseNum = txtCNum.Text;
                        if (lstCourseWrk.Items.Count > 0)
                        {
                            foreach (var item in lstCourseWrk.Items)
                            {
                                c.CourseWrks.Add(item.ToString(), 0);
                            }

                            txtCWrk.Text = "";
                            lstCourseWrk.Items.Clear();

                        }
                    }
                else
                    return;
            }
            else
            {
                MessageBox.Show("Must enter a Course Number");
            }
        
            txtCNum.Text = "";
            lblMsg.Text = "";
            AllCourses.Add(c);
        }

        private void FormCourse_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Hide();
            FormStudent frmStdnt = new FormStudent();
            frmStdnt.Tag = AllCourses;

            frmStdnt.ShowDialog();

        }

        private void btnStudForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCourseWrkRemove_Click(object sender, EventArgs e)
        {
            if (lstCourseWrk.SelectedIndex != -1)
            {
                lstCourseWrk.Items.RemoveAt(lstCourseWrk.SelectedIndex);
            }

        }

        private void txtCNum_Leave(object sender, EventArgs e)
        {
            if(txtCNum.Text != "")
            {
                foreach (Course ec in AllCourses)
                {
                    if (ec.CourseNum == txtCNum.Text)
                    {
                        MessageBox.Show("Course Number already exists. Enter a new value.");
                        txtCNum.Text = "";
                        txtCNum.Select();
                    }
                }
                c = new Course();
                c.CourseNum = txtCNum.Text;
            }
        }
    }
}

