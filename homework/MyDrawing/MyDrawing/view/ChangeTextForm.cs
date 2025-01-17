using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawing.view
{
    public partial class ChangeTextForm : Form
    {
        private PresentationModel presentationModel;
        public ChangeTextForm(PresentationModel presentationModel)
        {
            this.presentationModel = presentationModel;
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            presentationModel.pointerState.ChangeShapeText(changeNoteTextBox.Text);
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            ConfirmButton.Enabled = changeNoteTextBox.Text != "";
        }
    }
}
