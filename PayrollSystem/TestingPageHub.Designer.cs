namespace PayrollSystem
{
    partial class TestingPageHub
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
            this.btnTest1 = new System.Windows.Forms.Button();
            this.cmdTest2 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTest1
            // 
            this.btnTest1.Location = new System.Drawing.Point(25, 14);
            this.btnTest1.Name = "btnTest1";
            this.btnTest1.Size = new System.Drawing.Size(199, 85);
            this.btnTest1.TabIndex = 0;
            this.btnTest1.Text = "test Reading";
            this.btnTest1.UseVisualStyleBackColor = true;
            this.btnTest1.Click += new System.EventHandler(this.btnTest1_Click);
            // 
            // cmdTest2
            // 
            this.cmdTest2.Location = new System.Drawing.Point(12, 121);
            this.cmdTest2.Name = "cmdTest2";
            this.cmdTest2.Size = new System.Drawing.Size(199, 85);
            this.cmdTest2.TabIndex = 1;
            this.cmdTest2.Text = "testWriting";
            this.cmdTest2.UseVisualStyleBackColor = true;
            this.cmdTest2.Click += new System.EventHandler(this.cmdTest2_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(98, 282);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(260, 134);
            this.button2.TabIndex = 3;
            this.button2.Text = "create full example company loaded into memory";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(494, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "to see the company created, check documentation";
            // 
            // TestingPageHub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmdTest2);
            this.Controls.Add(this.btnTest1);
            this.Name = "TestingPageHub";
            this.Text = "TestingPageHub";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTest1;
        private System.Windows.Forms.Button cmdTest2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}