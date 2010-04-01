using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace BerryBox.Utility
{
    /// <summary>
    /// 分析jad文件
    /// </summary>
    public class JadReader
    {
        private string m_JadContent;
        //public JadReader(string file) {

        //    StreamReader sr = new StreamReader(file);
        //    this.m_JadContent = sr.ReadToEnd();
        //    sr.Close();
        //}

        public JadReader(string jadstring)
        {
            this.m_JadContent = jadstring;
           
        }
        private int totalSize = 0;

        public int TotalSize
        {
            get { return totalSize; }
            set { totalSize = value; }
        }
        private string midletName = "";

        public string MIDletName{
            get {
                if (!string.IsNullOrEmpty(midletName))
                    return this.midletName;
                else
                {
                    Regex re = new Regex("MIDlet-Name:(.+)", RegexOptions.IgnoreCase);
                    if (re.IsMatch(this.m_JadContent))
                    {
                        return re.Match(this.m_JadContent).Groups[1].Value.Trim();
                    }
                    else
                        return "";
                }
            }
        }
        private IList<CodFile> m_CodFiles;
        public IList<CodFile> CodFiles {
            get {
                if (m_CodFiles != null && m_CodFiles.Count > 0)
                    return m_CodFiles;
                else
                {
                    IList<CodFile> codfiles = new List<CodFile>();

                    Regex re = new Regex(@"RIM-COD-URL(-(\d+))?:(.+)", RegexOptions.IgnoreCase);
                    Regex reSize = new Regex(@"RIM-COD-Size(-(\d+))?:\s*(\d+)", RegexOptions.IgnoreCase);

                    //name and index
                    if (re.IsMatch(this.m_JadContent))
                    {

                        MatchCollection matches = re.Matches(this.m_JadContent);
                        foreach (Match m in matches)
                        {
                            CodFile cod = new CodFile();
                            cod.Name = m.Groups[3].Value.Trim();
                            cod.Id = (string.IsNullOrEmpty(m.Groups[2].Value) ? 0 : Convert.ToInt32(m.Groups[2].Value));
                            codfiles.Add(cod);
                        }
                    }
                    //size
                    if (reSize.IsMatch(this.m_JadContent))
                    {

                        MatchCollection matches = reSize.Matches(this.m_JadContent);
                        foreach (Match m in matches)
                        {
                            int index = (string.IsNullOrEmpty(m.Groups[2].Value) ? 0 : Convert.ToInt32(m.Groups[2].Value));

                            foreach (CodFile cod in codfiles)
                            {

                                if (cod.Id == index)
                                {
                                    cod.Size = Int32.Parse(m.Groups[3].Value);
                                    totalSize += cod.Size;
                                }
                            }
                        }
                    }
                    m_CodFiles = codfiles;
                    return codfiles;
                }
            }
        }
        
    }

    public class CodFile {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int size;

        public int Size
        {
            get { return size; }
            set { size = value; }
        }
    }
}
