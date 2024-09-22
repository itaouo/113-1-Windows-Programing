using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hello_World
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            studentGridView.Rows.Add("111820029", "Rita");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void enterStudentTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            String id = idTextBox.Text;
            String name = nameTextBox.Text;

            if (id == "")
            {
                MessageBox.Show("Please enter ID");
            }
            else if (name == "")
            {
                MessageBox.Show("Please enter name");
            }
            else
            {
                studentGridView.Rows.Add(idTextBox.Text, nameTextBox.Text);
            }
        }
    }
}
