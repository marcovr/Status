using Microsoft.VisualBasic.Devices;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Status
{
    class PerformanceStats : IDisposable
    {
        private PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private PowerStatus power = SystemInformation.PowerStatus;
        private ComputerInfo pcInfo = new ComputerInfo();

        public int CPULoad {
            get
            {
                return (int)cpuCounter.NextValue();
            }
        }

        public int RAMUsage
        {
            get
            {
                double fraction = (double)pcInfo.AvailablePhysicalMemory / pcInfo.TotalPhysicalMemory;
                return (int)Math.Round(100 - fraction * 100);
            }
        }

        public int BatteryPercent
        {
            get
            {
                return (int)Math.Round(power.BatteryLifePercent * 100);
            }
        }

        public bool BatteryCharging
        {
            get
            {
                return power.PowerLineStatus == PowerLineStatus.Online;
            }
        }

        public void Dispose()
        {
            cpuCounter.Dispose();
        }
    }
}
