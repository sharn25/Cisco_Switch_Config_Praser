using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excel = Microsoft.Office.Interop.Excel;

namespace Switch_Config_Praser.Utils
{
    class ExcelUtils
    {
        private static String TAG = "ExcelUtils";
        public static int getRow(String value, Excel.Worksheet xSheet)
        {
            int row = 0;
            if(value==null || value.Equals(""))
            {
                return row;
            }
            Excel.Range S_range = xSheet.Range["A1:A" + xSheet.UsedRange.Rows.Count];
            Excel.Range finder = null;

            finder = S_range.Find(value, Type.Missing,
            Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart,
            Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlNext, false,
            Type.Missing, Type.Missing);

            if (finder == null)
            {
                LogUtils.error(TAG, "Find : null", false);
                return row;
            }
            row = finder.Row;
            return row;
        }
    }
}
