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
    public partial class Order : Form
    {
        public Order ()
        {
            InitializeComponent();
        }

        private void label1_Click ( object sender, EventArgs e )
        {

        }

        private void Order_Load ( object sender, EventArgs e )
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "elbrusDataSet.Services". При необходимости она может быть перемещена или удалена.
            this.servicesTableAdapter.Fill(this.elbrusDataSet.Services);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "elbrusDataSet.Clients". При необходимости она может быть перемещена или удалена.
            this.clientsTableAdapter.Fill(this.elbrusDataSet.Clients);

        }

        private void label3_Click ( object sender, EventArgs e )
        {

        }

        private void button4_Click ( object sender, EventArgs e )
        {

        }

        private void label4_Click ( object sender, EventArgs e )
        {

        }

        private void textBox1_TextChanged ( object sender, EventArgs e )
        {

        }

        private void button1_Click ( object sender, EventArgs e )
        {

        }
    }
}
