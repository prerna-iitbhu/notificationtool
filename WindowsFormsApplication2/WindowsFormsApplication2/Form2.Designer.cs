namespace WindowsFormsApplication2
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.ProjectNotSet = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Projects = new System.Windows.Forms.ComboBox();
            this.RunOnStartup = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.RefreshTimeLabel = new System.Windows.Forms.Label();
            this.RefreshTimeTextBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Component = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.box = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProjectNotSet
            // 
            this.ProjectNotSet.AutoSize = true;
            this.ProjectNotSet.Location = new System.Drawing.Point(13, 9);
            this.ProjectNotSet.Name = "ProjectNotSet";
            this.ProjectNotSet.Size = new System.Drawing.Size(0, 13);
            this.ProjectNotSet.TabIndex = 0;
            this.ProjectNotSet.Click += new System.EventHandler(this.ProjectNotSet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Projects";
            // 
            // Projects
            // 
            this.Projects.FormattingEnabled = true;
            this.Projects.Items.AddRange(new object[] {
            "Jasper",
            "Bruin",
            "Merlin",
            "Other"});
            this.Projects.Location = new System.Drawing.Point(89, 29);
            this.Projects.Name = "Projects";
            this.Projects.Size = new System.Drawing.Size(121, 21);
            this.Projects.TabIndex = 2;
            this.Projects.SelectedIndexChanged += new System.EventHandler(this.Projects_SelectedIndexChanged_1);
            // 
            // RunOnStartup
            // 
            this.RunOnStartup.AutoSize = true;
            this.RunOnStartup.Location = new System.Drawing.Point(302, 36);
            this.RunOnStartup.Name = "RunOnStartup";
            this.RunOnStartup.Size = new System.Drawing.Size(94, 17);
            this.RunOnStartup.TabIndex = 3;
            this.RunOnStartup.Text = "RunOnStartup";
            this.RunOnStartup.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(135, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(242, 381);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // RefreshTimeLabel
            // 
            this.RefreshTimeLabel.AutoSize = true;
            this.RefreshTimeLabel.Location = new System.Drawing.Point(19, 33);
            this.RefreshTimeLabel.Name = "RefreshTimeLabel";
            this.RefreshTimeLabel.Size = new System.Drawing.Size(97, 13);
            this.RefreshTimeLabel.TabIndex = 6;
            this.RefreshTimeLabel.Text = "Refresh Time(mins)";
            // 
            // RefreshTimeTextBox
            // 
            this.RefreshTimeTextBox.Location = new System.Drawing.Point(142, 33);
            this.RefreshTimeTextBox.Name = "RefreshTimeTextBox";
            this.RefreshTimeTextBox.Size = new System.Drawing.Size(100, 20);
            this.RefreshTimeTextBox.TabIndex = 7;
            this.RefreshTimeTextBox.Text = "1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(217, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(115, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Visible = false;
            // 
            // Component
            // 
            this.Component.AutoSize = true;
            this.Component.Location = new System.Drawing.Point(18, 26);
            this.Component.Name = "Component";
            this.Component.Size = new System.Drawing.Size(61, 13);
            this.Component.TabIndex = 9;
            this.Component.Text = "Component";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(300, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(71, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Search";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(21, 72);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 12;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(186, 272);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "Add";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(186, 317);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 14;
            this.button5.Text = "Remove";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(286, 245);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 95);
            this.listBox2.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Projects);
            this.groupBox1.Location = new System.Drawing.Point(12, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 71);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Project";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.box);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.Component);
            this.groupBox2.Location = new System.Drawing.Point(12, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 182);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Component";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // box
            // 
            this.box.Location = new System.Drawing.Point(103, 23);
            this.box.Name = "box";
            this.box.Size = new System.Drawing.Size(174, 20);
            this.box.TabIndex = 13;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 429);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.RefreshTimeTextBox);
            this.Controls.Add(this.RefreshTimeLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RunOnStartup);
            this.Controls.Add(this.ProjectNotSet);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Reconfigure";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProjectNotSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Projects;
        private System.Windows.Forms.CheckBox RunOnStartup;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label RefreshTimeLabel;
        private System.Windows.Forms.TextBox RefreshTimeTextBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Component;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox box;
    }
}