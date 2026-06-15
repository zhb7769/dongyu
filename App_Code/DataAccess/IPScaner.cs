using System;
using System.IO;
using System.Text.RegularExpressions;
namespace NetWise.DataAccess
{

    /**/
    /// <summary>
    /// to scan the ip location from qqwry.dat
    /// </summary> 
    public class IPScaner
    {
        //私有成员   
        private string _dataPath;
        private string _ip;
        private string _country;
        private string _local;
        private long _firstStartIp;
        private long _lastStartIp;
        private FileStream _objfs;
        private long _startIp;
        private long _endIp;
        private int _countryFlag;
        private long _endIpOff;
        private string _errMsg;

        //公共属性
        public string DataPath
        {
            set { _dataPath = value; }
        }
        public string Ip
        {
            set { _ip = value; }
        }
        public string Country
        {
            get { return _country; }
        }
        public string Local
        {
            get { return _local; }
        }
        public string ErrMsg
        {
            get { return _errMsg; }
        }

        //搜索匹配数据
        private int QQwry()
        {
            string pattern = @"(((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))\.){3}((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))";
            Regex objRe = new Regex(pattern);
            Match objMa = objRe.Match(_ip);
            if (!objMa.Success)
            {
                this._errMsg = "IP格式错误";
                return 4;
            }
            long ipInt = this.IpToInt(_ip);
            int nRet = 0;
            if (ipInt >= IpToInt("127.0.0.0") && ipInt <= IpToInt("127.255.255.255"))
            {
                this._country = "本机内部环回地址";
                this._local = "";
                nRet = 1;
            }
            else if ((ipInt >= IpToInt("0.0.0.0") && ipInt <= IpToInt("2.255.255.255")) || (ipInt >= IpToInt("64.0.0.0") && ipInt <= IpToInt("126.255.255.255")) || (ipInt >= IpToInt("58.0.0.0") && ipInt <= IpToInt("60.255.255.255")))
            {
                this._country = "网络保留地址";
                this._local = "";
                nRet = 1;
            }
            _objfs = new FileStream(this._dataPath, FileMode.Open, FileAccess.Read);
            try
            {
                //objfs.Seek(0,SeekOrigin.Begin);
                _objfs.Position = 0;
                byte[] buff = new Byte[8];
                _objfs.Read(buff, 0, 8);
                _firstStartIp = buff[0] + buff[1] * 256 + buff[2] * 256 * 256 + buff[3] * 256 * 256 * 256;
                _lastStartIp = buff[4] * 1 + buff[5] * 256 + buff[6] * 256 * 256 + buff[7] * 256 * 256 * 256;
                long recordCount = Convert.ToInt64((_lastStartIp - _firstStartIp) / 7.0);
                if (recordCount <= 1)
                {
                    _country = "FileDataError";
                    _objfs.Close();
                    return 2;
                }
                long rangE = recordCount;
                long rangB = 0;
                long recNO = 0;
                while (rangB < rangE - 1)
                {
                    recNO = (rangE + rangB) / 2;
                    this.GetStartIp(recNO);
                    if (ipInt == this._startIp)
                    {
                        rangB = recNO;
                        break;
                    }
                    if (ipInt > this._startIp)
                        rangB = recNO;
                    else
                        rangE = recNO;
                }
                this.GetStartIp(rangB);
                this.GetEndIp();
                if (this._startIp <= ipInt && this._endIp >= ipInt)
                {
                    this.GetCountry();
                    this._local = this._local.Replace("（我们一定要解放台湾！！！）", "");
                }
                else
                {
                    nRet = 3;
                    this._country = "未知";
                    this._local = "";
                }
                _objfs.Close();
                return nRet;
            }
            catch
            {
                return 1;
            }
        }


        //IP地址转换成Int数据
        private long IpToInt(string ip)
        {
            char[] dot = new char[] { '.' };
            string[] ipArr = ip.Split(dot);
            if (ipArr.Length == 3)
                ip = ip + ".0";
            ipArr = ip.Split(dot);
            long ip_Int = 0;
            long p1 = long.Parse(ipArr[0]) * 256 * 256 * 256;
            long p2 = long.Parse(ipArr[1]) * 256 * 256;
            long p3 = long.Parse(ipArr[2]) * 256;
            long p4 = long.Parse(ipArr[3]);
            ip_Int = p1 + p2 + p3 + p4;
            return ip_Int;
        }


        //int转换成IP
        private string IntToIp(long ipInt)
        {
            long seg1 = (ipInt & 0xff000000) >> 24;
            if (seg1 < 0)
                seg1 += 0x100;
            long seg2 = (ipInt & 0x00ff0000) >> 16;
            if (seg2 < 0)
                seg2 += 0x100;
            long seg3 = (ipInt & 0x0000ff00) >> 8;
            if (seg3 < 0)
                seg3 += 0x100;
            long seg4 = (ipInt & 0x000000ff);
            if (seg4 < 0)
                seg4 += 0x100;
            string ip = seg1.ToString() + "." + seg2.ToString() + "." + seg3.ToString() + "." + seg4.ToString();
            return ip;
        }


        //获取起始IP范围
        private long GetStartIp(long recNo)
        {
            long offSet = _firstStartIp + recNo * 7;
            //objfs.Seek(offSet,SeekOrigin.Begin);
            _objfs.Position = offSet;
            byte[] buff = new Byte[7];
            _objfs.Read(buff, 0, 7);
            _endIpOff = Convert.ToInt64(buff[4].ToString()) + Convert.ToInt64(buff[5].ToString()) * 256 + Convert.ToInt64(buff[6].ToString()) * 256 * 256;
            _startIp = Convert.ToInt64(buff[0].ToString()) + Convert.ToInt64(buff[1].ToString()) * 256 + Convert.ToInt64(buff[2].ToString()) * 256 * 256 + Convert.ToInt64(buff[3].ToString()) * 256 * 256 * 256;
            return _startIp;
        }


        //获取结束IP
        private long GetEndIp()
        {
            //objfs.Seek(endIpOff,SeekOrigin.Begin);
            _objfs.Position = _endIpOff;
            byte[] buff = new Byte[5];
            _objfs.Read(buff, 0, 5);
            this._endIp = Convert.ToInt64(buff[0].ToString()) + Convert.ToInt64(buff[1].ToString()) * 256 + Convert.ToInt64(buff[2].ToString()) * 256 * 256 + Convert.ToInt64(buff[3].ToString()) * 256 * 256 * 256;
            this._countryFlag = buff[4];
            return this._endIp;

        }


        //获取国家/区域偏移量
        private string GetCountry()
        {
            switch (this._countryFlag)
            {
                case 1:
                case 2:
                    this._country = GetFlagStr(this._endIpOff + 4);
                    this._local = (1 == this._countryFlag) ? " " : this.GetFlagStr(this._endIpOff + 8);
                    break;
                default:
                    this._country = this.GetFlagStr(this._endIpOff + 4);
                    this._local = this.GetFlagStr(_objfs.Position);
                    break;
            }
            return " ";
        }


        //获取国家/区域字符串
        private string GetFlagStr(long offSet)
        {
            int flag = 0;
            byte[] buff = new Byte[3];
            while (1 == 1)
            {
                //objfs.Seek(offSet,SeekOrigin.Begin);
                _objfs.Position = offSet;
                flag = _objfs.ReadByte();
                if (flag == 1 || flag == 2)
                {
                    _objfs.Read(buff, 0, 3);
                    if (flag == 2)
                    {
                        this._countryFlag = 2;
                        this._endIpOff = offSet - 4;
                    }
                    offSet = Convert.ToInt64(buff[0].ToString()) + Convert.ToInt64(buff[1].ToString()) * 256 + Convert.ToInt64(buff[2].ToString()) * 256 * 256;
                }
                else
                {
                    break;
                }
            }
            if (offSet < 12)
                return " ";
            _objfs.Position = offSet;
            return GetStr();
        }


        //GetStr
        private string GetStr()
        {
            byte lowC = 0;
            byte upC = 0;
            string str = "";
            byte[] buff = new byte[2];
            while (1 == 1)
            {
                lowC = (Byte)_objfs.ReadByte();
                if (lowC == 0)
                    break;
                if (lowC > 127)
                {
                    upC = (byte)_objfs.ReadByte();
                    buff[0] = lowC;
                    buff[1] = upC;
                    System.Text.Encoding enc = System.Text.Encoding.GetEncoding("GB2312");
                    str += enc.GetString(buff);
                }
                else
                {
                    str += (char)lowC;
                }
            }
            return str;
        }


        // 获取IP地址
        public string IPLocation()
        {
            this.QQwry();
            return this._country + this._local;
        }


        public string IPLocation(string dataPath, string ip)
        {
            this._dataPath = dataPath;
            this._ip = ip;
            this.QQwry();
            return this._country + this._local;
        }
    }
}