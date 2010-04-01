using System;
using System.Collections.Generic;
using System.Text;

namespace BerryBox.Components
{
    public class DeviceLib
    {
        private Dictionary<string, DeviceInfo> d = new Dictionary<string, DeviceInfo>();
        public Dictionary<string, DeviceInfo> Devices
        {
            get { return this.d; }
        }
        public DeviceLib() {
            d.Add("0x1020100", new DeviceInfo("850", "DataTAC", ""));
            d.Add("0x1020400", new DeviceInfo("857", "DataTAC", ""));
            d.Add("0x1010100", new DeviceInfo("950", "Mobitex", ""));
            d.Add("0x1010400", new DeviceInfo("957", "Mobitex", ""));
            d.Add("0x00000101", new DeviceInfo("5710", "Mobitex", "5700"));
            d.Add("0x80000103", new DeviceInfo("5800", "GPRS", "5800"));
            d.Add("0x80000503", new DeviceInfo("6200", "GPRS", "6200"));           
            d.Add("0x90000503", new DeviceInfo("6230", "GPRS", "6230"));
            d.Add("0x84000503", new DeviceInfo("6300", "GPRS", "6200"));
            d.Add("0x505", new DeviceInfo("6500", "IDEN", "6500"));
            d.Add("0x80000403", new DeviceInfo("6700", "GPRS", "6700"));         
            d.Add("0x104", new DeviceInfo("6750", "CDMA", "6700"));
            d.Add("0x404", new DeviceInfo("6750", "CDMA", "6700"));
            d.Add("0x94000903", new DeviceInfo("7100", "GPRS", "7100"));
            d.Add("0x04000905", new DeviceInfo("7100i", "IDEN", "7100"));
            d.Add("0x04000904", new DeviceInfo("7130e", "CDMA", "7100"));
            d.Add("0x84000903", new DeviceInfo("7130g", "GPRS", "7100"));
            d.Add("0x94000503", new DeviceInfo("7200", "GPRS", "7200"));
            d.Add("0x1C000504", new DeviceInfo("7250", "CDMA", "7200"));
            d.Add("0x1C000506", new DeviceInfo("7270", "WLAN", "7200"));
            d.Add("0x9C000503", new DeviceInfo("7290", "GPRS", "7200"));
            d.Add("0x04000505", new DeviceInfo("7510", "IDEN", "7500"));
            d.Add("0x1c000505", new DeviceInfo("7520", "IDEN", "7520"));
            d.Add("0x94000403", new DeviceInfo("7700", "GPRS", "7700"));
            d.Add("0x04000404", new DeviceInfo("7750", "CDMA", "7700"));
            d.Add("0x84000A03", new DeviceInfo("SK65", "GPRS", "SK65"));
            d.Add("0x84000D03", new DeviceInfo("8100", "GPRS", "8100"));
            d.Add("0x8F000D03", new DeviceInfo("8110", "GPRS", "8100"));
            d.Add("0x8D000D03", new DeviceInfo("8120", "GPRS-WLAN", "8100"));
            d.Add("0x04000D04", new DeviceInfo("8130", "CDMA", "8100"));
            d.Add("0x06000D04", new DeviceInfo("8130m", "CDMA", "8100"));
            d.Add("0x8D001103", new DeviceInfo("8220", "GPRS-WLAN", "kickstart"));
            d.Add("0x04001104", new DeviceInfo("8230", "CDMA", "8200"));
            d.Add("0x06001104", new DeviceInfo("8230m", "CDMA", "8200"));
            d.Add("0x96000F03", new DeviceInfo("8300", "GPRS", "8300"));
            d.Add("0x8D000F03", new DeviceInfo("8310", "GPRS", "8300"));
            d.Add("0x84000F03", new DeviceInfo("8320", "GPRS-WLAN", "8300"));
            d.Add("0x84000F05", new DeviceInfo("8350", "IDEN-WLAN", "orion"));
            d.Add("0x8C000F03", new DeviceInfo("8520", "GPRS-WLAN", "gemini"));
            d.Add("0x05000F04", new DeviceInfo("8530", "CDMA-WLAN", "Aries"));
            d.Add("0x84000B03", new DeviceInfo("8700", "GPRS", "8700"));
            d.Add("0x84000E03", new DeviceInfo("8800", "GPRS", "8800"));
            d.Add("0x8D000E03", new DeviceInfo("8820", "GPRS-WLAN", "8800"));
            d.Add("0x04000B04", new DeviceInfo("8703e", "CDMA", "8700"));
            d.Add("0x04000F04", new DeviceInfo("8330", "CDMA", "8300"));
            d.Add("0x06000F04", new DeviceInfo("8330m", "CDMA", "8300"));
            d.Add("0x84000B07", new DeviceInfo("8707", "UMTS", "8700"));
            d.Add("0x84001503", new DeviceInfo("8900", "GPRS-WLAN", "Javelin"));
            d.Add("0x84000E07", new DeviceInfo("9000", "UMTS-WLAN", "9000"));
            d.Add("0x06001404", new DeviceInfo("9500", "CDMA-GPRS", "Thunder"));
            d.Add("0x04001404", new DeviceInfo("9530", "CDMA-GPRS", "Thunder"));
            d.Add("0x0D000D04", new DeviceInfo("9630", "CDMA-GPRS", "Niagara"));
            d.Add("0x16000D04", new DeviceInfo("9630fts", "CDMA-GPRS", "Niagara"));
            d.Add("0x04000E04", new DeviceInfo("8830", "CDMA-GPRS", "8800"));
            d.Add("0x06000E04", new DeviceInfo("8830m", "CDMA-GPRS", "8800"));
            d.Add("0x0D001404", new DeviceInfo("9520", "CDMA-GPRS-WLAN", "Odin"));
            d.Add("0x0C001404", new DeviceInfo("9550", "CDMA-GPRS-WLAN", "Odin"));
            d.Add("0x04001507", new DeviceInfo("9700", "UMTS-WLAN", "Onyx"));
        }
        /// <summary>
        /// 根据硬件ID取得设备信息
        /// </summary>
        /// <param name="hwid"></param>
        /// <returns></returns>
        public DeviceInfo GetDeviceInfo(string hwid)
        {
            hwid = "0x" + hwid.Substring(2).ToUpper();
            if (this.d.ContainsKey(hwid))
                return this.d[hwid];
            else
                return new DeviceInfo("UNKNOWN", "UNKNOWN", "UNKNOWN"); ;
        }
    }

    public class DeviceInfo
    {
        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private string series;

        public string Series
        {
            get { return series; }
            set { series = value; }
        }
        private string radio;

        public string Radio
        {
            get { return radio; }
            set { radio = value; }
        }

        public DeviceInfo(string model, string radio, string series)
        {
            this.model = model;
            this.radio = radio;
            this.series = series;
        }
    }
}
