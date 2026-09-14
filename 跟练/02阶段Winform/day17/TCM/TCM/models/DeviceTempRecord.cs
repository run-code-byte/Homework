using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCM.models
{
    internal class DeviceTempRecord : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private DateTime _CollectTime;
        public DateTime CollectTime
        {
            get { return _CollectTime; }
            set
            {
                _CollectTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CollectTime)));
            }
        }

        private ushort _DeviceStatus;
        public int  DeviceStatus
        {
            get { return _DeviceStatus; }
            set
            {
                _DeviceStatus = (ushort)value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DeviceStatus)));
            }
        }

        private ushort _SetTemp;
        public int SetTemp
        {
            get { return _SetTemp; }
            set
            {
                _SetTemp = (ushort)value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SetTemp)));
            }
        }

        private ushort _RealTemp;
        public int  RealTemp
        {
            get { return _RealTemp; }
            set
            {
                _RealTemp = (ushort)value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RealTemp)));
            }
        }

        private ushort _FaultCode;
        public int  FaultCode
        {
            get { return _FaultCode; }
            set
            {
                _FaultCode = (ushort)value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FaultCode)));
            }
        }

        public DeviceTempRecord(ushort[] DTR )
        {
            CollectTime = DateTime.Now;
            DeviceStatus = DTR[0];
            SetTemp = DTR[1];
            RealTemp = DTR[2];
            FaultCode = DTR[3];
        }
        public DeviceTempRecord() { }
    }
}
