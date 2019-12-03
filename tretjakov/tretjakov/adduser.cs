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
    public partial class adduser : MetroForm
    {
        public adduser()
        {
            InitializeComponent();
        }

        private void adduser_Load(object sender, EventArgs e)
        {

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            String login = metroTextBox1.Text;
            String password = metroTextBox2.Text;
            DB db = new DB();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("insert into `user` (login, password) values (@uL, @uP)", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = password;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Пользователь добавлен");
            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            String login = metroTextBox1.Text;
            String password = metroTextBox2.Text;
            DB db = new DB();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("DELETE FROM `user` WHERE login = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = password;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Пользователь Удален");
            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            String login = metroTextBox1.Text;
            String password = metroTextBox2.Text;
            DB db = new DB();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("UPDATE `user` SET password = @uP WHERE login = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = password;

            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Пароль изменен");
            else
                MessageBox.Show("Ошибка");

            db.closeConnection();
        }
    }
}
