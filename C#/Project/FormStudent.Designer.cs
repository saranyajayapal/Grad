namespace Ass7
{
    partial class FormStudent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.lblEarnedHours = new System.Windows.Forms.Label();
            this.txtEarnedHours = new System.Windows.Forms.TextBox();
            this.lblAvailCourses = new System.Windows.Forms.Label();
            this.lstStudentID = new System.Windows.Forms.ListBox();
            this.lstSelCourses = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lstAvailCourses = new System.Windows.Forms.ListBox();
            this.btnMoveright = new System.Windows.Forms.Button();
            this.btndelSel = new System.Windows.Forms.Button();
            this.txtMarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstCourseWrk = new System.Windows.Forms.ListBox();
            this.lblSelCourses = new System.Windows.Forms.Label();
            this.lblCourseWrk = new System.Windows.Forms.Label();
            this.btnUpdScore = new System.Windows.Forms.Button();
            this.btndeleteStd = new System.Windows.Forms.Button();
            this.lblGrade = new System.Windows.Forms.Label();
            this.btnSummary = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(316, 50);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(182, 22);
            this.txtStudentID.TabIndex = 0;
            this.txtStudentID.Leave += new System.EventHandler(this.txtStudentID_Leave);
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(128, 50);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(74, 17);
            this.lblStudentID.TabIndex = 1;
            this.lblStudentID.Text = "Student ID";
            // 
            // lblEarnedHours
            // 
            this.lblEarnedHours.AutoSize = true;
            this.lblEarnedHours.Location = new System.Drawing.Point(128, 110);
            this.lblEarnedHours.Name = "lblEarnedHours";
            this.lblEarnedHours.Size = new System.Drawing.Size(132, 17);
            this.lblEarnedHours.TabIndex = 2;
            this.lblEarnedHours.Text = "Total Earned Hours";
            // 
            // txtEarnedHours
            // 
            this.txtEarnedHours.Location = new System.Drawing.Point(316, 107);
            this.txtEarnedHours.Name = "txtEarnedHours";
            this.txtEarnedHours.Size = new System.Drawing.Size(182, 22);
            this.txtEarnedHours.TabIndex = 3;
            this.txtEarnedHours.Leave += new System.EventHandler(this.txtEarnedHours_Leave);
            // 
            // lblAvailCourses
            // 
            this.lblAvailCourses.AutoSize = true;
            this.lblAvailCourses.Location = new System.Drawing.Point(72, 229);
            this.lblAvailCourses.Name = "lblAvailCourses";
            this.lblAvailCourses.Size = new System.Drawing.Size(121, 17);
            this.lblAvailCourses.TabIndex = 4;
            this.lblAvailCourses.Text = "Available Courses";
            // 
            // lstStudentID
            // 
            this.lstStudentID.FormattingEnabled = true;
            this.lstStudentID.ItemHeight = 16;
            this.lstStudentID.Location = new System.Drawing.Point(552, 12);
            this.lstStudentID.Name = "lstStudentID";
            this.lstStudentID.Size = new System.Drawing.Size(223, 180);
            this.lstStudentID.TabIndex = 8;
            this.lstStudentID.SelectedIndexChanged += new System.EventHandler(this.lstStudentID_SelectedIndexChanged);
            // 
            // lstSelCourses
            // 
            this.lstSelCourses.FormattingEnabled = true;
            this.lstSelCourses.ItemHeight = 16;
            this.lstSelCourses.Location = new System.Drawing.Point(295, 261);
            this.lstSelCourses.Name = "lstSelCourses";
            this.lstSelCourses.Size = new System.Drawing.Size(223, 180);
            this.lstSelCourses.TabIndex = 9;
            this.lstSelCourses.SelectedIndexChanged += new System.EventHandler(this.lstSelCourses_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(742, 448);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(177, 73);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Add / Update Student";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lstAvailCourses
            // 
            this.lstAvailCourses.FormattingEnabled = true;
            this.lstAvailCourses.ItemHeight = 16;
            this.lstAvailCourses.Location = new System.Drawing.Point(37, 260);
            this.lstAvailCourses.Name = "lstAvailCourses";
            this.lstAvailCourses.Size = new System.Drawing.Size(223, 180);
            this.lstAvailCourses.TabIndex = 12;
            this.lstAvailCourses.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstAvailCourses_MouseDoubleClick);
            // 
            // btnMoveright
            // 
            this.btnMoveright.AccessibleDescription = ">";
            this.btnMoveright.Location = new System.Drawing.Point(266, 334);
            this.btnMoveright.Name = "btnMoveright";
            this.btnMoveright.Size = new System.Drawing.Size(23, 27);
            this.btnMoveright.TabIndex = 13;
            this.btnMoveright.Text = ">";
            this.btnMoveright.UseVisualStyleBackColor = true;
            this.btnMoveright.Click += new System.EventHandler(this.btnMoveright_Click);
            // 
            // btndelSel
            // 
            this.btndelSel.AccessibleDescription = ">";
            this.btndelSel.Location = new System.Drawing.Point(325, 448);
            this.btndelSel.Name = "btndelSel";
            this.btndelSel.Size = new System.Drawing.Size(160, 38);
            this.btndelSel.TabIndex = 14;
            this.btndelSel.Text = "Remove Course";
            this.btndelSel.UseVisualStyleBackColor = true;
            this.btndelSel.Click += new System.EventHandler(this.btndelSel_Click);
            // 
            // txtMarks
            // 
            this.txtMarks.Location = new System.Drawing.Point(819, 336);
            this.txtMarks.Name = "txtMarks";
            this.txtMarks.Size = new System.Drawing.Size(100, 22);
            this.txtMarks.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(816, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Score";
            // 
            // lstCourseWrk
            // 
            this.lstCourseWrk.FormattingEnabled = true;
            this.lstCourseWrk.ItemHeight = 16;
            this.lstCourseWrk.Location = new System.Drawing.Point(559, 261);
            this.lstCourseWrk.Name = "lstCourseWrk";
            this.lstCourseWrk.Size = new System.Drawing.Size(216, 180);
            this.lstCourseWrk.TabIndex = 18;
            this.lstCourseWrk.SelectedIndexChanged += new System.EventHandler(this.lstCourseWrk_SelectedIndexChanged);
            // 
            // lblSelCourses
            // 
            this.lblSelCourses.AutoSize = true;
            this.lblSelCourses.Location = new System.Drawing.Point(340, 229);
            this.lblSelCourses.Name = "lblSelCourses";
            this.lblSelCourses.Size = new System.Drawing.Size(119, 17);
            this.lblSelCourses.TabIndex = 19;
            this.lblSelCourses.Text = "Selected Courses";
            // 
            // lblCourseWrk
            // 
            this.lblCourseWrk.AutoSize = true;
            this.lblCourseWrk.Location = new System.Drawing.Point(613, 229);
            this.lblCourseWrk.Name = "lblCourseWrk";
            this.lblCourseWrk.Size = new System.Drawing.Size(90, 17);
            this.lblCourseWrk.TabIndex = 20;
            this.lblCourseWrk.Text = "Course Work";
            // 
            // btnUpdScore
            // 
            this.btnUpdScore.Location = new System.Drawing.Point(819, 376);
            this.btnUpdScore.Name = "btnUpdScore";
            this.btnUpdScore.Size = new System.Drawing.Size(100, 49);
            this.btnUpdScore.TabIndex = 21;
            this.btnUpdScore.Text = "Update Score";
            this.btnUpdScore.UseVisualStyleBackColor = true;
            this.btnUpdScore.Click += new System.EventHandler(this.btnUpdScore_Click);
            // 
            // btndeleteStd
            // 
            this.btndeleteStd.Location = new System.Drawing.Point(586, 198);
            this.btndeleteStd.Name = "btndeleteStd";
            this.btndeleteStd.Size = new System.Drawing.Size(159, 23);
            this.btndeleteStd.TabIndex = 22;
            this.btndeleteStd.Text = "Delete Student";
            this.btndeleteStd.UseVisualStyleBackColor = true;
            this.btndeleteStd.Click += new System.EventHandler(this.btndeleteStd_Click);
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrade.ForeColor = System.Drawing.Color.Red;
            this.lblGrade.Location = new System.Drawing.Point(304, 510);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(170, 29);
            this.lblGrade.TabIndex = 23;
            this.lblGrade.Text = "Course Grade:";
            // 
            // btnSummary
            // 
            this.btnSummary.Location = new System.Drawing.Point(761, 556);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(158, 33);
            this.btnSummary.TabIndex = 24;
            this.btnSummary.Text = "Summary Form>>";
            this.btnSummary.UseVisualStyleBackColor = true;
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click);
            // 
            // FormStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 601);
            this.Controls.Add(this.btnSummary);
            this.Controls.Add(this.lblGrade);
            this.Controls.Add(this.btndeleteStd);
            this.Controls.Add(this.btnUpdScore);
            this.Controls.Add(this.lblCourseWrk);
            this.Controls.Add(this.lblSelCourses);
            this.Controls.Add(this.lstCourseWrk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMarks);
            this.Controls.Add(this.btndelSel);
            this.Controls.Add(this.btnMoveright);
            this.Controls.Add(this.lstAvailCourses);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lstSelCourses);
            this.Controls.Add(this.lstStudentID);
            this.Controls.Add(this.lblAvailCourses);
            this.Controls.Add(this.txtEarnedHours);
            this.Controls.Add(this.lblEarnedHours);
            this.Controls.Add(this.lblStudentID);
            this.Controls.Add(this.txtStudentID);
            this.Name = "FormStudent";
            this.Text = "FormStudent";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormStudent_FormClosed);
            this.Load += new System.EventHandler(this.FormStudent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Label lblEarnedHours;
        private System.Windows.Forms.TextBox txtEarnedHours;
        private System.Windows.Forms.Label lblAvailCourses;
        private System.Windows.Forms.ListBox lstStudentID;
        private System.Windows.Forms.ListBox lstSelCourses;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListBox lstAvailCourses;
        private System.Windows.Forms.Button btnMoveright;
        private System.Windows.Forms.Button btndelSel;
        private System.Windows.Forms.TextBox txtMarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstCourseWrk;
        private System.Windows.Forms.Label lblSelCourses;
        private System.Windows.Forms.Label lblCourseWrk;
        private System.Windows.Forms.Button btnUpdScore;
        private System.Windows.Forms.Button btndeleteStd;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Button btnSummary;
    }
}