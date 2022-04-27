namespace YLWEDITransLina
{
    partial class frmTransLina
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
            this.tmrUp = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.txtDown = new System.Windows.Forms.TextBox();
            this.txtUp = new System.Windows.Forms.TextBox();
            this.chkResponseStop = new System.Windows.Forms.CheckBox();
            this.chkDownStop = new System.Windows.Forms.CheckBox();
            this.chkUpStop = new System.Windows.Forms.CheckBox();
            this.tmrDown = new System.Windows.Forms.Timer(this.components);
            this.tmrResponse = new System.Windows.Forms.Timer(this.components);
            this.txtUpCnt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDownCnt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtResponseCnt = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtUpMsg = new System.Windows.Forms.TextBox();
            this.txtDownMsg = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtResponseMsg = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtUpAttachMsg = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUpAttachCnt = new System.Windows.Forms.TextBox();
            this.txtUpAttach = new System.Windows.Forms.TextBox();
            this.chkUpAttachStop = new System.Windows.Forms.CheckBox();
            this.tmrUpAttach = new System.Windows.Forms.Timer(this.components);
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrUp
            // 
            this.tmrUp.Interval = 1000;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.txtUpAttachMsg);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtUpAttachCnt);
            this.panel1.Controls.Add(this.txtUpAttach);
            this.panel1.Controls.Add(this.chkUpAttachStop);
            this.panel1.Controls.Add(this.txtResponseMsg);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.txtDownMsg);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.txtUpMsg);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtResponseCnt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDownCnt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtUpCnt);
            this.panel1.Controls.Add(this.txtResponse);
            this.panel1.Controls.Add(this.txtDown);
            this.panel1.Controls.Add(this.txtUp);
            this.panel1.Controls.Add(this.chkResponseStop);
            this.panel1.Controls.Add(this.chkDownStop);
            this.panel1.Controls.Add(this.chkUpStop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 370);
            this.panel1.TabIndex = 3;
            // 
            // txtResponse
            // 
            this.txtResponse.Location = new System.Drawing.Point(129, 200);
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ReadOnly = true;
            this.txtResponse.Size = new System.Drawing.Size(47, 21);
            this.txtResponse.TabIndex = 8;
            // 
            // txtDown
            // 
            this.txtDown.Location = new System.Drawing.Point(127, 116);
            this.txtDown.Name = "txtDown";
            this.txtDown.ReadOnly = true;
            this.txtDown.Size = new System.Drawing.Size(47, 21);
            this.txtDown.TabIndex = 7;
            // 
            // txtUp
            // 
            this.txtUp.Location = new System.Drawing.Point(127, 34);
            this.txtUp.Name = "txtUp";
            this.txtUp.ReadOnly = true;
            this.txtUp.Size = new System.Drawing.Size(47, 21);
            this.txtUp.TabIndex = 6;
            // 
            // chkResponseStop
            // 
            this.chkResponseStop.AutoSize = true;
            this.chkResponseStop.Location = new System.Drawing.Point(27, 202);
            this.chkResponseStop.Name = "chkResponseStop";
            this.chkResponseStop.Size = new System.Drawing.Size(96, 16);
            this.chkResponseStop.TabIndex = 5;
            this.chkResponseStop.Text = "응답전문중지";
            this.chkResponseStop.UseVisualStyleBackColor = true;
            // 
            // chkDownStop
            // 
            this.chkDownStop.AutoSize = true;
            this.chkDownStop.Location = new System.Drawing.Point(27, 118);
            this.chkDownStop.Name = "chkDownStop";
            this.chkDownStop.Size = new System.Drawing.Size(96, 16);
            this.chkDownStop.TabIndex = 4;
            this.chkDownStop.Text = "다운로드중지";
            this.chkDownStop.UseVisualStyleBackColor = true;
            // 
            // chkUpStop
            // 
            this.chkUpStop.AutoSize = true;
            this.chkUpStop.Location = new System.Drawing.Point(27, 36);
            this.chkUpStop.Name = "chkUpStop";
            this.chkUpStop.Size = new System.Drawing.Size(84, 16);
            this.chkUpStop.TabIndex = 3;
            this.chkUpStop.Text = "업로드중지";
            this.chkUpStop.UseVisualStyleBackColor = true;
            // 
            // tmrDown
            // 
            this.tmrDown.Interval = 1000;
            // 
            // tmrResponse
            // 
            this.tmrResponse.Interval = 1000;
            // 
            // txtUpCnt
            // 
            this.txtUpCnt.Location = new System.Drawing.Point(252, 34);
            this.txtUpCnt.Name = "txtUpCnt";
            this.txtUpCnt.ReadOnly = true;
            this.txtUpCnt.Size = new System.Drawing.Size(116, 21);
            this.txtUpCnt.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "누적건수";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "누적건수";
            // 
            // txtDownCnt
            // 
            this.txtDownCnt.Location = new System.Drawing.Point(252, 116);
            this.txtDownCnt.Name = "txtDownCnt";
            this.txtDownCnt.ReadOnly = true;
            this.txtDownCnt.Size = new System.Drawing.Size(116, 21);
            this.txtDownCnt.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "누적건수";
            // 
            // txtResponseCnt
            // 
            this.txtResponseCnt.Location = new System.Drawing.Point(252, 200);
            this.txtResponseCnt.Name = "txtResponseCnt";
            this.txtResponseCnt.ReadOnly = true;
            this.txtResponseCnt.Size = new System.Drawing.Size(116, 21);
            this.txtResponseCnt.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 95);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(496, 1);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // txtUpMsg
            // 
            this.txtUpMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpMsg.Location = new System.Drawing.Point(27, 61);
            this.txtUpMsg.Name = "txtUpMsg";
            this.txtUpMsg.Size = new System.Drawing.Size(466, 21);
            this.txtUpMsg.TabIndex = 16;
            // 
            // txtDownMsg
            // 
            this.txtDownMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDownMsg.Location = new System.Drawing.Point(27, 143);
            this.txtDownMsg.Name = "txtDownMsg";
            this.txtDownMsg.Size = new System.Drawing.Size(466, 21);
            this.txtDownMsg.TabIndex = 18;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(12, 177);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(496, 1);
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // txtResponseMsg
            // 
            this.txtResponseMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponseMsg.Location = new System.Drawing.Point(27, 227);
            this.txtResponseMsg.Name = "txtResponseMsg";
            this.txtResponseMsg.Size = new System.Drawing.Size(466, 21);
            this.txtResponseMsg.TabIndex = 20;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(12, 261);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(496, 1);
            this.pictureBox3.TabIndex = 19;
            this.pictureBox3.TabStop = false;
            // 
            // txtUpAttachMsg
            // 
            this.txtUpAttachMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpAttachMsg.Location = new System.Drawing.Point(27, 310);
            this.txtUpAttachMsg.Name = "txtUpAttachMsg";
            this.txtUpAttachMsg.Size = new System.Drawing.Size(466, 21);
            this.txtUpAttachMsg.TabIndex = 26;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(12, 344);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(496, 1);
            this.pictureBox4.TabIndex = 25;
            this.pictureBox4.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 24;
            this.label4.Text = "누적건수";
            // 
            // txtUpAttachCnt
            // 
            this.txtUpAttachCnt.Location = new System.Drawing.Point(252, 283);
            this.txtUpAttachCnt.Name = "txtUpAttachCnt";
            this.txtUpAttachCnt.ReadOnly = true;
            this.txtUpAttachCnt.Size = new System.Drawing.Size(116, 21);
            this.txtUpAttachCnt.TabIndex = 23;
            // 
            // txtUpAttach
            // 
            this.txtUpAttach.Location = new System.Drawing.Point(129, 283);
            this.txtUpAttach.Name = "txtUpAttach";
            this.txtUpAttach.ReadOnly = true;
            this.txtUpAttach.Size = new System.Drawing.Size(47, 21);
            this.txtUpAttach.TabIndex = 22;
            // 
            // chkUpAttachStop
            // 
            this.chkUpAttachStop.AutoSize = true;
            this.chkUpAttachStop.Location = new System.Drawing.Point(27, 285);
            this.chkUpAttachStop.Name = "chkUpAttachStop";
            this.chkUpAttachStop.Size = new System.Drawing.Size(96, 16);
            this.chkUpAttachStop.TabIndex = 21;
            this.chkUpAttachStop.Text = "첨부파일중지";
            this.chkUpAttachStop.UseVisualStyleBackColor = true;
            // 
            // tmrUpAttach
            // 
            this.tmrUpAttach.Interval = 1000;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox5.Location = new System.Drawing.Point(12, 13);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(496, 1);
            this.pictureBox5.TabIndex = 27;
            this.pictureBox5.TabStop = false;
            // 
            // frmTransLina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 370);
            this.Controls.Add(this.panel1);
            this.Name = "frmTransLina";
            this.Text = "라이나 송수신";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmrUp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkResponseStop;
        private System.Windows.Forms.CheckBox chkDownStop;
        private System.Windows.Forms.CheckBox chkUpStop;
        private System.Windows.Forms.Timer tmrDown;
        private System.Windows.Forms.Timer tmrResponse;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.TextBox txtDown;
        private System.Windows.Forms.TextBox txtUp;
        private System.Windows.Forms.TextBox txtResponseMsg;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtDownMsg;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtUpMsg;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtResponseCnt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDownCnt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUpCnt;
        private System.Windows.Forms.TextBox txtUpAttachMsg;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUpAttachCnt;
        private System.Windows.Forms.TextBox txtUpAttach;
        private System.Windows.Forms.CheckBox chkUpAttachStop;
        private System.Windows.Forms.Timer tmrUpAttach;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}