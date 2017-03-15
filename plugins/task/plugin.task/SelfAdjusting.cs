using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Dragonfly.Plugin.Task
{
    internal class SelfAdjusting
    {
        internal static AdjustmentCondition CheckTriggeredCondition()
        {
            AdjustmentCondition con = GetAdjustmentCondition();
            if (con == null || con.Accumulated)
            {
                //累计的
                return null;
            }

            return con;
        }

        internal static AdjustmentCondition CheckAccumulatedCondition()
        {
            AdjustmentCondition con = GetAdjustmentCondition();
            if (con == null || !con.Accumulated)
            {
                //非累计的
                return null;
            }
            return con;
        }

        private static AdjustmentCondition GetAdjustmentCondition()
        {
            SettingHelper helper = SettingHelper.GetInstance();
            if (helper.PluginSetting == null || helper.PluginSetting.AdjustmentSetting == null ||
                helper.PluginSetting.AdjustmentSetting.Conditions == null ||
                helper.PluginSetting.AdjustmentSetting.Conditions.Count == 0)
            {
                return null;
            }

            SelfAdjusting.FullForegroundWindowInfo();

            AdjustmentCondition foregroundWindowCondition = null;
            List<AdjustmentCondition> conditions = helper.PluginSetting.AdjustmentSetting.Conditions;
            foreach (AdjustmentCondition con in conditions)
            {
                //0 filename, 1 title, 2 processname
                switch (con.ConditionType)
                {
                    case 0:
                        if (string.Empty.Equals(ForegroundWindowFileName))
                        {
                            break;
                        }
                        if (ForegroundWindowFileName.EndsWith(con.ConditionValue))
                        {
                            foregroundWindowCondition = con;
                            break;
                        }
                        break;
                    case 1:
                        if (string.Empty.Equals(ForegroundWindowTitle))
                        {
                            break;
                        }
                        if (ForegroundWindowTitle.StartsWith(con.ConditionValue))
                        {
                            foregroundWindowCondition = con;
                            break;
                        }
                        break;
                    case 2:
                        if (string.Empty.Equals(ForegroundWindowProcessName))
                        {
                            break;
                        }
                        if (ForegroundWindowProcessName.EndsWith(con.ConditionValue))
                        {
                            foregroundWindowCondition = con;
                            break;
                        }
                        break;

                }
                if (foregroundWindowCondition != null)
                {
                    break;
                }
            }
            return foregroundWindowCondition;
        }

        private static string ForegroundWindowTitle { set; get; }
        private static string ForegroundWindowFileName { set; get; }
        private static string ForegroundWindowProcessName { set; get; }

        private static void FullForegroundWindowInfo()
        {
            IntPtr foregroundWindowHandle = GetForegroundWindow();
            IntPtr destop = GetDesktopWindow();
            if (destop == foregroundWindowHandle)
            {
                ForegroundWindowTitle = string.Empty;
                ForegroundWindowFileName = string.Empty;
                ForegroundWindowProcessName = string.Empty;
                return;
            }

            int processId;
            GetWindowThreadProcessId(foregroundWindowHandle, out processId);

            Process process = Process.GetProcessById(processId);
            ForegroundWindowFileName = process.MainModule.FileName;
            ForegroundWindowTitle = process.MainWindowTitle;
            ForegroundWindowProcessName = process.ProcessName;

            Debug.WriteLine("ForegroundWindowFileName:" + ForegroundWindowFileName);
            Debug.WriteLine("ForegroundWindowTitle:" + ForegroundWindowTitle);
            Debug.WriteLine("ForegroundWindowProcessName:" + ForegroundWindowProcessName);

        }



        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

    }



}
