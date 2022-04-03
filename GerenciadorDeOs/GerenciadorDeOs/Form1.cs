using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorDeOs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(TxtUser.Text != "" && TxtPassword.Text != "")
            {

                string user = Convert.ToString(TxtUser.Text);
                string password = Convert.ToString(TxtPassword.Text);

                DataBase banco = new DataBase();
                int retornado = banco.UsuarioExiste(user, password, "Login");
                
                if(retornado != 0)
                {

                    MessageBox.Show("algo");

                }
                else
                {

                    LblLogin.ForeColor = Color.Red;
                    TxtUser.Text = "";
                    TxtUser.Focus();
                    LblPassword.ForeColor = Color.Red;
                    TxtPassword.Text = "";

                }

            }


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
