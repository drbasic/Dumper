namespace Dumper
{
    partial class FormMain
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
            this.btnStart = new System.Windows.Forms.Button();
            this.eLog = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBoxProcMain = new System.Windows.Forms.CheckBox();
            this.checkBoxProcGPU = new System.Windows.Forms.CheckBox();
            this.checkBoxProcPID = new System.Windows.Forms.CheckBox();
            this.comboBoxSetPID = new System.Windows.Forms.ComboBox();
            this.groupBoxProcOpt = new System.Windows.Forms.GroupBox();
            this.checkBoxProcAll = new System.Windows.Forms.CheckBox();
            this.groupBoxProcOpt.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 130);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Поехали!";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // eLog
            // 
            this.eLog.AcceptsReturn = true;
            this.eLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eLog.Location = new System.Drawing.Point(12, 159);
            this.eLog.Multiline = true;
            this.eLog.Name = "eLog";
            this.eLog.ReadOnly = true;
            this.eLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eLog.Size = new System.Drawing.Size(433, 171);
            this.eLog.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBoxProcMain
            // 
            this.checkBoxProcMain.AutoSize = true;
            this.checkBoxProcMain.Location = new System.Drawing.Point(12, 23);
            this.checkBoxProcMain.Name = "checkBoxProcMain";
            this.checkBoxProcMain.Size = new System.Drawing.Size(115, 17);
            this.checkBoxProcMain.TabIndex = 2;
            this.checkBoxProcMain.Text = "Главный процесс";
            this.checkBoxProcMain.UseVisualStyleBackColor = true;
            // 
            // checkBoxProcGPU
            // 
            this.checkBoxProcGPU.AutoSize = true;
            this.checkBoxProcGPU.Location = new System.Drawing.Point(141, 23);
            this.checkBoxProcGPU.Name = "checkBoxProcGPU";
            this.checkBoxProcGPU.Size = new System.Drawing.Size(94, 17);
            this.checkBoxProcGPU.TabIndex = 3;
            this.checkBoxProcGPU.Text = "GPU процесс";
            this.checkBoxProcGPU.UseVisualStyleBackColor = true;
            // 
            // checkBoxProcPID
            // 
            this.checkBoxProcPID.AutoSize = true;
            this.checkBoxProcPID.Location = new System.Drawing.Point(12, 46);
            this.checkBoxProcPID.Name = "checkBoxProcPID";
            this.checkBoxProcPID.Size = new System.Drawing.Size(95, 17);
            this.checkBoxProcPID.TabIndex = 4;
            this.checkBoxProcPID.Text = "PID процесса";
            this.checkBoxProcPID.UseVisualStyleBackColor = true;
            this.checkBoxProcPID.CheckedChanged += new System.EventHandler(this.checkBoxPID_CheckedChanged);
            // 
            // comboBoxSetPID
            // 
            this.comboBoxSetPID.Enabled = false;
            this.comboBoxSetPID.FormattingEnabled = true;
            this.comboBoxSetPID.Location = new System.Drawing.Point(114, 46);
            this.comboBoxSetPID.Name = "comboBoxSetPID";
            this.comboBoxSetPID.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSetPID.TabIndex = 5;
            // 
            // groupBoxProcOpt
            // 
            this.groupBoxProcOpt.Controls.Add(this.comboBoxSetPID);
            this.groupBoxProcOpt.Controls.Add(this.checkBoxProcMain);
            this.groupBoxProcOpt.Controls.Add(this.checkBoxProcPID);
            this.groupBoxProcOpt.Controls.Add(this.checkBoxProcGPU);
            this.groupBoxProcOpt.Location = new System.Drawing.Point(12, 35);
            this.groupBoxProcOpt.Name = "groupBoxProcOpt";
            this.groupBoxProcOpt.Size = new System.Drawing.Size(433, 89);
            this.groupBoxProcOpt.TabIndex = 6;
            this.groupBoxProcOpt.TabStop = false;
            this.groupBoxProcOpt.Text = "Выборочно";
            // 
            // checkBoxProcAll
            // 
            this.checkBoxProcAll.AutoSize = true;
            this.checkBoxProcAll.Location = new System.Drawing.Point(13, 13);
            this.checkBoxProcAll.Name = "checkBoxProcAll";
            this.checkBoxProcAll.Size = new System.Drawing.Size(148, 17);
            this.checkBoxProcAll.TabIndex = 7;
            this.checkBoxProcAll.Text = "Все процессы браузера";
            this.checkBoxProcAll.UseVisualStyleBackColor = true;
            this.checkBoxProcAll.CheckedChanged += new System.EventHandler(this.checkBoxProcAll_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 342);
            this.Controls.Add(this.checkBoxProcAll);
            this.Controls.Add(this.groupBoxProcOpt);
            this.Controls.Add(this.eLog);
            this.Controls.Add(this.btnStart);
            this.Name = "FormMain";
            this.Text = "Утилита для снятия дампов процессов с Yandex.Browser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.groupBoxProcOpt.ResumeLayout(false);
            this.groupBoxProcOpt.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox eLog;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBoxProcMain;
        private System.Windows.Forms.CheckBox checkBoxProcGPU;
        private System.Windows.Forms.CheckBox checkBoxProcPID;
        private System.Windows.Forms.ComboBox comboBoxSetPID;
        private System.Windows.Forms.GroupBox groupBoxProcOpt;
        private System.Windows.Forms.CheckBox checkBoxProcAll;
    }
}

