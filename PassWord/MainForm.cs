using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace PassWord
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
    {
        private ToolTip toolTip1;
        private TabControl tabControl;
        private TabPage tabPassWord;
        private CheckBox cbUpOrLower;
        private Label label1;
        private TextBox tbResult;
        private Button btnSha1;
        private Button btnMd5;
        private TextBox tbInput;
        private TabPage tabMachineKey;
        private Button btnMachineKey;
        private TextBox tbMachineKey;
        private Button btnBase64Encode;
        private Button btnBase64Decode;
        private Button btnClear;
        private Label label2;
        private TabPage tabAES;
        private Button btnAESKey;
        private Label label4;
        private Label label3;
        private TextBox tbAESResult;
        private TextBox tbSource;
        private Button btnAESDecrypt;
        private Button btnAESEncrypt;
        private TextBox tbAESKey;
        private Label label6;
        private Label label5;
        private TextBox tbAESIV;
        private TabPage tabRSA;
        private Label label7;
        private Label label8;
        private TextBox tbRSAPrivate;
        private TextBox tbRSAPublic;
        private Button btnRSADecrypt;
        private Button btnRSAEncrypt;
        private Label label9;
        private Label label10;
        private TextBox tbRSAResult;
        private TextBox tbRSASource;
        private Button btnRSAKey;
        private Button btnRSAPublicCopy;
        private Button btnRSAClear;
        private IContainer components;

		public MainForm()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
            toolTip1.SetToolTip(tbInput, "错误");
            
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPassWord = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBase64Decode = new System.Windows.Forms.Button();
            this.btnBase64Encode = new System.Windows.Forms.Button();
            this.cbUpOrLower = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.btnSha1 = new System.Windows.Forms.Button();
            this.btnMd5 = new System.Windows.Forms.Button();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.tabMachineKey = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMachineKey = new System.Windows.Forms.TextBox();
            this.btnMachineKey = new System.Windows.Forms.Button();
            this.tabAES = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAESIV = new System.Windows.Forms.TextBox();
            this.tbAESKey = new System.Windows.Forms.TextBox();
            this.btnAESDecrypt = new System.Windows.Forms.Button();
            this.btnAESEncrypt = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAESResult = new System.Windows.Forms.TextBox();
            this.tbSource = new System.Windows.Forms.TextBox();
            this.btnAESKey = new System.Windows.Forms.Button();
            this.tabRSA = new System.Windows.Forms.TabPage();
            this.btnRSAClear = new System.Windows.Forms.Button();
            this.btnRSAPublicCopy = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbRSAPrivate = new System.Windows.Forms.TextBox();
            this.tbRSAPublic = new System.Windows.Forms.TextBox();
            this.btnRSADecrypt = new System.Windows.Forms.Button();
            this.btnRSAEncrypt = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbRSAResult = new System.Windows.Forms.TextBox();
            this.tbRSASource = new System.Windows.Forms.TextBox();
            this.btnRSAKey = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPassWord.SuspendLayout();
            this.tabMachineKey.SuspendLayout();
            this.tabAES.SuspendLayout();
            this.tabRSA.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPassWord);
            this.tabControl.Controls.Add(this.tabMachineKey);
            this.tabControl.Controls.Add(this.tabAES);
            this.tabControl.Controls.Add(this.tabRSA);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(392, 373);
            this.tabControl.TabIndex = 6;
            // 
            // tabPassWord
            // 
            this.tabPassWord.Controls.Add(this.btnClear);
            this.tabPassWord.Controls.Add(this.btnBase64Decode);
            this.tabPassWord.Controls.Add(this.btnBase64Encode);
            this.tabPassWord.Controls.Add(this.cbUpOrLower);
            this.tabPassWord.Controls.Add(this.label1);
            this.tabPassWord.Controls.Add(this.tbResult);
            this.tabPassWord.Controls.Add(this.btnSha1);
            this.tabPassWord.Controls.Add(this.btnMd5);
            this.tabPassWord.Controls.Add(this.tbInput);
            this.tabPassWord.Location = new System.Drawing.Point(4, 22);
            this.tabPassWord.Name = "tabPassWord";
            this.tabPassWord.Padding = new System.Windows.Forms.Padding(3);
            this.tabPassWord.Size = new System.Drawing.Size(384, 347);
            this.tabPassWord.TabIndex = 0;
            this.tabPassWord.Text = "密码工具";
            this.tabPassWord.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(331, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(50, 23);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBase64Decode
            // 
            this.btnBase64Decode.Location = new System.Drawing.Point(194, 49);
            this.btnBase64Decode.Name = "btnBase64Decode";
            this.btnBase64Decode.Size = new System.Drawing.Size(75, 23);
            this.btnBase64Decode.TabIndex = 13;
            this.btnBase64Decode.Text = "Base64解码";
            this.btnBase64Decode.UseVisualStyleBackColor = true;
            this.btnBase64Decode.Click += new System.EventHandler(this.btnBase64Decode_Click);
            // 
            // btnBase64Encode
            // 
            this.btnBase64Encode.Location = new System.Drawing.Point(106, 49);
            this.btnBase64Encode.Name = "btnBase64Encode";
            this.btnBase64Encode.Size = new System.Drawing.Size(75, 23);
            this.btnBase64Encode.TabIndex = 12;
            this.btnBase64Encode.Text = "Base64编码";
            this.btnBase64Encode.UseVisualStyleBackColor = true;
            this.btnBase64Encode.Click += new System.EventHandler(this.btnBase64Encode_Click);
            // 
            // cbUpOrLower
            // 
            this.cbUpOrLower.AutoSize = true;
            this.cbUpOrLower.Location = new System.Drawing.Point(299, 52);
            this.cbUpOrLower.Name = "cbUpOrLower";
            this.cbUpOrLower.Size = new System.Drawing.Size(84, 16);
            this.cbUpOrLower.TabIndex = 11;
            this.cbUpOrLower.Text = "大小写转换";
            this.cbUpOrLower.UseVisualStyleBackColor = true;
            this.cbUpOrLower.Click += new System.EventHandler(this.cbUpOrLower_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "输入要加密的原文";
            // 
            // tbResult
            // 
            this.tbResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbResult.Location = new System.Drawing.Point(3, 77);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(378, 267);
            this.tbResult.TabIndex = 9;
            this.tbResult.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // btnSha1
            // 
            this.btnSha1.Location = new System.Drawing.Point(53, 49);
            this.btnSha1.Name = "btnSha1";
            this.btnSha1.Size = new System.Drawing.Size(40, 23);
            this.btnSha1.TabIndex = 8;
            this.btnSha1.Text = "SHA1";
            this.btnSha1.Click += new System.EventHandler(this.btnSha1_Click);
            // 
            // btnMd5
            // 
            this.btnMd5.Location = new System.Drawing.Point(8, 49);
            this.btnMd5.Name = "btnMd5";
            this.btnMd5.Size = new System.Drawing.Size(32, 23);
            this.btnMd5.TabIndex = 7;
            this.btnMd5.Text = "MD5";
            this.btnMd5.Click += new System.EventHandler(this.btnMd5_Click);
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(3, 24);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(378, 21);
            this.tbInput.TabIndex = 6;
            this.tbInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // tabMachineKey
            // 
            this.tabMachineKey.Controls.Add(this.label2);
            this.tabMachineKey.Controls.Add(this.tbMachineKey);
            this.tabMachineKey.Controls.Add(this.btnMachineKey);
            this.tabMachineKey.Location = new System.Drawing.Point(4, 22);
            this.tabMachineKey.Name = "tabMachineKey";
            this.tabMachineKey.Padding = new System.Windows.Forms.Padding(3);
            this.tabMachineKey.Size = new System.Drawing.Size(384, 347);
            this.tabMachineKey.TabIndex = 1;
            this.tabMachineKey.Text = "MachineKey工具";
            this.tabMachineKey.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 42);
            this.label2.TabIndex = 2;
            this.label2.Text = "本工具为ASP.NET应用程序的web.config生成machineKey配置节，生成后直接复制到web.config文件<system.web>标签内";
            // 
            // tbMachineKey
            // 
            this.tbMachineKey.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbMachineKey.Location = new System.Drawing.Point(3, 48);
            this.tbMachineKey.Multiline = true;
            this.tbMachineKey.Name = "tbMachineKey";
            this.tbMachineKey.Size = new System.Drawing.Size(378, 296);
            this.tbMachineKey.TabIndex = 1;
            this.tbMachineKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // btnMachineKey
            // 
            this.btnMachineKey.Location = new System.Drawing.Point(256, 6);
            this.btnMachineKey.Name = "btnMachineKey";
            this.btnMachineKey.Size = new System.Drawing.Size(120, 37);
            this.btnMachineKey.TabIndex = 0;
            this.btnMachineKey.Text = "生成MachineKey";
            this.btnMachineKey.UseVisualStyleBackColor = true;
            this.btnMachineKey.Click += new System.EventHandler(this.btnMachineKey_Click);
            // 
            // tabAES
            // 
            this.tabAES.Controls.Add(this.label6);
            this.tabAES.Controls.Add(this.label5);
            this.tabAES.Controls.Add(this.tbAESIV);
            this.tabAES.Controls.Add(this.tbAESKey);
            this.tabAES.Controls.Add(this.btnAESDecrypt);
            this.tabAES.Controls.Add(this.btnAESEncrypt);
            this.tabAES.Controls.Add(this.label4);
            this.tabAES.Controls.Add(this.label3);
            this.tabAES.Controls.Add(this.tbAESResult);
            this.tabAES.Controls.Add(this.tbSource);
            this.tabAES.Controls.Add(this.btnAESKey);
            this.tabAES.Location = new System.Drawing.Point(4, 22);
            this.tabAES.Name = "tabAES";
            this.tabAES.Padding = new System.Windows.Forms.Padding(3);
            this.tabAES.Size = new System.Drawing.Size(384, 347);
            this.tabAES.TabIndex = 2;
            this.tabAES.Text = "AES";
            this.tabAES.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "IV：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "KEY：";
            // 
            // tbAESIV
            // 
            this.tbAESIV.Location = new System.Drawing.Point(49, 59);
            this.tbAESIV.Name = "tbAESIV";
            this.tbAESIV.Size = new System.Drawing.Size(281, 21);
            this.tbAESIV.TabIndex = 10;
            this.tbAESIV.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // tbAESKey
            // 
            this.tbAESKey.Location = new System.Drawing.Point(49, 35);
            this.tbAESKey.Name = "tbAESKey";
            this.tbAESKey.Size = new System.Drawing.Size(281, 21);
            this.tbAESKey.TabIndex = 9;
            this.tbAESKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // btnAESDecrypt
            // 
            this.btnAESDecrypt.Location = new System.Drawing.Point(306, 6);
            this.btnAESDecrypt.Name = "btnAESDecrypt";
            this.btnAESDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnAESDecrypt.TabIndex = 8;
            this.btnAESDecrypt.Text = "AES解密";
            this.btnAESDecrypt.UseVisualStyleBackColor = true;
            this.btnAESDecrypt.Click += new System.EventHandler(this.btnAESDecrypt_Click);
            // 
            // btnAESEncrypt
            // 
            this.btnAESEncrypt.Location = new System.Drawing.Point(225, 6);
            this.btnAESEncrypt.Name = "btnAESEncrypt";
            this.btnAESEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnAESEncrypt.TabIndex = 7;
            this.btnAESEncrypt.Text = "AES加密";
            this.btnAESEncrypt.UseVisualStyleBackColor = true;
            this.btnAESEncrypt.Click += new System.EventHandler(this.btnAESEncrypt_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "原文：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "结果：";
            // 
            // tbAESResult
            // 
            this.tbAESResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbAESResult.Location = new System.Drawing.Point(3, 231);
            this.tbAESResult.Multiline = true;
            this.tbAESResult.Name = "tbAESResult";
            this.tbAESResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAESResult.Size = new System.Drawing.Size(378, 113);
            this.tbAESResult.TabIndex = 4;
            this.tbAESResult.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // tbSource
            // 
            this.tbSource.Location = new System.Drawing.Point(0, 103);
            this.tbSource.Multiline = true;
            this.tbSource.Name = "tbSource";
            this.tbSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbSource.Size = new System.Drawing.Size(384, 100);
            this.tbSource.TabIndex = 3;
            this.tbSource.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // btnAESKey
            // 
            this.btnAESKey.Location = new System.Drawing.Point(6, 6);
            this.btnAESKey.Name = "btnAESKey";
            this.btnAESKey.Size = new System.Drawing.Size(75, 23);
            this.btnAESKey.TabIndex = 2;
            this.btnAESKey.Text = "生成KEY";
            this.btnAESKey.UseVisualStyleBackColor = true;
            this.btnAESKey.Click += new System.EventHandler(this.btnAESKey_Click);
            // 
            // tabRSA
            // 
            this.tabRSA.Controls.Add(this.btnRSAClear);
            this.tabRSA.Controls.Add(this.btnRSAPublicCopy);
            this.tabRSA.Controls.Add(this.label7);
            this.tabRSA.Controls.Add(this.label8);
            this.tabRSA.Controls.Add(this.tbRSAPrivate);
            this.tabRSA.Controls.Add(this.tbRSAPublic);
            this.tabRSA.Controls.Add(this.btnRSADecrypt);
            this.tabRSA.Controls.Add(this.btnRSAEncrypt);
            this.tabRSA.Controls.Add(this.label9);
            this.tabRSA.Controls.Add(this.label10);
            this.tabRSA.Controls.Add(this.tbRSAResult);
            this.tabRSA.Controls.Add(this.tbRSASource);
            this.tabRSA.Controls.Add(this.btnRSAKey);
            this.tabRSA.Location = new System.Drawing.Point(4, 22);
            this.tabRSA.Name = "tabRSA";
            this.tabRSA.Size = new System.Drawing.Size(384, 347);
            this.tabRSA.TabIndex = 0;
            this.tabRSA.Text = "RSA";
            this.tabRSA.UseVisualStyleBackColor = true;
            // 
            // btnRSAClear
            // 
            this.btnRSAClear.Location = new System.Drawing.Point(339, 31);
            this.btnRSAClear.Name = "btnRSAClear";
            this.btnRSAClear.Size = new System.Drawing.Size(37, 23);
            this.btnRSAClear.TabIndex = 25;
            this.btnRSAClear.Text = "清空";
            this.btnRSAClear.UseVisualStyleBackColor = true;
            this.btnRSAClear.Click += new System.EventHandler(this.btnRSAClear_Click);
            // 
            // btnRSAPublicCopy
            // 
            this.btnRSAPublicCopy.Location = new System.Drawing.Point(339, 55);
            this.btnRSAPublicCopy.Name = "btnRSAPublicCopy";
            this.btnRSAPublicCopy.Size = new System.Drawing.Size(37, 23);
            this.btnRSAPublicCopy.TabIndex = 24;
            this.btnRSAPublicCopy.Text = "复制";
            this.btnRSAPublicCopy.UseVisualStyleBackColor = true;
            this.btnRSAPublicCopy.Click += new System.EventHandler(this.btnRSAPublicCopy_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "私钥：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "公钥：";
            // 
            // tbRSAPrivate
            // 
            this.tbRSAPrivate.Location = new System.Drawing.Point(52, 56);
            this.tbRSAPrivate.Name = "tbRSAPrivate";
            this.tbRSAPrivate.Size = new System.Drawing.Size(281, 21);
            this.tbRSAPrivate.TabIndex = 21;
            this.tbRSAPrivate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // tbRSAPublic
            // 
            this.tbRSAPublic.Location = new System.Drawing.Point(52, 32);
            this.tbRSAPublic.Name = "tbRSAPublic";
            this.tbRSAPublic.Size = new System.Drawing.Size(281, 21);
            this.tbRSAPublic.TabIndex = 20;
            this.tbRSAPublic.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // btnRSADecrypt
            // 
            this.btnRSADecrypt.Location = new System.Drawing.Point(306, 3);
            this.btnRSADecrypt.Name = "btnRSADecrypt";
            this.btnRSADecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnRSADecrypt.TabIndex = 19;
            this.btnRSADecrypt.Text = "RSA解密";
            this.btnRSADecrypt.UseVisualStyleBackColor = true;
            this.btnRSADecrypt.Click += new System.EventHandler(this.btnRSADecrypt_Click);
            // 
            // btnRSAEncrypt
            // 
            this.btnRSAEncrypt.Location = new System.Drawing.Point(225, 3);
            this.btnRSAEncrypt.Name = "btnRSAEncrypt";
            this.btnRSAEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnRSAEncrypt.TabIndex = 18;
            this.btnRSAEncrypt.Text = "RSA加密";
            this.btnRSAEncrypt.UseVisualStyleBackColor = true;
            this.btnRSAEncrypt.Click += new System.EventHandler(this.btnRSAEncrypt_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "原文：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 208);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "结果：";
            // 
            // tbRSAResult
            // 
            this.tbRSAResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbRSAResult.Location = new System.Drawing.Point(0, 234);
            this.tbRSAResult.Multiline = true;
            this.tbRSAResult.Name = "tbRSAResult";
            this.tbRSAResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbRSAResult.Size = new System.Drawing.Size(384, 113);
            this.tbRSAResult.TabIndex = 15;
            this.tbRSAResult.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // tbRSASource
            // 
            this.tbRSASource.Location = new System.Drawing.Point(0, 100);
            this.tbRSASource.Multiline = true;
            this.tbRSASource.Name = "tbRSASource";
            this.tbRSASource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbRSASource.Size = new System.Drawing.Size(384, 100);
            this.tbRSASource.TabIndex = 14;
            this.tbRSASource.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // btnRSAKey
            // 
            this.btnRSAKey.Location = new System.Drawing.Point(6, 3);
            this.btnRSAKey.Name = "btnRSAKey";
            this.btnRSAKey.Size = new System.Drawing.Size(75, 23);
            this.btnRSAKey.TabIndex = 13;
            this.btnRSAKey.Text = "生成公钥私钥";
            this.btnRSAKey.UseVisualStyleBackColor = true;
            this.btnRSAKey.Click += new System.EventHandler(this.btnRSAKey_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(392, 373);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "MainForm";
            this.Text = "密码生成工具";
            this.tabControl.ResumeLayout(false);
            this.tabPassWord.ResumeLayout(false);
            this.tabPassWord.PerformLayout();
            this.tabMachineKey.ResumeLayout(false);
            this.tabMachineKey.PerformLayout();
            this.tabAES.ResumeLayout(false);
            this.tabAES.PerformLayout();
            this.tabRSA.ResumeLayout(false);
            this.tabRSA.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void btnMd5_Click(object sender, System.EventArgs e)
		{
            if (tbInput.Text.Trim() == "")
            {

                Warning("请输入要加密的字符串");
                return;
            }
            else
            {
                toolTip1.Hide(tbInput);
                tbResult.Text = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(tbInput.Text.Trim(), "md5");
            }
		}

		private void btnSha1_Click(object sender, System.EventArgs e)
		{
            if (tbInput.Text.Trim() == "")
            {

                Warning("请输入要加密的字符串");
                return;
            }
            else
            {
                
                toolTip1.Hide(tbInput);
                tbResult.Text = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(tbInput.Text.Trim(), "sha1");
            }
		}

        void Warning(string text)
        {
            toolTip1.UseAnimation = true;
            toolTip1.UseFading = true;
            toolTip1.Show(text, tbInput, 8, 15, 1500);
        }

        private void cbUpOrLower_CheckedChanged(object sender, EventArgs e)
        {
            string p = tbResult.Text.Trim();
            if (!String.IsNullOrEmpty(p))
            {
                tbResult.Text = cbUpOrLower.Checked ? p.ToLower() : p.ToUpper();
            }
        }

        private void btnMachineKey_Click(object sender, EventArgs e)
        {
            string webconfig = "<machineKey validationKey=\"{0}\" decryptionKey=\"{1}\" validation=\"SHA1\" decryption=\"AES\"/>";
            string validationKey = CreateKey(64);
            string decryptionKey = CreateKey(32);
            tbMachineKey.Text = String.Format(webconfig, validationKey, decryptionKey);
        }

        protected string CreateKey(int len)
        {

            byte[] bytes = new byte[len];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {

                sb.Append(string.Format("{0:X2}", bytes[i]));

            }

            return sb.ToString();

        }

        private void btnBase64Encode_Click(object sender, EventArgs e)
        {
            if (tbInput.Text.Trim() == "")
            {

                Warning("请输入要编码的字符串");
                return;
            }
            else
            {
                byte[] bytes = Encoding.Default.GetBytes(tbInput.Text.Trim());
                tbResult.Text = Convert.ToBase64String(bytes);
            }

        }

        private void btnBase64Decode_Click(object sender, EventArgs e)
        {
            if (tbInput.Text.Trim() == "")
            {

                Warning("请输入要解码的字符串");
                return;
            }
            else
            {
                try
                {
                    byte[] _TextByte = Convert.FromBase64String(tbInput.Text.Trim());
                    tbResult.Text = System.Text.Encoding.Default.GetString(_TextByte);
                }
                catch
                {
                    tbResult.Text = "输入的64位编码字符串错误";
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbResult.Text = "";
            tbInput.Text = "";
        }

        private void btnAESKey_Click(object sender, EventArgs e)
        {
            string strKey = "";
            string strIV = "";
            AES.GenerateKeyAndIV(AES.AESKeyLen.L256, out strKey, out strIV);
            tbAESKey.Text = strKey;
            tbAESIV.Text = strIV;
        }

        private void btnAESEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbAESKey.Text))
            {
                MessageBox.Show("请先生成加密KEY");
                return;
            }
            else if (string.IsNullOrEmpty(tbSource.Text)) {
                MessageBox.Show("请输入要加密的原文");
                return;
            }
            else
            {
                try
                {
                    tbAESResult.Text = AES.Encrypt(tbSource.Text, tbAESKey.Text, tbAESIV.Text);
                }
                catch {
                    MessageBox.Show("加密失败");
                }
            }
        }

        private void btnAESDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbAESKey.Text))
            {
                MessageBox.Show("请先生成解密KEY");
                return;
            }
            else if (string.IsNullOrEmpty(tbSource.Text))
            {
                MessageBox.Show("请输入要解密的密文");
                return;
            }
            else
            {
                try
                {
                    tbAESResult.Text = AES.Decrypt(tbSource.Text, tbAESKey.Text, tbAESIV.Text);
                }
                catch
                {
                    MessageBox.Show("解密失败");
                }
            }
        }

        private void btnRSAKey_Click(object sender, EventArgs e)
        {
            string strPublic = "";
            string strPrivate = "";
            RSA.GenerateKey(out strPublic, out strPrivate);
            tbRSAPublic.Text = strPublic;
            tbRSAPrivate.Text = strPrivate;
        }

        private void btnRSAEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbRSAPublic.Text))
            {
                MessageBox.Show("请输入加密公钥", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(tbRSASource.Text))
            {
                MessageBox.Show("请输入要加密的原文", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    tbRSAResult.Text = RSA.RSAEncrypt(tbRSASource.Text, tbRSAPublic.Text);
                }
                catch {
                    MessageBox.Show("加密错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRSADecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbRSAPrivate.Text))
            {
                MessageBox.Show("请输入解密私钥", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(tbRSASource.Text))
            {
                MessageBox.Show("请输入要解密的原文", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    tbRSAResult.Text = RSA.RSADecrypt(tbRSASource.Text, tbRSAPrivate.Text);
                }
                catch {
                    MessageBox.Show("解密错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRSAPublicCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, string.Format("公钥:\r\n{0}\r\n\r\n私钥:\r\n{1}", tbRSAPublic.Text, tbRSAPrivate.Text));
            MessageBox.Show("密钥信息已复制到剪贴板");
        }

        private void btnRSAClear_Click(object sender, EventArgs e)
        {
            tbRSAPrivate.Text = "";
            tbRSAPublic.Text = "";
        }

        private void textBox_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }
	}
}
