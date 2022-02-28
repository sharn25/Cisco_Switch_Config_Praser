using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switch_Config_Praser.config.model
{
    class InterfaceVlan : Interface
    {
        private String ipAddress;
        private String subNetMask;

        public InterfaceVlan()
        {
            ipAddress = "";
            subNetMask = "";
        }

        public void setIpAdrress(String s)
        {
            ipAddress = s;
        }
        public String getIpAddress()
        {
            return ipAddress;
        }
        public void setSubNetMask(String s)
        {
            subNetMask = s;
        }
        public String getSubNetMask()
        {
            return subNetMask;
        }
    }
}
