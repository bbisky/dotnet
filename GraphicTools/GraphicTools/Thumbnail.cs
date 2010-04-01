using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;

namespace GraphicTools
{
    public class Thumbnail
    {

        /// <summary>
        /// ��������ͼ
        /// </summary>
        /// <param name="oImagePath">ԭͼ·��</param>
        /// <param name="width">����ͼ��</param>
        /// <param name="height">����ͼ��</param>
        /// <param name="corp">�Ƿ�ü�,Ϊtrueʱ,ͼƬ�����ü�Ϊָ���Ŀ�͸�; Ϊfalseʱ,ͼƬ���ᰴԭͼ������С,��͸߲��ᳬ��ָ����ֵ.</param>
        /// <param name="level">ͼƬ����1-100</param>
        /// <param name="newImagePath">����ͼ����·��</param>
        /// <returns></returns>
        public static bool GenerateThumbnail(string oImagePath, int width, int height, bool corp, int level, string newImagePath)
        {
            Image source = Image.FromFile(oImagePath);

            int tWidth = width;//����ͼ�Ŀ��
            int tHeight = height;// ����ͼ�ĸ߶�

            //����JPG�����ĺ���
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo ici = null;
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.MimeType == "image/jpeg")
                    ici = codec;
            }

            EncoderParameters ep = new EncoderParameters();
            ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)level);

            //            string thumbImgFile = overwrite ? oImagePath.Replace(Path.GetExtension(oImagePath), ".jpg") : GetThumbnailPath(oImagePath, width);
            string thumbImgFile = newImagePath;//overwrite ? oImagePath.Replace(Path.GetExtension(oImagePath), ".jpg") : string.Format("{0}_{1}x{2}{3}.jpg",Path.Combine(Path.GetDirectoryName(oImagePath),Path.GetFileNameWithoutExtension(oImagePath)),
            //  width,height,(corp?"_corped":""));
            //δָ���ļ�����·��������ԭ�ļ�
            if (string.IsNullOrEmpty(newImagePath))
                thumbImgFile = oImagePath.Replace(Path.GetExtension(oImagePath), ".jpg");
            Rectangle cropRec = new Rectangle(0, 0, source.Width, source.Height);
            //Դ��߱�
            double sRes = (double)source.Width / (double)source.Height;
            //Ŀ���߱�
            double tRes = (double)width / (double)height;


            if (corp)
            {//�ü�����
                cropRec.Width = source.Width;
                cropRec.Height = Convert.ToInt32((double)source.Width / tRes);
                cropRec.Y = (source.Height - cropRec.Height) / 2;
                cropRec.X = 0;
                if (cropRec.Width < tWidth)
                {
                    tWidth = cropRec.Width;
                    cropRec.Y = (source.Height - tHeight) / 2;
                    cropRec.Height = tHeight;
                }
                if (sRes > tRes)
                {
                    cropRec.Height = source.Height;
                    cropRec.Width = Convert.ToInt32((double)source.Height * tRes);
                    cropRec.X = (source.Width - cropRec.Width) / 2;
                    cropRec.Y = 0;
                    if (cropRec.Height < tHeight)
                    {
                        tHeight = cropRec.Height;
                        cropRec.X = (source.Width - tWidth) / 2;
                        cropRec.Width = tWidth;
                    }
                }

            }
            else
            {
                if (sRes > tRes)
                {
                    //tWidth = size;
                    tHeight = Convert.ToInt32((double)tWidth / sRes);

                }
                else
                {
                    tWidth = Convert.ToInt32((double)tHeight * sRes);

                }
                if (tWidth > source.Width)
                {
                    tWidth = source.Width;
                }
                if (tHeight > source.Height)
                {
                    tHeight = source.Height;
                }
            }

            Bitmap bm = new Bitmap(tWidth, tHeight);
            Graphics g = Graphics.FromImage(bm);

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.Clear(Color.White);
            g.DrawImage(source,
                new Rectangle(0, 0, tWidth, tHeight),
                cropRec,
                GraphicsUnit.Pixel);
            source.Dispose();

            bm.Save(thumbImgFile, ici, ep);
            g.Dispose();
            bm.Dispose();

            if (File.Exists(thumbImgFile))
                return true;
            else
                return false;

        }
    }
}
