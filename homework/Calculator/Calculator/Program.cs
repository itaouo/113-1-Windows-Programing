using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    internal static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {   
            Model model = new Model();
            CalculatorForm form = new CalculatorForm(model);
            Application.EnableVisualStyles();
            Application.Run(form);
        }
    }
}
