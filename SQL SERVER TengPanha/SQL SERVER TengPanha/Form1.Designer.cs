namespace SQL_SERVER_TengPanha
{
    partial class Form1
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
            this.People = new System.Windows.Forms.GroupBox();
            this.btnLottery = new System.Windows.Forms.Button();
            this.btnShow_employee = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.People.SuspendLayout();
            this.SuspendLayout();
            // 
            // People
            // 
            this.People.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.People.Controls.Add(this.btnLottery);
            this.People.Controls.Add(this.btnShow_employee);
            this.People.Controls.Add(this.btnLogout);
            this.People.ForeColor = System.Drawing.Color.White;
            this.People.Location = new System.Drawing.Point(48, 51);
            this.People.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.People.Name = "People";
            this.People.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.People.Size = new System.Drawing.Size(271, 554);
            this.People.TabIndex = 2;
            this.People.TabStop = false;
            this.People.Text = "People";
            this.People.Enter += new System.EventHandler(this.People_Enter);
            // 
            // btnLottery
            // 
            this.btnLottery.BackColor = System.Drawing.Color.Green;
            this.btnLottery.Location = new System.Drawing.Point(6, 81);
            this.btnLottery.Name = "btnLottery";
            this.btnLottery.Size = new System.Drawing.Size(259, 41);
            this.btnLottery.TabIndex = 2;
            this.btnLottery.Text = "LOTTERY EMPLOYEE";
            this.btnLottery.UseVisualStyleBackColor = false;
            this.btnLottery.Click += new System.EventHandler(this.btnLottery_Click);
            // 
            // btnShow_employee
            // 
            this.btnShow_employee.BackColor = System.Drawing.Color.ForestGreen;
            this.btnShow_employee.Location = new System.Drawing.Point(6, 34);
            this.btnShow_employee.Name = "btnShow_employee";
            this.btnShow_employee.Size = new System.Drawing.Size(259, 41);
            this.btnShow_employee.TabIndex = 1;
            this.btnShow_employee.Text = "SHOW EMPLOEE";
            this.btnShow_employee.UseVisualStyleBackColor = false;
            this.btnShow_employee.Click += new System.EventHandler(this.btnShow_employee_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.BackColor = System.Drawing.Color.Green;
            this.btnLogout.Font = new System.Drawing.Font("Impact", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(6, 495);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(259, 49);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(1445, 644);
            this.Controls.Add(this.People);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.People.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox People;
        private System.Windows.Forms.Button btnLottery;
        private System.Windows.Forms.Button btnShow_employee;
        private System.Windows.Forms.Button btnLogout;
    }
}

