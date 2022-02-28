using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switch_Config_Praser.config.model
{
    class Interface
    {
        private String name;
        private String description;

        //childs
        List<String> childs;

        public Interface()
        {
            name = "";
            description = "";
        }

        public String getName()
        {
            return name;
        }
        public void setName(String s)
        {
            name = s;
        }
        public String getdescription()
        {
            return description;
        }
        public void setdescription(String s)
        {
            description = s;
        }

        public void setChilds(List<String> c)
        {
            childs = c;
        }
        public List<String> getChilds()
        {
            if (childs == null)
            {
                childs = new List<String>();
            }
            return childs;
        }
        public void addChild(String s)
        {
            getChilds().Add(s);
        }

        public String getChild(int index)
        {
            if (getChilds().Count > index)
            {
                return getChilds()[index];
            }
            else
            {
                return null;
            }
        }
    }
}
