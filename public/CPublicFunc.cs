using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TobaccoApp
{
    class CPublicFunc
    {
       
        public bool IsDigitAndComa(string strSource)
        {//判断格式是否是：123,456
            if (strSource.Length == 0)
            {
                return false;
            }

            char[] chGet = strSource.ToCharArray();

            if ((chGet[0] == ',') || (chGet[chGet.Length - 1] == ','))
            {//头和尾如果是逗号，错误返回
                return false;
            }

            foreach (char chTemp in chGet)
            {
                if ((chTemp >= 0x30) && (chTemp <= 0x39))
                {
                }
                else if (chTemp == ',')
                {
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsHexChar(string strSource)
        {//判断格式是否是：1234567890ABCDEF
            if (strSource.Length == 0)
            {
                return false;
            }

            char[] chGet = strSource.ToCharArray();

            foreach (char chTemp in chGet)
            {
                if ((chTemp >= 0x30) && (chTemp <= 0x39))
                {
                }
                else if ((chTemp >= 65) && (chTemp <= 70))
                {
                }
                else if ((chTemp >= 97) && (chTemp <= 102))
                {
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
        /* ************************************************************************** */

        /* ************************************************************************** */
        public bool IsHexAndSpaceChar(string strSource)
        {//判断格式是否是：12 345 67 89 0A BC DE F1
            if (strSource.Length == 0)
            {
                return false;
            }

            char[] chGet = strSource.ToCharArray();

            foreach (char chTemp in chGet)
            {
                if ((chTemp >= 0x30) && (chTemp <= 0x39))
                {
                }
                else if ((chTemp >= 65) && (chTemp <= 70))
                {
                }
                else if ((chTemp >= 97) && (chTemp <= 102))
                {
                }
                else if (chTemp == 0x20)
                {
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public static string GetHexCharGUID(string strSource)
        {//数据库读取的GUID，保留Hex字符
            string strTarget = "";

            if (strSource.Length == 0)
            {
                return strSource;
            }

            char[] chGet = strSource.ToCharArray();

            foreach (char chTemp in chGet)
            {
                if ((chTemp >= 0x30) && (chTemp <= 0x39))
                {
                    strTarget += chTemp.ToString();
                }
                else if ((chTemp >= 65) && (chTemp <= 70))
                {
                    strTarget += chTemp.ToString();
                }
                else
                {
                }
            }

            return strTarget;
        }
        /* ************************************************************************** */

        /* ************************************************************************** */
        public static Int32 Convert_ByteToInt32(byte byteHigh, byte byteLow)
        {
            Int32 nTemp = 0;

            nTemp = byteHigh;
            nTemp <<= 8;
            nTemp |= byteLow;

            return nTemp;
        }
        public static byte[] intToBytes(int value)
        {
            byte[] src = new byte[4];
            src[3] = (byte)((value >> 24) & 0xFF);
            src[2] = (byte)((value >> 16) & 0xFF);
            src[1] = (byte)((value >> 8) & 0xFF);//高8位
            src[0] = (byte)(value & 0xFF);//低位
            return src;
        }
        public static byte[] shortToBytes(short value)
        {
            byte[] src = new byte[2];
            src[1] = (byte)((value >> 8) & 0xFF);//高8位
            src[0] = (byte)(value & 0xFF);//低位
            return src;
        }
        public static byte[] intArrToBytesArr(int[] value)
        {
            byte[] src = new byte[value.Length * 4];
            for (int i = 0; i < value.Length; i++)
            {
                src[i * 4 + 3] = (byte)((value[i] >> 24) & 0xFF);
                src[i * 4 + 2] = (byte)((value[i] >> 16) & 0xFF);
                src[i * 4 + 1] = (byte)((value[i] >> 8) & 0xFF);//高8位
                src[i * 4 + 0] = (byte)(value[i] & 0xFF);//低位
            }

            return src;
        }
        public static byte[] shortArrToBytesArr(short[] value)
        {
            byte[] src = new byte[value.Length * 2];
            for (int i = 0; i < value.Length; i++)
            {
                src[i * 2 + 1] = (byte)((value[i] >> 8) & 0xFF);//高8位
                src[i * 2 + 0] = (byte)(value[i] & 0xFF);//低位
            }
            return src;
        }

        //PC系统时间转6字节byte[]数组
        public static byte[] TimeToBytes()
        {
            byte[] byteTime = new byte[6];
            string strTime = DateTime.Now.ToString("yyMMddHHmmss");
            for (int i = 0; i < 6; i++)
            {
                byteTime[i] = Convert.ToByte(strTime.Substring(i * 2, 2), 10);
            }
            return byteTime;
        }

        //字符串转字节数组
        private static byte[] strToToHexByte(string strHex)
        {
            strHex = strHex.Replace(" ", null);
            if ((strHex.Length % 2) != 0)
                strHex = strHex.Insert(strHex.Length - 1, 0.ToString());
            byte[] returnBytes = new byte[strHex.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(strHex.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        //字节数转整数
        /// <summary>
        /// 按照先后顺序合并字节数组
        /// </summary>
        /// <param name="firstBytes"></param>
        /// <param name="firstIndex"></param>
        /// <param name="firstLength"></param>
        /// <param name="secondBytes"></param>
        /// <param name="secondIndex"></param>
        /// <param name="secondLength"></param>
        /// <returns></returns>
        public static byte[] CombineBytes(byte[] firstBytes, int firstIndex, int firstLength, byte[] secondBytes, int secondIndex, int secondLength)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryWriter bw = new BinaryWriter(ms);
                bw.Write(firstBytes, firstIndex, firstLength);
                bw.Write(secondBytes, secondIndex, secondLength);
                bw.Close();
                bw.Dispose();
                return ms.ToArray();
            }
        }
        /// <summary>
		/// 向左移位
		/// </summary>
		/// <param name="nNum">左移位数</param>
		/// <param name="MsgBufferLength"></param>
		/// <param name="byteMsgBuf"></param>
		/// <returns></returns>
		public static byte[] LeftShiftBuffer(int nNum, byte[] byteMsgBuf)
        {
            if (nNum > byteMsgBuf.Length)
            {
                byteMsgBuf = null;
            }
            else
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryWriter bw = new BinaryWriter(ms);
                    bw.Write(byteMsgBuf, nNum, byteMsgBuf.Length - nNum);
                    bw.Close();
                    bw.Dispose();
                    return ms.ToArray();
                }
            }
            return byteMsgBuf;
        }
    }
}
