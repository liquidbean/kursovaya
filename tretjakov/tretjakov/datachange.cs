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
    public partial class datachange : MetroForm
    {
        public datachange()
        {
            InitializeComponent();
        }

        private void datachange_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            String name = metroTextBox1.Text;
            String weight = metroTextBox2.Text;
            DB db = new DB();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("insert into `cargos` (name, weight) values (@uL, @uP)", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = weight;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Товар добавлен");
            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            String name = metroTextBox4.Text;

            DB db = new DB();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("insert into `drivers` (NameSurname) values (@uL)", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = name;


            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Водитель добавлен");
            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            String name = metroTextBox4.Text;

            DB db = new DB();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("DELETE FROM `drivers` WHERE NameSurname = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = name;


            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Водитель Удален");
            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            String name = metroTextBox7.Text;

            DB db = new DB();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("insert into `warehouse` (name) values (@uL)", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = name;


            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Склад добавлен");
            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            String name = metroTextBox7.Text;

            DB db = new DB();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("DELETE FROM `warehouse` WHERE name = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = name;


            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Водитель Удален");
            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            String number = metroTextBox3.Text;
            String model = metroTextBox5.Text;
            String dID = metroTextBox6.Text;

            DB db = new DB();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("insert into `vehicles` (number, Mark, drivers_id) values (@uN, @uM, @dID)", db.getConnection());
            command.Parameters.Add("@uN", MySqlDbType.VarChar).Value = number;
            command.Parameters.Add("@uM", MySqlDbType.VarChar).Value = model;
            command.Parameters.Add("@dID", MySqlDbType.VarChar).Value = dID;


            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Машина добавлена");
            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            String number = metroTextBox3.Text;
            String model = metroTextBox5.Text;
            String dID = metroTextBox6.Text;

            DB db = new DB();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("DELETE FROM `vehicles` WHERE number = @uN", db.getConnection());
            command.Parameters.Add("@uN", MySqlDbType.VarChar).Value = number;
            command.Parameters.Add("@uM", MySqlDbType.VarChar).Value = model;
            command.Parameters.Add("@dID", MySqlDbType.VarChar).Value = dID;


            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Машина удалена");
            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            String number = metroTextBox3.Text;
            String model = metroTextBox5.Text;
            String dID = metroTextBox6.Text;

            DB db = new DB();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("UPDATE `vehicles` SET drivers_id = @dID WHERE number = @uN", db.getConnection());
            command.Parameters.Add("@uN", MySqlDbType.VarChar).Value = number;
            command.Parameters.Add("@uM", MySqlDbType.VarChar).Value = model;
            command.Parameters.Add("@dID", MySqlDbType.VarChar).Value = dID;


            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Водитель изменен");
            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }

        private void metroButton15_Click(object sender, EventArgs e)
        {
            String dat = metroTextBox10.Text;
            String tim = metroTextBox13.Text;
            String dID = metroTextBox8.Text;
            String wID = metroTextBox11.Text;
            String cID = metroTextBox9.Text;
            String vID = metroTextBox12.Text;
            String adr = metroTextBox14.Text;

            DB db = new DB();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("insert into `routes` (cargos_id, vehicles_id, vehicles_drivers_id, warehouse_id, date, time, adres) values (@cID, @vID, @dID, @wID, @dT, @tI, @aD)", db.getConnection());
            command.Parameters.Add("@cID", MySqlDbType.VarChar).Value = cID;
            command.Parameters.Add("@vID", MySqlDbType.VarChar).Value = vID;
            command.Parameters.Add("@dID", MySqlDbType.VarChar).Value = dID;
            command.Parameters.Add("@wID", MySqlDbType.VarChar).Value = wID;
            command.Parameters.Add("@dT", MySqlDbType.VarChar).Value = dat;
            command.Parameters.Add("@tI", MySqlDbType.VarChar).Value = tim;
            command.Parameters.Add("@aD", MySqlDbType.VarChar).Value = adr;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Маршрут добавлен");
            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }

        private void metroButton14_Click(object sender, EventArgs e)
        {
            String dat = metroTextBox10.Text;
            String tim = metroTextBox13.Text;
            String dID = metroTextBox8.Text;
            String wID = metroTextBox11.Text;
            String cID = metroTextBox9.Text;
            String vID = metroTextBox12.Text;
            String adr = metroTextBox14.Text;
            DB db = new DB();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("DELETE FROM `routes` WHERE date = @dT AND time = @tI AND vehicles_id = @vID", db.getConnection());
            command.Parameters.Add("@cID", MySqlDbType.VarChar).Value = cID;
            command.Parameters.Add("@vID", MySqlDbType.VarChar).Value = vID;
            command.Parameters.Add("@dID", MySqlDbType.VarChar).Value = dID;
            command.Parameters.Add("@wID", MySqlDbType.VarChar).Value = wID;
            command.Parameters.Add("@dT", MySqlDbType.VarChar).Value = dat;
            command.Parameters.Add("@tI", MySqlDbType.VarChar).Value = tim;
            command.Parameters.Add("@aD", MySqlDbType.VarChar).Value = adr;


            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Маршрут удален");
            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
