using System;
using System.Windows.Forms;

namespace Dragonfly.Plugin.GridTrading.Utils
{
    public  class StringValidator
    {

        private static bool RegexCheck(string input, string errorMsg, Func<string, bool> checkMethod)
        {
            if (!checkMethod(input))
            {
                MessageBox.Show(errorMsg);
                return false;
            }
            return true;
        }

        private static bool RegexEmptyOrCheck(string input, string errorMsg, Func<string, bool> checkMethod)
        {
            return string.IsNullOrEmpty(input) || RegexCheck(input, errorMsg, checkMethod);
        }

        private static bool RegexNotEmptyAndCheck(string input, string errorMsg, Func<string, bool> checkMethod)
        {
            return string.IsNullOrEmpty(input) && RegexCheck(input, errorMsg, checkMethod);
        }


        // 正实数校验
        public static bool IsUnsignedRealNumber(string strCheck)
        {
            return RegexCheck(strCheck, "仅可输入正实数", RegexHelper.IsUnsignedRealNumber);
        }

        // 整数校验
        public static bool IsNumber(string strCheck)
        {
            return RegexCheck(strCheck, "仅可输入整数", RegexHelper.IsValidNumber);
        }

        // 正整数校验
        public static bool IsUnsignedNumber(string strCheck)
        {
            return RegexCheck(strCheck, "仅可输入正整数", RegexHelper.IsNumberUnsignedinteger);
        }

        // 字符串是否为空
        public static bool HasContent(string strCheck, string tipTitle)
        {
            if (strCheck == null || strCheck.Equals(string.Empty))
            {
                MessageBox.Show(tipTitle + "不可为空");
                return false;
            }
            return true;
        }

        // 必填或正整数
        public static bool IsNotEmptyAndUnsignedNumber(string strCheck)
        {
            return RegexNotEmptyAndCheck(strCheck, "仅可输入数字", RegexHelper.IsNumberUnsignedinteger); ;
        }

        // 必填或正实数
        public static bool IsNotEmptyAndUnsignedRealNumber(string strCheck)
        {
            return RegexNotEmptyAndCheck(strCheck, "仅可输入浮点数字", RegexHelper.IsUnsignedRealNumber); ;
        }

    }
}