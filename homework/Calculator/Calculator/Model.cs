using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Serialization;

namespace Calculator
{
    public class Model
    {
        private char symbol = ' ';
        private bool IsLastStepNumeric = true;
        private Number lhs = new Number();
        private Number result = new Number();
        private Number memory = new Number();
        private Number lastNum = new Number();

        public String getText() { return lastNum.GetString(); }

        public void ProcessDigit(int digit)
        {
            if (lhs.GetDouble() != 0 && !IsLastStepNumeric)
            {
                ProcessC();
            }
            lhs.EnterDigit(digit);
            IsLastStepNumeric = true;
            lastNum = lhs;
        }

        public void ProcessDot()
        {
            if (lhs.GetDouble() != 0 && !IsLastStepNumeric)
            {
                ProcessC();
            }
            lhs.EnterDecimalPoint();
            IsLastStepNumeric = true;
            lastNum = lhs;
        }

        public void ProcessOperation(char s)
        {
            if (lhs.GetDouble() != 0 && result.GetDouble() != 0 && IsLastStepNumeric)
            {
                Calculate();
            }
            else if (lhs.GetDouble() != 0 && IsLastStepNumeric)
            {
                result.SetNumber(lhs.GetDouble());
            }
            lhs.SetNumber(0);
            symbol = s;
            lastNum = result;
            IsLastStepNumeric = false;
        }

        public void ProcessEqual()
        {
            if (symbol != ' ')
            {
                if (lhs.GetDouble() == 0)
                {
                    lhs.SetNumber(result.GetDouble());
                }
                Calculate();
                IsLastStepNumeric = false;
            }
        }

        public void ProcessCE()
        {
            if (lastNum == result)
            {
                lhs.SetNumber(0);
            }
            lastNum.SetNumber(0);
            IsLastStepNumeric = false;
        }

        public void ProcessC()
        {
            lhs.SetNumber(0);
            result.SetNumber(0);
            IsLastStepNumeric = false;
            symbol = ' ';
        }

        public void ProcessMemoryClear()
        {
            memory.SetNumber(0);
            IsLastStepNumeric = false;
        }

        public void ProcessMemoryRecall()
        {
            lhs.SetNumber(memory.GetDouble());
            lastNum = lhs;
            IsLastStepNumeric = false;
        }

        public void ProcessMemoryPlus()
        {
            memory.SetNumber(memory.GetDouble() + lastNum.GetDouble());
            IsLastStepNumeric = false;
        }

        public void ProcessMemoryMinus()
        {
            memory.SetNumber(memory.GetDouble() - lastNum.GetDouble());
            IsLastStepNumeric = false;
        }

        public void ProcessMemorySupplant()
        {
            memory.SetNumber(lastNum.GetDouble());
            IsLastStepNumeric = false;
        }

        public void Calculate()
        {
            switch (symbol)
            {
                case '+':
                    result.SetNumber(result.GetDouble() + lhs.GetDouble());
                    break;
                case '-':
                    result.SetNumber(result.GetDouble() - lhs.GetDouble());
                    break;
                case '*':
                    result.SetNumber(result.GetDouble() * lhs.GetDouble());
                    break;
                case '/':
                    result.SetNumber(result.GetDouble() / lhs.GetDouble());
                    break;
                default:
                    break;
            }
            lastNum = result;
        }
    }
}
