namespace Application_desktop
{
    partial class AddGroupForm
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
            labTitle = new Label();
            labCycle = new Label();
            labSection = new Label();
            labSubSection = new Label();
            textBoxCycle = new TextBox();
            textBoxSection = new TextBox();
            textBoxSubSection = new TextBox();
            butValidate = new Button();
            SuspendLayout();
            // 
            // labTitle
            // 
            labTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            labTitle.Location = new Point(600, 50);
            labTitle.Name = "labtitle";
            labTitle.Size = new Size(300, 50);
            labTitle.TabIndex = 0;
            labTitle.Text = "Ajoutez un groupe";
            labTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labCycle
            // 
            labCycle.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labCycle.Location = new Point(600, 150);
            labCycle.Name = "labcycle";
            labCycle.Size = new Size(300, 50);
            labCycle.TabIndex = 0;
            labCycle.Text = "Cycle";
            labCycle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labSection
            // 
            labSection.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labSection.Location = new Point(600, 300);
            labSection.Name = "labsection";
            labSection.Size = new Size(300, 50);
            labSection.TabIndex = 0;
            labSection.Text = "Section";
            labSection.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labSubSection
            // 
            labSubSection.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labSubSection.Location = new Point(600, 450);
            labSubSection.Name = "labsubsection";
            labSubSection.Size = new Size(300, 50);
            labSubSection.TabIndex = 0;
            labSubSection.Text = "Sous section";
            labSubSection.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxcycle
            // 
            textBoxCycle.Location = new Point(600, 200);
            textBoxCycle.Name = "textBoxcycle";
            textBoxCycle.Size = new Size(300, 31);
            textBoxCycle.TabIndex = 2;
            // 
            // textBoxSection
            // 
            textBoxSection.Location = new Point(600, 350);
            textBoxSection.Name = "textBoxsection";
            textBoxSection.Size = new Size(300, 31);
            textBoxSection.TabIndex = 4;
            // 
            // textBoxSubSection
            // 
            textBoxSubSection.Location = new Point(600, 500);
            textBoxSubSection.Name = "textBoxsubsection";
            textBoxSubSection.Size = new Size(300, 31);
            textBoxSubSection.TabIndex = 6;
            // 
            // butValidate
            // 
            butValidate.Location = new Point(600, 600);
            butValidate.Name = "butvalidate";
            butValidate.Size = new Size(300, 50);
            butValidate.TabIndex = 7;
            butValidate.Text = "Ajouter";
            butValidate.UseVisualStyleBackColor = true;
            butValidate.Click += butValidate_Click;
            // 
            // AddStudent
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1500, 700);
            Controls.Add(butValidate);
            Controls.Add(textBoxCycle);
            Controls.Add(textBoxSection);
            Controls.Add(textBoxSubSection);
            Controls.Add(labTitle);
            Controls.Add(labCycle);
            Controls.Add(labSubSection);
            Controls.Add(labSection);
            Name = "AddStudent";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddStudent";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labTitle;
        private Label labCycle;
        private Label labSection;
        private Label labSubSection;
        private TextBox textBoxCycle;
        private TextBox textBoxSection;
        private TextBox textBoxSubSection;
        private Button butValidate;
    }
}