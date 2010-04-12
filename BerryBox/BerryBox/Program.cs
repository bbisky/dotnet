using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using BerryBox.Utility;
using System.Text;
namespace BerryBox
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
           
           
            
            //DESKTOPAPILib.IRimDatabaseAccess pRimDeviceAccess;
           // DESKTOPAPILib.IRimTables oTables = pRimDeviceAccess.Tables;
            //BBDEVMGRLib.DeviceManager dm = new BBDEVMGRLib.DeviceManager();

            //BBDEVMGRLib.IDevice device = dm.Devices.Item(0);
            //BBDEVMGRLib.IDeviceProperties property = device.Properties;
            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < property.Count; i++)
            //{
            //    sb.Append(string.Format("{0}:{1}", property.get_Item(i).Name, property.get_Item(i).Value));
            //}
            
            //MessageBox.Show(sb.ToString());
            // device.Properties;
            //Devices dev = new Devices();
            //dev.BuildDeviceClass();
           
            //    MessageBox.Show("ok");
            
           // return;
           /* string file = "documentstogo.jad";
            Utility.JadReader jadreader = new JadReader(file);
            
            Console.WriteLine(jadreader.MIDletName);
            Console.WriteLine(jadreader.CodFiles.Count);
             */
            if (!CheckEnvironment())
            {
                MessageBox.Show("没有找到JavaLoader.exe或ICSharpCode.SharpZipLib.dll,请将该文件拷贝到本程序同一目录下:)", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); 
               
                Application.Exit();

            }
            else
            {             
               
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);               
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);                
                Application.Run(new MainForm());
            }
             
          //  Application.Run(new TestRichTextBox() );
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            
                EventLog.WriteLog(e.Exception.Message, System.Diagnostics.EventLogEntryType.Error);

                MessageBox.Show("[Application_ThreadException]\r\n非常抱歉，程序非正常结束，请重新尝试运行本程序，如果出现与此相同的提示，请联系软件作者！", "疯掉了~~", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
           
                EventLog.WriteLog(e.ExceptionObject.ToString(), System.Diagnostics.EventLogEntryType.Error);
                MessageBox.Show("[CurrentDomain_UnhandledException]\r\n非常抱歉，程序非正常结束，请重新尝试运行本程序，如果出现与此相同的提示，请联系软件作者！", "疯掉了~~", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();    
        }
       
        static bool CheckEnvironment()
        {
            if (!File.Exists("JavaLoader.exe"))
            {
                return false;
            }
            else
                return true;
        }
    }
}