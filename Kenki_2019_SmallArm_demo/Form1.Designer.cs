namespace Kenki_2019_SmallArm_demo
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.Init_button = new System.Windows.Forms.Button();
            this.Write_button = new System.Windows.Forms.Button();
            this.Write_mode_checkBox = new System.Windows.Forms.CheckBox();
            this.Send_textBox = new System.Windows.Forms.TextBox();
            this.Open_button = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.servoInfo1 = new System.Windows.Forms.Label();
            this.label_TB1 = new System.Windows.Forms.Label();
            this.infoLabel1 = new System.Windows.Forms.Label();
            this.infoLabel2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Read_textBox = new System.Windows.Forms.TextBox();
            this.infoLabel3 = new System.Windows.Forms.Label();
            this.infoLabel4 = new System.Windows.Forms.Label();
            this.infoLabel5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.AM_Send_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ID1_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ID3_textBox = new System.Windows.Forms.TextBox();
            this.ID2_textBox = new System.Windows.Forms.TextBox();
            this.AMinfoLabel4 = new System.Windows.Forms.Label();
            this.Theta0_textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.AMinfoLabel6 = new System.Windows.Forms.Label();
            this.AMinfoLabel5 = new System.Windows.Forms.Label();
            this.AMinfoLabel3 = new System.Windows.Forms.Label();
            this.AMinfoLabel2 = new System.Windows.Forms.Label();
            this.AMinfoLabel1 = new System.Windows.Forms.Label();
            this.Theta2_textBox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Theta1_textBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.AllowDrop = true;
            this.trackBar1.CausesValidation = false;
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.Default;
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(19, 76);
            this.trackBar1.Maximum = 360;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 250);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickFrequency = 30;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
            // 
            // Init_button
            // 
            this.Init_button.Location = new System.Drawing.Point(638, 37);
            this.Init_button.Name = "Init_button";
            this.Init_button.Size = new System.Drawing.Size(120, 30);
            this.Init_button.TabIndex = 1;
            this.Init_button.Text = "Initialize";
            this.Init_button.UseVisualStyleBackColor = true;
            this.Init_button.Click += new System.EventHandler(this.Init_button_Click);
            // 
            // Write_button
            // 
            this.Write_button.Location = new System.Drawing.Point(622, 359);
            this.Write_button.Name = "Write_button";
            this.Write_button.Size = new System.Drawing.Size(120, 30);
            this.Write_button.TabIndex = 2;
            this.Write_button.Text = "Sync Write";
            this.Write_button.UseVisualStyleBackColor = true;
            // 
            // Write_mode_checkBox
            // 
            this.Write_mode_checkBox.AutoSize = true;
            this.Write_mode_checkBox.Location = new System.Drawing.Point(622, 329);
            this.Write_mode_checkBox.Name = "Write_mode_checkBox";
            this.Write_mode_checkBox.Size = new System.Drawing.Size(111, 16);
            this.Write_mode_checkBox.TabIndex = 3;
            this.Write_mode_checkBox.Text = "Continuous Write";
            this.Write_mode_checkBox.UseVisualStyleBackColor = true;
            // 
            // Send_textBox
            // 
            this.Send_textBox.Location = new System.Drawing.Point(50, 516);
            this.Send_textBox.Name = "Send_textBox";
            this.Send_textBox.ReadOnly = true;
            this.Send_textBox.Size = new System.Drawing.Size(443, 19);
            this.Send_textBox.TabIndex = 4;
            // 
            // Open_button
            // 
            this.Open_button.Location = new System.Drawing.Point(401, 11);
            this.Open_button.Name = "Open_button";
            this.Open_button.Size = new System.Drawing.Size(120, 20);
            this.Open_button.TabIndex = 5;
            this.Open_button.Text = "Open";
            this.Open_button.UseVisualStyleBackColor = true;
            this.Open_button.Click += new System.EventHandler(this.Open_button_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(50, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(175, 20);
            this.comboBox1.TabIndex = 6;
            // 
            // servoInfo1
            // 
            this.servoInfo1.AutoSize = true;
            this.servoInfo1.Location = new System.Drawing.Point(17, 40);
            this.servoInfo1.Name = "servoInfo1";
            this.servoInfo1.Size = new System.Drawing.Size(35, 12);
            this.servoInfo1.TabIndex = 8;
            this.servoInfo1.Text = "label1";
            // 
            // label_TB1
            // 
            this.label_TB1.AutoSize = true;
            this.label_TB1.Location = new System.Drawing.Point(17, 329);
            this.label_TB1.Name = "label_TB1";
            this.label_TB1.Size = new System.Drawing.Size(35, 12);
            this.label_TB1.TabIndex = 9;
            this.label_TB1.Text = "label2";
            // 
            // infoLabel1
            // 
            this.infoLabel1.AutoSize = true;
            this.infoLabel1.Location = new System.Drawing.Point(10, 14);
            this.infoLabel1.Name = "infoLabel1";
            this.infoLabel1.Size = new System.Drawing.Size(30, 12);
            this.infoLabel1.TabIndex = 10;
            this.infoLabel1.Text = "COM";
            this.infoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // infoLabel2
            // 
            this.infoLabel2.AutoSize = true;
            this.infoLabel2.Location = new System.Drawing.Point(231, 14);
            this.infoLabel2.Name = "infoLabel2";
            this.infoLabel2.Size = new System.Drawing.Size(57, 12);
            this.infoLabel2.TabIndex = 11;
            this.infoLabel2.Text = "Baudrate: ";
            this.infoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(285, 11);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(78, 20);
            this.comboBox2.TabIndex = 12;
            // 
            // Read_textBox
            // 
            this.Read_textBox.Location = new System.Drawing.Point(50, 541);
            this.Read_textBox.Name = "Read_textBox";
            this.Read_textBox.ReadOnly = true;
            this.Read_textBox.Size = new System.Drawing.Size(443, 19);
            this.Read_textBox.TabIndex = 13;
            // 
            // infoLabel3
            // 
            this.infoLabel3.AutoSize = true;
            this.infoLabel3.Location = new System.Drawing.Point(13, 519);
            this.infoLabel3.Name = "infoLabel3";
            this.infoLabel3.Size = new System.Drawing.Size(30, 12);
            this.infoLabel3.TabIndex = 14;
            this.infoLabel3.Text = "Send";
            this.infoLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // infoLabel4
            // 
            this.infoLabel4.AutoSize = true;
            this.infoLabel4.Location = new System.Drawing.Point(13, 544);
            this.infoLabel4.Name = "infoLabel4";
            this.infoLabel4.Size = new System.Drawing.Size(31, 12);
            this.infoLabel4.TabIndex = 15;
            this.infoLabel4.Text = "Read";
            this.infoLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // infoLabel5
            // 
            this.infoLabel5.AutoSize = true;
            this.infoLabel5.Location = new System.Drawing.Point(369, 15);
            this.infoLabel5.Name = "infoLabel5";
            this.infoLabel5.Size = new System.Drawing.Size(23, 12);
            this.infoLabel5.TabIndex = 16;
            this.infoLabel5.Text = "bps";
            this.infoLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 73);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(766, 437);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.trackBar1);
            this.tabPage1.Controls.Add(this.servoInfo1);
            this.tabPage1.Controls.Add(this.label_TB1);
            this.tabPage1.Controls.Add(this.Write_button);
            this.tabPage1.Controls.Add(this.Write_mode_checkBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(758, 411);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Servo Mover";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(319, 190);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 30);
            this.button3.TabIndex = 10;
            this.button3.Text = "Test Write";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.AM_Send_button);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.ID1_textBox);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.ID3_textBox);
            this.tabPage2.Controls.Add(this.ID2_textBox);
            this.tabPage2.Controls.Add(this.AMinfoLabel4);
            this.tabPage2.Controls.Add(this.Theta0_textBox);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.AMinfoLabel6);
            this.tabPage2.Controls.Add(this.AMinfoLabel5);
            this.tabPage2.Controls.Add(this.AMinfoLabel3);
            this.tabPage2.Controls.Add(this.AMinfoLabel2);
            this.tabPage2.Controls.Add(this.AMinfoLabel1);
            this.tabPage2.Controls.Add(this.Theta2_textBox);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.Theta1_textBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(758, 411);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Arm Mover";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // AM_Send_button
            // 
            this.AM_Send_button.Location = new System.Drawing.Point(593, 80);
            this.AM_Send_button.Name = "AM_Send_button";
            this.AM_Send_button.Size = new System.Drawing.Size(120, 67);
            this.AM_Send_button.TabIndex = 20;
            this.AM_Send_button.Text = "Sync Write";
            this.AM_Send_button.UseVisualStyleBackColor = true;
            this.AM_Send_button.Click += new System.EventHandler(this.AM_Sendbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(410, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "ID1";
            // 
            // ID1_textBox
            // 
            this.ID1_textBox.Location = new System.Drawing.Point(439, 80);
            this.ID1_textBox.Name = "ID1_textBox";
            this.ID1_textBox.ReadOnly = true;
            this.ID1_textBox.Size = new System.Drawing.Size(98, 19);
            this.ID1_textBox.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "ID3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(410, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "ID2";
            // 
            // ID3_textBox
            // 
            this.ID3_textBox.Location = new System.Drawing.Point(439, 128);
            this.ID3_textBox.Name = "ID3_textBox";
            this.ID3_textBox.ReadOnly = true;
            this.ID3_textBox.Size = new System.Drawing.Size(98, 19);
            this.ID3_textBox.TabIndex = 15;
            // 
            // ID2_textBox
            // 
            this.ID2_textBox.Location = new System.Drawing.Point(439, 105);
            this.ID2_textBox.Name = "ID2_textBox";
            this.ID2_textBox.ReadOnly = true;
            this.ID2_textBox.Size = new System.Drawing.Size(98, 19);
            this.ID2_textBox.TabIndex = 14;
            // 
            // AMinfoLabel4
            // 
            this.AMinfoLabel4.AutoSize = true;
            this.AMinfoLabel4.Location = new System.Drawing.Point(240, 83);
            this.AMinfoLabel4.Name = "AMinfoLabel4";
            this.AMinfoLabel4.Size = new System.Drawing.Size(23, 12);
            this.AMinfoLabel4.TabIndex = 13;
            this.AMinfoLabel4.Text = "θ0";
            // 
            // Theta0_textBox
            // 
            this.Theta0_textBox.Location = new System.Drawing.Point(269, 80);
            this.Theta0_textBox.Name = "Theta0_textBox";
            this.Theta0_textBox.ReadOnly = true;
            this.Theta0_textBox.Size = new System.Drawing.Size(98, 19);
            this.Theta0_textBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "label6";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 69);
            this.button1.TabIndex = 10;
            this.button1.Text = "Calc";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AMinfoLabel6
            // 
            this.AMinfoLabel6.AutoSize = true;
            this.AMinfoLabel6.Location = new System.Drawing.Point(240, 131);
            this.AMinfoLabel6.Name = "AMinfoLabel6";
            this.AMinfoLabel6.Size = new System.Drawing.Size(23, 12);
            this.AMinfoLabel6.TabIndex = 9;
            this.AMinfoLabel6.Text = "θ2";
            // 
            // AMinfoLabel5
            // 
            this.AMinfoLabel5.AutoSize = true;
            this.AMinfoLabel5.Location = new System.Drawing.Point(240, 108);
            this.AMinfoLabel5.Name = "AMinfoLabel5";
            this.AMinfoLabel5.Size = new System.Drawing.Size(23, 12);
            this.AMinfoLabel5.TabIndex = 8;
            this.AMinfoLabel5.Text = "θ1";
            // 
            // AMinfoLabel3
            // 
            this.AMinfoLabel3.AutoSize = true;
            this.AMinfoLabel3.Location = new System.Drawing.Point(34, 133);
            this.AMinfoLabel3.Name = "AMinfoLabel3";
            this.AMinfoLabel3.Size = new System.Drawing.Size(12, 12);
            this.AMinfoLabel3.TabIndex = 7;
            this.AMinfoLabel3.Text = "Z";
            // 
            // AMinfoLabel2
            // 
            this.AMinfoLabel2.AutoSize = true;
            this.AMinfoLabel2.Location = new System.Drawing.Point(34, 108);
            this.AMinfoLabel2.Name = "AMinfoLabel2";
            this.AMinfoLabel2.Size = new System.Drawing.Size(12, 12);
            this.AMinfoLabel2.TabIndex = 6;
            this.AMinfoLabel2.Text = "Y";
            // 
            // AMinfoLabel1
            // 
            this.AMinfoLabel1.AutoSize = true;
            this.AMinfoLabel1.Location = new System.Drawing.Point(34, 83);
            this.AMinfoLabel1.Name = "AMinfoLabel1";
            this.AMinfoLabel1.Size = new System.Drawing.Size(12, 12);
            this.AMinfoLabel1.TabIndex = 5;
            this.AMinfoLabel1.Text = "X";
            // 
            // Theta2_textBox
            // 
            this.Theta2_textBox.Location = new System.Drawing.Point(269, 128);
            this.Theta2_textBox.Name = "Theta2_textBox";
            this.Theta2_textBox.ReadOnly = true;
            this.Theta2_textBox.Size = new System.Drawing.Size(98, 19);
            this.Theta2_textBox.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(52, 130);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(107, 19);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "0";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(52, 105);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(107, 19);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "0";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(52, 80);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(107, 19);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "0";
            // 
            // Theta1_textBox
            // 
            this.Theta1_textBox.Location = new System.Drawing.Point(269, 105);
            this.Theta1_textBox.Name = "Theta1_textBox";
            this.Theta1_textBox.ReadOnly = true;
            this.Theta1_textBox.Size = new System.Drawing.Size(98, 19);
            this.Theta1_textBox.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(512, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 30);
            this.button2.TabIndex = 10;
            this.button2.Text = "Torque : Off";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 572);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.infoLabel5);
            this.Controls.Add(this.infoLabel4);
            this.Controls.Add(this.infoLabel3);
            this.Controls.Add(this.Read_textBox);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.Init_button);
            this.Controls.Add(this.infoLabel2);
            this.Controls.Add(this.infoLabel1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Open_button);
            this.Controls.Add(this.Send_textBox);
            this.Name = "Form1";
            this.Text = "Transfantome - Small Arm (Demo)";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button Init_button;
        private System.Windows.Forms.Button Write_button;
        private System.Windows.Forms.CheckBox Write_mode_checkBox;
        private System.Windows.Forms.TextBox Send_textBox;
        private System.Windows.Forms.Button Open_button;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label servoInfo1;
        private System.Windows.Forms.Label label_TB1;
        private System.Windows.Forms.Label infoLabel1;
        private System.Windows.Forms.Label infoLabel2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox Read_textBox;
        private System.Windows.Forms.Label infoLabel3;
        private System.Windows.Forms.Label infoLabel4;
        private System.Windows.Forms.Label infoLabel5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label AMinfoLabel6;
        private System.Windows.Forms.Label AMinfoLabel5;
        private System.Windows.Forms.Label AMinfoLabel3;
        private System.Windows.Forms.Label AMinfoLabel2;
        private System.Windows.Forms.Label AMinfoLabel1;
        private System.Windows.Forms.TextBox Theta2_textBox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox Theta1_textBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label AMinfoLabel4;
        private System.Windows.Forms.TextBox Theta0_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ID1_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ID3_textBox;
        private System.Windows.Forms.TextBox ID2_textBox;
        private System.Windows.Forms.Button AM_Send_button;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

