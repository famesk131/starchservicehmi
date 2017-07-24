using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarchServiceHMI.Models
{
    public class TagConfig : IEquatable<TagConfig>
    {
        int id;
        string tag_id;
        string webpage;
        string tag_name;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Tag_id
        {
            get
            {
                return tag_id;
            }

            set
            {
                tag_id = value;
            }
        }

        public string Webpage
        {
            get
            {
                return webpage;
            }

            set
            {
                webpage = value;
            }
        }

        public string Tag_name
        {
            get
            {
                return tag_name;
            }

            set
            {
                tag_name = value;
            }
        }

        public bool Equals(TagConfig obj)
        {
            if (obj == null)
                return false;
            TagConfig objAsPart = obj as TagConfig;
            if (objAsPart == null)
                return false;
            else
                return Equals(objAsPart);
        }
    }
}