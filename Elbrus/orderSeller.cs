using System;
using System.Linq;
using System.Windows.Forms;

namespace Elbrus
{
    public partial class orderSeller : Form
    {
        private YourDbContext dbContext; // Объект контекста базы данных

        public orderSeller ()
        {
            InitializeComponent();
            dbContext = new YourDbContext(); // Инициализируем объект контекста базы данных
        }

        private void Seller_Load ( object sender, EventArgs e )
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "elbrusDataSet.Clients". При необходимости она может быть перемещена или удалена.
            this.clientsTableAdapter.Fill(this.elbrusDataSet.Clients);
            // Получаем последний номер заказа из базы данных
            //string lastOrderCode = GenerateNewOrderCode();

            // Вставляем его в подсказку текстового поля для ввода номера заказа
            //textBox1.Text = lastOrderCode;
        }

        //private string GetLastOrderCode ()
        //{
        //    using (var dbContext = new YourDbContext())
        //    {
        //        // Получаем максимальное значение CodeOrder из таблицы Orders
        //        var lastOrder = dbContext.Orders.OrderByDescending(o => o.CodeOrder).FirstOrDefault();
        //        if (lastOrder != null)
        //        {
        //            return lastOrder.CodeOrder;
        //        }
        //        else
        //        {
        //            // Если нет заказов, возвращаем пустую строку или другое значение по умолчанию
        //            return "";
        //        }
        //    }
        //}


        //private string GenerateNewOrderCode ()
        //{
        //    string lastOrderCode = GetLastOrderCode();
        //    if (!string.IsNullOrEmpty(lastOrderCode))
        //    {
        //        // Разделяем строку кода заказа по символу '/'
        //        string[] parts = lastOrderCode.Split('/');
        //        if (parts.Length == 2)
        //        {
        //            // Парсим число из первой части
        //            if (int.TryParse(parts[0], out int lastNumber))
        //            {
        //                // Увеличиваем число на 1 и форматируем обратно в строку с добавлением даты
        //                lastNumber++;
        //                string newOrderCode = lastNumber.ToString() + "/" + DateTime.Now.ToString("dd.MM.yyyy");
        //                return newOrderCode;
        //            }
        //        }
        //    }
        //    // Если не удалось получить последний номер заказа или разобрать его, возвращаем значение по умолчанию
        //    return "1/" + DateTime.Now.ToString("dd.MM.yyyy");
        //}


        private void button4_Click ( object sender, EventArgs e )
        {
            // Открываем форму продавца
            Seller sellerForm = new Seller();
            sellerForm.Show();
            // Закрываем текущую форму заказа продавца
            this.Close();
        }

        private void textBox1_TextChanged ( object sender, EventArgs e )
        {
            // Дополнительные действия при изменении текста в текстовом поле
        }

        private void fillByToolStripButton_Click ( object sender, EventArgs e )
        {
            try
            {
                this.clientsTableAdapter.Fill(this.elbrusDataSet.Clients);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button7_Click ( object sender, EventArgs e )
        {
            // Показываем текстовое поле для добавления новой услуги
            textBox2.Visible = true;
            textBox2.Focus(); // Устанавливаем фокус на текстовое поле
        }

        //private void textBox2_TextChanged ( object sender, EventArgs e )/////////nenf ljltkfnm
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        // Добавляем новую услугу в ListBox
        //        listBox1.Items.Add(textBox2.Text);
        //        textBox2.Clear(); // Очищаем текстовое поле
        //        textBox2.Visible = false; // Скрываем текстовое поле
        //                                  // Остановим дальнейшую обработку события KeyPress
        //        e.Handled = true;
        //    }
        //}
    }
}
