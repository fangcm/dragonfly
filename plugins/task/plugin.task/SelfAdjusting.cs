using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragonfly.Plugin.Task
{
    internal class SelfAdjusting
    {
/*
        private string GetTitleAndFileName(IntPtr handle, LogType type, out bool isAllowedByTitleAndFileNameFilter)
        {
            IntPtr destop = WindowUtils.GetDesktopWindow();
            if (destop == handle)
            {
                isAllowedByTitleAndFileNameFilter = false;
                return "";
            }

            int processId;
            WindowUtils.GetWindowThreadProcessId(handle, out processId);
            Process process = Process.GetProcessById(processId);
            string inputModuleFilename = process.MainModule.FileName;
            string curModuleFilename = Process.GetCurrentProcess().MainModule.FileName;
            if (inputModuleFilename == curModuleFilename)
            {
                isAllowedByTitleAndFileNameFilter = false;
                return "";
            }

            string windowTitle = WindowUtils.GetWindowText(handle);
            if (string.IsNullOrEmpty(windowTitle))
                windowTitle = "[NULL]";

            string titleAndFileName = windowTitle + inputModuleFilename;
            isAllowedByTitleAndFileNameFilter = IsAllowedByTitleAndFileNameFilter(type, titleAndFileName);
            if (!isAllowedByTitleAndFileNameFilter)
                return "";

            if (windowPrevHandle.Equals(handle))
                titleAndFileName = string.Empty;
            else
            {

                windowPrevHandle = handle;

                System.DateTime dt = DateTime.Now;
                string time = dt.ToString("u", DateTimeFormatInfo.InvariantInfo);
                titleAndFileName = time + " " + titleAndFileName;
            }
            return titleAndFileName;
        }
*/
    }


    internal class AdjustmentConfig
    {

    }
}
