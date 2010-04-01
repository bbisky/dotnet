using System;
using System.Text;
using System.Text.RegularExpressions;

namespace BerryBox.Utility
{
    public class FileSizeHelper
    {
        /// <summary>
        /// 用户可读的size表示法
        /// 如1024返回 1K
        /// </summary>
        /// <param name="Bytes">字节大小</param>
        /// <returns></returns>
        public static string FriendlySize(double Bytes)
        {            
            int i = 0;
            while (Bytes >= 1024)
            {
                Bytes = Bytes / 1024;
                i++;
            }
            if (i > 4)
                return "大于1024T";
            return String.Format("{0}{1}", Math.Round(Bytes, 1), Enum.GetNames(typeof(SizeUnit))[i]);
        }

        /// <summary>
        /// 取得字节大小
        /// </summary>
        /// <param name="friendlySize"></param>
        /// <returns></returns>
        public static long ByteSize(string friendlySize)
        {
            Regex r = new Regex(@"^(\d+)(TB|GB|MB|KB|B)?$");
            if (r.IsMatch(friendlySize))
            {
                Match match =r.Match(friendlySize);
                long iSize = Int32.Parse(match.Groups[1].Value);
                //是否带单位
                SizeUnit unit = String.IsNullOrEmpty(match.Groups[2].Value) ? SizeUnit.B : (SizeUnit)Enum.Parse(typeof(SizeUnit), match.Groups[2].Value);
                for (int i = 0; i < (int)unit; i++)
                {
                    iSize *= 1024;
                }
                return iSize;                 
            }
            else
                return 0;
        }
        /// <summary>
        /// 文件大小单位
        /// </summary>
        enum SizeUnit
        {       
            B  = 0,
            KB = 1,
            MB = 2,
            GB = 3,
            TB = 4
        }
    }
}
