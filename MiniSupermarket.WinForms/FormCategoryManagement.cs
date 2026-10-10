
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;          // THÊM
using System.Net.Http.Json;     // THÊM
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormCategoryManagement : Form
    {
        // =====================================================
        // DANH SÁCH NHÓM HÀNG
        // =====================================================

        private List<Category> categories =
            new List<Category>();


        // =====================================================
        // KẾT NỐI API
        // =====================================================

        private HttpClient client =
            new HttpClient
            {
                BaseAddress =
                    new Uri("https://localhost:7123/api/")
            };


        // =====================================================
        // PHÂN QUYỀN
        // =====================================================

        private bool IsAdmin()
        {
            return string.Equals(
                SessionManager.CurrentRole,
                "Admin",
                StringComparison.OrdinalIgnoreCase);
        }

        private void KiemTraQuyen()
        {
            bool isAdmin = IsAdmin();

            // Admin được thêm, sửa, xóa
            btnAdd.Enabled = isAdmin;
            btnUpdate.Enabled = isAdmin;
            btnDelete.Enabled = isAdmin;
        }


        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public FormCategoryManagement()
        {
            InitializeComponent();
        }


        // =====================================================
        // FORM LOAD
        // =====================================================

        private async void FormCategoryManagement_Load_1(
            object sender,
            EventArgs e)
        {
            await LoadData();

            SelectFirstRow();

            txtSearch.Text =
                "Nhập từ khóa...";

            txtSearch.ForeColor =
                Color.Gray;

            lblStatus.Text =
                "Ready";

            // ===== PHÂN QUYỀN =====
            KiemTraQuyen();
        }


        // =====================================================
        // LẤY DỮ LIỆU TỪ API
        // =====================================================

        private async System.Threading.Tasks.Task LoadData()
        {
            try
            {
                List<Category> data =
                    await client.GetFromJsonAsync<List<Category>>(
                        "categories");

                if (data == null)
                {
                    categories =
                        new List<Category>();
                }
                else
                {
                    categories = data;
                }

                DisplayCategories(categories);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể kết nối đến API!\n\n"
                    + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                categories =
                    new List<Category>();

                DisplayCategories(categories);
            }
        }


        // =====================================================
        // HIỂN THỊ DANH SÁCH
        // =====================================================

        private void DisplayCategories(
            List<Category> list)
        {
            dataGridView1.Rows.Clear();

            foreach (Category category in list)
            {
                int rowIndex =
                    dataGridView1.Rows.Add();

                DataGridViewRow row =
                    dataGridView1.Rows[rowIndex];

                row.Cells[0].Value =
                    category.ID;

                row.Cells[1].Value =
                    category.Name;

                row.Cells[2].Value =
                    category.Description;
            }

            lblStatus.Text =
                "Có " + list.Count + " nhóm hàng";
        }


        // =====================================================
        // CLICK VÀO DÒNG
        // =====================================================

        private void dataGridView1_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            ShowCategory(e.RowIndex);
        }


        // =====================================================
        // HIỂN THỊ CHI TIẾT
        // =====================================================

        private void ShowCategory(
            int rowIndex)
        {
            if (rowIndex < 0 ||
                rowIndex >= dataGridView1.Rows.Count)
            {
                return;
            }

            DataGridViewRow row =
                dataGridView1.Rows[rowIndex];

            txtID.Text =
                Convert.ToString(
                    row.Cells[0].Value);

            txtName.Text =
                Convert.ToString(
                    row.Cells[1].Value);

            txtDescription.Text =
                Convert.ToString(
                    row.Cells[2].Value);
        }


        // =====================================================
        // CHỌN DÒNG ĐẦU TIÊN
        // =====================================================

        private void SelectFirstRow()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.ClearSelection();

                dataGridView1.Rows[0].Selected =
                    true;

                dataGridView1.CurrentCell =
                    dataGridView1.Rows[0].Cells[0];

                ShowCategory(0);
            }
            else
            {
                ClearInput();
            }
        }


        // =====================================================
        // XÓA Ô NHẬP
        // =====================================================

        private void ClearInput()
        {
            txtID.Clear();
            txtName.Clear();
            txtDescription.Clear();
        }


        // =====================================================
        // TÌM KIẾM
        // =====================================================

        private void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            string keyword =
                txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword) ||
                keyword == "Nhập từ khóa...")
            {
                DisplayCategories(categories);

                SelectFirstRow();

                return;
            }

            List<Category> result =
                categories
                    .Where(x =>
                        x.Name.IndexOf(
                            keyword,
                            StringComparison.OrdinalIgnoreCase
                        ) >= 0

                        ||

                        x.Description.IndexOf(
                            keyword,
                            StringComparison.OrdinalIgnoreCase
                        ) >= 0
                    )
                    .ToList();

            DisplayCategories(result);

            if (result.Count > 0)
            {
                dataGridView1.ClearSelection();

                dataGridView1.Rows[0].Selected =
                    true;

                dataGridView1.CurrentCell =
                    dataGridView1.Rows[0].Cells[0];

                ShowCategory(0);

                lblStatus.Text =
                    "Tìm thấy " +
                    result.Count +
                    " nhóm hàng";
            }
            else
            {
                ClearInput();

                lblStatus.Text =
                    "Không tìm thấy";

                MessageBox.Show(
                    "Không tìm thấy nhóm hàng!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }


        // =====================================================
        // TẢI LẠI
        // =====================================================

        private async void btnReload_Click(
            object sender,
            EventArgs e)
        {
            txtSearch.Text =
                "Nhập từ khóa...";

            txtSearch.ForeColor =
                Color.Gray;

            await LoadData();

            SelectFirstRow();

            lblStatus.Text =
                "Đã tải lại dữ liệu";
        }


        // =====================================================
        // THÊM MỚI
        // =====================================================

        private async void btnAdd_Click(
            object sender,
            EventArgs e)
        {
            // ===== PHÂN QUYỀN =====
            if (!IsAdmin())
            {
                MessageBox.Show(
                    "Bạn không có quyền thêm nhóm hàng!",
                    "Không có quyền",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(
                txtName.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập Tên Nhóm hàng!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtName.Focus();

                return;
            }


            // =================================================
            // SỬA: KHÔNG TỰ TẠO ID NỮA
            // SQL SERVER SẼ TỰ TĂNG ID
            // =================================================

            Category category =
                new Category
                {
                    Name =
                        txtName.Text.Trim(),

                    Description =
                        txtDescription.Text.Trim()
                };


            try
            {
                HttpResponseMessage response =
                    await client.PostAsJsonAsync(
                        "categories",
                        category);


                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Thêm mới thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    await LoadData();

                    SelectFirstRow();

                    lblStatus.Text =
                        "Đã thêm nhóm hàng";
                }
                else
                {
                    MessageBox.Show(
                        "Thêm nhóm hàng thất bại!\n"
                        + response.StatusCode,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể kết nối API!\n\n"
                    + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // CẬP NHẬT
        // =====================================================

        private async void btnUpdate_Click(
            object sender,
            EventArgs e)
        {
            // ===== PHÂN QUYỀN =====
            if (!IsAdmin())
            {
                MessageBox.Show(
                    "Bạn không có quyền cập nhật nhóm hàng!",
                    "Không có quyền",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int id;

            if (!int.TryParse(
                txtID.Text,
                out id))
            {
                MessageBox.Show(
                    "Vui lòng chọn nhóm hàng cần cập nhật!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            if (string.IsNullOrWhiteSpace(
                txtName.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập Tên Nhóm hàng!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtName.Focus();

                return;
            }


            // =================================================
            // TẠO ĐỐI TƯỢNG CẦN CẬP NHẬT
            // =================================================

            Category category =
                new Category
                {
                    ID = id,

                    Name =
                        txtName.Text.Trim(),

                    Description =
                        txtDescription.Text.Trim()
                };


            try
            {
                HttpResponseMessage response =
                    await client.PutAsJsonAsync(
                        "categories/" + id,
                        category);


                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Cập nhật thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    await LoadData();

                    SelectCategoryByID(id);

                    lblStatus.Text =
                        "Đã cập nhật nhóm hàng";
                }
                else
                {
                    MessageBox.Show(
                        "Cập nhật thất bại!\n"
                        + response.StatusCode,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể kết nối API!\n\n"
                    + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =====================================================
        // XÓA
        // =====================================================

        private async void btnDelete_Click(
            object sender,
            EventArgs e)
        {
            // ===== PHÂN QUYỀN =====
            if (!IsAdmin())
            {
                MessageBox.Show(
                    "Bạn không có quyền xóa nhóm hàng!",
                    "Không có quyền",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int id;

            if (!int.TryParse(
                txtID.Text,
                out id))
            {
                MessageBox.Show(
                    "Vui lòng chọn nhóm hàng cần xóa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            Category category =
                categories.FirstOrDefault(
                    x => x.ID == id);

            if (category == null)
            {
                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Bạn có chắc muốn xóa nhóm hàng \""
                    + category.Name
                    + "\" không?",

                    "Xác nhận xóa",

                    MessageBoxButtons.YesNo,

                    MessageBoxIcon.Question
                );

            if (result ==
                DialogResult.Yes)
            {
                try
                {
                    // =================================================
                    // SỬA: XÓA TRÊN SQL SERVER THÔNG QUA API
                    // =================================================

                    HttpResponseMessage response =
                        await client.DeleteAsync(
                            "categories/" + id);


                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show(
                            "Xóa thành công!",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        await LoadData();

                        SelectFirstRow();

                        lblStatus.Text =
                            "Đã xóa nhóm hàng";
                    }
                    else
                    {
                        MessageBox.Show(
                            "Xóa thất bại!\n"
                            + response.StatusCode,
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Không thể kết nối API!\n\n"
                        + ex.Message,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }


        // =====================================================
        // CHỌN NHÓM HÀNG THEO ID
        // =====================================================

        private void SelectCategoryByID(
            int id)
        {
            for (int i = 0;
                 i < dataGridView1.Rows.Count;
                 i++)
            {
                string currentID =
                    Convert.ToString(
                        dataGridView1.Rows[i]
                            .Cells[0].Value);

                if (currentID ==
                    id.ToString())
                {
                    dataGridView1.ClearSelection();

                    dataGridView1.Rows[i].Selected =
                        true;

                    dataGridView1.CurrentCell =
                        dataGridView1.Rows[i].Cells[0];

                    ShowCategory(i);

                    return;
                }
            }
        }


        // =====================================================
        // PLACEHOLDER - ENTER
        // =====================================================

        private void txtSearch_Enter(
            object sender,
            EventArgs e)
        {
            if (txtSearch.Text ==
                "Nhập từ khóa...")
            {
                txtSearch.Clear();

                txtSearch.ForeColor =
                    Color.Black;
            }
        }


        // =====================================================
        // PLACEHOLDER - LEAVE
        // =====================================================

        private void txtSearch_Leave(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                txtSearch.Text))
            {
                txtSearch.Text =
                    "Nhập từ khóa...";

                txtSearch.ForeColor =
                    Color.Gray;
            }
        }


        // =====================================================
        // MODEL CATEGORY
        // =====================================================

        private class Category
        {
            public int ID { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }
        }
    }
}
