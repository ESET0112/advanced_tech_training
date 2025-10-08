namespace day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ISmartDevice> smartDevices = new List<ISmartDevice>
        {
            new Light("Light"),
            new Fan("Fan"),
            new Thermostat("Thermostat")
        };

            Console.WriteLine("=== SMART HOME DEVICE SYSTEM ===");
            Console.WriteLine();

            Console.WriteLine("1. TURNING ON ALL DEVICES:");
            Console.WriteLine("---------------------------");
            foreach (var device in smartDevices)
            {
                device.TurnOn();
            }
            Console.WriteLine();

            Console.WriteLine("2. CONNECTING TO WIFI:");
            Console.WriteLine("----------------------");
            foreach (var device in smartDevices)
            {
                device.ConnectToWiFi("Wifi_5G");
            }
            Console.WriteLine();

            Console.WriteLine("3. DEVICE STATUS:");
            Console.WriteLine("-----------------");
            foreach (var device in smartDevices)
            {
                device.ShowStatus();
            }
            Console.WriteLine();

            

        }
    }
    public interface IDevice
    {
        string DeviceName { get; set; }
        bool IsOn { get; set; }

        public void TurnOn();
        public void TurnOff();
    }
    public interface ISmartDevice : IDevice 
    {
        void ConnectToWiFi(string networkName);
        void ShowStatus();
    }
    public class Light: ISmartDevice
    {
        public string DeviceName { get; set; }
        public bool IsOn { get; set; }
        public int Brightness { get; set; }


        public Light(string name)
        {
            DeviceName = name;
            IsOn = false;
            Brightness = 0;
        }
        public void TurnOn()
        {
            if (IsOn == false)
            {
                IsOn = true;
            }
        }
        public void TurnOff()
        {
            if (IsOn)
            {
                IsOn = false;
            }
        }

        public void ConnectToWiFi(string networkName)
        {
            Console.WriteLine($"{DeviceName} connected to WiFi: {networkName}");
        }

        public void ShowStatus()
        {
            string status = IsOn ? "On" : "Off";
            Console.WriteLine($"Device Name: {DeviceName} | Status: {status} | Brightness: {Brightness} ");
        }

    }

    public class Fan : ISmartDevice
    {
        public string DeviceName { get; set; }
        public bool IsOn { get; set; }
        public int Speed { get; set; }


        public Fan(string name)
        {
            DeviceName = name;
            IsOn = false;
            Speed = 0;
        }
        public void TurnOn()
        {
            if (IsOn == false)
            {
                IsOn = true;
                this.Speed = 50;
            }
        }
        public void TurnOff()
        {
            if (IsOn)
            {
                IsOn = false;
                this.Speed = 0;
            }
        }

        public void ConnectToWiFi(string networkName)
        {
            Console.WriteLine($"{DeviceName} connected to WiFi: {networkName}");
        }

        public void ShowStatus()
        {
            string status = IsOn ? "On" : "Off";
            Console.WriteLine($"Device Name: {DeviceName} | Status: {status} | Speed: {Speed} ");
        }

    }
    public class Thermostat : ISmartDevice
    {
        public string DeviceName { get; set; }
        public bool IsOn { get; set; }
        public int Temparature { get; set; }


        public Thermostat(string name)
        {
            DeviceName = name;
            IsOn = false;
            Temparature = 0;
        }

        public void TurnOn()
        {
            if (IsOn == false)
            {
                IsOn = true;
                this.Temparature = 30;
            }
        }
        public void TurnOff()
        {
            if (IsOn)
            {
                IsOn = false;
                this.Temparature = 0;
            }
        }

        public void ConnectToWiFi(string networkName)
        {
            Console.WriteLine($"{DeviceName} connected to WiFi: {networkName}");
        }

        public void ShowStatus()
        {
            string status = IsOn ? "On" : "Off";
            Console.WriteLine($"Device Name: {DeviceName} | Status: {status} | Temparature: {Temparature} ");
        }


    }
}
