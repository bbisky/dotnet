using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace BerryBox.Utility
{
   public class JavaLoader
    {

       public static void Run(TextBox output, params string [] pms) {
           System.Diagnostics.Process p = new System.Diagnostics.Process();
           p.StartInfo.FileName = "JavaLoader.exe";//readOption.GetValue("Lame");

           StringBuilder sb = new StringBuilder();
           foreach (string s in pms) {
               sb.Append(" ");
               sb.Append(s);
           }
           p.StartInfo.Arguments = sb.ToString();		
           //	p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
           p.StartInfo.UseShellExecute = false;
           p.StartInfo.RedirectStandardOutput = true;
           p.StartInfo.RedirectStandardError = true;
          // p.StartInfo.CreateNoWindow = true;
           p.Start();
           tout t1 = new tout(p,output);
           terr t2 = new terr(p, output);
           Thread thread1 = new Thread(new ThreadStart(t1.Read));
           Thread thread2 = new Thread(new ThreadStart(t2.Read));
           thread1.Start();
           thread2.Start();

           //string output = p.StandardOutput.ReadToEnd();
           //string error = p.StandardError.ReadToEnd();
           p.WaitForExit();

          
       }
    }

   class tout
   {
       Process p;
       TextBox output;
       public tout(Process p, TextBox output)
       {
           this.p = p;
           this.output = output;
       }
       public void Read()
       {
           int a = -1;
           while ((a = p.StandardOutput.Read()) > 0)
           {
               Console.Write(((char)a).ToString());
           }
           Thread.CurrentThread.Abort();
           return;
       }
   }
   class terr
   {
       private delegate void WriteLog(string msg);
       Process p;
       TextBox output;
       public terr(Process p, TextBox output)
       {
           this.p = p;
           this.output = output;
       }
       public void Read()
       {
           int a = -1;
           StringBuilder sb = new StringBuilder();
           while ((a = p.StandardError.Read()) > 0)
           {
               sb.Append((char)a);
           }
           Thread.CurrentThread.Abort();
           Output(sb.ToString());
           return;
       }

       void Output(string msg) {
           if (this.output.InvokeRequired)
           {
               WriteLog log = new WriteLog(Output);
               this.output.BeginInvoke(log, msg);
           }
           else
               this.output.Text = msg;
       }
   }


}
