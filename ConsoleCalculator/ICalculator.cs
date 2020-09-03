using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculator
{
   public interface ICalculator
    {
        void Operate(char oper);
        void ToggleCase();
        void CheckAndOperate(char key);
        bool SendKeyPress(char key);

    }
}
