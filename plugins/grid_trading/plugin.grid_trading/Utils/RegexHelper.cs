﻿using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Dragonfly.Plugin.GridTrading.Utils
{
    public class RegexHelper
    {
        #region 验证输入字符串是否与模式字符串匹配
        /// <summary>
        /// 验证输入字符串是否与模式字符串匹配，匹配返回true
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="pattern">模式字符串</param>        
        public static bool IsMatch(string input, string pattern)
        {
            return IsMatch(input, pattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 验证输入字符串是否与模式字符串匹配，匹配返回true
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <param name="pattern">模式字符串</param>
        /// <param name="options">筛选条件</param>
        public static bool IsMatch(string input, string pattern, RegexOptions options)
        {
            return Regex.IsMatch(input, pattern, options);
        }
        #endregion

        #region 返回匹配结果
        /// <summary>
        /// 匹配到的多项
        /// </summary>
        /// <param name="input">待验证字符串</param>
        /// <param name="pattern">匹配模式</param>
        /// <param name="strStart">匹配项的起始标志</param>
        /// <param name="strEnd">匹配项的结束标志</param>
        /// <param name="result">匹配结果</param>
        public static void GetMatchList(string input, string pattern, string strStart, string strEnd, List<string> result)
        {
            if (result == null)
                result = new List<string>();

            if (!IsMatch(input, pattern)) return;

            int startIdx = 0, endIdx = 0;
            Regex regex = new Regex(pattern);
            MatchCollection matchList = regex.Matches(input);
            foreach (Match item in matchList)
            {
                startIdx = item.Value.IndexOf(strStart);
                endIdx = item.Value.LastIndexOf(strEnd);
                result.Add(item.Value.Substring(startIdx + strStart.Length + 1, endIdx - startIdx - strStart.Length - 2));
            }
        }

        /// <summary>
        /// 匹配特定内容
        /// </summary>
        /// <param name="input">待验证字符串</param>
        /// <param name="pattern">匹配模式</param>
        /// <param name="strStart">匹配项的起始标志</param>
        /// <param name="strEnd">匹配项的结束标志</param>
        /// <returns>匹配结果</returns>
        public static string GetMatchItem(string input, string pattern, string strStart, string strEnd)
        {
            string result = string.Empty;

            if (!IsMatch(input, pattern)) return result;

            int startIdx = 0, endIdx = 0;
            Regex regex = new Regex(pattern);
            Match matchInfo = regex.Match(input);
            startIdx = matchInfo.Value.IndexOf(strStart);
            endIdx = matchInfo.Value.IndexOf(strEnd);

            result = matchInfo.Value.Substring(startIdx + strStart.Length + 1, endIdx - startIdx - strStart.Length - 2);

            return result;
        }

        #endregion

        #region 常用格式验证
        /// <summary>
        /// 中文字符
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsChineseWords(string input)
        {
            string strPattern = "^[\u4e00-\u9fa5]{0,}$";
            return IsMatch(input, strPattern);
        }

        /// <summary>
        /// 数字
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsValidNumber(string input)
        {
            string strPattern = @"^[0-9]*$";
            return IsMatch(input, strPattern);
        }

        /// <summary>
        /// 正实数（正浮点数）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsUnsignedRealNumber(string input)
        {
            string strPattern = @"^\d+(\.\d{1,2})?$";
            return IsMatch(input, strPattern);
        }

        /// <summary>
        /// 匹配正整数
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNumberUnsignedinteger(string input)
        {
            string strPattern = @"^[1-9]\d*$";
            return IsMatch(input, strPattern);
        }

        /// <summary>
        /// 只能输入某个区间数字
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNumberRange(string input, int min, int max)
        {
            string strPattern = string.Format(@"^[{0}-{1}]$", min, max);
            return IsMatch(input, strPattern);
        }

        /// <summary>
        /// 只能输入m到n个数字
        /// </summary>
        /// <param name="input"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsNumberLength(string input, int min, int max)
        {
            string strPattern = string.Format(@"\d{{0},{1}}$", min, max);
            return IsMatch(input, strPattern);
        }
        #endregion
    }
}