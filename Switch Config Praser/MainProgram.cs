using Microsoft.Office.Interop.Excel;
using Switch_Config_Praser.config;
using Switch_Config_Praser.config.model;
using Switch_Config_Praser.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excel = Microsoft.Office.Interop.Excel;

namespace Switch_Config_Praser
{
    class MainProgram
    {
        private static String TAG = "MainProgram";
        List<Config> configObjs = new List<Config>();

        public void loadConfigs(String[] configFiles)
        {
            for(int i = 0; i < configFiles.Length; i++)
            {
                Config config = ConfigPraser.prase(configFiles[i]);
                if (config == null)
                {
                    continue;
                }
                configObjs.Add(config);
            }
        }

        public void printOutput()
        {
            for(int i = 0; i < configObjs.Count; i++)
            {
                Config config = configObjs[i];
                LogUtils.log(TAG, "HostName - " + config.getHostName(), true);
                LogUtils.log(TAG, "Version - " + config.getVersion() , true);
                LogUtils.log(TAG, "Total Interface Ports - " + config.getInterfacePorts().Count, true);
                LogUtils.log(TAG, "Total Vlan Interface - " + config.getInterfaceVlans().Count + "\n", true);
            }
        }

        public void createXLS()
        {
            Excel.Application xApp = new Excel.Application();
            if (xApp == null)
            {
                LogUtils.error(TAG, "Unable to get Excel Application.", true);
                return;
            }
            object misValue = System.Reflection.Missing.Value;
            Excel.Workbook xWorkBook = xApp.Workbooks.Add(Type.Missing);

            Excel.Worksheet xWorkSheet = xWorkBook.Worksheets.get_Item(1);

            int f_row = 1, f_col = 1;
            int row, col = 2;

            (xWorkSheet.Cells[f_row, f_col] as Range).Value = "Elements";
            for (int i = 0; i< configObjs.Count; i++)
            {
                col = col + i;
                (xWorkSheet.Cells[f_row, col] as Range).Value = "Config " + (i+1);
                Config config = configObjs[i];
                String hostname = config.getHostName();
                String version = config.getVersion();

                //Hostname
                row = ExcelUtils.getRow("Hostname", xWorkSheet);
                if (row == 0) {
                    row = xWorkSheet.UsedRange.Rows.Count + 1;
                    (xWorkSheet.Cells[row, f_col] as Range).Value = "Hostname";
                }
                (xWorkSheet.Cells[row, col] as Range).Value = hostname;

                //Version
                row = ExcelUtils.getRow("Version", xWorkSheet);
                if (row == 0)
                {
                    row = xWorkSheet.UsedRange.Rows.Count + 1;
                    (xWorkSheet.Cells[row, f_col] as Range).Value = "Version";
                }
                (xWorkSheet.Cells[row, col] as Range).Value = version;

                //Total Interface
                row = ExcelUtils.getRow("Total Interface Ports", xWorkSheet);
                if (row == 0)
                {
                    row = xWorkSheet.UsedRange.Rows.Count + 1;
                    (xWorkSheet.Cells[row, f_col] as Range).Value = " Total Interface Ports";
                }
                List<InterfacePort> interfacePorts = config.getInterfacePorts();
                (xWorkSheet.Cells[row, col] as Range).Value = interfacePorts.Count;

                //Total Interface
                row = ExcelUtils.getRow("Total Interface VLANS", xWorkSheet);
                if (row == 0)
                {
                    row = xWorkSheet.UsedRange.Rows.Count + 1;
                    (xWorkSheet.Cells[row, f_col] as Range).Value = "Total Interface VLANS";
                }
                List<InterfaceVlan> interfaceVlans = config.getInterfaceVlans();
                (xWorkSheet.Cells[row, col] as Range).Value = interfaceVlans.Count;

                //Port Interfaces
                for(int j = 0; j < interfacePorts.Count; j++)
                {
                    InterfacePort interfacePort = interfacePorts[j];
                    String name = interfacePort.getName();
                    row = ExcelUtils.getRow(name, xWorkSheet);
                    if (row == 0)
                    {
                        row = xWorkSheet.UsedRange.Rows.Count + 1;
                        (xWorkSheet.Cells[row, f_col] as Range).Value = name;
                    }
                    (xWorkSheet.Cells[row, col] as Range).Value = interfacePort.getVlan();
                }

                //VLan interfaces
                for (int j = 0; j < interfaceVlans.Count; j++)
                {
                    InterfaceVlan interfaceVlan = interfaceVlans[j];
                    String name = interfaceVlan.getName();
                    row = ExcelUtils.getRow(name, xWorkSheet);
                    if (row == 0)
                    {
                        row = xWorkSheet.UsedRange.Rows.Count + 1;
                        (xWorkSheet.Cells[row, f_col] as Range).Value = name;
                    }
                    (xWorkSheet.Cells[row, col] as Range).Value = interfaceVlan.getIpAddress();
                }
            }

            //Save XLS
            xWorkBook.SaveAs(@"E:\Other\Tools\My_Work\Project_TLC\Tool\CCAT\Output.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xWorkBook.Close(true, misValue, misValue);
            xApp.Quit();
        }
    }
}
