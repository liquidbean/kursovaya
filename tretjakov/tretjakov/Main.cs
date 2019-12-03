using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;
using MetroFramework.Fonts;
using MySql.Data.MySqlClient;

namespace tretjakov
{
    public partial class Main : MetroForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
        private void SetBorderAndGridlineStyles()
        {
            this.dataGridView1.GridColor = Color.BlueViolet;
            this.dataGridView1.CellBorderStyle =
                DataGridViewCellBorderStyle.None;
            this.dataGridView1.RowHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT vehicles.number AS 'Номер машины', vehicles.mark AS 'Марка машины', drivers.NameSurname AS 'Имя водителя' FROM `vehicles` JOIN `drivers` ON drivers.id = vehicles.drivers_id", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            Autorize aut = new Autorize();
            aut.Show();
            this.Close();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `drivers`", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `cargos`", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT routes.date AS 'Дата', routes.time AS 'Время', routes.adres AS 'Адрес доставки', drivers.NameSurname AS 'Имя Водителя', CONCAT(vehicles.mark, '  ', vehicles.number) AS 'Машина', cargos.name AS 'Товар', cargos.weight AS 'Вес товара', warehouse.name AS 'Склад' FROM `routes` JOIN `drivers` ON(drivers.id = vehicles_drivers_id)JOIN `vehicles` ON(vehicles.id = vehicles_id)JOIN `cargos` ON(cargos.id = cargos_id)JOIN `warehouse` ON(warehouse.id = warehouse_id); ", db.getConnection()); ;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `warehouse`", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            adduser au = new adduser();
            au.Show();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            datachange dc = new datachange();
            dc.Show();
        }
    }
}
