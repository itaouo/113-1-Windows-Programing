using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        private Model model;

        public CalculatorForm(Model model)
        {
            this.model = model;
            InitializeComponent();
        }

        public void number1Button_Click(object sender, EventArgs e)
        {
            model.ProcessDigit(1);
            ioTextBox.Text = model.getText();
        }

        public void number2Button_Click(object sender, EventArgs e)
        {
            model.ProcessDigit(2);
            ioTextBox.Text = model.getText();
        }

        public void number3Button_Click(object sender, EventArgs e)
        {
            model.ProcessDigit(3);
            ioTextBox.Text = model.getText();
        }

        public void number4Button_Click(object sender, EventArgs e)
        {
            model.ProcessDigit(4);
            ioTextBox.Text = model.getText();
        }

        public void number5Button_Click(object sender, EventArgs e)
        {
            model.ProcessDigit(5);
            ioTextBox.Text = model.getText();
        }

        public void number6Button_Click(object sender, EventArgs e)
        {
            model.ProcessDigit(6);
            ioTextBox.Text = model.getText();
        }

        public void number7Button_Click(object sender, EventArgs e)
        {
            model.ProcessDigit(7);
            ioTextBox.Text = model.getText();
        }

        public void number8Button_Click(object sender, EventArgs e)
        {
            model.ProcessDigit(8);
            ioTextBox.Text = model.getText();
        }

        public void number9Button_Click(object sender, EventArgs e)
        {
            model.ProcessDigit(9);
            ioTextBox.Text = model.getText();
        }

        public void number0Button_Click(object sender, EventArgs e)
        {
            model.ProcessDigit(0);
            ioTextBox.Text = model.getText();
        }

        public void decimalPointButton_Click(object sender, EventArgs e)
        {
            model.ProcessDot();
            ioTextBox.Text = model.getText();
        }

        public void EqualButton_Click(object sender, EventArgs e)
        {
            model.ProcessEqual();
            ioTextBox.Text = model.getText();
        }

        public void plusButton_Click(object sender, EventArgs e)
        {
            model.ProcessOperation('+');
            ioTextBox.Text = model.getText();
        }

        public void minusButton_Click(object sender, EventArgs e)
        {
            model.ProcessOperation('-');
            ioTextBox.Text = model.getText();
        }

        public void multiplicationButton_Click(object sender, EventArgs e)
        {
            model.ProcessOperation('*');
            ioTextBox.Text = model.getText();
        }

        public void divisionButton_Click(object sender, EventArgs e)
        {
            model.ProcessOperation('/');
            ioTextBox.Text = model.getText();
        }

        public void ClearAllButton_Click(object sender, EventArgs e)
        {
            model.ProcessC();
            ioTextBox.Text = model.getText();
        }

        public void ClearInputButton_Click(object sender, EventArgs e)
        {
            model.ProcessCE();
            ioTextBox.Text = model.getText();
        }

        private void MemoryClearButton_Click(object sender, EventArgs e)
        {
            model.ProcessMemoryClear();
        }

        private void MemoryRecallButton_Click(object sender, EventArgs e)
        {
            model.ProcessMemoryRecall();
            ioTextBox.Text = model.getText();
        }

        private void MemoryPlusButton_Click(object sender, EventArgs e)
        {
            model.ProcessMemoryPlus();
        }

        private void MemoryMinusButton_Click(object sender, EventArgs e)
        {
            model.ProcessMemoryMinus();
        }

        private void MemorySupplantButton_Click(object sender, EventArgs e)
        {
            model.ProcessMemorySupplant();
        }
    }
}
