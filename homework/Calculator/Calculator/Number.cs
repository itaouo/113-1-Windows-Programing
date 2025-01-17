using System;
using System.Data;
using System.Windows.Forms;

public class Number
{
    private double Value { get; set; }
    private int Power { get; set; }

    public Number()
    {
        Value = 0;
        Power = 0;
    }

    public double GetDouble()
    {
        return Value;
    }

    public String GetString()
    {
        if (Power == -1)
        {
            return Value.ToString() + '.';
        }
        return Value.ToString();
    }

    public void SetNumber(double number)
    {
        Value = number;
        String numberString = number.ToString();
        Power = numberString.IndexOf('.') + 1;
    }

    public bool hasDicimalPoint()
    {
        if (Power != 0)
        {
            return true;
        }
        return false;
    }

    public void EnterDigit(int inputNum)
    {
        if (Power == 0)
        {
            Value = Value * 10 + inputNum;
        }
        else
        {
            Value = Value + inputNum * Math.Pow(10, Power);
            Power--;
        }
    }

    public void EnterDecimalPoint()
    {
        if (!hasDicimalPoint())
        {
            Power--;
        }
    }
}