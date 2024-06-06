namespace DisDemo
{
    partial class ImportForm
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
            this.AreaCB = new System.Windows.Forms.ComboBox();
            this.StartValueL = new System.Windows.Forms.Label();
            this.resultPicL = new System.Windows.Forms.Button();
            this.startStrTb = new System.Windows.Forms.TextBox();
            this.numStr = new System.Windows.Forms.TextBox();
            this.NumberL = new System.Windows.Forms.Label();
            this.stepTb = new System.Windows.Forms.TextBox();
            this.IncreaseL = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.Usercheck = new System.Windows.Forms.CheckBox();
            this.Reservecheck = new System.Windows.Forms.CheckBox();
            this.EPCcheck = new System.Windows.Forms.CheckBox();
            this.startAddSampleLb = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.startValueTb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.areaSampleL = new System.Windows.Forms.Label();
            this.startAddSampleTb = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据区域：";
            // 
            // AreaCB
            // 
            this.AreaCB.FormattingEnabled = true;
            this.AreaCB.Items.AddRange(new object[] {
            "RFU",
            "EPC",
            "USER"});
            this.AreaCB.Location = new System.Drawing.Point(94, 34);
            this.AreaCB.Name = "AreaCB";
            this.AreaCB.Size = new System.Drawing.Size(121, 20);
            this.AreaCB.TabIndex = 1;
            this.AreaCB.SelectedIndexChanged += new System.EventHandler(this.AreaCB_SelectedIndexChanged);
            // 
            // StartValueL
            // 
            this.StartValueL.AutoSize = true;
            this.StartValueL.Location = new System.Drawing.Point(12, 95);
            this.StartValueL.Name = "StartValueL";
            this.StartValueL.Size = new System.Drawing.Size(53, 12);
            this.StartValueL.TabIndex = 2;
            this.StartValueL.Text = "起始值：";
            // 
            // resultPicL
            // 
            this.resultPicL.Location = new System.Drawing.Point(114, 240);
            this.resultPicL.Name = "resultPicL";
            this.resultPicL.Size = new System.Drawing.Size(75, 30);
            this.resultPicL.TabIndex = 4;
            this.resultPicL.Text = "设置";
            this.resultPicL.UseVisualStyleBackColor = true;
            this.resultPicL.Click += new System.EventHandler(this.button1_Click);
            // 
            // startStrTb
            // 
            this.startStrTb.Location = new System.Drawing.Point(94, 91);
            this.startStrTb.Name = "startStrTb";
            this.startStrTb.Size = new System.Drawing.Size(220, 21);
            this.startStrTb.TabIndex = 5;
            this.startStrTb.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // numStr
            // 
            this.numStr.Location = new System.Drawing.Point(121, 48);
            this.numStr.Name = "numStr";
            this.numStr.Size = new System.Drawing.Size(147, 21);
            this.numStr.TabIndex = 7;
            this.numStr.Text = "100";
            // 
            // NumberL
            // 
            this.NumberL.AutoSize = true;
            this.NumberL.Location = new System.Drawing.Point(13, 49);
            this.NumberL.Name = "NumberL";
            this.NumberL.Size = new System.Drawing.Size(41, 12);
            this.NumberL.TabIndex = 6;
            this.NumberL.Text = "个数：";
            // 
            // stepTb
            // 
            this.stepTb.Location = new System.Drawing.Point(94, 175);
            this.stepTb.Name = "stepTb";
            this.stepTb.Size = new System.Drawing.Size(147, 21);
            this.stepTb.TabIndex = 9;
            this.stepTb.Text = "1";
            // 
            // IncreaseL
            // 
            this.IncreaseL.AutoSize = true;
            this.IncreaseL.Location = new System.Drawing.Point(12, 179);
            this.IncreaseL.Name = "IncreaseL";
            this.IncreaseL.Size = new System.Drawing.Size(41, 12);
            this.IncreaseL.TabIndex = 8;
            this.IncreaseL.Text = "增值：";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(106, 372);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 33);
            this.button2.TabIndex = 10;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Usercheck
            // 
            this.Usercheck.AutoSize = true;
            this.Usercheck.Enabled = false;
            this.Usercheck.Location = new System.Drawing.Point(271, 10);
            this.Usercheck.Name = "Usercheck";
            this.Usercheck.Size = new System.Drawing.Size(48, 16);
            this.Usercheck.TabIndex = 23;
            this.Usercheck.Text = "USER";
            this.Usercheck.UseVisualStyleBackColor = true;
            // 
            // Reservecheck
            // 
            this.Reservecheck.AutoSize = true;
            this.Reservecheck.Enabled = false;
            this.Reservecheck.Location = new System.Drawing.Point(122, 11);
            this.Reservecheck.Name = "Reservecheck";
            this.Reservecheck.Size = new System.Drawing.Size(42, 16);
            this.Reservecheck.TabIndex = 22;
            this.Reservecheck.Text = "RFU";
            this.Reservecheck.UseVisualStyleBackColor = true;
            // 
            // EPCcheck
            // 
            this.EPCcheck.AutoSize = true;
            this.EPCcheck.Enabled = false;
            this.EPCcheck.Location = new System.Drawing.Point(198, 10);
            this.EPCcheck.Name = "EPCcheck";
            this.EPCcheck.Size = new System.Drawing.Size(42, 16);
            this.EPCcheck.TabIndex = 21;
            this.EPCcheck.Text = "EPC";
            this.EPCcheck.UseVisualStyleBackColor = true;
            // 
            // startAddSampleLb
            // 
            this.startAddSampleLb.AutoSize = true;
            this.startAddSampleLb.Location = new System.Drawing.Point(92, 127);
            this.startAddSampleLb.Name = "startAddSampleLb";
            this.startAddSampleLb.Size = new System.Drawing.Size(41, 12);
            this.startAddSampleLb.TabIndex = 24;
            this.startAddSampleLb.Text = "示例：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 25;
            this.label7.Text = "数据区域：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.startAddSampleTb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.startValueTb);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.areaSampleL);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.AreaCB);
            this.groupBox1.Controls.Add(this.StartValueL);
            this.groupBox1.Controls.Add(this.startAddSampleLb);
            this.groupBox1.Controls.Add(this.startStrTb);
            this.groupBox1.Controls.Add(this.IncreaseL);
            this.groupBox1.Controls.Add(this.stepTb);
            this.groupBox1.Controls.Add(this.resultPicL);
            this.groupBox1.Location = new System.Drawing.Point(3, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 278);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "导入数据格式";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "起始位：";
            // 
            // startValueTb
            // 
            this.startValueTb.Location = new System.Drawing.Point(94, 210);
            this.startValueTb.Name = "startValueTb";
            this.startValueTb.Size = new System.Drawing.Size(147, 21);
            this.startValueTb.TabIndex = 31;
            this.startValueTb.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 12);
            this.label5.TabIndex = 29;
            // 
            // areaSampleL
            // 
            this.areaSampleL.AutoSize = true;
            this.areaSampleL.Location = new System.Drawing.Point(92, 64);
            this.areaSampleL.Name = "areaSampleL";
            this.areaSampleL.Size = new System.Drawing.Size(41, 12);
            this.areaSampleL.TabIndex = 28;
            this.areaSampleL.Text = "示例：";
            // 
            // startAddSampleTb
            // 
            this.startAddSampleTb.BackColor = System.Drawing.SystemColors.Control;
            this.startAddSampleTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.startAddSampleTb.Location = new System.Drawing.Point(136, 127);
            this.startAddSampleTb.Multiline = true;
            this.startAddSampleTb.Name = "startAddSampleTb";
            this.startAddSampleTb.Size = new System.Drawing.Size(177, 42);
            this.startAddSampleTb.TabIndex = 27;
            this.startAddSampleTb.Text = "0001";
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 410);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Usercheck);
            this.Controls.Add(this.Reservecheck);
            this.Controls.Add(this.EPCcheck);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.numStr);
            this.Controls.Add(this.NumberL);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportForm";
            this.Text = "导入数据参数设置";
            this.Load += new System.EventHandler(this.ImportForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AreaCB;
        private System.Windows.Forms.Label StartValueL;
        private System.Windows.Forms.Button resultPicL;
        private System.Windows.Forms.TextBox startStrTb;
        private System.Windows.Forms.TextBox numStr;
        private System.Windows.Forms.Label NumberL;
        private System.Windows.Forms.TextBox stepTb;
        private System.Windows.Forms.Label IncreaseL;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox Usercheck;
        private System.Windows.Forms.CheckBox Reservecheck;
        private System.Windows.Forms.CheckBox EPCcheck;
        private System.Windows.Forms.Label startAddSampleLb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label areaSampleL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox startValueTb;
        private System.Windows.Forms.TextBox startAddSampleTb;
    }
}