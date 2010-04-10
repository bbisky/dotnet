using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace BerryBox.Utility
{
    public class USBDriverInstaller
    {
        private string COMMONFILES_FOLDER = @"C:\Program Files\Common Files\Research In Motion\USB Drivers";


        public bool Install() {
            try
            {
                CopyFiles();
                ImportRegistySettings();
                RunDPInst();
            }
            catch (Exception ex) {
                MessageBox.Show("复制文件失败:" + ex.Message);
            }
            return true;
        }

        private bool ImportRegistySettings()
        {
            string regfile = Path.Combine(this.COMMONFILES_FOLDER, "RimUsb.dll");
            if (File.Exists(regfile))
            {
                //TODO: write the tempRegFile content
                Process dp = new Process();
                dp.StartInfo.FileName = "regedit.exe";
                dp.StartInfo.Arguments = "/s " + regfile;
                dp.Start();
                if (dp.WaitForExit(10000))
                {
                    return true;
                    File.Delete(regfile);
                }
                
            }
                 return false;
        }      

        private bool RunDPInst() {

            string dpInstall = Path.Combine(this.COMMONFILES_FOLDER, "x86.exe");
            Process dp = new Process();
            dp.StartInfo.FileName = dpInstall;
            dp.StartInfo.UseShellExecute = true;
            dp.StartInfo.Arguments = "";
            dp.StartInfo.Verb = "runas";
            dp.Start();
            dp.WaitForExit();
            return true;
        }

        /// <summary>
        /// 复制文件到common files目录
        /// </summary>
        /// <returns></returns>
        private bool CopyFiles() {     
       
            DirectoryInfo driverFilesFolder = new DirectoryInfo("USB Drivers");
            if (driverFilesFolder.Exists)
            {
                DirectoryInfo commonFolder = new DirectoryInfo(this.COMMONFILES_FOLDER);
                if (!commonFolder.Exists)
                {
                    commonFolder.Create();
                }

                FileInfo[] driverFiles = driverFilesFolder.GetFiles();
                foreach (FileInfo fi in driverFiles)
                {
                    fi.CopyTo(Path.Combine(this.COMMONFILES_FOLDER, fi.Name), true);
                }
                return true;

            }
            else
                return false;
        }


    }
}
