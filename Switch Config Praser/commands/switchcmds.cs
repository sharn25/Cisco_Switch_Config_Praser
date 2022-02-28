using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switch_Config_Praser.commands
{
    class switchcmds
    {
        //interface and child cmds
        public static String INTERFACE_CMD = "interface ";
        public static String INTERFACE_DES = "description ";
        public static String INTERFACE_SW_ACC = "switchport access vlan ";
        public static String INTERFACE_SW_TRUCK = "switchport mode trunk";
        public static String INTERFACE_SHUTDOWN = "shutdown";
        public static String INTERFACE_NO_SHUTDOWN = "no shutdown";



        public static String INTERFACE_VLAN_CMD = "interface Vlan";
        public static String INTERGACE_IP = "ip address";
        public static String INTERGACE_NO_IP = "no ip address";

        public static String INTERFACE_LOOPBACK_CMD = "interface Loopback";

        //hostname and version
        public static String HOSTNAME_CMD = "hostname ";
        public static String VERSION_CMD = "version ";
    }
}
