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
            this.checkBoxProcessMain = new System.Windows.Forms.CheckBox();
            this.checkBoxProcessGPU = new System.Windows.Forms.CheckBox();
            this.checkBoxProcessPID = new System.Windows.Forms.CheckBox();
            this.comboBoxpPocessID = new System.Windows.Forms.ComboBox();
            this.groupBoxProcOpt = new System.Windows.Forms.GroupBox();
            this.checkBoxProcessAll = new System.Windows.Forms.CheckBox();
            this.groupBoxProcOpt.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(17, 142);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 28);
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
            this.eLog.Location = new System.Drawing.Point(16, 177);
            this.eLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.eLog.Multiline = true;
            this.eLog.Name = "eLog";
            this.eLog.ReadOnly = true;
            this.eLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eLog.Size = new System.Drawing.Size(576, 228);
            this.eLog.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBoxProcessMain
            // 
            this.checkBoxProcessMain.AutoSize = true;
            this.checkBoxProcessMain.Location = new System.Drawing.Point(16, 28);
            this.checkBoxProcessMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxProcessMain.Name = "checkBoxProcessMain";
            this.checkBoxProcessMain.Size = new System.Drawing.Size(145, 21);
            this.checkBoxProcessMain.TabIndex = 2;
            this.checkBoxProcessMain.Text = "Главный процесс";
            this.checkBoxProcessMain.UseVisualStyleBackColor = true;
            // 
            // checkBoxProcessGPU
            // 
            this.checkBoxProcessGPU.AutoSize = true;
            this.checkBoxProcessGPU.Location = new System.Drawing.Point(188, 28);
            this.checkBoxProcessGPU.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxProcessGPU.Name = "checkBoxProcessGPU";
            this.checkBoxProcessGPU.Size = new System.Drawing.Size(118, 21);
            this.checkBoxProcessGPU.TabIndex = 3;
            this.checkBoxProcessGPU.Text = "GPU процесс";
            this.checkBoxProcessGPU.UseVisualStyleBackColor = true;
            // 
            // checkBoxProcessPID
            // 
            this.checkBoxProcessPID.AutoSize = true;
            this.checkBoxProcessPID.Location = new System.Drawing.Point(16, 57);
            this.checkBoxProcessPID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxProcessPID.Name = "checkBoxProcessPID";
            this.checkBoxProcessPID.Size = new System.Drawing.Size(118, 21);
            this.checkBoxProcessPID.TabIndex = 4;
            this.checkBoxProcessPID.Text = "PID процесса";
            this.checkBoxProcessPID.UseVisualStyleBackColor = true;
            this.checkBoxProcessPID.CheckedChanged += new System.EventHandler(this.checkBoxPID_CheckedChanged);
            // 
            // comboBoxpPocessID
            // 
            this.comboBoxpPocessID.Enabled = false;
            this.comboBoxpPocessID.FormattingEnabled = true;
            this.comboBoxpPocessID.Location = new System.Drawing.Point(152, 57);
            this.comboBoxpPocessID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxpPocessID.Name = "comboBoxpPocessID";
            this.comboBoxpPocessID.Size = new System.Drawing.Size(160, 24);
            this.comboBoxpPocessID.TabIndex = 5;
            // 
            // groupBoxProcOpt
            // 
            this.groupBoxProcOpt.Controls.Add(this.comboBoxpPocessID);
            this.groupBoxProcOpt.Controls.Add(this.checkBoxProcessMain);
            this.groupBoxProcOpt.Controls.Add(this.checkBoxProcessPID);
            this.groupBoxProcOpt.Controls.Add(this.checkBoxProcessGPU);
            this.groupBoxProcOpt.Location = new System.Drawing.Point(16, 43);
            this.groupBoxProcOpt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxProcOpt.Name = "groupBoxProcOpt";
            this.groupBoxProcOpt.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxProcOpt.Size = new System.Drawing.Size(577, 91);
            this.groupBoxProcOpt.TabIndex = 6;
            this.groupBoxProcOpt.TabStop = false;
            this.groupBoxProcOpt.Text = "Выборочно";
            // 
            // checkBoxProcessAll
            // 
            this.checkBoxProcessAll.AutoSize = true;
            this.checkBoxProcessAll.Location = new System.Drawing.Point(17, 16);
            this.checkBoxProcessAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxProcessAll.Name = "checkBoxProcessAll";
            this.checkBoxProcessAll.Size = new System.Drawing.Size(239, 21);
            this.checkBoxProcessAll.TabIndex = 7;
            this.checkBoxProcessAll.Text = "Все процессы браузера (долго)";
            this.checkBoxProcessAll.UseVisualStyleBackColor = true;
            this.checkBoxProcessAll.CheckedChanged += new System.EventHandler(this.checkBoxProcAll_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 421);
            this.Controls.Add(this.checkBoxProcessAll);
            this.Controls.Add(this.groupBoxProcOpt);
            this.Controls.Add(this.eLog);
            this.Controls.Add(this.btnStart);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.CheckBox checkBoxProcessMain;
        private System.Windows.Forms.CheckBox checkBoxProcessGPU;
        private System.Windows.Forms.CheckBox checkBoxProcessPID;
        private System.Windows.Forms.ComboBox comboBoxpPocessID;
        private System.Windows.Forms.GroupBox groupBoxProcOpt;
        private System.Windows.Forms.CheckBox checkBoxProcessAll;
    }
}

