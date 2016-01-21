namespace ZMS
{
    partial class Coverpage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Coverpage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonExitApp = new System.Windows.Forms.Button();
            this.buttonVreport = new System.Windows.Forms.Button();
            this.groupBoxLogIn = new System.Windows.Forms.GroupBox();
            this.buttonLoginEnter = new System.Windows.Forms.Button();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelPass = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBoxLogIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonExitApp);
            this.panel1.Controls.Add(this.buttonVreport);
            this.panel1.Controls.Add(this.groupBoxLogIn);
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1230, 690);
            this.panel1.TabIndex = 0;
            // 
            // buttonExitApp
            // 
            this.buttonExitApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExitApp.Location = new System.Drawing.Point(1083, 610);
            this.buttonExitApp.Name = "buttonExitApp";
            this.buttonExitApp.Size = new System.Drawing.Size(135, 54);
            this.buttonExitApp.TabIndex = 6;
            this.buttonExitApp.Text = "Exit Application";
            this.buttonExitApp.UseVisualStyleBackColor = true;
            this.buttonExitApp.Click += new System.EventHandler(this.buttonExitApp_Click);
            // 
            // buttonVreport
            // 
            this.buttonVreport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVreport.Location = new System.Drawing.Point(877, 610);
            this.buttonVreport.Name = "buttonVreport";
            this.buttonVreport.Size = new System.Drawing.Size(135, 54);
            this.buttonVreport.TabIndex = 5;
            this.buttonVreport.Text = "View Report";
            this.buttonVreport.UseVisualStyleBackColor = true;
            // 
            // groupBoxLogIn
            // 
            this.groupBoxLogIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBoxLogIn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.groupBoxLogIn.Controls.Add(this.buttonLoginEnter);
            this.groupBoxLogIn.Controls.Add(this.textBoxPass);
            this.groupBoxLogIn.Controls.Add(this.textBoxName);
            this.groupBoxLogIn.Controls.Add(this.labelPass);
            this.groupBoxLogIn.Controls.Add(this.labelName);
            this.groupBoxLogIn.Font = new System.Drawing.Font("Footlight MT Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxLogIn.Location = new System.Drawing.Point(664, 137);
            this.groupBoxLogIn.Name = "groupBoxLogIn";
            this.groupBoxLogIn.Size = new System.Drawing.Size(554, 311);
            this.groupBoxLogIn.TabIndex = 4;
            this.groupBoxLogIn.TabStop = false;
            this.groupBoxLogIn.Text = "Log In:";
            // 
            // buttonLoginEnter
            // 
            this.buttonLoginEnter.Font = new System.Drawing.Font("Footlight MT Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoginEnter.Image = ((System.Drawing.Image)(resources.GetObject("buttonLoginEnter.Image")));
            this.buttonLoginEnter.Location = new System.Drawing.Point(336, 228);
            this.buttonLoginEnter.Name = "buttonLoginEnter";
            this.buttonLoginEnter.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.buttonLoginEnter.Size = new System.Drawing.Size(150, 62);
            this.buttonLoginEnter.TabIndex = 4;
            this.buttonLoginEnter.Text = "Log In";
            this.buttonLoginEnter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonLoginEnter.UseVisualStyleBackColor = true;
            this.buttonLoginEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(155, 150);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(331, 23);
            this.textBoxPass.TabIndex = 3;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(155, 58);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(331, 23);
            this.textBoxName.TabIndex = 2;
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(23, 153);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(67, 15);
            this.labelPass.TabIndex = 1;
            this.labelPass.Text = "Password:";
            this.labelPass.Click += new System.EventHandler(this.labelPass_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(23, 61);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(79, 15);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "User Name:";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.DarkKhaki;
            this.labelTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTitle.Font = new System.Drawing.Font("Footlight MT Light", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(86, 38);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(522, 53);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Zoo Management System";
            this.labelTitle.Click += new System.EventHandler(this.labelTitle_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(86, 137);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(522, 527);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Coverpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 690);
            this.Controls.Add(this.panel1);
            this.Name = "Coverpage";
            this.Text = "Coverpage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxLogIn.ResumeLayout(false);
            this.groupBoxLogIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.GroupBox groupBoxLogIn;
        private System.Windows.Forms.Button buttonLoginEnter;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonExitApp;
        private System.Windows.Forms.Button buttonVreport;
    }
}