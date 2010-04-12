using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BerryBox.Utility;
using ICSharpCode.SharpZipLib.Zip;
using System.Threading;
using System.Diagnostics;
using System.Text.RegularExpressions;
using BerryBox.Components;
using System.Drawing.Imaging;
using System.Reflection;
using System.Net;
using System.Security.Principal;
using System.Runtime.InteropServices;

namespace BerryBox
{
    public partial class MainForm : Form
    {
        private IniFile config = new IniFile("BerryBox.ini");
        //list���Ƿ�Ϊ���ص�cod�ļ�
        private bool m_IsLocalFile = true;
        private Process javaloader;

        /// <summary>
        /// ȡ���������
        /// </summary>
        /// <returns></returns>
        private string PasswordParam
        {
            get
            {
                return string.IsNullOrEmpty(tb_Global_DevicePasswd.Text)
                    ? ""
                    : string.Format(" -w{0} ", tb_Global_DevicePasswd.Text);
            }
        }
        public MainForm()
        {
            
                InitializeComponent();
                string version = this.ProductVersion.Substring(0,this.ProductVersion.LastIndexOf("."));
                labelBuild.Text = "(build:" + this.ProductVersion.Substring(this.ProductVersion.LastIndexOf(".")+1)+")";
                this.Text += "-" + version + labelBuild.Text;
                labelBerryBoxTitle.Text = "BerryBox " + version;
                //����list�߶�
                ImageList imgList = new ImageList();
                imgList.ImageSize = new Size(1, 20);
                lvCodLoaderFiles.SmallImageList = imgList;

            //init systools tab
                ddl_SysTools_ImageType.SelectedIndex = 0;
                string initFolder = this.config.GetString("SysTools", "ScreenshotSaveFolder", "");
                if (!string.IsNullOrEmpty(initFolder))
                    tb_SysTools_ScreenCaptureLocation.Text = initFolder;      
         
            //init ota tab
                BindDeviceModels();

                comboBox_OTA_DeviceModel.Text = this.config.GetString("OTADownloader", "Model", "");
                comboBox_OTA_OS.SelectedItem = this.config.GetString("OTADownloader", "OS", "4.0");
                tb_OTA_SavePath.Text = this.config.GetString("OTADownloader", "SavePath", "");


                //UAC 
                SetDriverInstallButtonStyle();
                
        }

        #region Helper Functions for UAC

        /// <summary>
        /// The function checks whether the current process is run as administrator.
        /// In other words, it dictates whether the primary access token of the 
        /// process belongs to user account that is a member of the local 
        /// Administrators group and it is elevated.
        /// </summary>
        /// <returns>
        /// Returns true if the primary access token of the process belongs to user 
        /// account that is a member of the local Administrators group and it is 
        /// elevated. Returns false if the token does not.
        /// </returns>
        internal bool IsRunAsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(id);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }


        /// <summary>
        /// The function gets the elevation information of the current process. It 
        /// dictates whether the process is elevated or not. Token elevation is only 
        /// available on Windows Vista and newer operating systems, thus 
        /// IsProcessElevated throws a C++ exception if it is called on systems prior 
        /// to Windows Vista. It is not appropriate to use this function to determine 
        /// whether a process is run as administartor.
        /// </summary>
        /// <returns>
        /// Returns true if the process is elevated. Returns false if it is not.
        /// </returns>
        /// <exception cref="System.ComponentModel.Win32Exception">
        /// When any native Windows API call fails, the function throws a Win32Exception 
        /// with the last error code.
        /// </exception>
        /// <remarks>
        /// TOKEN_INFORMATION_CLASS provides TokenElevationType to check the elevation 
        /// type (TokenElevationTypeDefault / TokenElevationTypeLimited / 
        /// TokenElevationTypeFull) of the process. It is different from TokenElevation 
        /// in that, when UAC is turned off, elevation type always returns 
        /// TokenElevationTypeDefault even though the process is elevated (Integrity 
        /// Level == High). In other words, it is not safe to say if the process is 
        /// elevated based on elevation type. Instead, we should use TokenElevation. 
        /// </remarks>
        internal bool IsProcessElevated()
        {
            bool fIsElevated = false;
            SafeTokenHandle hToken = null;
            int cbTokenElevation = 0;
            IntPtr pTokenElevation = IntPtr.Zero;

            try
            {
                // Open the access token of the current process with TOKEN_QUERY.
                if (!NativeMethod.OpenProcessToken(Process.GetCurrentProcess().Handle,
                    NativeMethod.TOKEN_QUERY, out hToken))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }

                // Allocate a buffer for the elevation information.
                cbTokenElevation = Marshal.SizeOf(typeof(TOKEN_ELEVATION));
                pTokenElevation = Marshal.AllocHGlobal(cbTokenElevation);
                if (pTokenElevation == IntPtr.Zero)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }

                // Retrieve token elevation information.
                if (!NativeMethod.GetTokenInformation(hToken,
                    TOKEN_INFORMATION_CLASS.TokenElevation, pTokenElevation,
                    cbTokenElevation, out cbTokenElevation))
                {
                    // When the process is run on operating systems prior to Windows 
                    // Vista, GetTokenInformation returns false with the error code 
                    // ERROR_INVALID_PARAMETER because TokenElevation is not supported 
                    // on those operating systems.
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }

                // Marshal the TOKEN_ELEVATION struct from native to .NET object.
                TOKEN_ELEVATION elevation = (TOKEN_ELEVATION)Marshal.PtrToStructure(
                    pTokenElevation, typeof(TOKEN_ELEVATION));

                // TOKEN_ELEVATION.TokenIsElevated is a non-zero value if the token 
                // has elevated privileges; otherwise, a zero value.
                fIsElevated = (elevation.TokenIsElevated != 0);
            }
            finally
            {
                // Centralized cleanup for all allocated resources. 
                if (hToken != null)
                {
                    hToken.Close();
                    hToken = null;
                }
                if (pTokenElevation != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pTokenElevation);
                    pTokenElevation = IntPtr.Zero;
                    cbTokenElevation = 0;
                }
            }

            return fIsElevated;
        }

        

        private void SetDriverInstallButtonStyle() {

            // Get and display the process elevation information (IsProcessElevated) 
            // and integrity level (GetProcessIntegrityLevel). The information is not 
            // available on operating systems prior to Windows Vista.
            if (Environment.OSVersion.Version.Major >= 6)
            {
                // Running Windows Vista or later (major version >= 6). 

                try
                {
                    // Get and display the process elevation information.
                    bool fIsElevated = IsProcessElevated();
                    
                    // Update the Self-elevate button to show the UAC shield icon on 
                    // the UI if the process is not elevated.
                    this.btn_Global_InstallDriver.FlatStyle = FlatStyle.System;
                    NativeMethod.SendMessage(btn_Global_InstallDriver.Handle,
                        NativeMethod.BCM_SETSHIELD, 0,
                        fIsElevated ? IntPtr.Zero : (IntPtr)1);
                    //��ʾ����Ա��form�ı�����
                    if (IsRunAsAdmin())
                        this.Text = "����Ա:" + this.Text;
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.Message, "An error occurred in IsProcessElevated",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }
        }
        #endregion

        #region Global
        /// <summary>
        /// ����codloader process�����ó�ʼ����
        /// </summary>
        /// <param name="redirectOutput"></param>
        /// <param name="redirectError"></param>
        /// <param name="createNoWindow"></param>
        private void CreateJavaLoader(bool redirectOutput, bool redirectError, bool createNoWindow)
        {
            if (this.javaloader != null )
            {
                this.javaloader.Dispose();
                this.javaloader.Close();
            }
            //init javaloader
            javaloader = new Process();
            javaloader.StartInfo.FileName = "JavaLoader.exe";
            javaloader.StartInfo.Arguments = string.Format("-u {0} ", this.PasswordParam);
            javaloader.StartInfo.UseShellExecute = false;
            javaloader.StartInfo.RedirectStandardOutput = redirectOutput;
            javaloader.StartInfo.RedirectStandardError = redirectError;
            javaloader.StartInfo.CreateNoWindow = createNoWindow;
        }

        private void btn_Global_ConnectDevice_Click(object sender, EventArgs e)
        {
            ButtonToggle(btn_Global_ConnectDevice, false);
            Thread thread_DeviceInfo = new Thread(new ThreadStart(DeviceInfo));
            thread_DeviceInfo.IsBackground = true;
            thread_DeviceInfo.Start();
            //thread_DeviceInfo.Join();


        }
        #endregion

        #region Jad Creator
        private void btnBrowserCodFolder_Click(object sender, EventArgs e)
        {
            string initFolder = this.config.GetString("jadcreator", "LastCodFolder", "");
            DialogResult dr;
            if (!string.IsNullOrEmpty(initFolder))
                dialogBrowserCodFolder.SelectedPath = initFolder;
            dialogBrowserCodFolder.Description = "��ѡ��Cod�ļ����ڵ�Ŀ¼";
            dialogBrowserCodFolder.ShowNewFolderButton = false;
            dr = dialogBrowserCodFolder.ShowDialog();
            if (dr == DialogResult.OK) {
                tbCodPath.Text = dialogBrowserCodFolder.SelectedPath;
                ListCodFiles();
            }
        }
        /// <summary>
        /// �г�Ŀ¼�µ�����cod�ļ�
        /// </summary>
        /// <param name="path"></param>
        protected void ListCodFiles() {
            string path = tbCodPath.Text;
            if (!string.IsNullOrEmpty(path))
            {
                DirectoryInfo root = new DirectoryInfo(path);
                FileInfo[] codFiles = root.GetFiles("*.cod");
                if (codFiles.Length == 0)
                {
                    tbCodFileList.Text = "��Ŀ¼û��cod�ļ�";

                }
                else
                {
                    //Ĭ�������Ϊ��һ��cod�ļ���
                    tbSoftName.Text = Path.GetFileNameWithoutExtension(codFiles[0].Name);
                    tbCodFileList.Text = "";
                    foreach (FileInfo fi in codFiles)
                    {
                        tbCodFileList.Text += string.Format("{0} - [{1}]\r\n", fi.Name, Utility.FileSizeHelper.FriendlySize(fi.Length));
                    }
                    btnBuildJad.Enabled = true;
                    btn_JAD_BuildAlx.Enabled = true;
                }
                //�������Ŀ¼λ��
                config.WriteValue("jadcreator", "LastCodFolder", tbCodPath.Text);
            }
        }

        /// <summary>
        /// ����Ҫ�Ĳ���
        /// </summary>
        /// <returns></returns>
        private bool CheckForm() {
            if (string.IsNullOrEmpty(tbSoftName.Text))
            {
                tbSoftName.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
                tbSoftName.BackColor = System.Drawing.SystemColors.Window;
            if (string.IsNullOrEmpty(tbSoftVersion.Text))
            {
                tbSoftVersion.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
                tbSoftVersion.BackColor = System.Drawing.SystemColors.Window;
            if (string.IsNullOrEmpty(tbSoftVendor.Text))
            {
                tbSoftVendor.BackColor = System.Drawing.Color.Yellow;
                return false;
            }
            else
                tbSoftVendor.BackColor = System.Drawing.SystemColors.Window;
            return true;
            
        }
        private void btnBuildJad_Click(object sender, EventArgs e)
        {
            if (CheckForm())
            {
                DirectoryInfo root = new DirectoryInfo(tbCodPath.Text);
                FileInfo[] codFiles = root.GetFiles("*.cod");
                if (codFiles.Length == 0)
                {
                    ErrorBox("û��cod�ļ�");
                    return;
                }
                else
                {
                    string jadPath = Path.Combine(tbCodPath.Text, "JAD");
                    foreach (FileInfo fi in codFiles)
                    {//��ѹ
                        UnZip(fi.FullName, jadPath);
                    }

                    if (CreateJadFile(jadPath))
                    {
                        MessageBox.Show(string.Format("����jad�ɹ����ļ���{0}", jadPath),"�����ɹ�", MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("����jadʧ��", "����");
                    }
                }
            }
        }
        private void btn_JAD_BuildAlx_Click(object sender, EventArgs e)
        {
            if (CheckForm())
            {
                if (CreateAlxFile(tbCodPath.Text))
                {
                    MessageBox.Show("����ALX�ɹ����ļ���ԴĿ¼", "�����ɹ�", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("����ALXʧ��", "����");
                }
              
            }
        }

        bool CreateAlxFile(string path)
        {
            DirectoryInfo root = new DirectoryInfo(path);
            FileInfo[] codFiles = root.GetFiles("*.cod");
            if (codFiles.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<loader version=\"1.0\">\r\n"); 
                sb.Append("<application id=\"[NAME]\">\r\n");
                sb.Append("<name>[NAME]</name> \r\n");
                sb.Append("<description>[DESCRIPTION]</description>\r\n"); 
                sb.Append("<version>[VERSION]</version>\r\n"); 
                sb.Append("<vendor>[VENDOR]</vendor>\r\n"); 
                sb.Append("<copyright>Copyright (c) 2010 [VENDOR]</copyright>\r\n"); 
                sb.Append("<fileset Java=\"1.25\">\r\n"); 
                sb.Append("<directory />\r\n"); 
                sb.Append("<files>\r\n");
                foreach (FileInfo fi in codFiles)
                {
                    sb.Append(fi.Name);
                    sb.Append("\r\n");
                }
                sb.Append("</files>\r\n"); 
                sb.Append("</fileset>\r\n"); 
                sb.Append("</application>\r\n"); 
                sb.Append("</loader>\r\n");

                sb.Replace("[NAME]", tbSoftName.Text.Trim());
                sb.Replace("[DESCRIPTION]", tbSoftDescription.Text.Trim());
                sb.Replace("[VENDOR]", tbSoftVendor.Text.Trim());
                sb.Replace("[VERSION]", tbSoftVersion.Text.Trim());

                using (StreamWriter jad = new StreamWriter(
                     File.Create(
                         Path.Combine(path,
                                      string.Format("{0}.alx", tbSoftName.Text.Trim())
                                      )
                     ), Encoding.UTF8
                 ))
                {
                    jad.Write(sb.ToString());
                    jad.Close();
                }
                return true;
            }
            return false;
        }

        bool CreateJadFile(string path)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("RIM-COD-Module-Name: [NAME]\r\n");
            sb.Append("MIDlet-Name: [NAME] \r\n");
            sb.Append("MIDlet-Description: [DESCRIPTION]\r\n");
            sb.Append("MIDlet-Vendor: [VENDOR]\r\n");
            sb.Append("MIDlet-Version: [VERSION]\r\n");
            sb.Append("\r\n");
            sb.Append("MicroEdition-Configuration: CLDC-1.1\r\n");
            sb.Append("RIM-COD-Module-Dependencies: net_rim_cldc\r\n");
            sb.Append("RIM-MIDlet-Flags-1: 0\r\n");
            sb.Append("RIM-MIDlet-NameResourceId-1: 0\r\n");
            sb.Append("MicroEdition-Profile: MIDP-2.0\r\n");
            sb.Append("RIM-COD-Creation-Time: 1218812329\r\n");
            sb.Append("Manifest-Version: 1.0\r\n\r\n");
            sb.Replace("[NAME]", tbSoftName.Text.Trim());
            sb.Replace("[DESCRIPTION]", tbSoftDescription.Text.Trim());
            sb.Replace("[VENDOR]", tbSoftVendor.Text.Trim());
            sb.Replace("[VERSION]", tbSoftVersion.Text.Trim());

           
            DirectoryInfo root = new DirectoryInfo(path);
            FileInfo[] codFiles = root.GetFiles("*.cod");
            int count = 0;
            foreach (FileInfo fi in codFiles) {
                if (count == 0)
                {
                    //ʱ��
                    //TimeSpan ts = new TimeSpan(fi.CreationTimeUtc.Ticks - new DateTime(1970, 1, 1, 0, 0, 0).Ticks);
                    //sb.Replace("[CREATIONTIME]", ((long)ts.TotalMilliseconds).ToString());

                    sb.Append("RIM-COD-URL: ");
                    sb.Append(fi.Name);
                    sb.Append("\r\n");
                    sb.Append("RIM-COD-Size: ");
                    sb.Append(fi.Length);
                    sb.Append("\r\n");
                }
                else {
                    sb.Append(string.Format("RIM-COD-URL-{0}: ",count));
                    sb.Append(fi.Name);
                    sb.Append("\r\n");
                    sb.Append(string.Format("RIM-COD-Size-{0}: ",count));
                    sb.Append(fi.Length);
                    sb.Append("\r\n");
                }
                count++;
            }
            using (StreamWriter jad = new StreamWriter(
                     File.Create(
                         Path.Combine(path,
                                      string.Format("{0}.jad", tbSoftName.Text.Trim())
                                      )
                     )
                 ))
            {
                jad.Write(sb.ToString());
                jad.Close();
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="path">���jad�ļ�·��</param>
        void UnZip(string file,string path) {
            
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            try
            {
                using (ZipInputStream s = new ZipInputStream(File.OpenRead(file)))
                {
                    
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
                            using (FileStream streamWriter = File.Create(Path.Combine(path,theEntry.Name)))
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
            }
            catch {
                //����Ҫ��ѹ���ļ�ֱ�Ӹ�����jadĿ¼

                File.Copy(file, Path.Combine(path, Path.GetFileName(file)),true);

            }
        }

    

        private void tbCodFileList_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (File.Exists(path))
            {//�ļ�
                return;
            }
            else
            {
                tbCodPath.Text = path;
                ListCodFiles();
            }

        }

        private void tbCodFileList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else 
                e.Effect = DragDropEffects.None;
        }

        #endregion

        #region Cod Loader
        
        void CheckConnectedDevice()
        {
            CreateJavaLoader(true, true, true);
            this.javaloader.StartInfo.Arguments += "enum";          
            this.javaloader.Start();
            string output = this.javaloader.StandardOutput.ReadToEnd();           
            this.javaloader.WaitForExit();
            if (!String.IsNullOrEmpty(output))
            {
                statusLabelLeft.Text = string.Format("PIN:{0}", output.Replace("\r\n", "").Replace("0x", ""));
            }
            else
                statusLabelLeft.Text = "δ�����豸";

        }

        #region Device Info
        void DeviceInfo() {
            

            CreateJavaLoader(true, true, true);
            this.javaloader.StartInfo.Arguments += "deviceinfo";
            this.javaloader.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            this.javaloader.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);
            this.javaloader.Start();
          
            this.javaloader.BeginOutputReadLine();
            this.javaloader.BeginErrorReadLine();

            if (!this.javaloader.WaitForExit(10000))
            {//�ȴ�10��
                ButtonToggle(btn_Global_ConnectDevice, true);
                this.javaloader.Kill();
                this.javaloader.Close();
                Thread.CurrentThread.Abort();
            }
            ButtonToggle(btn_Global_ConnectDevice, true);
        }
        /// <summary>
        /// ֱ�ӽ�������Ϣ�����������־
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
                CodLoaderLog(e.Data.ToString());
        }
        private StringBuilder sbDeviceInfo = new StringBuilder();
        void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
                sbDeviceInfo.Append(e.Data);
            else
            {
                string output = sbDeviceInfo.ToString();
                if (!String.IsNullOrEmpty(output))
                {
                    Regex re;
                    if(output.StartsWith("Hardware"))
                        //Ӣ�İ�javaloader
                        re = new Regex(@"Id:\s+(\w+)PIN:\s+([0-9a-fx]{10}).+Vendor\sID:\s+([0-9\-]{1,5})Active\sWAFs:\s+0x(\d)", RegexOptions.Singleline);
                    else
                        re = new Regex(@"Id:\s+(\w+)PIN:\s+([0-9a-fx]{10}).+��Ӫ�̴���:\s+([0-9\-]{1,5})���ߵ�״̬:\s+(\w)", RegexOptions.Singleline);
                   
                    if (re.IsMatch(output))
                    {
                        Match match = re.Match(output);
                        DeviceLib lib = new DeviceLib();
                        DeviceInfo device = lib.GetDeviceInfo(match.Groups[1].Value);
                        string pin = match.Groups[2].Value.Replace("0x", "");
                        SetLabelText(lable_Global_PIN, pin);
                        SetLabelText(label_Global_DeviceType, string.Format("{0}({1})",device.Model,device.Series));
                        SetLabelText(label_Global_Vendor, match.Groups[3].Value);
                        SetLabelText(label_Global_Status, match.Groups[4].Value);
                        statusLabelLeft.Text = statusLabelLeft.Text = string.Format("PIN:{0}", pin);
                        
                        SetCodLoaderFormStatus(true);
                        Thread thread_DeviceOSInfo = new Thread(new ThreadStart(DeviceOSInfo));
                        thread_DeviceOSInfo.IsBackground = true;
                        thread_DeviceOSInfo.Start();

                        //wait for osinfo thread
                        thread_DeviceOSInfo.Join();
                    }
                    else {
                        //use enum
                        CheckConnectedDevice();
                    }
                   // CodLoaderLog(output);

                }
                else
                    statusLabelLeft.Text = "δ�����豸";
               
            }
        }

        void SetCodLoaderFormStatus(bool enable)
        {
            SetControlAttribute(panel_CodLoader, "Enabled", enable);
            SetControlAttribute(lvCodLoaderFiles, "Enabled", enable);
            //ButtonToggle(btnSelectCodFolder, enable);
            //ButtonToggle(btnInstallSelected, enable);
            //ButtonToggle(btnLoadDeviceModules, enable);
            //ButtonToggle(btnSaveSelected, enable);
            //ButtonToggle(btnDeleteSelected, enable);
            //ButtonToggle(btn_SysTools_Capture, enable);
            //ButtonToggle(btn_SysTools_ScreenCaptureBrowser, enable);
            //ButtonToggle(btn_SysTools_TimeSync, enable);
            //ButtonToggle(btn_SysTools_Wipe, enable);
            //ButtonToggle(btn_SysTools_WirelessOFF, enable);
            //ButtonToggle(btn_SysTools_WirelessON, enable);
            SetControlAttribute(groupBox_SysTools, "Enabled", enable);
        }
        #endregion

        #region ��ϵͳ���ڻ�ȡOS Version
        void DeviceOSInfo()
        {
            
            CreateJavaLoader(true, true, true);
            this.javaloader.StartInfo.Arguments += "eventlog";
            this.javaloader.OutputDataReceived += new DataReceivedEventHandler(doi_OutputReceived);
            this.javaloader.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);
            this.javaloader.Start();

            this.javaloader.BeginOutputReadLine();
            this.javaloader.BeginErrorReadLine();
            this.javaloader.WaitForExit();
        }
        Regex re_OSVersion = new Regex(@"a='([0-9\.]{5,11})',o='([0-9\.]{5,11})'");
        void doi_OutputReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                if(re_OSVersion.IsMatch(e.Data.ToString())){
                    //CodLoaderLog("Found:" + e.Data.ToString());
                    Match match = re_OSVersion.Match(e.Data.ToString());
                    SetLabelText(label_Global_OS, string.Format("v{0}(ƽ̨:{1})", match.Groups[1], match.Groups[2]));
                    ((Process)sender).Kill();
                    ((Process)sender).Close();
                    Thread.CurrentThread.Abort();
                }
            }
        }

        #endregion

        #region �̰߳�ȫ������·���
        private delegate void SetControlAttributeDelegate(Control control, string attribute, object value);
        void SetControlAttribute(Control control, string attribute, object value) {
            if (control.InvokeRequired)
            {
                SetControlAttributeDelegate dlg = new SetControlAttributeDelegate(SetControlAttribute);
                this.BeginInvoke(dlg, control, attribute, value);
            }
            else
            {
                foreach (PropertyInfo pi in control.GetType().GetProperties())
                {
                    if (pi.Name == attribute)
                    {
                        pi.SetValue(control, value, null);
                    }
                }
            }
        }
        private delegate void SetButtonStatus(Button button, bool status);
        private delegate void SetLableTextDelegate(Label label, string text);
        void SetLabelText(Label label, string text) {
            if (label.InvokeRequired)
            {
                SetLableTextDelegate dlg = new SetLableTextDelegate(SetLabelText);
                this.BeginInvoke(dlg, label, text);
            }
            else
                label.Text = text;
        }
        void ButtonToggle(Button button, bool status)
        {
            if (button.InvokeRequired)
            {
                SetButtonStatus sbs = new SetButtonStatus(ButtonToggle);
                this.BeginInvoke(sbs, button, status);
            }
            else
                button.Enabled = status;
        }

    #endregion        

        #region ����Ŀ¼cod�ļ�
        /// <summary>
        /// ѡ��Ҫ��װ��COD�ļ�Ŀ¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectCodFolder_Click(object sender, EventArgs e)
        {
            string initFolder = this.config.GetString("codloader", "LastCodFolder", "");
            DialogResult dr;
            if (!string.IsNullOrEmpty(initFolder))
                dialogBrowserCodFolder.SelectedPath = initFolder;
            dialogBrowserCodFolder.Description = "��ѡ��Cod�ļ����ڵ�Ŀ¼";
            dialogBrowserCodFolder.ShowNewFolderButton = false;

            dr = dialogBrowserCodFolder.ShowDialog();
            if (dr == DialogResult.OK)
            {

                  lvCodLoaderFiles.Tag =  dialogBrowserCodFolder.SelectedPath;
                 CodLoaderListCodFiles();
            }
        }

        /// <summary>
        /// �г�Ŀ¼�µ�����cod�ļ�
        /// </summary>
        /// <param name="path"></param>
        protected void CodLoaderListCodFiles()
        {
            string path = lvCodLoaderFiles.Tag.ToString();
            if (!string.IsNullOrEmpty(path))
            {
                DirectoryInfo root = new DirectoryInfo(path);
                FileInfo[] codFiles = root.GetFiles("*.cod");
                //lvCodLoaderFiles.Items.Clear();
                if (codFiles.Length == 0)
                {
                    CodLoaderLog("��Ŀ¼û��cod�ļ�");

                }
                else
                {
                    
                    foreach (FileInfo fi in codFiles)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = fi.Name;
                        item.Tag = fi.FullName;
                        item.SubItems.Add(Utility.FileSizeHelper.FriendlySize(fi.Length));
                        lvCodLoaderFiles.Items.Add(item);
                    }
                    if (codFiles.Length > 0)
                        this.m_IsLocalFile = true;
                    CodLoaderLog(string.Format("���ָ�{0}cod�ļ���{1}", codFiles.Length,path));
                }
                //�������Ŀ¼λ��
                config.WriteValue("codloader", "LastCodFolder", lvCodLoaderFiles.Tag.ToString());
            }
        }
#endregion

        #region �������־����
        private delegate void WriteLogDelegate(string msg);

        void CodLoaderLog(string msg) {
            if (string.IsNullOrEmpty(msg))
                return;
            msg = msg.Replace("RIM Java Loader for WinLoader\r\n��Ȩ 2001-2005 Research In Motion Limited","");
            if (tbCodLoaderLog.InvokeRequired)
            {
                WriteLogDelegate log = new WriteLogDelegate(CodLoaderLog);
                this.BeginInvoke(log, msg);
            }
            else
            {
                tbCodLoaderLog.Text += msg + "\r\n";
                //�������ײ�
                this.tbCodLoaderLog.SelectionStart = this.tbCodLoaderLog.Text.Length;
                this.tbCodLoaderLog.SelectionLength = 0;
                this.tbCodLoaderLog.ScrollToCaret();
            }
        }

        
        #endregion      

        #region ȫѡ
        private void cbCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvCodLoaderFiles.Items)
            {
                item.Checked = (sender as CheckBox).Checked;
            }
        }
        #endregion

        #region ��װѡ��
        public void LoadSelected(params string[] pms)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in pms)
            {
                sb.Append(" ");
                sb.Append(s);
            }
            CreateJavaLoader(false, false, false);
            this.javaloader.StartInfo.Arguments += sb.ToString();            
            this.javaloader.Start();
            CodLoaderLog("���ڼ������...");          
            this.javaloader.WaitForExit();

        }


        private void btnInstallSelected_Click(object sender, EventArgs e)
        {

            string strParams = ListToString();
            if (string.IsNullOrEmpty(strParams))
           {
              ErrorBox("����ѡ��Ҫ��װ��codģ��");
           }
           else
                LoadSelected("load", strParams);

        }
        #endregion        

        #region �����ֻ�ģ��
        private void btnLoadDeviceModules_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(LoadDeviceModules));
            thread.IsBackground = true;
            thread.Start();
        }
        void LoadDeviceModules() {
            CreateJavaLoader(true, true, true);

            this.javaloader.StartInfo.Arguments += "dir";         
            this.javaloader.Start();
            CodLoaderLog("�����豸�ϵ�ģ����Ϣ...");
            //���̶߳�ȡ����ֹ����
            Thread threadError = new Thread(new ParameterizedThreadStart(ReadError));
            Thread threadOutput = new Thread(new ParameterizedThreadStart(ReadOutput));
            threadError.IsBackground = true;
            threadOutput.IsBackground = true;
            threadOutput.Start(this.javaloader);
            threadError.Start(this.javaloader);         
            this.javaloader.WaitForExit();
          
        }

        public void ReadError(object process)
        {

            Process p = (Process)process;
            int a = -1;
            StringBuilder sb = new StringBuilder();
            while ((a = p.StandardError.Read()) > 0)
            {
                sb.Append((char)a);              
            }
            // sb.Remove(0, sb.ToString().IndexOf(@"Limited\r\n") + 11);
            CodLoaderLog(sb.ToString());
            Thread.CurrentThread.Abort();
            return;
        }
        public void ReadOutput(object process)
        {
            Process p = (Process)process;
            int a = -1;
            StringBuilder sb = new StringBuilder();
            while ((a = p.StandardOutput.Read()) > 0)
            {
                sb.Append((char)a);
            }
            //CodLoaderLog(sb.ToString());
            BindCodFilesToList(sb.ToString());
            Thread.CurrentThread.Abort();

            return;
        }
        #endregion
        
        #region ��ģ�鵽LIST
        void BindCodFilesToList(string msg)
        {

            if (lvCodLoaderFiles.InvokeRequired)
            {
                WriteLogDelegate bindToList = new WriteLogDelegate(BindCodFilesToList);
                this.BeginInvoke(bindToList, msg);
            }
            else
            {
                lvCodLoaderFiles.Items.Clear();
                Regex re = new Regex(@"(\w+)[\s]{2,}([\d\.]+)[\s]{2,}(\d+)[\s]{2,}", RegexOptions.IgnoreCase| RegexOptions.Multiline);
               // string[] cods = msg.Split(new string[] { "\r\n" });
                if (re.IsMatch(msg)) {
                    int count = 0;
                    foreach (Match match in re.Matches(msg)) {
                        if (cbHideRimCods.Checked) {//����ϵͳģ��
                            if (match.Groups[1].Value.StartsWith("net_rim"))
                                continue;
                        }
                        ListViewItem item = new ListViewItem();
                        item.Text = match.Groups[1].Value;
                        item.Tag = match.Groups[1].Value;
                        item.SubItems.Add(Utility.FileSizeHelper.FriendlySize(Convert.ToDouble(match.Groups[3].Value)));
                        item.SubItems.Add(match.Groups[2].Value);
                        lvCodLoaderFiles.Items.Add(item);
                        count++;
                        
                    }
                    if (count > 0)
                        this.m_IsLocalFile = false;
                    CodLoaderLog(string.Format("����{0}��cods", count));
                }
            }
        }
        #endregion

        #region ɾ��ѡ��

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            //�����ļ�������
            if (this.m_IsLocalFile)
                return;

            string strParams = ListToString();
            if (string.IsNullOrEmpty(strParams))
            {
                ErrorBox("����ѡ��Ҫɾ����codģ��");
            }
            else
            {
                //ǿ��ɾ��ȷ��
                if (!cbForceDelete.Checked || 
                    DialogResult.Yes == MessageBox.Show("��ѡ����ǿ��ɾ��ѡ������ģ������ʹ�ã�ʹ��ǿ��ѡ��������豸��������",
                                                        "ȷ��ɾ��",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question)
                    )
                {
                    CreateJavaLoader(true, true, true);
                    this.javaloader.StartInfo.Arguments += "erase "
                        + (cbForceDelete.Checked ? "-f " : "") 
                        + strParams;

                    this.javaloader.Start();
                    CodLoaderLog("ɾ��ѡ����ģ��..." + (cbForceDelete.Checked ? "ʹ��\"-f\"����ǿ��ɾ������ʹ�õ�ģ��" : ""));

                    string output = this.javaloader.StandardOutput.ReadToEnd();
                    string error = this.javaloader.StandardError.ReadToEnd();
                    CodLoaderLog(output);
                    CodLoaderLog(error);
                    this.javaloader.WaitForExit();
                }
            }

        }
        #endregion

        #region common
        //����ʾ
        private void ErrorBox(string msg) {
            MessageBox.Show(this,msg, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //��list���������Ϊ�ַ�������
        private string ListToString()
        {

            StringBuilder sbParams = new StringBuilder();
            foreach (ListViewItem item in lvCodLoaderFiles.Items)
            {
                if (item.Checked)
                {
                    //�����ŷ�ֹ·�������Ļ�ո����
                    sbParams.Append("\"");
                    sbParams.Append(item.Tag);
                    sbParams.Append("\" ");
                }
            }
            return sbParams.ToString();
        }
        

        private void lvCodLoaderFiles_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (File.Exists(path))
            {//�ļ�
                lvCodLoaderFiles.Items.Clear();
                FileInfo fi = new FileInfo(path);
                ListViewItem item = new ListViewItem();
                item.Text = fi.Name;
                item.Tag = fi.FullName;
                item.SubItems.Add(Utility.FileSizeHelper.FriendlySize(fi.Length));
                lvCodLoaderFiles.Items.Add(item);
            }
            else
            {
                lvCodLoaderFiles.Tag = path;
                CodLoaderListCodFiles();
            }
        }

       
        #endregion

        #region ����ѡ��
        private void btnSaveSelected_Click(object sender, EventArgs e)
        {
            //�����ļ�������
            if (this.m_IsLocalFile)
                return;
            string strParams = ListToString();
            if (string.IsNullOrEmpty(strParams))
            {
                ErrorBox("����ѡ��Ҫ�����codģ��");
            }
            else{
                dialogBrowserCodFolder.ShowNewFolderButton = true;
                dialogBrowserCodFolder.Description = "����ѡ���COD�ļ����浽:";
                string initFolder = this.config.GetString("codloader", "SaveCodFolder", "");
                
                if (!string.IsNullOrEmpty(initFolder))
                    dialogBrowserCodFolder.SelectedPath = initFolder;

                if (DialogResult.OK == dialogBrowserCodFolder.ShowDialog())
                {
                    this.config.WriteValue("codloader", "SaveCodFolder", dialogBrowserCodFolder.SelectedPath);
                    CreateJavaLoader(false, true, true);
                    this.javaloader.StartInfo.Arguments += "save " + strParams;
                   
                    this.javaloader.Start();
                    CodLoaderLog("����ѡ����ģ��...");

                   // string output = this.javaloader.StandardOutput.ReadToEnd();
                    string error = this.javaloader.StandardError.ReadToEnd();
                  //  CodLoaderLog(output);
                 //   CodLoaderLog(error);
                    this.javaloader.WaitForExit();

                    //�ƶ��ļ�
                    string []strCods = strParams.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int count = 0;
                    foreach (string s in strCods) {
                        string fileName = s.Replace("\"","") + ".cod";
                        if (File.Exists(fileName)) {                            
                            //�ƶ��ļ���ָ��Ŀ¼
                            File.Copy(fileName, Path.Combine(dialogBrowserCodFolder.SelectedPath, fileName),true);
                            File.Delete(fileName);
                            count++;
                        }
                        
                    }
                    if (count > 0)
                    {

                        MessageBox.Show(string.Format("�ɹ�����{0}���ļ�����{1};", count,dialogBrowserCodFolder.SelectedPath), "�����ɹ�", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                    }
                    else
                    {
                        CodLoaderLog("�����ļ�ʧ�ܣ�");
                    }
                }
              
            }
        }

        #endregion

        #endregion

        #region ����
        private void linkLabelHomeWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch(Exception ex)
            {
                MessageBox.Show("���ܴ�����." + ex.Message);
            }

        }

        private void VisitLink()
        {
            linkLabelHomeWeb.LinkVisited = true;
            System.Diagnostics.Process.Start("iexplore.exe", "http://oteam.cn/?from=BerryBox v" + Application.ProductVersion);
        }
        #endregion

        #region  ϵͳ����

            #region ��ͼ
        void CaptureScreen(object paras)
        {
            string[] p = (string[])paras;
            string savePath = p[0];
            string imageType = p[1];
                CreateJavaLoader(true, true, true);
                this.javaloader.StartInfo.Arguments += string.Format("screenshot \"{0}\"", savePath);
                this.javaloader.Start();
                this.javaloader.WaitForExit(10000);
                if (File.Exists(savePath))
                {
                    if (imageType != "BMP")
                    {
                        if (SaveImageAs(savePath, imageType))
                           SetPictureBoxImage(picture_SysTools_Screen,savePath.Replace(".bmp", "." + imageType));
                    }
                    else
                        SetPictureBoxImage(picture_SysTools_Screen,savePath);
                }
                ButtonToggle(btn_SysTools_Capture, true) ;
                      
        }

        private delegate void SetPictureBoxDelegate(PictureBox pb, string imageFile);

        void SetPictureBoxImage(PictureBox pb, string imageFile) {
            if (pb.InvokeRequired)
            {
                SetPictureBoxDelegate dlg = new SetPictureBoxDelegate(SetPictureBoxImage);
                this.BeginInvoke(dlg, pb, imageFile);
            }
            else {
                Image img = Image.FromFile(imageFile);
                pb.Image = img;
                pb.Width = img.Width;
                pb.Height = img.Height;
                pb.Refresh();
            }
        
        }
        private void btn_SysTools_Capture_Click(object sender, EventArgs e)
        {            
            if (!string.IsNullOrEmpty(tb_SysTools_ScreenCaptureLocation.Text))
            {
                ButtonToggle(btn_SysTools_Capture, false);
                string savePath = Path.Combine(tb_SysTools_ScreenCaptureLocation.Text, DateTime.Now.Ticks.ToString());
                string imageType = ddl_SysTools_ImageType.SelectedItem.ToString();
                savePath += ".bmp";

                Thread thread = new Thread(new ParameterizedThreadStart(CaptureScreen));
                thread.IsBackground = true;
                string[] paras = {savePath,imageType };
                thread.Start(paras);
            }
            else
            {
                ErrorBox("����ѡ���ͼ�ļ������Ŀ¼");
            }
           

        }

        private bool SaveImageAs(string path, string type)
        {
            ImageFormat imgFormat = ImageFormat.Png;
            string mimeType = "image/png";
            if (type == "JPG")
            {
                imgFormat = ImageFormat.Jpeg;
                mimeType = "image/jpeg";
            }
            string newName;
            if(path.EndsWith(".bmp")){
                newName = path.Replace(".bmp","." + type.ToLower());

            }
            else
                newName = path + "." + type.ToLower();
            Image img =Image.FromFile(path);
            if (img != null)
            {
                //����JPG�����ĺ���
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo ici = null;
                foreach (ImageCodecInfo codec in codecs)
                {
                    if (codec.MimeType == mimeType)
                    {
                        ici = codec;
                        break;
                    }
                }

                EncoderParameters ep = new EncoderParameters();
                ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 90L);


                img.Save(newName, ici, ep);
                //newBm.Dispose();
                img.Dispose();
                File.Delete(path);
                return File.Exists(newName);
            }
            return false;
        }

        private void btn_SysTools_ScreenCaptureBrowser_Click(object sender, EventArgs e)
        {

            string initFolder = this.config.GetString("SysTools", "ScreenshotSaveFolder", "");

            if (!string.IsNullOrEmpty(initFolder))
                dialogBrowserCodFolder.SelectedPath = initFolder;
            dialogBrowserCodFolder.ShowNewFolderButton = true;
            dialogBrowserCodFolder.Description = "��ѡ���ͼ����·��";

            if (dialogBrowserCodFolder.ShowDialog() == DialogResult.OK)
            {
                tb_SysTools_ScreenCaptureLocation.Text = dialogBrowserCodFolder.SelectedPath;
                //save
                this.config.WriteValue("SysTools", "ScreenshotSaveFolder", tb_SysTools_ScreenCaptureLocation.Text);
            }
        }

        #endregion

        

        
        #region ���ߵ翪��
        private void btn_SysTools_WirelessOFF_Click(object sender, EventArgs e)
        {
            ButtonToggle(btn_SysTools_WirelessOFF, false);
            Thread thread = new Thread(new ParameterizedThreadStart(SwitchRadio));
            thread.IsBackground = true;
            thread.Start("off");
        }
        void SwitchRadio(object paras)
        {
            string option = (string)paras;
            
            CreateJavaLoader(true, true, true);
            this.javaloader.StartInfo.Arguments += string.Format("radio {0}", option);
            this.javaloader.Start();
            if (this.javaloader.WaitForExit(5000))
            {
                MessageBox.Show(string.Format("�豸���ߵ���{0}", option == "on" ? "����" : "�ر�"),"�����ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ErrorBox("���ߵ����ʧ��");
               
            }
            ButtonToggle(option == "on" ? btn_SysTools_WirelessON : btn_SysTools_WirelessOFF, true);
        }
        

        private void btn_SysTools_WirelessON_Click(object sender, EventArgs e)
        {
            ButtonToggle(btn_SysTools_WirelessON, false);
            Thread thread = new Thread(new ParameterizedThreadStart(SwitchRadio));
            thread.IsBackground = true;
            thread.Start("on");
        }
#endregion

        #region ����ʱ��
        private void btn_SysTools_TimeSync_Click(object sender, EventArgs e)
        {
            ButtonToggle(btn_SysTools_TimeSync, false);
            Thread thread = new Thread(new ThreadStart(SyncSystemTimeToDevice));
            thread.IsBackground = true;
            thread.Start();
        }

        void SyncSystemTimeToDevice()
        {            
            CreateJavaLoader(true, true, true);
            this.javaloader.StartInfo.Arguments += "settime";
            this.javaloader.Start();
            if (this.javaloader.WaitForExit(5000))
            {
                MessageBox.Show("ʱ�����óɹ�", "�����ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ErrorBox("ʱ������ʧ��");

            }
            ButtonToggle(btn_SysTools_TimeSync, true);
        }
        #endregion

        #region WIPE
        private void btn_SysTools_Wipe_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ȷ��ҪWIPE�����豸�𣿸ò���ִ�гɹ���������Ϊ�豸���¼���OS��", "ȷ��WIPE",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                ButtonToggle(btn_SysTools_Wipe, false);
                Thread thread = new Thread(new ParameterizedThreadStart(WipeDevice));
                thread.IsBackground = true;
                string addParams = "";
                if (cb_SysTools_A.Checked)
                    addParams += "-a";
                if (cb_SysTools_F.Checked)
                    addParams += " -f";
                thread.Start(addParams);
            }
        }
        void WipeDevice(object paras)
        {            
            string addParams = (string)paras;
            CreateJavaLoader(false, false, false);
            this.javaloader.StartInfo.Arguments += string.Format("wipe {0}",addParams);
            this.javaloader.Start();
           this.javaloader.WaitForExit();
           MessageBox.Show("�豸�Ѳ���", "�����ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ButtonToggle(btn_SysTools_Wipe, true);
        }
        #endregion


        #endregion

        #region OTA Downloader
        private void btn_OTA_Download_Click(object sender, EventArgs e)
        {
            string url = tb_OTA_URL.Text.Trim();
            if (string.IsNullOrEmpty(url))
            {
                ErrorBox("����ָ��Ҫ���ص�Jad��ַ");
                tb_OTA_URL.Focus();
                return;
            }
            else if (!url.ToLower().StartsWith("http://") && !url.ToLower().StartsWith("https://"))
            {
                ErrorBox("��Ǹ,Ŀǰֻ֧��http��https�����ص�ַ!");
                tb_OTA_URL.Focus();
                return;
            }
            groupBox_OTA.Enabled = false;
            tb_OTA_CodFiles.Text = "";
            tbCodLoaderLog.Text = "";
            label_OTA_MIDletName.Text = "";
            label_OTA_CodCount.Text = "������{0}��Cod�ļ�";
            progressBar_OTA.Value = 0;
            //��ǰĿ¼
            string savePath = Environment.CurrentDirectory;
            if (!string.IsNullOrEmpty(tb_OTA_SavePath.Text))
            {
                savePath = tb_OTA_SavePath.Text;
                this.config.WriteValue("OTADownloader", "SavePath", savePath);
            }
            string model = comboBox_OTA_DeviceModel.Text;
            string os = comboBox_OTA_OS.SelectedItem.ToString();
            if(!string.IsNullOrEmpty(model))
                this.config.WriteValue("OTADownloader", "Model", model);
            if (!string.IsNullOrEmpty(os))
                this.config.WriteValue("OTADownloader", "OS", os);

            Thread thread = new Thread(new ParameterizedThreadStart(DownloadFromOTA));
            thread.IsBackground = true;
            thread.Start(new string[]{url,model,os});

           
        }

        void DownloadFromOTA(object param) {
            string[] paras = (string[])param;

            string url = paras[0];
            string model = string.IsNullOrEmpty(paras[1])?"8300":paras[1];
            string os = string.IsNullOrEmpty(paras[2]) ? "4.5" : paras[2];
            StringBuilder sb = new StringBuilder();
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            req.UserAgent = string.Format("BlackBerry{0}/{1}.0Profile/MIDP-2.0 Configuration/CLDC-1.1",
                                            model,
                                            os);
            req.AllowAutoRedirect = true;
            req.MaximumAutomaticRedirections = 2;
           // req.KeepAlive = false;
           
           // req.Proxy = new WebProxy("127.0.0.1", 8000);
            try
            {
                HttpWebResponse wr = req.GetResponse() as HttpWebResponse;
                CodLoaderLog("ContentType:" + wr.ContentType);
                CodLoaderLog("ContentEncoding:" + wr.ContentEncoding);
                CodLoaderLog("Server:" + wr.Server);
                CodLoaderLog("StatusDescription:" + wr.StatusDescription);
               
                
                using (StreamReader s = new StreamReader(wr.GetResponseStream()))
                {
                    sb.Append(s.ReadToEnd());
                }
                CodLoaderLog(sb.ToString());
                if (wr.ContentType != "text/vnd.sun.j2me.app-descriptor")
                {
                    ErrorBox("��������Ӧ���ݲ���һ����Ч��jad����");
                    SetControlAttribute(groupBox_OTA, "Enabled", true);
                    return;
                }
            }
            catch (Exception ex) {
                ErrorBox("����jad�ļ�ʧ��:" + ex.Message);
                SetControlAttribute(groupBox_OTA, "Enabled", true);
                return;
            }
            
            
            string urlPath = url.Substring(0, url.LastIndexOf("/")+1);
            JadReader reader = new JadReader(sb.ToString());
            SetControlAttribute(label_OTA_CodCount, "Text", string.Format("������{0}��Cod�ļ�", reader.CodFiles.Count));
            SetControlAttribute(label_OTA_MIDletName,"Text",string.Format("{0}-[{1}]", reader.MIDletName, FileSizeHelper.FriendlySize(reader.TotalSize)));

            //savepath
            string savePath = this.config.GetString("OTADownloader", "SavePath", Environment.CurrentDirectory);                

            savePath = Path.Combine(savePath, reader.MIDletName);

            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            int progress = 0;
            WebClient client = new WebClient();
           
            
            //download
            foreach (CodFile cod in reader.CodFiles)
            {
                OTADownloaderLog(string.Format("����:{0} - [{1}]...", cod.Name, FileSizeHelper.FriendlySize(cod.Size)));

                string oldCodName = cod.Name;
                string codUrl = urlPath + cod.Name;
                //���Ե�ַ
                if(cod.Name.ToLower().IndexOf("://") > 0)
                {
                    codUrl = cod.Name;
                    cod.Name = Path.GetFileName(cod.Name);
                }
                //�޸ı����cod�ļ���Ϊ ����� + ���
                if (Path.GetExtension(cod.Name).ToLower() != ".cod")
                {
                    cod.Name = reader.MIDletName + (cod.Id == 0 ? ".cod" : string.Format("-{0}.cod", cod.Id));
                }

                //ȥ����������ַ�
                char[] invalid = Path.GetInvalidFileNameChars();
                foreach (char c in invalid)
                {
                    cod.Name = cod.Name.Replace(c, '_');
                }
               
                try
                {
                    client.Headers.Set("UserAgent", req.UserAgent);
                  
                    client.DownloadFile(codUrl, Path.Combine(savePath, cod.Name));
                    OTADownloaderLog("�ɹ�\r\n");
                    //�滻codname
                    sb.Replace(oldCodName, cod.Name);
                }
                catch {
                    OTADownloaderLog("ʧ��\r\n");
                    OTADownloaderLog("��ֹ�������أ������ԣ�\r\n");
                    SetControlAttribute(groupBox_OTA, "Enabled", true);
                    return;
                }
                progress++;
                //�����µ�jad
               // CreateJadFile(savePath);
                UpdateOTAProgress(reader.CodFiles.Count, progress);
            }
            //����jad�ļ�           
            StreamWriter sw = new StreamWriter(Path.Combine(savePath, reader.MIDletName + ".jad"));
            sw.Write(sb.ToString());
            sw.Close();

            SetControlAttribute(groupBox_OTA, "Enabled", true);
            
            MessageBox.Show("���سɹ�", "���سɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        ////�����ļ����еķǷ��ַ�
        //string OSSafeFileName(string filename)
        //{
        //    string safeName = filename;
        //    if (filename.IndexOf("://") > 0)
        //        safeName = Path.GetFileName(filename);
        //    //remove invalid chars
        //    char[] invalid = Path.GetInvalidFileNameChars();
        //    foreach (char c in invalid) {
        //        safeName = safeName.Replace(c, '_');
        //    }
        //    if (Path.GetExtension(safeName).ToLower() != ".cod")
        //        safeName += ".cod";
        //    return safeName;
        //}
     
        void OTADownloaderLog(string msg)
        {
            if (string.IsNullOrEmpty(msg))
                return;

            if (tb_OTA_CodFiles.InvokeRequired)
            {
                WriteLogDelegate log = new WriteLogDelegate(OTADownloaderLog);
                this.BeginInvoke(log, msg);
            }
            else
            {
                tb_OTA_CodFiles.Text += msg ;
                //�������ײ�
                this.tb_OTA_CodFiles.SelectionStart = this.tb_OTA_CodFiles.Text.Length;
                this.tb_OTA_CodFiles.SelectionLength = 0;
                this.tb_OTA_CodFiles.ScrollToCaret();
            }
        }


        void UpdateOTAProgress(int total, int current) {

            int progress = current * 100 / total;
            SetControlAttribute(progressBar_OTA, "Value", progress);
        }

        void BindDeviceModels()
        {
            DeviceLib lib = new DeviceLib();
            foreach (DeviceInfo di in lib.Devices.Values) {
                comboBox_OTA_DeviceModel.Items.Add(string.Format("{0}", di.Model));
            }
        }
       

        private void btn_OTA_BrowseSaveFolder_Click(object sender, EventArgs e)
        {
            dialogBrowserCodFolder.Description = "��ѡ�񱣴�·��";
            dialogBrowserCodFolder.ShowNewFolderButton = true;
            dialogBrowserCodFolder.SelectedPath = this.config.GetString("OTADownloader", "SavePath", "");
            if (dialogBrowserCodFolder.ShowDialog() == DialogResult.OK)
            {
                tb_OTA_SavePath.Text = dialogBrowserCodFolder.SelectedPath;
            }
        }
        private void link_OTA_Help_MouseHover(object sender, EventArgs e)
        {
            ToolTip tip = new ToolTip();
            tip.ToolTipIcon = ToolTipIcon.Info;
            tip.ToolTipTitle = "UserAgent";
            tip.SetToolTip(link_OTA_Help,"�˴���������ʱʹ�õ�UserAgent,\r\n�е�����ϵͳ�����UserAgent�ض�����\r\n�����ֻ�ϵͳ�汾�����,\r\n����:google��ȫϵ�������");
            //tip.SetToolTip(comboBox_OTA_DeviceModel, "�˴���������ʱʹ�õ�UserAgent,\r\n�е�����ϵͳ�����UserAgent�ض�����\r\n�����ֻ�ϵͳ�汾�����,\r\n����:google��ȫϵ�������");

        }
        #endregion

        #region Driver Installer
        private void btn_Global_InstallDriver_Click(object sender, EventArgs e)
        {
            // Elevate the process if it is not run as administrator.
            if (!IsRunAsAdmin())
            {
                // Launch itself as administrator
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.UseShellExecute = true;
                proc.WorkingDirectory = Environment.CurrentDirectory;
                proc.FileName = Application.ExecutablePath;
                proc.Verb = "runas";

                try
                {
                    Process.Start(proc);
                }
                catch
                {
                    // The user refused to allow privileges elevation.
                    // Do nothing and return directly ...
                    return;
                }

                Application.Exit();  // Quit itself
            }
            else
            {
                if (DialogResult.OK == 
                    MessageBox.Show(this,"������Ժ򵯳���������װ���ڲ���,ֱ����ʾ������װ�ɹ�!", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                {
                    CodLoaderLog("���ڼ���USB����...");
                    USBDriverInstaller installer = new USBDriverInstaller();
                    bool ret = installer.Install();
                    CodLoaderLog(ret ? "������װ�ɹ�!":"��װ����ʧ��!");
                }
            }

        }

        #endregion

        #region Jar2Cod

        private void tb_Jar2Cod_JarFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void tb_Jar2Cod_JarFiles_DragDrop(object sender, DragEventArgs e)
        {
            tb_Jar2Cod_JarFiles.Tag = "";
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            if (File.Exists(path))
            {//�ļ�
                if (Path.GetExtension(path).ToLower() == ".jar")
                {
                    tb_Jar2Cod_JarFiles.Text = "";
                    tb_Jar2Cod_JarFiles.Text = path;
                    tb_Jar2Cod_JarFiles.Tag = path;
                    btn_Jar2Cod_Convert.Enabled = true;
                }
                else
                    tb_Jar2Cod_JarFiles.Text = "����һ����Ч��jar�ļ�";
            }
            else
            {
                ListFiles(path);
            }
        }

        void ListFiles(string path)
        {
            tb_Jar2Cod_JarFiles.Text = "";
            DirectoryInfo di = new DirectoryInfo(path);
            if (di.Exists)
            {

                FileInfo[] files = di.GetFiles("*.jar");
                if (files.Length > 0)
                {
                    
                    foreach (FileInfo fi in files)
                    {

                        tb_Jar2Cod_JarFiles.Text += fi.FullName + "\r\n";
                    }
                    tb_Jar2Cod_JarFiles.Tag = path;

                    btn_Jar2Cod_Convert.Enabled = true;
                }
                else
                    tb_Jar2Cod_JarFiles.Text = "û���ҵ�jar�ļ�";
            }

        }
        //��־rapc.exe��net_rim_api.jar��λ���Ƿ�ı䣬�ı��������config�ļ�
        private string rapc;
        private string rimapi;
        private void btn_Jar2Cod_Convert_Click(object sender, EventArgs e)
        {
            this.rapc = tb_Jar2Cod_RAPC.Text;
            this.rimapi = tb_Jar2Cod_RIMAPI.Text;
            if (string.IsNullOrEmpty(rapc) || string.IsNullOrEmpty(rimapi)) {
                ErrorBox("��������rapc.exe��net_rim_api.jar�ļ���λ�ã�");
                return;
            }
            if (!File.Exists(rapc) || !File.Exists(rimapi))
            {
                ErrorBox("���õ�rapc.exe��net_rim_api.jar�ļ������ڣ�");
                return;
            }
            string path = tb_Jar2Cod_JarFiles.Tag.ToString();
            
            if (!string.IsNullOrEmpty(path))
            {
                tbCodLoaderLog.Text = "";
                
                string []files = tb_Jar2Cod_JarFiles.Text.Split(new string[] {"\r\n" },  StringSplitOptions.RemoveEmptyEntries);
                if (files.Length > 0)
                {
                    btn_Jar2Cod_Convert.Enabled = false;
                    Thread thread = new Thread(new ParameterizedThreadStart(Jar2CodProcess));
                    thread.IsBackground = true;
                    thread.Start(files);
                }
              //  MessageBox.Show(this, "ȫ���ļ�ת����ɣ���鿴��־�����Ƿ��д���", "�������", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void Jar2CodProcess(object param)
        {
            string[] files = (string[])param;
            string jar = "";
            string codename = "";
            string jad = "";
            foreach (string fi in files)
            {

                jar = fi;
                //jar�ļ�����Ϊcodename,������ԴĿ¼
                codename = jar.Substring(0, jar.LastIndexOf("."));
                jad = codename + ".jad";
                //����ͬ����jad�ļ�
                if (!File.Exists(jad))
                    jad = "";


                CodLoaderLog("��ʼת��..." + jar);
                if (!string.IsNullOrEmpty(jad))
                {
                    CodLoaderLog("ʹ��JAD..." + jad);
                }
                else
                {
                    CodLoaderLog("û��ʹ��JAD�ļ�");
                }
                RapcRun(rapc, rimapi, codename, jad, jar);

                if (File.Exists(codename + ".cod"))
                {
                    CodLoaderLog("ת�����COD��" + codename + ".cod");
                }
                if (File.Exists(codename + ".err"))
                {
                    StreamReader sr = new StreamReader(File.OpenRead(codename + ".err"));
                    string err = sr.ReadToEnd();
                    sr.Close();
                    CodLoaderLog("����������ת����������ˣ���������");
                    CodLoaderLog(err);
                }
                CodLoaderLog("  ");
                CodLoaderLog("==========================================================");

                CodLoaderLog("  ");
            }
            SetControlAttribute(btn_Jar2Cod_Convert, "Enabled", true);
            CodLoaderLog("ȫ��ת���������,��鿴��־����Ƿ��д�������");
        }

        void RapcRun(string rapcpath, string rimapi,string codename,string jad,string jar) {
           
            Process rapc = new Process();
            rapc.StartInfo.FileName = "\"" + rapcpath + "\"";
            rapc.StartInfo.Arguments = string.Format("-import=\"{0}\" -codename=\"{1}\" -midlet {2} \"{3}\"",
                                                    rimapi,
                                                    codename,
                                                    string.IsNullOrEmpty(jad) ? "": string.Format("jad=\"{0}\"", jad),
                                                    jar
                                                    );

            rapc.StartInfo.CreateNoWindow = true;
            rapc.StartInfo.UseShellExecute = false;
           // rapc.StartInfo.RedirectStandardOutput = true;
          //  rapc.StartInfo.RedirectStandardError = true;
          //  rapc.OutputDataReceived +=new DataReceivedEventHandler(rapc_OutputDataReceived);
          //  rapc.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);
            rapc.Start();
          //  rapc.BeginErrorReadLine();
           // rapc.BeginOutputReadLine();
           // CodLoaderLog("Arguments:" + rapc.StartInfo.Arguments);
           // CodLoaderLog("==========================================================");
           
          //  CodLoaderLog(output);
          //  CodLoaderLog("!!!!ERROR!!!!");
         //  CodLoaderLog(error);
            rapc.WaitForExit();
        }

        void rapc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
                CodLoaderLog(e.Data.ToString());
        }

        private void btn_Jar2Cod_Select_RAPC_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "rapc.exe|rapc.exe";
            dialog.Multiselect = false;
            if (dialog.ShowDialog(this) == DialogResult.OK) {
                tb_Jar2Cod_RAPC.Text = dialog.FileName;
            
            }
            dialog.Dispose();
        }

        private void btn_Jar2Cod_Select_RIMAPI_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "net_rim_api.jar|net_rim_api.jar";
            dialog.Multiselect = false;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
               tb_Jar2Cod_RIMAPI.Text = dialog.FileName;

            }
            dialog.Dispose();
        }

        

        

        private void tb_Jar2Cod_RAPC_TextChanged(object sender, EventArgs e)
        {
            this.config.WriteValue("Jar2Cod", "RAPC", tb_Jar2Cod_RAPC.Text);
        }

        private void tb_Jar2Cod_RIMAPI_TextChanged(object sender, EventArgs e)
        {
            this.config.WriteValue("Jar2Cod", "NetRimAPI", tb_Jar2Cod_RIMAPI.Text);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabJar2Cod")
            {
                tb_Jar2Cod_RAPC.Text = this.config.GetString("Jar2Cod", "RAPC", "");
                tb_Jar2Cod_RIMAPI.Text = this.config.GetString("Jar2Cod", "NetRimAPI", "");
            }
        }

        #endregion

       

    }
}