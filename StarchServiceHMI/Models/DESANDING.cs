using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarchServiceHMI.Models
{
    public class DESANDING
    {
        public string name;
        private string tapioca;


        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Tapioca
        {
            get
            {
                return tapioca;
            }

            set
            {
                tapioca = value;
            }
        }
    }
}