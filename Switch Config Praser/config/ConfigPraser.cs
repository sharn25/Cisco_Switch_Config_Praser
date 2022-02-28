using Switch_Config_Praser.commands;
using Switch_Config_Praser.config.model;
using Switch_Config_Praser.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switch_Config_Praser.config
{
    class ConfigPraser
    {
        private static String TAG = "ConfigPraser";

        public static Config prase(String path)
        {
            String[] configArry = FileUtils.getFileArray(path);
            if(configArry == null || configArry.Length < 1)
            {
                LogUtils.error(TAG, "Unable to open config file at path - " + path, true);
                return null;
            }
            //Create config Object
            Config config = new Config(path);

            //Scan input config file arry
            for (int i = 0; i < configArry.Length; i++)
            {
                String curLine = configArry[i];
                LogUtils.log(TAG, "Line: " + curLine, false);
                if(!curLine.Equals("!") || !curLine.Equals(""))
                {
                    if (curLine.Contains(switchcmds.HOSTNAME_CMD))
                    {
                        config.setHostname(curLine.Replace(switchcmds.HOSTNAME_CMD, ""));
                    }else if (curLine.StartsWith(switchcmds.VERSION_CMD))
                    {
                        config.setVersion(curLine.Replace(switchcmds.VERSION_CMD, ""));
                    }else if (curLine.StartsWith(switchcmds.INTERFACE_CMD) && !curLine.Contains(switchcmds.INTERFACE_VLAN_CMD) && !curLine.Contains(switchcmds.INTERFACE_LOOPBACK_CMD))
                    {
                        InterfacePort interfacePort = new InterfacePort();
                        interfacePort.setName(curLine.Replace(switchcmds.INTERFACE_CMD, ""));

                        while (!curLine.Contains("!"))
                        {
                            i = i + 1;
                            curLine = configArry[i];
                            interfacePort.addChild(curLine);
                            if (curLine.Contains(switchcmds.INTERFACE_DES))
                            {
                                String des = curLine.Replace(switchcmds.INTERFACE_DES, "");//Get Port Description
                                if(des.StartsWith(" "))
                                {
                                    des = des.Substring(1);
                                }
                                interfacePort.setdescription(des);
                            }
                            else if (curLine.Contains(switchcmds.INTERFACE_SHUTDOWN) && !curLine.Contains(switchcmds.INTERFACE_NO_SHUTDOWN))//Get is the port is disable
                            {
                                interfacePort.setIsShutDown(true);
                            }else if (curLine.Contains(switchcmds.INTERFACE_SW_ACC))
                            {
                                interfacePort.setVlan(curLine.Replace(switchcmds.INTERFACE_SW_ACC, "").Trim());
                                interfacePort.setIstruckPort(false);
                                interfacePort.setIsVlanTagged(true);
                            }else if (curLine.Contains(switchcmds.INTERFACE_SW_TRUCK))
                            {
                                interfacePort.setIstruckPort(true);
                                interfacePort.setIsVlanTagged(false);
                            }
                            
                        }
                        config.addInterfacePort(interfacePort);
                    }else if (curLine.StartsWith(switchcmds.INTERFACE_VLAN_CMD) && !curLine.Contains(switchcmds.INTERFACE_LOOPBACK_CMD))
                    {
                        InterfaceVlan interfaceVlan = new InterfaceVlan();
                        interfaceVlan.setName("Vlan " + curLine.Replace(switchcmds.INTERFACE_VLAN_CMD,""));
                        while (!curLine.Contains("!"))
                        {
                            i = i + 1;
                            curLine = configArry[i];
                            interfaceVlan.addChild(curLine);
                            if (curLine.Contains(switchcmds.INTERFACE_DES))
                            {
                                String des = curLine.Replace(switchcmds.INTERFACE_DES, "");//Get Port Description
                                if (des.StartsWith(" "))
                                {
                                    des = des.Substring(1);
                                }
                                interfaceVlan.setdescription(des);
                            }else if (curLine.Contains(switchcmds.INTERGACE_IP) && !curLine.Contains(switchcmds.INTERGACE_NO_IP))
                            {
                                String ip = curLine.Replace(switchcmds.INTERGACE_IP, "");
                                while(ip.StartsWith(" "))
                                {
                                    ip = ip.Substring(1);
                                }
                                int index = ip.IndexOf(" ");
                                String ipaddress = ip.Substring(0, index).Trim();
                                interfaceVlan.setIpAdrress(ipaddress);
                                interfaceVlan.setSubNetMask(ip.Substring(index).Trim());
                            }
                        }
                        config.addInterfaceVlan(interfaceVlan);
                    }
                    else if (curLine.Contains(switchcmds.INTERFACE_LOOPBACK_CMD))
                    {

                    }
                }
            }
            return config;
        }
    }
}
