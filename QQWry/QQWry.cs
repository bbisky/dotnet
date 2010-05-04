using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Sky.QQWry
{    
	/// <summary>
	/// ��ȡ����ip���ʵ����(sky)
    ///  //usage
    ///  Sky.QQWry.QQWry qqwry = new Sky.QQWry.QQWry(Server.MapPath("~/App_Data/QQWry.dat"));
    ///  Sky.QQWry.IPLocation location = qqwry.SearchIPLocation("127.0.0.1");
	/// </summary>
	public class QQWry
	{
		//��һ��ģʽ
		#region ��һ��ģʽ
		/**//// <summary>
		/// ��һ��ģʽ
		/// </summary>
		#endregion
		private const byte REDIRECT_MODE_1        = 0x01;
 
		//�ڶ���ģʽ
		#region �ڶ���ģʽ
		/**//// <summary>
		/// �ڶ���ģʽ
		/// </summary>
		#endregion
		private const byte REDIRECT_MODE_2        = 0x02;
 
		//ÿ����¼����
		#region ÿ����¼����
		/**//// <summary>
		/// ÿ����¼����
		/// </summary>
		#endregion        
		private const int IP_RECORD_LENGTH        = 7;
 
		//���ݿ��ļ�
		#region ���ݿ��ļ�
		/**//// <summary>
		/// �ļ�����
		/// </summary>
		#endregion        
		private FileStream ipFile;
 
		private const string unCountry = "δ֪����";
		private const string unArea    = "δ֪����";
 
		//������ʼλ��
		#region ������ʼλ��
		/**//// <summary>
		/// ������ʼλ��
		/// </summary>
		#endregion
		private long ipBegin;
 
		//��������λ��
		#region ��������λ��
		/**//// <summary>
		/// ��������λ��
		/// </summary>
		#endregion
		private long ipEnd;
 
		//IP��ַ����
		#region IP��ַ����
		/**//// <summary>
		/// IP����
		/// </summary>
		#endregion
		private IPLocation loc;
 
		//�洢�ı�����
		#region �洢�ı�����
		/**//// <summary>
		/// �洢�ı�����
		/// </summary>
		#endregion
		private byte[] buf;
 
		//�洢3�ֽ�
		#region �洢3�ֽ�
		/**//// <summary>
		/// �洢3�ֽ�
		/// </summary>
		#endregion
		private byte[] b3;
 
		//�洢4�ֽ�
		#region �洢4�ֽ�
		/**//// <summary>
		/// �洢4�ֽ�IP��ַ
		/// </summary>
		#endregion
		private byte[] b4;
 
		//���캯��
		#region ���캯��
		/// <summary>
		/// ����һ��QQWry�����
		/// </summary>
		/// <param name="ipfile">IP���ݿ��ļ�����·��</param>        
		public QQWry( string ipfile )
		{            
                
			buf = new byte[100];
			b3 = new byte[3];
			b4 = new byte[4];            
			try
			{
				ipFile = new FileStream( ipfile,FileMode.Open );
			}
			catch( Exception ex )
			{
				throw new Exception( ex.Message );
			}            
			ipBegin = readLong4(0);
			ipEnd = readLong4(4);
			loc = new IPLocation();
		}
        #endregion
        /// <summary>
        /// 
        /// </summary>
		public void Close()
		{
			ipFile.Close();
		}


		//����IP��ַ����
		#region ����IP��ַ����
		/**//// <summary>
		/// ����IP��ַ����
		/// </summary>
		/// <param name="ip"></param>
		/// <returns></returns>
		#endregion
		public IPLocation SearchIPLocation( string ip )
		{
			//���ַ�IPת��Ϊ�ֽ�
			string[] ipSp = ip.Split('.');
			if( ipSp.Length != 4 )
			{
				throw new ArgumentOutOfRangeException( "���ǺϷ���IP��ַ!" );
			}
			byte[] IP = new byte[4];
			for( int i = 0; i < IP.Length ; i++ )
			{
				IP[i] = (byte)(Int32.Parse( ipSp[i] ) & 0xFF) ;
			}

			IPLocation local = null;
			long offset = locateIP( IP );

			if( offset != -1 )
			{
				local = getIPLocation( offset );
			}

			if( local == null )
			{
				local = new IPLocation();
				local.area = unArea;
				local.country = unCountry;
			}            
			return local;
		}


		//ȡ�þ�����Ϣ
		#region ȡ�þ�����Ϣ
		/**//// <summary>
		/// ȡ�þ�����Ϣ
		/// </summary>
		/// <param name="offset"></param>
		/// <returns></returns>
		
		private IPLocation getIPLocation( long offset )
		{
			ipFile.Position = offset + 4;
			//��ȡ��һ���ֽ��ж��Ƿ��Ǳ�־�ֽ�
			byte one = (byte)ipFile.ReadByte();
			if( one == REDIRECT_MODE_1 )
			{
				//��һ��ģʽ
				//��ȡ����ƫ��
				long countryOffset = readLong3();
				//ת��ƫ�ƴ�
				ipFile.Position = countryOffset;
				//�ٴμ���־�ֽ�
				byte b = (byte)ipFile.ReadByte();
				if( b == REDIRECT_MODE_2 )
				{
					loc.country = readString( readLong3() );
					ipFile.Position = countryOffset + 4;
				}
				else
					loc.country = readString( countryOffset );

				//��ȡ������־
				loc.area = readArea( ipFile.Position );

			}
			else if( one == REDIRECT_MODE_2 )
			{
				//�ڶ���ģʽ
				loc.country = readString( readLong3() );
				loc.area = readArea( offset + 8 );
			}
			else
			{
				//��ͨģʽ
				loc.country = readString( --ipFile.Position );
				loc.area = readString( ipFile.Position );
			}
			return loc;
        }
        #endregion

        //ȡ�õ�����Ϣ
		#region ȡ�õ�����Ϣ
		/**//// <summary>
		/// ��ȡ��������
		/// </summary>
		/// <param name="offset"></param>
		/// <returns></returns>
		
		private string readArea( long offset )
		{
			ipFile.Position = offset;
			byte one = (byte)ipFile.ReadByte();
			if( one == REDIRECT_MODE_1 || one == REDIRECT_MODE_2 )
			{
				long areaOffset = readLong3( offset + 1 );
				if( areaOffset == 0 )
					return unArea;
				else
				{
					return readString( areaOffset );
				}
			}
			else
			{
				return readString( offset );
			}
        }
        #endregion

        //��ȡ�ַ���
		#region ��ȡ�ַ���
		/**//// <summary>
		/// ��ȡ�ַ���
		/// </summary>
		/// <param name="offset"></param>
		/// <returns></returns>
		
		private string readString( long offset )
		{
			ipFile.Position = offset;
			int i = 0;
			for(i = 0, buf[i]=(byte)ipFile.ReadByte();buf[i] != (byte)(0);buf[++i]=(byte)ipFile.ReadByte());
            
			if( i > 0 )
				return Encoding.Default.GetString( buf,0,i );
			else
				return "";
        }
        #endregion

        //����IP��ַ���ڵľ���ƫ����
		#region ����IP��ַ���ڵľ���ƫ����
		/**//// <summary>
		/// ����IP��ַ���ڵľ���ƫ����
		/// </summary>
		/// <param name="ip"></param>
		/// <returns></returns>
		
		private long locateIP( byte[] ip )
		{
			long m = 0;
			int r;

			//�Ƚϵ�һ��IP��
			readIP( ipBegin, b4 );
			r = compareIP( ip,b4);
			if( r == 0 )
				return ipBegin;
			else if( r < 0 )
				return -1;
			//��ʼ��������
			for( long i = ipBegin,j=ipEnd; i<j; )
			{
				m = this.getMiddleOffset( i,j );
				readIP( m,b4 );
				r = compareIP( ip,b4 );
				if( r > 0 )
					i = m;
				else if( r < 0 )
				{
					if( m == j )
					{
						j -= IP_RECORD_LENGTH;
						m = j;
					}
					else
					{
						j = m;
					}
				}
				else
					return readLong3( m+4 );
			}
			m = readLong3( m+4 );
			readIP( m,b4 );
			r = compareIP( ip,b4 );
			if( r <= 0 )
				return m;
			else
				return -1;
        }
        #endregion

        //����4�ֽڵ�IP��ַ
		#region ����4�ֽڵ�IP��ַ
		/**//// <summary>
		/// �ӵ�ǰλ�ö�ȡ���ֽ�,�����ֽ���IP��ַ
		/// </summary>
		/// <param name="offset"></param>
		/// <param name="ip"></param>
		
		private void readIP( long offset, byte[] ip )
		{
			ipFile.Position = offset;
			ipFile.Read( ip,0,ip.Length );
			byte tmp = ip[0];
			ip[0] = ip[3];
			ip[3] = tmp;
			tmp = ip[1];
			ip[1] = ip[2];
			ip[2] = tmp;
        }
        #endregion

        //�Ƚ�IP��ַ�Ƿ���ͬ
		#region �Ƚ�IP��ַ�Ƿ���ͬ
		/**//// <summary>
		/// �Ƚ�IP��ַ�Ƿ���ͬ
		/// </summary>
		/// <param name="ip"></param>
		/// <param name="beginIP"></param>
		/// <returns>0:���,1:ip����beginIP,-1:С��</returns>
		
		private int compareIP( byte[] ip, byte[] beginIP )
		{
			for( int i = 0; i < 4; i++ )
			{
				int r = compareByte( ip[i],beginIP[i] );
				if( r != 0 )
					return r;
			}
			return 0;
        }
        #endregion

        //�Ƚ������ֽ��Ƿ����
		#region �Ƚ������ֽ��Ƿ����
		/**//// <summary>
		/// �Ƚ������ֽ��Ƿ����
		/// </summary>
		/// <param name="bsrc"></param>
		/// <param name="bdst"></param>
		/// <returns></returns>
		
		private int compareByte( byte bsrc, byte bdst )
		{
			if( ( bsrc&0xFF ) > ( bdst&0xFF ) )
				return 1;
			else if( (bsrc ^ bdst) == 0 )
				return 0;
			else
				return -1;
        }
        #endregion

        //���ݵ�ǰλ�ö�ȡ4�ֽ�
		#region ���ݵ�ǰλ�ö�ȡ4�ֽ�
		/**//// <summary>
		/// �ӵ�ǰλ�ö�ȡ4�ֽ�,ת��Ϊ������
		/// </summary>
		/// <param name="offset"></param>
		/// <returns></returns>
		
		private long readLong4( long offset )
		{
			long ret = 0;
			ipFile.Position = offset;
			ret |= ( ipFile.ReadByte() & 0xFF );
			ret |= ( ( ipFile.ReadByte() << 8 ) & 0xFF00 );
			ret |= ( ( ipFile.ReadByte() << 16 ) & 0xFF0000 );
			ret |= ( ( ipFile.ReadByte() << 24 ) & 0xFF000000 );
			return ret;
        }
        #endregion

        //���ݵ�ǰλ��,��ȡ3�ֽ�
		#region ���ݵ�ǰλ��,��ȡ3�ֽ�
		/**//// <summary>
		/// ���ݵ�ǰλ��,��ȡ3�ֽ�
		/// </summary>
		/// <param name="offset"></param>
		/// <returns></returns>
		
		private long readLong3( long offset )
		{
			long ret = 0;
			ipFile.Position = offset;
			ret |= ( ipFile.ReadByte() & 0xFF );
			ret |= ( (ipFile.ReadByte() << 8 ) & 0xFF00 );
			ret |= ( (ipFile.ReadByte() << 16 ) & 0xFF0000 );
			return ret;
        }
        #endregion

        //�ӵ�ǰλ�ö�ȡ3�ֽ�
		#region �ӵ�ǰλ�ö�ȡ3�ֽ�
		/**//// <summary>
		/// �ӵ�ǰλ�ö�ȡ3�ֽ�
		/// </summary>
		/// <returns></returns>
		
		private long readLong3()
		{
			long ret = 0;            
			ret |= ( ipFile.ReadByte() & 0xFF );
			ret |= ( (ipFile.ReadByte() << 8 ) & 0xFF00 );
			ret |= ( (ipFile.ReadByte() << 16 ) & 0xFF0000 );
			return ret;
        }
        #endregion

        //ȡ��begin��end֮���ƫ����
		#region ȡ��begin��end֮���ƫ����
		/**//// <summary>
		/// ȡ��begin��end�м��ƫ��
		/// </summary>
		/// <param name="begin"></param>
		/// <param name="end"></param>
		/// <returns></returns>
		
		private long getMiddleOffset( long begin, long end )
		{
			long records = ( end - begin ) / IP_RECORD_LENGTH;
			records >>= 1;
			if( records == 0 )
				records = 1;
			return begin + records * IP_RECORD_LENGTH;
        }
        #endregion
    }    
    //class QQWry


    /// <summary>
    /// IPλ�ö���
    /// </summary>
	public class IPLocation 
	{
        /// <summary>
        /// ���Ҽ�����
        /// </summary>
		public String country;
		/// <summary>
		/// ����λ��
		/// </summary>
        public String area;
        
        /// <summary>
        /// ���캯��
        /// </summary>
		public IPLocation() 
		{
			country = area = "";
		}
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public IPLocation getCopy() 
		{
			IPLocation ret = new IPLocation();
			ret.country = country;
			ret.area = area;
			return ret;
		}
	}
}

