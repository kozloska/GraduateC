namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbSpreading = new System.Windows.Forms.TrackBar();
            this.tbDirection = new System.Windows.Forms.TrackBar();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLife = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRadiusPortal = new System.Windows.Forms.TrackBar();
            this.lblDirection = new System.Windows.Forms.Label();
            this.lblSpreading = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblLife = new System.Windows.Forms.Label();
            this.lblRadiusPortal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTick = new System.Windows.Forms.Label();
            this.tbTick = new System.Windows.Forms.TrackBar();
            this.button3 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lblY = new System.Windows.Forms.Label();
            this.tbY = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpreading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLife)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRadiusPortal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbY)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(12, 50);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(746, 615);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.Click += new System.EventHandler(this.pictureBox1_Click);
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbSpreading
            // 
            this.tbSpreading.Location = new System.Drawing.Point(779, 158);
            this.tbSpreading.Maximum = 359;
            this.tbSpreading.Name = "tbSpreading";
            this.tbSpreading.Size = new System.Drawing.Size(137, 56);
            this.tbSpreading.TabIndex = 1;
            this.tbSpreading.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // tbDirection
            // 
            this.tbDirection.Location = new System.Drawing.Point(779, 79);
            this.tbDirection.Maximum = 359;
            this.tbDirection.Name = "tbDirection";
            this.tbDirection.Size = new System.Drawing.Size(137, 56);
            this.tbDirection.TabIndex = 3;
            this.tbDirection.Scroll += new System.EventHandler(this.trackBar1_Scroll_1);
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(779, 240);
            this.tbSpeed.Maximum = 50;
            this.tbSpeed.Minimum = 1;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(137, 56);
            this.tbSpeed.TabIndex = 4;
            this.tbSpeed.Value = 10;
            this.tbSpeed.Scroll += new System.EventHandler(this.trackBar1_Scroll_2);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "Задание 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(200, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 31);
            this.button2.TabIndex = 6;
            this.button2.Text = "Задание 2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(388, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(182, 32);
            this.button4.TabIndex = 7;
            this.button4.Text = "Задание 4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(576, 13);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(182, 31);
            this.button5.TabIndex = 8;
            this.button5.Text = "Задание 5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Broadway", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(774, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "Направление";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Broadway", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(774, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 26);
            this.label3.TabIndex = 11;
            this.label3.Text = "Разброс";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Broadway", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(774, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 26);
            this.label2.TabIndex = 12;
            this.label2.Text = "Скорость";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Broadway", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(774, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 26);
            this.label4.TabIndex = 13;
            this.label4.Text = "Время жизни";
            // 
            // tbLife
            // 
            this.tbLife.Location = new System.Drawing.Point(779, 317);
            this.tbLife.Maximum = 160;
            this.tbLife.Minimum = 40;
            this.tbLife.Name = "tbLife";
            this.tbLife.Size = new System.Drawing.Size(137, 56);
            this.tbLife.TabIndex = 14;
            this.tbLife.Value = 40;
            this.tbLife.Scroll += new System.EventHandler(this.trackBar1_Scroll_3);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Broadway", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(775, 512);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 26);
            this.label5.TabIndex = 15;
            this.label5.Text = "Радиус круга";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // tbRadiusPortal
            // 
            this.tbRadiusPortal.Location = new System.Drawing.Point(780, 541);
            this.tbRadiusPortal.Maximum = 80;
            this.tbRadiusPortal.Minimum = 20;
            this.tbRadiusPortal.Name = "tbRadiusPortal";
            this.tbRadiusPortal.Size = new System.Drawing.Size(140, 56);
            this.tbRadiusPortal.TabIndex = 16;
            this.tbRadiusPortal.Value = 20;
            this.tbRadiusPortal.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(992, 58);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(14, 16);
            this.lblDirection.TabIndex = 17;
            this.lblDirection.Text = "0";
            // 
            // lblSpreading
            // 
            this.lblSpreading.AutoSize = true;
            this.lblSpreading.Location = new System.Drawing.Point(992, 139);
            this.lblSpreading.Name = "lblSpreading";
            this.lblSpreading.Size = new System.Drawing.Size(14, 16);
            this.lblSpreading.TabIndex = 18;
            this.lblSpreading.Text = "0";
            this.lblSpreading.Click += new System.EventHandler(this.label6_Click);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(992, 219);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(14, 16);
            this.lblSpeed.TabIndex = 19;
            this.lblSpeed.Text = "0";
            // 
            // lblLife
            // 
            this.lblLife.AutoSize = true;
            this.lblLife.Location = new System.Drawing.Point(992, 296);
            this.lblLife.Name = "lblLife";
            this.lblLife.Size = new System.Drawing.Size(14, 16);
            this.lblLife.TabIndex = 20;
            this.lblLife.Text = "0";
            // 
            // lblRadiusPortal
            // 
            this.lblRadiusPortal.AutoSize = true;
            this.lblRadiusPortal.Location = new System.Drawing.Point(992, 522);
            this.lblRadiusPortal.Name = "lblRadiusPortal";
            this.lblRadiusPortal.Size = new System.Drawing.Size(14, 16);
            this.lblRadiusPortal.TabIndex = 21;
            this.lblRadiusPortal.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Broadway", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(775, 367);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(204, 26);
            this.label6.TabIndex = 22;
            this.label6.Text = "Количество частиц";
            this.label6.Click += new System.EventHandler(this.label6_Click_1);
            // 
            // lblTick
            // 
            this.lblTick.AutoSize = true;
            this.lblTick.Location = new System.Drawing.Point(992, 375);
            this.lblTick.Name = "lblTick";
            this.lblTick.Size = new System.Drawing.Size(14, 16);
            this.lblTick.TabIndex = 23;
            this.lblTick.Text = "0";
            // 
            // tbTick
            // 
            this.tbTick.Location = new System.Drawing.Point(780, 397);
            this.tbTick.Minimum = 1;
            this.tbTick.Name = "tbTick";
            this.tbTick.Size = new System.Drawing.Size(126, 56);
            this.tbTick.TabIndex = 24;
            this.tbTick.Value = 1;
            this.tbTick.Scroll += new System.EventHandler(this.tbTick_Scroll);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(780, 437);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(226, 63);
            this.button3.TabIndex = 25;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_2);
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Font = new System.Drawing.Font("Broadway", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY.Location = new System.Drawing.Point(777, 580);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(143, 26);
            this.lblY.TabIndex = 26;
            this.lblY.Text = "Направление";
            this.lblY.Visible = false;
            this.lblY.Click += new System.EventHandler(this.label7_Click);
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(780, 609);
            this.tbY.Maximum = 450;
            this.tbY.Minimum = 50;
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(140, 56);
            this.tbY.TabIndex = 27;
            this.tbY.Value = 50;
            this.tbY.Visible = false;
            this.tbY.Scroll += new System.EventHandler(this.tbY_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 685);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tbTick);
            this.Controls.Add(this.lblTick);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblRadiusPortal);
            this.Controls.Add(this.lblLife);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.lblSpreading);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.tbRadiusPortal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbLife);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbSpeed);
            this.Controls.Add(this.tbDirection);
            this.Controls.Add(this.tbSpreading);
            this.Controls.Add(this.picDisplay);
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpreading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLife)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRadiusPortal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar tbSpreading;
        private System.Windows.Forms.TrackBar tbDirection;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tbLife;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar tbRadiusPortal;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.Label lblSpreading;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblLife;
        private System.Windows.Forms.Label lblRadiusPortal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTick;
        private System.Windows.Forms.TrackBar tbTick;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.TrackBar tbY;
    }
}

