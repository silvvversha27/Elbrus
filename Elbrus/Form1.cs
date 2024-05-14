using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Elbrus;

namespace Elbrus
{
    public partial class Form1 : Form
    {
        public Form1 ()
        {
            InitializeComponent();
        }

        public void Form1_Load ( object sender, EventArgs e )
        {

        }

        private void textBox1_TextChanged ( object sender, EventArgs e )
        {

        }

        private void label1_Click ( object sender, EventArgs e )
        {

        }

        private void label2_Click ( object sender, EventArgs e )
        {

        }

        private void label3_Click ( object sender, EventArgs e )
        {

        }

        private void button1_Click ( object sender, EventArgs e )
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Вызываем метод аутентификации пользователя
            (bool isAuthenticated, string position) = AuthenticateUser(username, password);

            if (isAuthenticated)
            {
                // В зависимости от должности пользователя открываем соответствующую форму
                switch (position)
                {
                    case "Продавец":
                        Seller sellerForm = new Seller();
                        sellerForm.Show();
                        break;
                    case "Старший смены":
                        Supervisor seniorShiftForm = new Supervisor();
                        seniorShiftForm.Show();
                        break;
                    case "Администратор":
                        Admin adminForm = new Admin();
                        adminForm.Show();
                        break;
                    default:
                        MessageBox.Show("Должность не определена. Обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                this.Hide(); // Скрываем окно авторизации
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль. Попробуйте еще раз.", "Ошибка аутентификации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private (bool isAuthenticated, string position) AuthenticateUser ( string username, string password )
        {
            using (var context = new YourDbContext())
            {
                // Выполняем запрос к базе данных для поиска пользователя с указанным логином и паролем
                var user = context.Employees.FirstOrDefault(e => e.Login == username && e.Password == password);

                // Если пользователь найден, возвращаем true и его должность
                if (user != null)
                {
                    MessageBox.Show($"Пользователь найден:{user.SurnName} {user.FirstName} {user.LastName} \t Должность: {user.Post}", "Успешная аутентификация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return (true, user.Post);
                }
                else
                {
                    MessageBox.Show("Пользователь не найден. Проверьте правильность введенных данных.", "Ошибка аутентификации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Если пользователь не найден, возвращаем false и пустую строку для должности
                    return (false, "");
                }
            }
        }
        private void checkBox1_CheckedChanged ( object sender, EventArgs e )
        {
            // Показываем или скрываем пароль в поле ввода
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0'; // Показываем пароль
            }
            else
            {
                txtPassword.PasswordChar = '*'; // Скрываем пароль с использованием *
            }
        }
    }
}
