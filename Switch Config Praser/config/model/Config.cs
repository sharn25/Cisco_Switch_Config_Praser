using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switch_Config_Praser.config.model
{
    class Config
    {
        private String filePath;

        //String
        private String hostname;
        private String version;

        //Interfaces
        List<InterfacePort> interfacePorts;
        List<InterfaceVlan> interfaceVlans;

        public Config(String path)
        {
            filePath = path;
        }

        public void setHostname(String s)
        {
            hostname = s;
        }
        public String getHostName()
        {
            return hostname;
        }
        public void setVersion(String s)
        {
            version = s;
        }
        public String getVersion()
        {
            return version;
        }
        public void setInterfaceVlan(List<InterfaceVlan> InterfaceVlans)
        {            
            interfaceVlans = InterfaceVlans;
        }
        public List<InterfaceVlan> getInterfaceVlans()
        {
            if (interfaceVlans == null)
            {
                interfaceVlans = new List<InterfaceVlan>();
            }
            return interfaceVlans;
        }
        public void setInterfacePorts(List<InterfaceVlan> InterfacePorts)
        {
            interfaceVlans = InterfacePorts;
        }
        public List<InterfacePort> getInterfacePorts()
        {
            if (interfacePorts == null)
            {
                interfacePorts = new List<InterfacePort>();
            }
            return interfacePorts;
        }

        public void addInterfaceVlan(InterfaceVlan iv)
        {
            getInterfaceVlans().Add(iv);
        }
        public InterfaceVlan getInterfaceVlan(int index)
        {
            if (getInterfaceVlans().Count > index)
            {
                return getInterfaceVlans()[index];
            }
            else
            {
                return null;
            }
           
        }
        public void addInterfacePort(InterfacePort iv)
        {
            getInterfacePorts().Add(iv);
        }
        public InterfacePort getInterfacePort(int index)
        {
            if (getInterfacePorts().Count > index)
            {
                return getInterfacePorts()[index];
            }
            else
            {
                return null;
            }
        }
    }
}
