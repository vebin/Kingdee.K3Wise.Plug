namespace K3DoNetPlug.CommonForm
{
    partial class FormBaseData
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxKeyword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewMain = new System.Windows.Forms.TreeView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.FNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridViewSelected = new System.Windows.Forms.DataGridView();
            this.SFNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SFName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SFFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SFItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelected)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxKeyword);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 34);
            this.panel1.TabIndex = 0;
            // 
            // textBoxKeyword
            // 
            this.textBoxKeyword.Location = new System.Drawing.Point(193, 4);
            this.textBoxKeyword.Name = "textBoxKeyword";
            this.textBoxKeyword.Size = new System.Drawing.Size(505, 21);
            this.textBoxKeyword.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "关键字";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(704, 2);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 0;
            this.buttonSearch.Text = "搜索";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeViewMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(852, 415);
            this.splitContainer1.SplitterDistance = 153;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeViewMain
            // 
            this.treeViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewMain.Location = new System.Drawing.Point(0, 0);
            this.treeViewMain.Name = "treeViewMain";
            this.treeViewMain.Size = new System.Drawing.Size(153, 415);
            this.treeViewMain.TabIndex = 0;
            this.treeViewMain.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewMain_BeforeExpand);
            this.treeViewMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMain_AfterSelect);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dataGridViewSelected);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 272);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(695, 143);
            this.panel5.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewMain);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(695, 415);
            this.panel3.TabIndex = 1;
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.AllowUserToAddRows = false;
            this.dataGridViewMain.AllowUserToDeleteRows = false;
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FNumber,
            this.FName,
            this.FFullName,
            this.FItemID});
            this.dataGridViewMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewMain.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.ReadOnly = true;
            this.dataGridViewMain.RowTemplate.Height = 23;
            this.dataGridViewMain.Size = new System.Drawing.Size(695, 266);
            this.dataGridViewMain.TabIndex = 0;
            this.dataGridViewMain.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewMain_CellMouseDoubleClick);
            // 
            // FNumber
            // 
            this.FNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FNumber.DataPropertyName = "FNumber";
            this.FNumber.Frozen = true;
            this.FNumber.HeaderText = "代码";
            this.FNumber.Name = "FNumber";
            this.FNumber.ReadOnly = true;
            this.FNumber.Width = 54;
            // 
            // FName
            // 
            this.FName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FName.DataPropertyName = "FName";
            this.FName.Frozen = true;
            this.FName.HeaderText = "名称";
            this.FName.Name = "FName";
            this.FName.ReadOnly = true;
            this.FName.Width = 54;
            // 
            // FFullName
            // 
            this.FFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FFullName.DataPropertyName = "FFullName";
            this.FFullName.Frozen = true;
            this.FFullName.HeaderText = "全名";
            this.FFullName.Name = "FFullName";
            this.FFullName.ReadOnly = true;
            this.FFullName.Width = 493;
            // 
            // FItemID
            // 
            this.FItemID.DataPropertyName = "FItemID";
            this.FItemID.Frozen = true;
            this.FItemID.HeaderText = "FItemID";
            this.FItemID.Name = "FItemID";
            this.FItemID.ReadOnly = true;
            this.FItemID.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonCancel);
            this.panel2.Controls.Add(this.buttonOk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 449);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(852, 41);
            this.panel2.TabIndex = 2;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(716, 11);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "取  消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(600, 11);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "确  定";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.splitContainer1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 34);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(852, 415);
            this.panel4.TabIndex = 3;
            // 
            // dataGridViewSelected
            // 
            this.dataGridViewSelected.AllowUserToAddRows = false;
            this.dataGridViewSelected.AllowUserToDeleteRows = false;
            this.dataGridViewSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelected.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SFNumber,
            this.SFName,
            this.SFFullName,
            this.SFItemID});
            this.dataGridViewSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSelected.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSelected.Name = "dataGridViewSelected";
            this.dataGridViewSelected.ReadOnly = true;
            this.dataGridViewSelected.RowTemplate.Height = 23;
            this.dataGridViewSelected.Size = new System.Drawing.Size(695, 143);
            this.dataGridViewSelected.TabIndex = 1;
            this.dataGridViewSelected.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewSelected_CellMouseDoubleClick);
            // 
            // SFNumber
            // 
            this.SFNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SFNumber.DataPropertyName = "FNumber";
            this.SFNumber.Frozen = true;
            this.SFNumber.HeaderText = "代码";
            this.SFNumber.Name = "SFNumber";
            this.SFNumber.ReadOnly = true;
            this.SFNumber.Width = 54;
            // 
            // SFName
            // 
            this.SFName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SFName.DataPropertyName = "FName";
            this.SFName.Frozen = true;
            this.SFName.HeaderText = "名称";
            this.SFName.Name = "SFName";
            this.SFName.ReadOnly = true;
            this.SFName.Width = 54;
            // 
            // SFFullName
            // 
            this.SFFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SFFullName.DataPropertyName = "FFullName";
            this.SFFullName.Frozen = true;
            this.SFFullName.HeaderText = "全名";
            this.SFFullName.Name = "SFFullName";
            this.SFFullName.ReadOnly = true;
            this.SFFullName.Width = 493;
            // 
            // SFItemID
            // 
            this.SFItemID.DataPropertyName = "FItemID";
            this.SFItemID.Frozen = true;
            this.SFItemID.HeaderText = "FItemID";
            this.SFItemID.Name = "SFItemID";
            this.SFItemID.ReadOnly = true;
            this.SFItemID.Visible = false;
            // 
            // FormBaseData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 490);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormBaseData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基础资料";
            this.Load += new System.EventHandler(this.FormBaseData_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelected)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewMain;
        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.TextBox textBoxKeyword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn FNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn FName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FItemID;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridViewSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFItemID;
    }
}