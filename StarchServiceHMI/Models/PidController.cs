using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarchServiceHMI.Models
{
    public class PidController
    {
        private int id;
        private String name;
        private Boolean isAutoMode;
        private String pvValue;
        private String coValue;
        private String spValue;
        private String kpValue;
        private String kiValue;
        private String kdValue;

        // Tag name
        private String mode;
        private String pv;
        private String co;
        private String sp;
        private String kp;
        private String ki;
        private String kd;

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

        public bool IsAutoMode
        {
            get
            {
                return isAutoMode;
            }

            set
            {
                isAutoMode = value;
            }
        }

        public string Mode
        {
            get
            {
                return mode;
            }

            set
            {
                mode = value;
            }
        }

        public string Pv
        {
            get
            {
                return pv;
            }

            set
            {
                pv = value;
            }
        }

        public string Co
        {
            get
            {
                return co;
            }

            set
            {
                co = value;
            }
        }

        public string Sp
        {
            get
            {
                return sp;
            }

            set
            {
                sp = value;
            }
        }

        public string Kp
        {
            get
            {
                return kp;
            }

            set
            {
                kp = value;
            }
        }

        public string Ki
        {
            get
            {
                return ki;
            }

            set
            {
                ki = value;
            }
        }

        public string Kd
        {
            get
            {
                return kd;
            }

            set
            {
                kd = value;
            }
        }

        public string PvValue
        {
            get
            {
                return pvValue;
            }

            set
            {
                pvValue = value;
            }
        }

        public string CoValue
        {
            get
            {
                return coValue;
            }

            set
            {
                coValue = value;
            }
        }

        public string SpValue
        {
            get
            {
                return spValue;
            }

            set
            {
                spValue = value;
            }
        }

        public string KpValue
        {
            get
            {
                return kpValue;
            }

            set
            {
                kpValue = value;
            }
        }

        public string KiValue
        {
            get
            {
                return kiValue;
            }

            set
            {
                kiValue = value;
            }
        }

        public string KdValue
        {
            get
            {
                return kdValue;
            }

            set
            {
                kdValue = value;
            }
        }

        //Mode of PID-Controller
        public static bool tranformModeValue(string value)
        {
            bool isAutoMode = false;
            if (value == "True")
                isAutoMode = true;
            else
                isAutoMode = false;
            return isAutoMode;
        }
    }
}