
namespace GodswarHack
{
    partial class AutoDCForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.StartDCbutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fornaxSV = new System.Windows.Forms.CheckBox();
            this.atlantaSV = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Aqua;
            this.label1.Location = new System.Drawing.Point(260, 242);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "AutoDC1.0";
            // 
            // StartDCbutton
            // 
            this.StartDCbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartDCbutton.ForeColor = System.Drawing.Color.Aqua;
            this.StartDCbutton.Location = new System.Drawing.Point(197, 113);
            this.StartDCbutton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartDCbutton.Name = "StartDCbutton";
            this.StartDCbutton.Size = new System.Drawing.Size(100, 28);
            this.StartDCbutton.TabIndex = 1;
            this.StartDCbutton.Text = "Start";
            this.StartDCbutton.UseVisualStyleBackColor = true;
            this.StartDCbutton.Click += new System.EventHandler(this.StartDC);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(297, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(16, 39);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(132, 210);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(39, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Victims ID";
            // 
            // fornaxSV
            // 
            this.fornaxSV.AutoSize = true;
            this.fornaxSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fornaxSV.ForeColor = System.Drawing.Color.Aqua;
            this.fornaxSV.Location = new System.Drawing.Point(197, 208);
            this.fornaxSV.Name = "fornaxSV";
            this.fornaxSV.Size = new System.Drawing.Size(66, 20);
            this.fornaxSV.TabIndex = 6;
            this.fornaxSV.Text = "Fornax";
            this.fornaxSV.UseVisualStyleBackColor = true;
            this.fornaxSV.CheckedChanged += new System.EventHandler(this.fornaxSV_CheckedChanged);
            // 
            // atlantaSV
            // 
            this.atlantaSV.AutoSize = true;
            this.atlantaSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.atlantaSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.atlantaSV.ForeColor = System.Drawing.Color.Aqua;
            this.atlantaSV.Location = new System.Drawing.Point(197, 182);
            this.atlantaSV.Name = "atlantaSV";
            this.atlantaSV.Size = new System.Drawing.Size(66, 20);
            this.atlantaSV.TabIndex = 7;
            this.atlantaSV.Text = "Atlanta";
            this.atlantaSV.UseVisualStyleBackColor = false;
            this.atlantaSV.CheckedChanged += new System.EventHandler(this.atlantaSV_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Aqua;
            this.label3.Location = new System.Drawing.Point(210, 163);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Server";
            // 
            // AutoDCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(339, 262);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.atlantaSV);
            this.Controls.Add(this.fornaxSV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.StartDCbutton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AutoDCForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoDCForm";
            this.Load += new System.EventHandler(this.AutoDCForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AutoDCForm_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StartDCbutton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox fornaxSV;
        private System.Windows.Forms.CheckBox atlantaSV;
        private System.Windows.Forms.Label label3;
    }
}