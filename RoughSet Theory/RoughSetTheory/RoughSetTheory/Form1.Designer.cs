namespace RoughSetTheory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnGetAttribute = new System.Windows.Forms.Button();
            this.btnTestConn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpMedical = new System.Windows.Forms.TabPage();
            this.dgvMedicalList = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thirstDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hungerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frequentUrinationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightLossDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tirednessDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diabetesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medicalDataDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tpAttribute = new System.Windows.Forms.TabPage();
            this.dgvAttributeList = new System.Windows.Forms.DataGridView();
            this.attributesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equivalenceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attributeListDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRetrieveMedicalData = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpMedical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicalList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicalDataDataTableBindingSource)).BeginInit();
            this.tpAttribute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attributeListDataTableBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetAttribute
            // 
            this.btnGetAttribute.Location = new System.Drawing.Point(22, 173);
            this.btnGetAttribute.Name = "btnGetAttribute";
            this.btnGetAttribute.Size = new System.Drawing.Size(144, 43);
            this.btnGetAttribute.TabIndex = 0;
            this.btnGetAttribute.Text = "Attributes";
            this.btnGetAttribute.UseVisualStyleBackColor = true;
            this.btnGetAttribute.Click += new System.EventHandler(this.btnGetAttribute_Click);
            // 
            // btnTestConn
            // 
            this.btnTestConn.Location = new System.Drawing.Point(22, 26);
            this.btnTestConn.Name = "btnTestConn";
            this.btnTestConn.Size = new System.Drawing.Size(144, 43);
            this.btnTestConn.TabIndex = 0;
            this.btnTestConn.Text = "Test Connection";
            this.btnTestConn.UseVisualStyleBackColor = true;
            this.btnTestConn.Click += new System.EventHandler(this.btnTestConn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(779, 287);
            this.panel1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpMedical);
            this.tabControl1.Controls.Add(this.tpAttribute);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(779, 287);
            this.tabControl1.TabIndex = 1;
            // 
            // tpMedical
            // 
            this.tpMedical.Controls.Add(this.dgvMedicalList);
            this.tpMedical.Location = new System.Drawing.Point(4, 30);
            this.tpMedical.Name = "tpMedical";
            this.tpMedical.Padding = new System.Windows.Forms.Padding(3);
            this.tpMedical.Size = new System.Drawing.Size(771, 253);
            this.tpMedical.TabIndex = 0;
            this.tpMedical.Text = "Medical Data List";
            this.tpMedical.UseVisualStyleBackColor = true;
            // 
            // dgvMedicalList
            // 
            this.dgvMedicalList.AutoGenerateColumns = false;
            this.dgvMedicalList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicalList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.patientsDataGridViewTextBoxColumn,
            this.thirstDataGridViewTextBoxColumn,
            this.hungerDataGridViewTextBoxColumn,
            this.frequentUrinationDataGridViewTextBoxColumn,
            this.weightLossDataGridViewTextBoxColumn,
            this.tirednessDataGridViewTextBoxColumn,
            this.diabetesDataGridViewTextBoxColumn});
            this.dgvMedicalList.DataSource = this.medicalDataDataTableBindingSource;
            this.dgvMedicalList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMedicalList.Location = new System.Drawing.Point(3, 3);
            this.dgvMedicalList.Name = "dgvMedicalList";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Zawgyi-One", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMedicalList.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMedicalList.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvMedicalList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Zawgyi-One", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvMedicalList.RowTemplate.Height = 35;
            this.dgvMedicalList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicalList.Size = new System.Drawing.Size(765, 247);
            this.dgvMedicalList.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // patientsDataGridViewTextBoxColumn
            // 
            this.patientsDataGridViewTextBoxColumn.DataPropertyName = "Patients";
            this.patientsDataGridViewTextBoxColumn.HeaderText = "Patients";
            this.patientsDataGridViewTextBoxColumn.Name = "patientsDataGridViewTextBoxColumn";
            // 
            // thirstDataGridViewTextBoxColumn
            // 
            this.thirstDataGridViewTextBoxColumn.DataPropertyName = "Thirst";
            this.thirstDataGridViewTextBoxColumn.HeaderText = "Thirst";
            this.thirstDataGridViewTextBoxColumn.Name = "thirstDataGridViewTextBoxColumn";
            // 
            // hungerDataGridViewTextBoxColumn
            // 
            this.hungerDataGridViewTextBoxColumn.DataPropertyName = "Hunger";
            this.hungerDataGridViewTextBoxColumn.HeaderText = "Hunger";
            this.hungerDataGridViewTextBoxColumn.Name = "hungerDataGridViewTextBoxColumn";
            // 
            // frequentUrinationDataGridViewTextBoxColumn
            // 
            this.frequentUrinationDataGridViewTextBoxColumn.DataPropertyName = "FrequentUrination";
            this.frequentUrinationDataGridViewTextBoxColumn.HeaderText = "FrequentUrination";
            this.frequentUrinationDataGridViewTextBoxColumn.Name = "frequentUrinationDataGridViewTextBoxColumn";
            // 
            // weightLossDataGridViewTextBoxColumn
            // 
            this.weightLossDataGridViewTextBoxColumn.DataPropertyName = "WeightLoss";
            this.weightLossDataGridViewTextBoxColumn.HeaderText = "WeightLoss";
            this.weightLossDataGridViewTextBoxColumn.Name = "weightLossDataGridViewTextBoxColumn";
            // 
            // tirednessDataGridViewTextBoxColumn
            // 
            this.tirednessDataGridViewTextBoxColumn.DataPropertyName = "Tiredness";
            this.tirednessDataGridViewTextBoxColumn.HeaderText = "Tiredness";
            this.tirednessDataGridViewTextBoxColumn.Name = "tirednessDataGridViewTextBoxColumn";
            // 
            // diabetesDataGridViewTextBoxColumn
            // 
            this.diabetesDataGridViewTextBoxColumn.DataPropertyName = "Diabetes";
            this.diabetesDataGridViewTextBoxColumn.HeaderText = "Diabetes";
            this.diabetesDataGridViewTextBoxColumn.Name = "diabetesDataGridViewTextBoxColumn";
            // 
            // medicalDataDataTableBindingSource
            // 
            this.medicalDataDataTableBindingSource.DataSource = typeof(DataObject.AttributeDataset.MedicalDataDataTable);
            // 
            // tpAttribute
            // 
            this.tpAttribute.Controls.Add(this.dgvAttributeList);
            this.tpAttribute.Location = new System.Drawing.Point(4, 30);
            this.tpAttribute.Name = "tpAttribute";
            this.tpAttribute.Padding = new System.Windows.Forms.Padding(3);
            this.tpAttribute.Size = new System.Drawing.Size(771, 253);
            this.tpAttribute.TabIndex = 1;
            this.tpAttribute.Text = "Attributes & Equivalence Classes";
            this.tpAttribute.UseVisualStyleBackColor = true;
            // 
            // dgvAttributeList
            // 
            this.dgvAttributeList.AutoGenerateColumns = false;
            this.dgvAttributeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttributeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.attributesDataGridViewTextBoxColumn,
            this.equivalenceDataGridViewTextBoxColumn});
            this.dgvAttributeList.DataSource = this.attributeListDataTableBindingSource;
            this.dgvAttributeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttributeList.Location = new System.Drawing.Point(3, 3);
            this.dgvAttributeList.Name = "dgvAttributeList";
            this.dgvAttributeList.Size = new System.Drawing.Size(765, 247);
            this.dgvAttributeList.TabIndex = 1;
            // 
            // attributesDataGridViewTextBoxColumn
            // 
            this.attributesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.attributesDataGridViewTextBoxColumn.DataPropertyName = "Attributes";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Zawgyi-One", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attributesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.attributesDataGridViewTextBoxColumn.HeaderText = "Attributes";
            this.attributesDataGridViewTextBoxColumn.Name = "attributesDataGridViewTextBoxColumn";
            this.attributesDataGridViewTextBoxColumn.Width = 94;
            // 
            // equivalenceDataGridViewTextBoxColumn
            // 
            this.equivalenceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.equivalenceDataGridViewTextBoxColumn.DataPropertyName = "Equivalence";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Zawgyi-One", 9.75F);
            this.equivalenceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.equivalenceDataGridViewTextBoxColumn.HeaderText = "Equivalence";
            this.equivalenceDataGridViewTextBoxColumn.Name = "equivalenceDataGridViewTextBoxColumn";
            this.equivalenceDataGridViewTextBoxColumn.Width = 107;
            // 
            // attributeListDataTableBindingSource
            // 
            this.attributeListDataTableBindingSource.DataSource = typeof(DataObject.AttributeDataset.AttributeListDataTable);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnTestConn);
            this.panel2.Controls.Add(this.btnRetrieveMedicalData);
            this.panel2.Controls.Add(this.btnGetAttribute);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 387);
            this.panel2.TabIndex = 1;
            // 
            // btnRetrieveMedicalData
            // 
            this.btnRetrieveMedicalData.Location = new System.Drawing.Point(22, 96);
            this.btnRetrieveMedicalData.Name = "btnRetrieveMedicalData";
            this.btnRetrieveMedicalData.Size = new System.Drawing.Size(144, 43);
            this.btnRetrieveMedicalData.TabIndex = 0;
            this.btnRetrieveMedicalData.Text = "Retrieve Dataset";
            this.btnRetrieveMedicalData.UseVisualStyleBackColor = true;
            this.btnRetrieveMedicalData.Click += new System.EventHandler(this.btnRetrieveMedicalData_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(200, 287);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(779, 100);
            this.panel3.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView2);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(771, 253);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(771, 253);
            this.dataGridView2.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 387);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Zawgyi-One", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Rough Set Theory Main Module";
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpMedical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicalList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicalDataDataTableBindingSource)).EndInit();
            this.tpAttribute.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attributeListDataTableBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetAttribute;
        private System.Windows.Forms.Button btnTestConn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRetrieveMedicalData;
        private System.Windows.Forms.DataGridView dgvMedicalList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpMedical;
        private System.Windows.Forms.TabPage tpAttribute;
        private System.Windows.Forms.DataGridView dgvAttributeList;
        private System.Windows.Forms.BindingSource medicalDataDataTableBindingSource;
        private System.Windows.Forms.BindingSource attributeListDataTableBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn attributesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn equivalenceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn thirstDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hungerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn frequentUrinationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightLossDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tirednessDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diabetesDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView2;

    }
}

