namespace MiniSupermarket.WinForms
{
    partial class FormCategoryManagement
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;

        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.Label lblInfoTitle;

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;

        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 =
                new System.Windows.Forms.DataGridViewCellStyle();

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 =
                new System.Windows.Forms.DataGridViewCellStyle();

            this.lblSearch = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();

            this.lblListTitle = new System.Windows.Forms.Label();
            this.lblInfoTitle = new System.Windows.Forms.Label();

            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();

            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            this.dataGridView1 = new System.Windows.Forms.DataGridView();

            this.colID =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colName =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.colDescription =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.statusStrip1 =
                new System.Windows.Forms.StatusStrip();

            this.lblStatus =
                new System.Windows.Forms.ToolStripStatusLabel();


            ((System.ComponentModel.ISupportInitialize)
                (this.dataGridView1)).BeginInit();

            this.statusStrip1.SuspendLayout();

            this.SuspendLayout();


            // =====================================================
            // lblSearch
            // =====================================================

            this.lblSearch.AutoSize = true;

            this.lblSearch.ForeColor =
                System.Drawing.Color.FromArgb(52, 58, 64);

            this.lblSearch.Location =
                new System.Drawing.Point(17, 13);

            this.lblSearch.Name =
                "lblSearch";

            this.lblSearch.Size =
                new System.Drawing.Size(49, 13);

            this.lblSearch.TabIndex = 0;

            this.lblSearch.Text =
                "Tìm kiếm";


            // =====================================================
            // lblID
            // =====================================================

            this.lblID.AutoSize = true;

            this.lblID.ForeColor =
                System.Drawing.Color.FromArgb(52, 58, 64);

            this.lblID.Location =
                new System.Drawing.Point(369, 81);

            this.lblID.Name =
                "lblID";

            this.lblID.Size =
                new System.Drawing.Size(36, 13);

            this.lblID.TabIndex = 5;

            this.lblID.Text =
                "Mã ID";


            // =====================================================
            // lblName
            // =====================================================

            this.lblName.AutoSize = true;

            this.lblName.ForeColor =
                System.Drawing.Color.FromArgb(52, 58, 64);

            this.lblName.Location =
                new System.Drawing.Point(369, 121);

            this.lblName.Name =
                "lblName";

            this.lblName.Size =
                new System.Drawing.Size(84, 13);

            this.lblName.TabIndex = 6;

            this.lblName.Text =
                "Tên Nhóm hàng";


            // =====================================================
            // lblDescription
            // =====================================================

            this.lblDescription.AutoSize = true;

            this.lblDescription.ForeColor =
                System.Drawing.Color.FromArgb(52, 58, 64);

            this.lblDescription.Location =
                new System.Drawing.Point(369, 162);

            this.lblDescription.Name =
                "lblDescription";

            this.lblDescription.Size =
                new System.Drawing.Size(38, 13);

            this.lblDescription.TabIndex = 7;

            this.lblDescription.Text =
                "Mô Tả";


            // =====================================================
            // lblListTitle
            // =====================================================

            this.lblListTitle.AutoSize = true;

            this.lblListTitle.ForeColor =
                System.Drawing.Color.Black;

            this.lblListTitle.Location =
                new System.Drawing.Point(17, 61);

            this.lblListTitle.Name =
                "lblListTitle";

            this.lblListTitle.Size =
                new System.Drawing.Size(117, 13);

            this.lblListTitle.TabIndex = 3;

            this.lblListTitle.Text =
                "Danh sách Nhóm hàng";


            // =====================================================
            // lblInfoTitle
            // =====================================================

            this.lblInfoTitle.AutoSize = true;

            this.lblInfoTitle.ForeColor =
                System.Drawing.Color.Black;

            this.lblInfoTitle.Location =
                new System.Drawing.Point(369, 61);

            this.lblInfoTitle.Name =
                "lblInfoTitle";

            this.lblInfoTitle.Size =
                new System.Drawing.Size(110, 13);

            this.lblInfoTitle.TabIndex = 4;

            this.lblInfoTitle.Text =
                "Thông tin Nhóm hàng";


            // =====================================================
            // txtSearch
            // =====================================================

            this.txtSearch.BackColor =
                System.Drawing.Color.White;

            this.txtSearch.ForeColor =
                System.Drawing.Color.FromArgb(33, 37, 41);

            this.txtSearch.Location =
                new System.Drawing.Point(17, 30);

            this.txtSearch.Name =
                "txtSearch";

            this.txtSearch.Size =
                new System.Drawing.Size(202, 20);

            this.txtSearch.TabIndex = 0;

            this.txtSearch.Enter +=
                new System.EventHandler(
                    this.txtSearch_Enter);

            this.txtSearch.Leave +=
                new System.EventHandler(
                    this.txtSearch_Leave);


            // =====================================================
            // txtID
            // =====================================================

            this.txtID.BackColor =
                System.Drawing.Color.FromArgb(233, 236, 239);

            this.txtID.ForeColor =
                System.Drawing.Color.FromArgb(73, 80, 87);

            this.txtID.Location =
                new System.Drawing.Point(369, 95);

            this.txtID.Name =
                "txtID";

            this.txtID.ReadOnly = true;

            this.txtID.Size =
                new System.Drawing.Size(155, 20);

            this.txtID.TabIndex = 4;


            // =====================================================
            // txtName
            // =====================================================

            this.txtName.BackColor =
                System.Drawing.Color.White;

            this.txtName.ForeColor =
                System.Drawing.Color.FromArgb(33, 37, 41);

            this.txtName.Location =
                new System.Drawing.Point(369, 136);

            this.txtName.Name =
                "txtName";

            this.txtName.Size =
                new System.Drawing.Size(155, 20);

            this.txtName.TabIndex = 5;


            // =====================================================
            // txtDescription
            // =====================================================

            this.txtDescription.BackColor =
                System.Drawing.Color.White;

            this.txtDescription.ForeColor =
                System.Drawing.Color.FromArgb(33, 37, 41);

            this.txtDescription.Location =
                new System.Drawing.Point(369, 177);

            this.txtDescription.Multiline = true;

            this.txtDescription.Name =
                "txtDescription";

            this.txtDescription.ScrollBars =
                System.Windows.Forms.ScrollBars.Vertical;

            this.txtDescription.Size =
                new System.Drawing.Size(155, 48);

            this.txtDescription.TabIndex = 6;


            // =====================================================
            // btnSearch
            // =====================================================

            this.btnSearch.BackColor =
                System.Drawing.Color.DarkGray;

            this.btnSearch.FlatAppearance.BorderSize = 0;

            this.btnSearch.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnSearch.ForeColor =
                System.Drawing.Color.White;

            this.btnSearch.Location =
                new System.Drawing.Point(225, 29);

            this.btnSearch.Name =
                "btnSearch";

            this.btnSearch.Size =
                new System.Drawing.Size(62, 22);

            this.btnSearch.TabIndex = 1;

            this.btnSearch.Text =
                "Tìm kiếm";

            this.btnSearch.UseVisualStyleBackColor = false;

            this.btnSearch.Click +=
                new System.EventHandler(
                    this.btnSearch_Click);


            // =====================================================
            // btnReload
            // =====================================================

            this.btnReload.BackColor =
                System.Drawing.Color.DarkGray;

            this.btnReload.FlatAppearance.BorderSize = 0;

            this.btnReload.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnReload.ForeColor =
                System.Drawing.Color.White;

            this.btnReload.Location =
                new System.Drawing.Point(292, 29);

            this.btnReload.Name =
                "btnReload";

            this.btnReload.Size =
                new System.Drawing.Size(60, 22);

            this.btnReload.TabIndex = 2;

            this.btnReload.Text =
                "Tải lại";

            this.btnReload.UseVisualStyleBackColor = false;

            this.btnReload.Click +=
                new System.EventHandler(
                    this.btnReload_Click);


            // =====================================================
            // btnAdd
            // =====================================================

            this.btnAdd.BackColor =
                System.Drawing.Color.DarkGray;

            this.btnAdd.FlatAppearance.BorderSize = 0;

            this.btnAdd.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnAdd.ForeColor =
                System.Drawing.Color.Black;

            this.btnAdd.Location =
                new System.Drawing.Point(369, 236);

            this.btnAdd.Name =
                "btnAdd";

            this.btnAdd.Size =
                new System.Drawing.Size(70, 23);

            this.btnAdd.TabIndex = 7;

            this.btnAdd.Text =
                "Thêm";

            this.btnAdd.UseVisualStyleBackColor = false;

            this.btnAdd.Click +=
                new System.EventHandler(
                    this.btnAdd_Click);


            // =====================================================
            // btnUpdate
            // =====================================================

            this.btnUpdate.BackColor =
                System.Drawing.Color.DarkGray;

            this.btnUpdate.FlatAppearance.BorderSize = 0;

            this.btnUpdate.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnUpdate.ForeColor =
                System.Drawing.Color.Black;

            this.btnUpdate.Location =
                new System.Drawing.Point(445, 236);

            this.btnUpdate.Name =
                "btnUpdate";

            this.btnUpdate.Size =
                new System.Drawing.Size(70, 23);

            this.btnUpdate.TabIndex = 8;

            this.btnUpdate.Text =
                "Cập nhật";

            this.btnUpdate.UseVisualStyleBackColor = false;

            this.btnUpdate.Click +=
                new System.EventHandler(
                    this.btnUpdate_Click);


            // =====================================================
            // btnDelete
            // =====================================================

            this.btnDelete.BackColor =
                System.Drawing.Color.DarkGray;

            this.btnDelete.FlatAppearance.BorderSize = 0;

            this.btnDelete.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnDelete.ForeColor =
                System.Drawing.Color.Black;

            this.btnDelete.Location =
                new System.Drawing.Point(521, 236);

            this.btnDelete.Name =
                "btnDelete";

            this.btnDelete.Size =
                new System.Drawing.Size(55, 23);

            this.btnDelete.TabIndex = 9;

            this.btnDelete.Text =
                "Xóa";

            this.btnDelete.UseVisualStyleBackColor = false;

            this.btnDelete.Click +=
                new System.EventHandler(
                    this.btnDelete_Click);


            // =====================================================
            // DATA GRID VIEW
            // =====================================================

            this.dataGridView1.AllowUserToAddRows = false;

            this.dataGridView1.AllowUserToDeleteRows = false;

            this.dataGridView1.AllowUserToResizeRows = false;

            this.dataGridView1.BackgroundColor =
                System.Drawing.Color.White;


            // HEADER STYLE

            dataGridViewCellStyle1.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;

            dataGridViewCellStyle1.BackColor =
                System.Drawing.Color.FromArgb(0, 102, 204);

            dataGridViewCellStyle1.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    8.25F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point,
                    ((byte)(0)));

            dataGridViewCellStyle1.ForeColor =
                System.Drawing.Color.White;

            dataGridViewCellStyle1.SelectionBackColor =
                System.Drawing.SystemColors.Highlight;

            dataGridViewCellStyle1.SelectionForeColor =
                System.Drawing.SystemColors.HighlightText;

            dataGridViewCellStyle1.WrapMode =
                System.Windows.Forms.DataGridViewTriState.True;

            this.dataGridView1.ColumnHeadersDefaultCellStyle =
                dataGridViewCellStyle1;

            this.dataGridView1.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;


            // CELL STYLE

            dataGridViewCellStyle2.Alignment =
                System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;

            dataGridViewCellStyle2.BackColor =
                System.Drawing.Color.White;

            dataGridViewCellStyle2.Font =
                new System.Drawing.Font(
                    "Microsoft Sans Serif",
                    8.25F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point,
                    ((byte)(0)));

            dataGridViewCellStyle2.ForeColor =
                System.Drawing.Color.FromArgb(33, 37, 41);

            dataGridViewCellStyle2.SelectionBackColor =
                System.Drawing.Color.FromArgb(204, 229, 255);

            dataGridViewCellStyle2.SelectionForeColor =
                System.Drawing.Color.FromArgb(0, 64, 128);

            dataGridViewCellStyle2.WrapMode =
                System.Windows.Forms.DataGridViewTriState.False;

            this.dataGridView1.DefaultCellStyle =
                dataGridViewCellStyle2;


            this.dataGridView1.EnableHeadersVisualStyles = false;

            this.dataGridView1.GridColor =
                System.Drawing.Color.FromArgb(222, 226, 230);

            this.dataGridView1.Location =
                new System.Drawing.Point(17, 78);

            this.dataGridView1.MultiSelect = false;

            this.dataGridView1.Name =
                "dataGridView1";

            this.dataGridView1.ReadOnly = true;

            this.dataGridView1.RowHeadersWidth = 30;

            this.dataGridView1.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dataGridView1.Size =
                new System.Drawing.Size(339, 195);

            this.dataGridView1.TabIndex = 3;


            // =====================================================
            // CỘT 1 - ID
            // =====================================================

            this.colID.HeaderText =
                "Mã ID";

            this.colID.Name =
                "colID";

            this.colID.ReadOnly = true;

            this.colID.Width = 55;


            // =====================================================
            // CỘT 2 - TÊN
            // =====================================================

            this.colName.HeaderText =
                "Tên Nhóm hàng";

            this.colName.Name =
                "colName";

            this.colName.ReadOnly = true;

            this.colName.Width = 125;


            // =====================================================
            // CỘT 3 - MÔ TẢ
            // =====================================================

            this.colDescription.HeaderText =
                "Mô tả";

            this.colDescription.Name =
                "colDescription";

            this.colDescription.ReadOnly = true;

            this.colDescription.Width = 145;


            // =====================================================
            // THÊM CỘT VÀO DATAGRIDVIEW
            // =====================================================

            this.dataGridView1.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[]
                {
                    this.colID,
                    this.colName,
                    this.colDescription
                });


            this.dataGridView1.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dataGridView1_CellClick);


            // =====================================================
            // STATUS STRIP
            // =====================================================

            this.statusStrip1.BackColor =
                System.Drawing.Color.FromArgb(224, 224, 224);

            this.statusStrip1.Items.AddRange(
                new System.Windows.Forms.ToolStripItem[]
                {
                    this.lblStatus
                });

            this.statusStrip1.Location =
                new System.Drawing.Point(0, 281);

            this.statusStrip1.Name =
                "statusStrip1";

            this.statusStrip1.Padding =
                new System.Windows.Forms.Padding(1, 0, 12, 0);

            this.statusStrip1.Size =
                new System.Drawing.Size(540, 22);

            this.statusStrip1.TabIndex = 10;

            this.statusStrip1.Text =
                "statusStrip1";


            // =====================================================
            // STATUS LABEL
            // =====================================================

            this.lblStatus.ForeColor =
                System.Drawing.Color.Black;

            this.lblStatus.Name =
                "lblStatus";

            this.lblStatus.Size =
                new System.Drawing.Size(39, 17);

            this.lblStatus.Text =
                "Ready";


            // =====================================================
            // FORM
            // =====================================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(6F, 13F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.FromArgb(245, 247, 250);

            this.ClientSize =
                new System.Drawing.Size(590, 303);

            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnReload);

            this.Controls.Add(this.lblListTitle);
            this.Controls.Add(this.dataGridView1);

            this.Controls.Add(this.lblInfoTitle);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtID);

            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);

            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);

            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);

            this.Controls.Add(this.statusStrip1);

            this.ForeColor =
                System.Drawing.Color.FromArgb(33, 37, 41);

            this.MinimumSize =
                new System.Drawing.Size(591, 307);

            this.Name =
                "FormCategoryManagement";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text =
                "Quản lý Danh mục Nhóm hàng";

            this.Load +=
                new System.EventHandler(
                    this.FormCategoryManagement_Load_1);


            ((System.ComponentModel.ISupportInitialize)
                (this.dataGridView1)).EndInit();

            this.statusStrip1.ResumeLayout(false);

            this.statusStrip1.PerformLayout();

            this.ResumeLayout(false);

            this.PerformLayout();
        }
    }
}