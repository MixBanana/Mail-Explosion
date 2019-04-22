using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace Mail_Explosion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This tool created by MixBanana.", "Mail Explosion");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = int.Parse(comboBox2.SelectedItem.ToString()); //Convert combobox from string to int
            var fromAddress = new MailAddress(textBox1.Text, textBox3.Text);

            var toAddress = new MailAddress(richTextBox2.Text, "To Name");
            string fromPassword = textBox2.Text;
            string subject = textBox5.Text;
            string body = richTextBox1.Text;

            var smtp = new SmtpClient
            {
                Host = comboBox1.Text,
                Port = x,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                IsBodyHtml = true, // Enable using HTML.
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //Port
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Password
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                textBox2.PasswordChar = '\0';
            else
                textBox2.PasswordChar = '*';
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                textBox2.PasswordChar = '\0';
            else
                textBox2.PasswordChar = '*';
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                textBox3.Show();
            }
            else
                textBox3.Hide();
            textBox3.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*'; //Hide password chars when app loaded.
            checkBox5.Hide();
            textBox3.Hide();
        }
    }
}