namespace Ass7
{
    partial class FormCourse
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
            this.txtCNum = new System.Windows.Forms.TextBox();
            this.lblCourseNum = new System.Windows.Forms.Label();
            this.txtCWrk = new System.Windows.Forms.TextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnAddCrseWrk = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnStudForm = new System.Windows.Forms.Button();
            this.btnCourseWrkRemove = new System.Windows.Forms.Button();
            this.lstCourseWrk = new System.Windows.Forms.ListBox();
            this.lblCourseWrk = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCNum
            // 
            this.txtCNum.Location = new System.Drawing.Point(337, 66);
            this.txtCNum.Name = "txtCNum";
            this.txtCNum.Size = new System.Drawing.Size(100, 22);
            this.txtCNum.TabIndex = 0;
            this.txtCNum.Leave += new System.EventHandler(this.txtCNum_Leave);
            // 
            // lblCourseNum
            // 
            this.lblCourseNum.AutoSize = true;
            this.lblCourseNum.Location = new System.Drawing.Point(212, 71);
            this.lblCourseNum.Name = "lblCourseNum";
            this.lblCourseNum.Size = new System.Drawing.Size(103, 17);
            this.lblCourseNum.TabIndex = 1;
            this.lblCourseNum.Text = "CourseNumber";
            // 
            // txtCWrk
            // 
            this.txtCWrk.Location = new System.Drawing.Point(337, 134);
            this.txtCWrk.Name = "txtCWrk";
            this.txtCWrk.Size = new System.Drawing.Size(100, 22);
            this.txtCWrk.TabIndex = 3;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(150, 403);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 17);
            this.lblMsg.TabIndex = 5;
            // 
            // btnAddCrseWrk
            // 
            this.btnAddCrseWrk.Location = new System.Drawing.Point(476, 128);
            this.btnAddCrseWrk.Name = "btnAddCrseWrk";
            this.btnAddCrseWrk.Size = new System.Drawing.Size(145, 29);
            this.btnAddCrseWrk.TabIndex = 6;
            this.btnAddCrseWrk.Text = "Add Course Works";
            this.btnAddCrseWrk.UseVisualStyleBackColor = true;
            this.btnAddCrseWrk.Click += new System.EventHandler(this.btnAddCrseWrk_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(497, 265);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(147, 62);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnStudForm
            // 
            this.btnStudForm.Location = new System.Drawing.Point(639, 403);
            this.btnStudForm.Name = "btnStudForm";
            this.btnStudForm.Size = new System.Drawing.Size(139, 23);
            this.btnStudForm.TabIndex = 9;
            this.btnStudForm.Text = "Student Form >>";
            this.btnStudForm.UseVisualStyleBackColor = true;
            this.btnStudForm.Click += new System.EventHandler(this.btnStudForm_Click);
            // 
            // btnCourseWrkRemove
            // 
            this.btnCourseWrkRemove.Location = new System.Drawing.Point(337, 333);
            this.btnCourseWrkRemove.Name = "btnCourseWrkRemove";
            this.btnCourseWrkRemove.Size = new System.Drawing.Size(121, 45);
            this.btnCourseWrkRemove.TabIndex = 10;
            this.btnCourseWrkRemove.Text = "Remove CourseWork";
            this.btnCourseWrkRemove.UseVisualStyleBackColor = true;
            this.btnCourseWrkRemove.Click += new System.EventHandler(this.btnCourseWrkRemove_Click);
            // 
            // lstCourseWrk
            // 
            this.lstCourseWrk.FormattingEnabled = true;
            this.lstCourseWrk.ItemHeight = 16;
            this.lstCourseWrk.Location = new System.Drawing.Point(328, 211);
            this.lstCourseWrk.Name = "lstCourseWrk";
            this.lstCourseWrk.Size = new System.Drawing.Size(140, 116);
            this.lstCourseWrk.TabIndex = 11;
            // 
            // lblCourseWrk
            // 
            this.lblCourseWrk.AutoSize = true;
            this.lblCourseWrk.Location = new System.Drawing.Point(212, 134);
            this.lblCourseWrk.Name = "lblCourseWrk";
            this.lblCourseWrk.Size = new System.Drawing.Size(86, 17);
            this.lblCourseWrk.TabIndex = 2;
            this.lblCourseWrk.Text = "CourseWork";
            // 
            // FormCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstCourseWrk);
            this.Controls.Add(this.btnCourseWrkRemove);
            this.Controls.Add(this.btnStudForm);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddCrseWrk);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.txtCWrk);
            this.Controls.Add(this.lblCourseWrk);
            this.Controls.Add(this.lblCourseNum);
            this.Controls.Add(this.txtCNum);
            this.Name = "FormCourse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCourse_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCNum;
        private System.Windows.Forms.Label lblCourseNum;
        private System.Windows.Forms.TextBox txtCWrk;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnAddCrseWrk;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnStudForm;
        private System.Windows.Forms.Button btnCourseWrkRemove;
        private System.Windows.Forms.ListBox lstCourseWrk;
        private System.Windows.Forms.Label lblCourseWrk;
 
    }
}

