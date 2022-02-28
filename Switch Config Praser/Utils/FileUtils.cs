using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switch_Config_Praser.Utils
{
    class FileUtils
    {
        private static String TAG = "FileUtils";
       public static String[] getFileArray(String path)
        {
            String[] arry = null;
            try
            {
                arry = File.ReadAllLines(path);
            }
            catch (Exception e)
            {
                LogUtils.log(TAG, "File not found. Path : " + path, true);
                return null;
            }
            return arry;
        }
    }
}
