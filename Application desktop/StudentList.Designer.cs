using System.Windows.Forms;

namespace Application_desktop
{
    partial class StudentList
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
            dataGridView = new DataGridView();
            dataGridViewTextBoxColumnId = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumnName = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumnFirstname = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumnClass = new DataGridViewTextBoxColumn();
            butColumnEdit = new DataGridViewButtonColumn();
            butColumnDelete = new DataGridViewButtonColumn();
            labTitle = new Label();
            butAdd = new Button();
            butRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumnId, dataGridViewTextBoxColumnName, dataGridViewTextBoxColumnFirstname, dataGridViewTextBoxColumnClass, butColumnEdit, butColumnDelete });
            dataGridView.Location = new Point(210, 200);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 62;
            dataGridView.Size = new Size(1500, 700);
            dataGridView.TabIndex = 2;
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            // 
            // dataGridViewTextBoxColumn
            // 
            dataGridViewTextBoxColumnId.HeaderText = "Id élève";
            dataGridViewTextBoxColumnId.MinimumWidth = 8;
            dataGridViewTextBoxColumnId.Name = "dataGridViewTextBoxColumnId";
            dataGridViewTextBoxColumnId.Width = 170;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumnName.HeaderText = "Nom";
            dataGridViewTextBoxColumnName.MinimumWidth = 8;
            dataGridViewTextBoxColumnName.Name = "dataGridViewTextBoxColumnName";
            dataGridViewTextBoxColumnName.Width = 280;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumnFirstname.HeaderText = "Prénom";
            dataGridViewTextBoxColumnFirstname.MinimumWidth = 8;
            dataGridViewTextBoxColumnFirstname.Name = "dataGridViewTextBoxColumnFirstname";
            dataGridViewTextBoxColumnFirstname.Width = 280;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumnClass.HeaderText = "Groupe";
            dataGridViewTextBoxColumnClass.MinimumWidth = 8;
            dataGridViewTextBoxColumnClass.Name = "dataGridViewTextBoxColumnClass";
            dataGridViewTextBoxColumnClass.Width = 275;
            // 
            // butColumnEdit
            // 
            butColumnEdit.MinimumWidth = 8;
            butColumnEdit.Name = " ";
            butColumnEdit.Text = "Modifier";
            butColumnEdit.UseColumnTextForButtonValue = true;
            butColumnEdit.Width = 215;
            // 
            // butColumnDelete
            // 
            butColumnDelete.MinimumWidth = 8;
            butColumnDelete.Name = " ";
            butColumnDelete.Text = "Supprimer";
            butColumnDelete.UseColumnTextForButtonValue = true;
            butColumnDelete.Width = 215;
            // 
            // labTitle
            // 
            labTitle.Font = new Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
            labTitle.Location = new Point(750, 100);
            labTitle.Name = "labtitle";
            labTitle.Size = new Size(500, 100);
            labTitle.TabIndex = 4;
            labTitle.Text = "Dashboard élève";
            // 
            // buttonAdd
            // 
            butAdd.Font = new Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
            butAdd.Location = new Point(1700, 50);
            butAdd.Name = "butadd";
            butAdd.Size = new Size(150, 100);
            butAdd.TabIndex = 5;
            butAdd.Text = "+";
            butAdd.UseVisualStyleBackColor = true;
            butAdd.Click += butadd_Click;
            // 
            // buttonRefresh
            // 
            butRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            butRefresh.Location = new Point(1750, 850);
            butRefresh.Name = "butadd";
            butRefresh.Size = new Size(150, 40);
            butRefresh.TabIndex = 5;
            butRefresh.Text = "Raffraichir";
            butRefresh.UseVisualStyleBackColor = true;
            butRefresh.Click += refresh_Click;
            // 
            // ListStudent
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1403, 875);
            Controls.Add(butAdd);
            Controls.Add(butRefresh);
            Controls.Add(labTitle);
            Controls.Add(dataGridView);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "ListStudent";
            Text = "ListStudent";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnId;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnName;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnFirstname;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnClass;
        private DataGridViewButtonColumn butColumnEdit;
        private DataGridViewButtonColumn butColumnDelete;
        private Label labTitle;
        private Button butAdd;
        private Button butRefresh;
    }
}