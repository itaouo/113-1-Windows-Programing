using MyDrawing.model.command;
using System;
using System.Windows.Forms;

namespace MyDrawing
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Factory factory = new Factory();
            Model model = new Model(factory);
            PresentationModel presentationModel = new PresentationModel(model);
            MyDrawingForm form = new MyDrawingForm(presentationModel, model);
            Application.Run(form);
        }
    }
}
