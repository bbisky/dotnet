using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace BerryBox.Utility
{
   
    public class Devices
    {
        private XmlDocument deviceXml;
        public Devices(){
            this.deviceXml = new XmlDocument();
            try
            {
                this.deviceXml.Load("Components/Devices.xml");
            }
            catch { }
            }
        /// <summary>
        /// get device detail
        /// </summary>
        /// <param name="hwid"></param>
        /// <returns></returns>
        public string GetDeviceDetail(string hwid) {
            if (this.deviceXml != null)
            {
                XmlNodeList list = this.deviceXml.SelectNodes("/devicesrc/osfiles/os");
                foreach (XmlNode xn in list)
                {
                    if (xn.InnerText.ToUpper() == hwid.ToUpper())
                    {
                        return xn.Attributes["model"].Value;
                    }
                }

            }
            
                return "UNKNOW";
        }

        public void BuildDeviceClass()
        {
            if (this.deviceXml != null)
            {
                StreamWriter sw = new StreamWriter(File.Create("DeviceLib.cs"));
                
                
                XmlNodeList list = this.deviceXml.SelectNodes("/devicesrc/osfiles/os");
                foreach (XmlNode xn in list)
                {
                    sw.WriteLine(string.Format("d.Add(\"{3}\",new DeviceInfo(\"{0}\",\"{1}\",\"{2}\"));", 
                        xn.Attributes["model"].Value,
                        xn.Attributes["radio"].Value,
                        xn.Attributes["series"] == null? "": xn.Attributes["series"].Value,
                        xn.InnerText
                        ));
                }
                sw.Close();

            }
            //<os model="9700" radio="UMTS-WLAN" series="Onyx" Colour="True" Theme="Normal" JVMLevel="1.0" Camera="True" VideoRecorder="True" VoiceNotes="True" pttApp="True" Memory="Large" KeyboardType="Qwerty" Sound="Tunes8700g" SystemSize="normal" Bluetooth="True" MMS="True" GPS="True" ThemeSupport="Enhanced" VAD="True" JPN_Input="True" WLAN="True" VPN="True" UMA="True">0x04001507</os>
        }
    }

    
}
