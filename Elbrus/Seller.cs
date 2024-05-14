using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elbrus
{
    public partial class Seller : Form
    {
        private Timer sessionTimer;
        private DateTime sessionEndTime;

        public Seller ()
        {
            InitializeComponent();
            this.Load += Seller_Load;
        }

        private void Seller_Load ( object sender, EventArgs e )
        {
            // Инициализация таймера сеанса
            sessionTimer = new Timer();
            sessionTimer.Interval = 20000; // & минут (или ваше значение в миллисекундах)
            sessionTimer.Tick += SessionTimer_Tick;

            // Начало нового сеанса
            StartNewSession();
        }

        private void StartNewSession ()
        {
            // Установка времени окончания сеанса
            sessionEndTime = DateTime.Now.AddSeconds(10); // 10 секунд (или ваше значение)
            sessionTimer.Start();
        }
        private void SessionTimer_Tick ( object sender, EventArgs e )
        {
            // Проверка на истечение времени сеанса
            if (DateTime.Now >= sessionEndTime)
            {
                sessionTimer.Stop();
                MessageBox.Show("Время сеанса истекло!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Закрытие текущей формы Seller, если она открыта
                if (Application.OpenForms["Seller"] != null)
                {
                    Application.OpenForms["Seller"].Close();
                }

                // Закрытие текущей формы orderSeller, если она открыта
                if (Application.OpenForms["orderSeller"] != null)
                {
                    Application.OpenForms["orderSeller"].Close();
                }

                // Переход на форму авторизации
                Form1 loginForm = new Form1();
                loginForm.Show();
            }
            else
            {
                // Проверяем, осталось ли менее 2 минут до окончания сеанса
                TimeSpan timeRemaining = sessionEndTime - DateTime.Now;
                if (timeRemaining.TotalSeconds <= 120)
                {
                    // Показываем сообщение об окончании времени сеанса через 2 минуты
                    MessageBox.Show("Осталось менее 2 минут до окончания сеанса!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button1_Click ( object sender, EventArgs e )
        {
            orderSeller orderSellerForm = new orderSeller();
            orderSellerForm.Show();
            this.Close();
        }

        private void button2_Click ( object sender, EventArgs e )
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }

        private void label1_Click ( object sender, EventArgs e )
        {

        }
    }
}
