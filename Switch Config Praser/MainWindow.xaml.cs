using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Switch_Config_Praser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private String[] configFiles = new String[5];
        public MainWindow()
        {
            InitializeComponent();

            //Set Debug Mode
            StaticResources.isDebugMode = true;

            //Call MainProgram
            MainProgram mainProgram = new MainProgram();
            getConfigFiles();
            mainProgram.loadConfigs(configFiles);
            mainProgram.printOutput();
            mainProgram.createXLS();
        }

        private void getConfigFiles()
        {
            configFiles[0] = @"D:\S07_SWT_101";
            configFiles[1] = @"D:\S07_SWT_102";
            configFiles[2] = @"D:\d01-stcswt-101-confg";
            configFiles[3] = @"D:\d01-stcswt-102-confg";
            configFiles[4] = @"D:\d01-stcswt-103-confg";
        }
    }
}
