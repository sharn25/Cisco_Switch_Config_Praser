using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switch_Config_Praser.config.model
{
    class InterfacePort : Interface
    {
        private String vlan;

        private Boolean isvlanTagged;
        private Boolean istruckPort;
        private Boolean isshutDown;
        private String ipAddress;
        private String subNetMask;

        public InterfacePort()
        {
            vlan = "1";
            isvlanTagged = false;
            istruckPort = false;
            isshutDown = false;
            ipAddress = "";
            subNetMask = "";
        }
        public void setIpAdrress(String s)
        {
            ipAddress = s;
        }
        public String getIpAddress(String s)
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

        public String getVlan()
        {
            return vlan;
        }
        public void setVlan(String s)
        {
            vlan = s;
        }

        public void setIsVlanTagged(Boolean b)
        {
            isvlanTagged = b;
        }
        public Boolean isVlanTagged()
        {
            return isvlanTagged;
        }
        public void setIstruckPort(Boolean b)
        {
            istruckPort = b;
        }
        public Boolean isTruckPort()
        {
            return istruckPort;
        }
        public void setIsShutDown(Boolean b)
        {
            isshutDown = b;
        }
        public Boolean IsShutDown()
        {
            return isshutDown;
        }
    }
}
