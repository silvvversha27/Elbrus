using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Elbrus
{
    public class YourDbContext : DbContext
    {
        // Определите свойства, которые будут представлять таблицы в базе данных
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }

        // Добавьте другие DbSet для других таблиц, если они есть

        // Определите конструктор для контекста, передавая строку подключения в базовый класс DbContext
        //--БД КБК:
        //public YourDbContext () : base("Data Source=wsr;Initial Catalog=Elbrus;User ID=user13;Password=1234;Encrypt=False") // Указывайте имя строки подключения, как в вашем app.config
        //{}
        //--БД ДОМАШНЯЯ:
        public YourDbContext() : base("name=Elbrus.Properties.Settings.ElbrusConnectionString3")
        {
        }


        // Определяем класс для сущности Employee, отображающий столбцы таблицы Employees в базе данных
        public class Employee
        {
            [Key] public int EmployeesID { get; set; }
            public string Post { get; set; }
            public string SurnName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Login { get; set; }
            public string Password { get; set; }
            public string LastEnter { get; set; }
            public string TypeInput { get; set; }
        }
        public class Order
        {
            [Key] public int OrdersID { get; set; }
            public string CodeOrder { get; set; }
            public DateTime Date { get; set; }
            public string Time { get; set; }
            public int CodeClient { get; set; }
            public string Status { get; set; }
            public DateTime DateExit { get; set; }
        }
    }

}
