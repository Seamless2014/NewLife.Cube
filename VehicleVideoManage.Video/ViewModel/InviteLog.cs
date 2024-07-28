using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleVideoManage.Video.ViewModel
{
    [Serializable]
    public class InviteLog
    {
        public int ID
        {
            get;
            set;
        }

        public string SimNo
        {
            get;
            set;
        }

        public string DeviceId
        {
            get;
            set;
        }

        public string PlateNo
        {
            get;
            set;
        }

        public int Channel
        {
            get;
            set;
        }

        public bool Tcp
        {
            get;
            set;
        }

        public string ServerIp
        {
            get;
            set;
        }

        public string Remark
        {
            get;
            set;
        }

        public string Descr
        {
            get;
            set;
        }

        public int ServerPort
        {
            get;
            set;
        }

        public string Owner
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public DateTime CreateTime
        {
            get;
            set;
        }

        public DateTime UpdateTime
        {
            get;
            set;
        }

        public InviteLog()
        {
            CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }
    }
}
