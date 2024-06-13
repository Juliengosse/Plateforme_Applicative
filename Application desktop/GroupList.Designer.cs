using System.Windows.Forms;

namespace Application_desktop
{
    partial class GroupList
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
            dataGridViewTextBoxColumnCycle = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumnSection = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumnSubSection = new DataGridViewTextBoxColumn();
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
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumnId, dataGridViewTextBoxColumnCycle, dataGridViewTextBoxColumnSection, dataGridViewTextBoxColumnSubSection, butColumnEdit, butColumnDelete });
            dataGridView.Location = new Point(210, 200);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 62;
            dataGridView.Size = new Size(1500, 700);
            dataGridView.TabIndex = 2;
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            // 
            // dataGridViewTextBoxColumnId
            // 
            dataGridViewTextBoxColumnId.HeaderText = "Id groupe";
            dataGridViewTextBoxColumnId.MinimumWidth = 8;
            dataGridViewTextBoxColumnId.Name = "dataGridViewTextBoxColumnId";
            dataGridViewTextBoxColumnId.Width = 170;
            // 
            // dataGridViewTextBoxColumnCycle
            // 
            dataGridViewTextBoxColumnCycle.HeaderText = "Cycle d'étude";
            dataGridViewTextBoxColumnCycle.MinimumWidth = 8;
            dataGridViewTextBoxColumnCycle.Name = "dataGridViewTextBoxColumnCycle";
            dataGridViewTextBoxColumnCycle.Width = 280;
            // 
            // dataGridViewTextBoxColumnSection
            // 
            dataGridViewTextBoxColumnSection.HeaderText = "Section (année d'étude)";
            dataGridViewTextBoxColumnSection.MinimumWidth = 8;
            dataGridViewTextBoxColumnSection.Name = "dataGridViewTextBoxColumnSection";
            dataGridViewTextBoxColumnSection.Width = 280;
            // 
            // dataGridViewTextBoxColumnSubSection
            // 
            dataGridViewTextBoxColumnSubSection.HeaderText = "Sous-section (formation alternant/étudiant)";
            dataGridViewTextBoxColumnSubSection.MinimumWidth = 8;
            dataGridViewTextBoxColumnSubSection.Name = "dataGridViewTextBoxColumnSubSection";
            dataGridViewTextBoxColumnSubSection.Width = 275;
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
            labTitle.Text = "Dashboard groupe";
            // 
            // butAdd
            // 
            butAdd.Font = new Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
            butAdd.Location = new Point(1700, 50);
            butAdd.Name = "butadd";
            butAdd.Size = new Size(150, 100);
            butAdd.TabIndex = 5;
            butAdd.Text = "+";
            butAdd.UseVisualStyleBackColor = true;
            butAdd.Click += butAdd_Click;
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
            butRefresh.Click += butRefresh_Click;
            // 
            // ListClass
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1403, 875);
            Controls.Add(butAdd);
            Controls.Add(butRefresh);
            Controls.Add(labTitle);
            Controls.Add(dataGridView);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "ListClass";
            Text = "ListClass";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnId;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnCycle;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnSection;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumnSubSection;
        private DataGridViewButtonColumn butColumnEdit;
        private DataGridViewButtonColumn butColumnDelete;
        private Label labTitle;
        private Button butAdd;
        private Button butRefresh;
    }
}