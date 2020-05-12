using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Dragonfly.Plugin.GridTrading.Utils
{
    public class RegexHelper
    {
        private static Regex RegNumber = new Regex("^[0-9]+$");
        private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");

        public static bool IsNotEmpty(string inputData)
        {
            return !string.IsNullOrWhiteSpace(inputData);
        }

        private static bool IsNumber(string input)
        {
            Match m = RegNumber.Match(input);
            return m.Success;
        }

        private static bool IsDecimal(string input)
        {
            Match m = RegDecimal.Match(input);
            return m.Success;
        }

        private static bool RegexCheck(Control ctrl, string errorMsg, Func<string, bool> checkMethod)
        {
            string strCheck = ctrl.Text.Trim();
            if (string.IsNullOrWhiteSpace(strCheck) || !checkMethod(strCheck))
            {
                MessageBox.Show(errorMsg, "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                return false;
            }
            return true;
        }

        public static bool CheckIsNumberAndNotEmpty(Control ctrl)
        {
            return RegexCheck(ctrl, "请输入数字", RegexHelper.IsNumber);
        }

        public static bool CheckIsDecimalAndNotEmpty(Control ctrl)
        {
            return RegexCheck(ctrl, "请输入数字", RegexHelper.IsDecimal);

        }

        public static bool CheckNotEmpty(Control ctrl)
        {
            string strCheck = ctrl.Text.Trim();
            if (string.IsNullOrWhiteSpace(strCheck))
            {
                MessageBox.Show("该项为必填", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                return false;
            }
            return true;

        }


    }
}