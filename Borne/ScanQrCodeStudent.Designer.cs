namespace Borne
{
    partial class ScanQrCodeStudent
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            cmbBox = new ComboBox();
            pictureBox = new PictureBox();
            label = new Label();
            button = new Button();
            textBox = new TextBox();
            timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // cmbBox
            // 
            cmbBox.FormattingEnabled = true;
            cmbBox.Location = new Point(429, 83);
            cmbBox.Margin = new Padding(4, 5, 4, 5);
            cmbBox.Name = "cmbBox";
            cmbBox.Size = new Size(427, 33);
            cmbBox.TabIndex = 0;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(286, 208);
            pictureBox.Margin = new Padding(4, 5, 4, 5);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(714, 500);
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(267, 91);
            label.Name = "label";
            label.Size = new Size(72, 25);
            label.TabIndex = 2;
            label.Text = "Caméra";
            // 
            // button
            // 
            button.Location = new Point(1071, 86);
            button.Name = "button";
            button.Size = new Size(112, 34);
            button.TabIndex = 3;
            button.Text = "Scan";
            button.UseVisualStyleBackColor = true;
            button.Click += button_Click;
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // ScanQrCodeStudent
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1263, 768);
            Controls.Add(button);
            Controls.Add(label);
            Controls.Add(pictureBox);
            Controls.Add(cmbBox);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ScanQrCodeStudent";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Borne";
            FormClosing += ScanQrCodeStudent_FormClosing;
            Load += ScanQrCodeStudent_load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbBox;
        private PictureBox pictureBox;
        private Label label;
        private Button button;
        private TextBox textBox;
        private System.Windows.Forms.Timer timer;
    }
}