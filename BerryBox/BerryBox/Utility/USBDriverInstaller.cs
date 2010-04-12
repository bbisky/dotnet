using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using ICSharpCode.SharpZipLib.Zip;

namespace BerryBox.Utility
{
    public class USBDriverInstaller
    {
        private string COMMONFILES_FOLDER = @"C:\Program Files\Common Files\Research In Motion\USB Drivers";


        public bool Install() {
            try
            {
                if (CopyFiles())
                {
                   // EventLog.WriteLog("CopyFiles成功", EventLogEntryType.Information);
                    if (ImportRegistySettings())
                    {                        
                        return RunDPInst();
                    }
                }
                //else
                //    EventLog.WriteLog("CopyFiles失败", EventLogEntryType.Information);
                
            }
            catch (Exception ex) {
                MessageBox.Show("复制文件失败:" + ex.Message);
            }
            return false;
        }

        private bool ImportRegistySettings()
        {
            string regfile = Path.Combine(this.COMMONFILES_FOLDER, "RimUsb.dll");
            if (File.Exists(regfile))
            {
                //TODO: write the tempRegFile content
                Process dp = new Process();
                dp.StartInfo.FileName = "regedit.exe";
                dp.StartInfo.Arguments = "/s \"" + regfile + "\"";
                dp.StartInfo.UseShellExecute = false;
                dp.Start();
                if (dp.WaitForExit(10000))
                {
                   // EventLog.WriteLog("导入注册表成功", EventLogEntryType.Information);
                    File.Delete(regfile);
                    return true;
                }

            }
            else
            {
               // EventLog.WriteLog("导入注册表失败", EventLogEntryType.Error);
                
            }
            return false;
        }      

        private bool RunDPInst() {
            string dpInstall = Path.Combine(this.COMMONFILES_FOLDER, "dpinst.exe");
            Process dp = new Process();
            dp.StartInfo.FileName = dpInstall;
            dp.StartInfo.UseShellExecute = true;
            dp.StartInfo.Arguments = "";
           // dp.StartInfo.Verb = "runas";
            dp.Start();
            dp.WaitForExit();
            return true;
        }

        /// <summary>
        /// 复制文件到common files目录
        /// </summary>
        /// <returns></returns>
        private bool CopyFiles() {

            if (File.Exists("USB Drivers.dll"))
            {
               return UnZip("USB Drivers.dll", this.COMMONFILES_FOLDER);
            }
            else
                return false;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="path">解压路径</param>
        bool UnZip(string file, string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (ZipInputStream s = new ZipInputStream(File.OpenRead(file)))
                {
                    s.Password = "Berry+box)*^$@";
                    ZipEntry theEntry;
                    while ((theEntry = s.GetNextEntry()) != null)
                    {
                        string directoryName = Path.GetDirectoryName(theEntry.Name);
                        string fileName = Path.GetFileName(theEntry.Name);

                        // create directory
                        if (directoryName.Length > 0)
                        {
                            Directory.CreateDirectory(directoryName);
                        }

                        if (fileName != String.Empty)
                        {
                            using (FileStream streamWriter = File.Create(Path.Combine(path, theEntry.Name)))
                            {

                                int size = 2048;
                                byte[] data = new byte[2048];
                                while (true)
                                {
                                    size = s.Read(data, 0, data.Length);
                                    if (size > 0)
                                    {
                                        streamWriter.Write(data, 0, size);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }

                }

                return true;
            }
            catch(Exception ex)
            {
                EventLog.WriteLog(ex.Message, EventLogEntryType.Error);
                return false;
            }
        }


    }
}
