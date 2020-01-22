namespace VRS_Projekt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.modeButton1 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mode1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mode2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mode3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.liveByte = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.notepadRadioButton = new System.Windows.Forms.RadioButton();
            this.switchRadioButton = new System.Windows.Forms.RadioButton();
            this.closeRadioButton = new System.Windows.Forms.RadioButton();
            this.modeButton2 = new System.Windows.Forms.Button();
            this.modeButton3 = new System.Windows.Forms.Button();
            this.graphButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.messageQueue1 = new System.Messaging.MessageQueue();
            this.horizontalGain = new System.Windows.Forms.TrackBar();
            this.verticalGain = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalGain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verticalGain)).BeginInit();
            this.SuspendLayout();
            // 
            // modeButton1
            // 
            this.modeButton1.BackColor = System.Drawing.SystemColors.Control;
            this.modeButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modeButton1.Font = new System.Drawing.Font("Roboto", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modeButton1.Location = new System.Drawing.Point(21, 28);
            this.modeButton1.Margin = new System.Windows.Forms.Padding(6);
            this.modeButton1.Name = "modeButton1";
            this.modeButton1.Size = new System.Drawing.Size(162, 27);
            this.modeButton1.TabIndex = 0;
            this.modeButton1.Text = "Cursor mode";
            this.modeButton1.UseVisualStyleBackColor = false;
            this.modeButton1.Click += new System.EventHandler(this.changeMode_click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "App is running";
            this.notifyIcon1.BalloonTipTitle = "Gesture recognition";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Gesture recognition";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationToolStripMenuItem,
            this.mode1ToolStripMenuItem,
            this.mode2ToolStripMenuItem,
            this.mode3ToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(220, 154);
            // 
            // showApplicationToolStripMenuItem
            // 
            this.showApplicationToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showApplicationToolStripMenuItem.Name = "showApplicationToolStripMenuItem";
            this.showApplicationToolStripMenuItem.Size = new System.Drawing.Size(219, 30);
            this.showApplicationToolStripMenuItem.Text = "Show application";
            this.showApplicationToolStripMenuItem.Click += new System.EventHandler(this.showApplicationToolStripMenuItem_Click);
            // 
            // mode1ToolStripMenuItem
            // 
            this.mode1ToolStripMenuItem.Name = "mode1ToolStripMenuItem";
            this.mode1ToolStripMenuItem.Size = new System.Drawing.Size(219, 30);
            this.mode1ToolStripMenuItem.Text = "Cursor mode";
            this.mode1ToolStripMenuItem.Click += new System.EventHandler(this.changeMode_click);
            // 
            // mode2ToolStripMenuItem
            // 
            this.mode2ToolStripMenuItem.Name = "mode2ToolStripMenuItem";
            this.mode2ToolStripMenuItem.Size = new System.Drawing.Size(219, 30);
            this.mode2ToolStripMenuItem.Text = "User mode";
            this.mode2ToolStripMenuItem.Click += new System.EventHandler(this.changeMode_click);
            // 
            // mode3ToolStripMenuItem
            // 
            this.mode3ToolStripMenuItem.Name = "mode3ToolStripMenuItem";
            this.mode3ToolStripMenuItem.Size = new System.Drawing.Size(219, 30);
            this.mode3ToolStripMenuItem.Text = "Fast action";
            this.mode3ToolStripMenuItem.Click += new System.EventHandler(this.changeMode_click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(219, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitApp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.liveByte);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(32, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 53);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial communication";
            // 
            // liveByte
            // 
            this.liveByte.AutoSize = true;
            this.liveByte.Location = new System.Drawing.Point(112, 23);
            this.liveByte.Name = "liveByte";
            this.liveByte.Size = new System.Drawing.Size(143, 34);
            this.liveByte.TabIndex = 10;
            this.liveByte.Text = "00000000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 34);
            this.label1.TabIndex = 9;
            this.label1.Text = "Live byte";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.notepadRadioButton);
            this.groupBox2.Controls.Add(this.switchRadioButton);
            this.groupBox2.Controls.Add(this.closeRadioButton);
            this.groupBox2.Controls.Add(this.modeButton2);
            this.groupBox2.Controls.Add(this.modeButton1);
            this.groupBox2.Controls.Add(this.modeButton3);
            this.groupBox2.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(32, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(202, 236);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mode selection";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 34;
            this.comboBox1.Items.AddRange(new object[] {
            "Notepad",
            "Microsoft Edge",
            "Paint",
            "This PC"});
            this.comboBox1.Location = new System.Drawing.Point(41, 200);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(131, 42);
            this.comboBox1.TabIndex = 17;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // notepadRadioButton
            // 
            this.notepadRadioButton.AutoSize = true;
            this.notepadRadioButton.Location = new System.Drawing.Point(21, 206);
            this.notepadRadioButton.Name = "notepadRadioButton";
            this.notepadRadioButton.Size = new System.Drawing.Size(21, 20);
            this.notepadRadioButton.TabIndex = 5;
            this.notepadRadioButton.UseVisualStyleBackColor = true;
            this.notepadRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // switchRadioButton
            // 
            this.switchRadioButton.AutoSize = true;
            this.switchRadioButton.Checked = true;
            this.switchRadioButton.Location = new System.Drawing.Point(21, 172);
            this.switchRadioButton.Name = "switchRadioButton";
            this.switchRadioButton.Size = new System.Drawing.Size(269, 38);
            this.switchRadioButton.TabIndex = 4;
            this.switchRadioButton.TabStop = true;
            this.switchRadioButton.Text = "Switch application";
            this.switchRadioButton.UseVisualStyleBackColor = true;
            this.switchRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // closeRadioButton
            // 
            this.closeRadioButton.AutoSize = true;
            this.closeRadioButton.Location = new System.Drawing.Point(21, 143);
            this.closeRadioButton.Name = "closeRadioButton";
            this.closeRadioButton.Size = new System.Drawing.Size(255, 38);
            this.closeRadioButton.TabIndex = 3;
            this.closeRadioButton.Text = "Close application";
            this.closeRadioButton.UseVisualStyleBackColor = true;
            this.closeRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // modeButton2
            // 
            this.modeButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modeButton2.Font = new System.Drawing.Font("Roboto", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modeButton2.Location = new System.Drawing.Point(21, 67);
            this.modeButton2.Margin = new System.Windows.Forms.Padding(6);
            this.modeButton2.Name = "modeButton2";
            this.modeButton2.Size = new System.Drawing.Size(162, 27);
            this.modeButton2.TabIndex = 1;
            this.modeButton2.Text = "User mode";
            this.modeButton2.UseVisualStyleBackColor = true;
            this.modeButton2.Click += new System.EventHandler(this.changeMode_click);
            // 
            // modeButton3
            // 
            this.modeButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modeButton3.Font = new System.Drawing.Font("Roboto", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modeButton3.Location = new System.Drawing.Point(21, 106);
            this.modeButton3.Margin = new System.Windows.Forms.Padding(6);
            this.modeButton3.Name = "modeButton3";
            this.modeButton3.Size = new System.Drawing.Size(162, 27);
            this.modeButton3.TabIndex = 2;
            this.modeButton3.Text = "Fast action";
            this.modeButton3.UseVisualStyleBackColor = true;
            this.modeButton3.Click += new System.EventHandler(this.changeMode_click);
            // 
            // graphButton
            // 
            this.graphButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.graphButton.Font = new System.Drawing.Font("Roboto", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphButton.Location = new System.Drawing.Point(416, 299);
            this.graphButton.Margin = new System.Windows.Forms.Padding(6);
            this.graphButton.Name = "graphButton";
            this.graphButton.Size = new System.Drawing.Size(87, 27);
            this.graphButton.TabIndex = 4;
            this.graphButton.Text = "Show data";
            this.graphButton.UseVisualStyleBackColor = true;
            this.graphButton.Click += new System.EventHandler(this.showGraphButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Roboto", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(317, 299);
            this.exitButton.Margin = new System.Windows.Forms.Padding(6);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(87, 27);
            this.exitButton.TabIndex = 10;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitApp);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(259, 25);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(308, 142);
            this.textBox1.TabIndex = 11;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineWidth = 0;
            chartArea1.AxisX.Maximum = 15D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "Time [s]";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.Maximum = 4000D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "Distance [mm]";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 335);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Sensor_1";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Sensor_2";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Sensor_3";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Sensor_4";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(555, 313);
            this.chart1.TabIndex = 12;
            this.chart1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Distances";
            this.chart1.Titles.Add(title1);
            this.chart1.Visible = false;
            // 
            // messageQueue1
            // 
            this.messageQueue1.MessageReadPropertyFilter.LookupId = true;
            this.messageQueue1.SynchronizingObject = this;
            // 
            // horizontalGain
            // 
            this.horizontalGain.Location = new System.Drawing.Point(323, 205);
            this.horizontalGain.Maximum = 5;
            this.horizontalGain.Minimum = 1;
            this.horizontalGain.Name = "horizontalGain";
            this.horizontalGain.Size = new System.Drawing.Size(180, 80);
            this.horizontalGain.TabIndex = 13;
            this.horizontalGain.Value = 1;
            this.horizontalGain.Scroll += new System.EventHandler(this.horizontalGain_Scroll);
            // 
            // verticalGain
            // 
            this.verticalGain.Location = new System.Drawing.Point(323, 266);
            this.verticalGain.Maximum = 5;
            this.verticalGain.Minimum = 1;
            this.verticalGain.Name = "verticalGain";
            this.verticalGain.Size = new System.Drawing.Size(180, 80);
            this.verticalGain.TabIndex = 14;
            this.verticalGain.Value = 1;
            this.verticalGain.Scroll += new System.EventHandler(this.verticalGain_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(259, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(359, 34);
            this.label2.TabIndex = 15;
            this.label2.Text = "Horizontal cursor sensitivity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(259, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(326, 34);
            this.label3.TabIndex = 16;
            this.label3.Text = "Vertical cursor sensitivity";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(579, 653);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.graphButton);
            this.Controls.Add(this.verticalGain);
            this.Controls.Add(this.horizontalGain);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Gesture recognition";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalGain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verticalGain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button modeButton1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mode1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mode2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mode3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label liveByte;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button modeButton2;
        private System.Windows.Forms.Button modeButton3;
        private System.Windows.Forms.Button graphButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Messaging.MessageQueue messageQueue1;
        private System.Windows.Forms.TrackBar horizontalGain;
        private System.Windows.Forms.TrackBar verticalGain;
        private System.Windows.Forms.RadioButton notepadRadioButton;
        private System.Windows.Forms.RadioButton switchRadioButton;
        private System.Windows.Forms.RadioButton closeRadioButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

