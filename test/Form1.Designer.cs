namespace Phys
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
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.circleCount = new System.Windows.Forms.Label();
            this.showVector_btn = new System.Windows.Forms.Button();
            this.formParam = new System.Windows.Forms.Label();
            this.switchGravity_btn = new System.Windows.Forms.Button();
            this.panel1 = new DoubleBufferedPanel();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 15;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // circleCount
            // 
            this.circleCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.circleCount.AutoSize = true;
            this.circleCount.Location = new System.Drawing.Point(1092, 498);
            this.circleCount.Name = "circleCount";
            this.circleCount.Size = new System.Drawing.Size(35, 13);
            this.circleCount.TabIndex = 1;
            this.circleCount.Text = "label1";
            // 
            // showVector_btn
            // 
            this.showVector_btn.Location = new System.Drawing.Point(12, 12);
            this.showVector_btn.Name = "showVector_btn";
            this.showVector_btn.Size = new System.Drawing.Size(75, 23);
            this.showVector_btn.TabIndex = 2;
            this.showVector_btn.Text = "Draw vector";
            this.showVector_btn.UseVisualStyleBackColor = true;
            this.showVector_btn.Click += new System.EventHandler(this.showVector_btn_Click);
            // 
            // formParam
            // 
            this.formParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.formParam.AutoSize = true;
            this.formParam.Location = new System.Drawing.Point(1092, 17);
            this.formParam.Name = "formParam";
            this.formParam.Size = new System.Drawing.Size(35, 13);
            this.formParam.TabIndex = 0;
            this.formParam.Text = "label1";
            // 
            // switchGravity_btn
            // 
            this.switchGravity_btn.Location = new System.Drawing.Point(93, 12);
            this.switchGravity_btn.Name = "switchGravity_btn";
            this.switchGravity_btn.Size = new System.Drawing.Size(96, 23);
            this.switchGravity_btn.TabIndex = 3;
            this.switchGravity_btn.Text = "Switch gravity";
            this.switchGravity_btn.UseVisualStyleBackColor = true;
            this.switchGravity_btn.Click += new System.EventHandler(this.switchGravity_btn_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1115, 454);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 520);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.switchGravity_btn);
            this.Controls.Add(this.formParam);
            this.Controls.Add(this.showVector_btn);
            this.Controls.Add(this.circleCount);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label circleCount;
        private System.Windows.Forms.Button showVector_btn;
        private System.Windows.Forms.Label formParam;
        private System.Windows.Forms.Button switchGravity_btn;
        private DoubleBufferedPanel panel1;
    }
}

