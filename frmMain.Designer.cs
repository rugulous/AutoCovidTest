namespace CovidReg
{
    partial class frmMain
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
            this.btnGetStarted = new System.Windows.Forms.Button();
            this.grpStudent = new System.Windows.Forms.GroupBox();
            this.btnStudentID = new System.Windows.Forms.Button();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.grpStudent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetStarted
            // 
            this.btnGetStarted.Location = new System.Drawing.Point(100, 58);
            this.btnGetStarted.Name = "btnGetStarted";
            this.btnGetStarted.Size = new System.Drawing.Size(178, 70);
            this.btnGetStarted.TabIndex = 0;
            this.btnGetStarted.Text = "Get Started";
            this.btnGetStarted.UseVisualStyleBackColor = true;
            this.btnGetStarted.Click += new System.EventHandler(this.btnGetStarted_Click);
            // 
            // grpStudent
            // 
            this.grpStudent.Controls.Add(this.btnStudentID);
            this.grpStudent.Controls.Add(this.txtStudentID);
            this.grpStudent.Location = new System.Drawing.Point(25, 21);
            this.grpStudent.Name = "grpStudent";
            this.grpStudent.Size = new System.Drawing.Size(369, 150);
            this.grpStudent.TabIndex = 1;
            this.grpStudent.TabStop = false;
            this.grpStudent.Text = "Student ID";
            this.grpStudent.Visible = false;
            // 
            // btnStudentID
            // 
            this.btnStudentID.Location = new System.Drawing.Point(85, 88);
            this.btnStudentID.Name = "btnStudentID";
            this.btnStudentID.Size = new System.Drawing.Size(209, 32);
            this.btnStudentID.TabIndex = 1;
            this.btnStudentID.Text = "Go!";
            this.btnStudentID.UseVisualStyleBackColor = true;
            this.btnStudentID.Click += new System.EventHandler(this.btnStudentID_Click);
            // 
            // txtBNo
            // 
            this.txtStudentID.Location = new System.Drawing.Point(46, 49);
            this.txtStudentID.Name = "txtBNo";
            this.txtStudentID.Size = new System.Drawing.Size(284, 20);
            this.txtStudentID.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 197);
            this.Controls.Add(this.grpStudent);
            this.Controls.Add(this.btnGetStarted);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.Text = "Covid Registration Helper";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.grpStudent.ResumeLayout(false);
            this.grpStudent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetStarted;
        private System.Windows.Forms.GroupBox grpStudent;
        private System.Windows.Forms.Button btnStudentID;
        private System.Windows.Forms.TextBox txtStudentID;
    }
}

