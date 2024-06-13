namespace Application_desktop
{
    partial class AddStudent
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
            labName = new Label();
            labFirstname = new Label();
            labClass = new Label();
            textBoxName = new TextBox();
            textBoxFirstname = new TextBox();
            textBoxGroup = new TextBox();
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
            labTitle.Text = "Ajoutez un élève";
            labTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labName
            // 
            labName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labName.Location = new Point(600, 150);
            labName.Name = "labname";
            labName.Size = new Size(300, 50);
            labName.TabIndex = 0;
            labName.Text = "Nom";
            labName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labFirstname
            // 
            labFirstname.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labFirstname.Location = new Point(600, 300);
            labFirstname.Name = "labfirstname";
            labFirstname.Size = new Size(300, 50);
            labFirstname.TabIndex = 0;
            labFirstname.Text = "Prénom";
            labFirstname.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labClass
            // 
            labClass.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labClass.Location = new Point(600, 450);
            labClass.Name = "labclass";
            labClass.Size = new Size(300, 50);
            labClass.TabIndex = 0;
            labClass.Text = "Groupe";
            labClass.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(600, 200);
            textBoxName.Name = "textBoxname";
            textBoxName.Size = new Size(300, 31);
            textBoxName.TabIndex = 2;
            // 
            // textBoxFirstname
            // 
            textBoxFirstname.Location = new Point(600, 350);
            textBoxFirstname.Name = "textBoxfirstname";
            textBoxFirstname.Size = new Size(300, 31);
            textBoxFirstname.TabIndex = 4;
            // 
            // textBoxClass
            // 
            textBoxGroup.Location = new Point(600, 500);
            textBoxGroup.Name = "textBoxclass";
            textBoxGroup.Size = new Size(300, 31);
            textBoxGroup.TabIndex = 6;
            // 
            // butValidate
            // 
            butValidate.Location = new Point(600, 600);
            butValidate.Name = "butvalidate";
            butValidate.Size = new Size(300, 50);
            butValidate.TabIndex = 7;
            butValidate.Text = "Ajouter";
            butValidate.UseVisualStyleBackColor = true;
            butValidate.Click += butvalidate_Click;
            // 
            // AddStudent
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1500, 700);
            Controls.Add(butValidate);
            Controls.Add(textBoxName);
            Controls.Add(textBoxFirstname);
            Controls.Add(textBoxGroup);
            Controls.Add(labTitle);
            Controls.Add(labName);
            Controls.Add(labClass);
            Controls.Add(labFirstname);
            Name = "AddStudent";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddStudent";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labTitle;
        private Label labName;
        private Label labFirstname;
        private Label labClass;
        private TextBox textBoxName;
        private TextBox textBoxFirstname;
        private TextBox textBoxGroup;
        private Button butValidate;
    }
}