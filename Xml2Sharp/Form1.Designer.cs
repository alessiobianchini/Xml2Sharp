using System;
using System.Drawing;

namespace Xml2Sharp
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.StartConversionButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.newConversionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xml2Sharp ";
            // 
            // label1
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 150);
            this.label2.Name = "label1";
            this.label2.Size = new System.Drawing.Size(150, 32);
            this.label2.Visible = false;
            this.label2.ForeColor = Color.Orange;
            this.label2.TabIndex = 4;
            this.label2.Text = "file name";
            // 
            // button2
            // 
            this.SelectFileButton.Location = new Point(40, 200);
            this.SelectFileButton.Name = "Button2";
            this.SelectFileButton.Size = new Size(88, 32);
            this.SelectFileButton.TabIndex = 4;
            this.SelectFileButton.Text = "Select file";
            this.SelectFileButton.Click += new EventHandler(this.Btn_Click);
            // 
            // button3
            // 
            this.StartConversionButton.Location = new Point(40, 200);
            this.StartConversionButton.Name = "Button2";
            this.StartConversionButton.Size = new Size(88, 32);
            this.StartConversionButton.TabIndex = 4;
            this.StartConversionButton.Text = "Start conversion";
            this.StartConversionButton.Visible = false;
            this.StartConversionButton.Click += new EventHandler(this.Convert);
            // 
            // button4
            // 
            this.downloadButton.Location = new Point(40, 200);
            this.downloadButton.Name = "Button2";
            this.downloadButton.Size = new Size(88, 32);
            this.downloadButton.TabIndex = 4;
            this.downloadButton.Text = "Download file";
            this.downloadButton.Visible = false;
            this.downloadButton.Click += new EventHandler(this.Download);
            // 
            // button5
            // 
            this.newConversionButton.Location = new Point(40, 250);
            this.newConversionButton.Name = "Button2";
            this.newConversionButton.Size = new Size(88, 32);
            this.newConversionButton.TabIndex = 4;
            this.newConversionButton.Text = "New conversion";
            this.newConversionButton.Visible = false;
            this.newConversionButton.Click += new EventHandler(this.NewConversion);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectFileButton);
            this.Controls.Add(this.StartConversionButton);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.newConversionButton);
            this.Name = "Xml2Sharp";
            this.Text = "Xml2Sharp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.Button StartConversionButton;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Button newConversionButton;
    }
}
