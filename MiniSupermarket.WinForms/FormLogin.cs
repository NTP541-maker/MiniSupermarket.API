using System;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();

            // Gắn sự kiện cho nút Đăng nhập
            btnLogin.Click += btnLogin_Click;
        }

        // Sự kiện khi bấm nút Đăng nhập
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // Lấy tài khoản và mật khẩu
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            // Kiểm tra không được để trống
            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ tài khoản và mật khẩu!",
                    "Cảnh báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                // Gọi API đăng nhập
                bool loginSuccess =
                    await ApiClientService.LoginAsync(
                        username,
                        password);

                // Đăng nhập thành công
                if (loginSuccess)
                {
                    MessageBox.Show(
                        "Đăng nhập thành công!\n" +
                        "Quyền: " +
                        SessionManager.CurrentRole,
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Mở Form quản lý danh mục
                    FormCategoryManagement mainForm =
                        new FormCategoryManagement();

                    this.Hide();

                    mainForm.ShowDialog();

                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Sai tài khoản hoặc mật khẩu!",
                        "Đăng nhập thất bại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Hiện đầy đủ lỗi để kiểm tra nguyên nhân
                MessageBox.Show(
                    ex.ToString(),
                    "Lỗi hệ thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}