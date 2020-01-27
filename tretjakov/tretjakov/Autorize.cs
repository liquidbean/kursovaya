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
    public partial class Autorize : MetroForm
    {
        public Autorize()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            String login = metroTextBox1.Text;
            String password = metroTextBox2.Text;
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `login` = @uL AND `password` = @uP", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = password;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if(table.Rows.Count > 0)
            {
                Main main = new Main();
                main.Show();
            }
            else
            {
                MessageBox.Show("Пользователь не найден", "Ошибка");
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {

            DB db = new DB();

            try
            {
                db.openConnection();
                if (db.getConnection() != null){
                    MessageBox.Show("Соединение есть");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Соеденения нет");
            }

        }
    }
}
