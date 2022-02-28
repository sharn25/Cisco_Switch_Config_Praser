using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * Logger Class
 */
namespace Switch_Config_Praser.Utils
{
    class LogUtils
    {
		public static void log(String tag, String msg, Boolean t)
		{
			if (StaticResources.isDebugMode && t)
			{
				Console.WriteLine("[LOG] {0} : {1}", tag, msg);
			}
		}

		public static void info(String tag, String msg, Boolean t)
		{
			if (t)
			{
				Console.WriteLine("[INFO] {0} : {1}", tag, msg);
			}
		}
		public static void error(String tag, String msg, Boolean t)
		{
			if (t)
			{
				Console.WriteLine("[ERROR] {0} : {1}", tag, msg);
			}
		}

	}
}
