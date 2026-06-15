using System;
using System.Text.RegularExpressions;
namespace NetWise.DBUtility
{
    /// <summary>
    /// 字符串操作方法
    /// </summary>
    public class StringMethodControl
    {
        #region SQL 特殊字符过滤,防SQL注入
        /// <summary>
        /// SQL 特殊字符过滤,防SQL注入
        /// </summary>
        /// <param name="Contents">检查的SQL语句</param>
        /// <returns></returns>
        public static string SqlFilter(string Contents)
        {
            if (Contents != null && Contents.Trim() != string.Empty)
            {
                Contents = Regex.Replace(Contents, "exec|insert|select|delete|update|master|truncate|declare|'", "", RegexOptions.IgnoreCase);
            }
            return Contents;
        }
        #endregion

        #region 是否为数字
        /// <summary>
        /// 是否为数字
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool isNumber(object obj)
        {
            bool result = false;
            if (obj.ToString().Trim() != string.Empty)
            {
                //为指定的正则表达式初始化并编译 Regex 类的实例
                System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"^-?(\d*)$");
                //在指定的输入字符串中搜索 Regex 构造函数中指定的正则表达式匹配项
                System.Text.RegularExpressions.Match mc = rg.Match(obj.ToString());
                //指示匹配是否成功
                result = mc.Success;
            }
            return result;
        }

        /// <summary>
        /// 是否为小数
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool isDecimal(string obj)
        {
            //为指定的正则表达式初始化并编译 Regex 类的实例
            System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"^\d*(?:$|\.\d*$)");
            //在指定的输入字符串中搜索 Regex 构造函数中指定的正则表达式匹配项
            System.Text.RegularExpressions.Match mc = rg.Match(obj.ToString());
            //指示匹配是否成功
            return (mc.Success);
        }
        #endregion

        #region 替换标记内的内容
        /// <summary>
        /// 替换标记内的内容
        /// </summary>
        /// <param name="firstSign">开始标记</param>
        /// <param name="endSign">结束标记</param>
        /// <param name="Contents">原始内容</param>
        /// <param name="newContents">替换内容</param>
        /// <returns></returns>
        public static string ReplaceContent(string firstSign, string endSign, string Contents, string newContents)
        {
            Contents = Regex.Replace(Contents, firstSign + "((.|\n)*?)" + endSign, firstSign + "\r\n" + newContents + "\r\n" + endSign, RegexOptions.IgnoreCase);
            return Contents;
        }
        #endregion

        #region 清除脚本等内容
        /// <summary>
        /// 清除所有HTML标记
        /// </summary>
        /// <param name="Contents"></param>
        /// <returns></returns>
        public static string ClearHtml(string Contents)
        {
            Contents = Regex.Replace(Contents, "<(object|script)(.*?)>((.|\n)*?)</(object|script|)>", " ", RegexOptions.IgnoreCase);
            Contents = Regex.Replace(Contents, "<!--#(.*?)((.|\n)*?)-->", " ", RegexOptions.IgnoreCase);
            Contents = Regex.Replace(Contents, "<%(.*?)((.|\n)*?)%>", " ", RegexOptions.IgnoreCase);
            //					Contents = regexp.Replace(Contents, "&(nbsp|quot|copy);", "");
            //					Contents = regexp.Replace(Contents, "<([\s\S])+?>", " ", RegexOptions.IgnoreCase);
            //					Contents = regexp.Replace(Contents, "\W", " ");
            return Contents;
        }

        /// <summary>
        /// 清除所有HTML标记
        /// </summary>
        /// <param name="Contents"></param>
        /// <returns></returns>
        public static string ClearAllHtml(string Contents)
        {
            Contents = Regex.Replace(Contents, @"<([\s\S])+?>", "", RegexOptions.IgnoreCase);
            Contents = Regex.Replace(Contents, "&(nbsp|quot|copy);", "", RegexOptions.IgnoreCase);
            Contents = Regex.Replace(Contents, " ", "", RegexOptions.IgnoreCase);
            return Contents;
        }
        #endregion

        #region 代码过滤
        /// <summary>
        /// 代码解释功能，目的是为了防止一些人恶意的提交一些代码，影响系统的安全使用，通过字符转换的方法，防止这种现象的发生
        /// </summary>
        /// <param name="html">要转换的数据字符串</param>
        /// <param name="filter">要过滤掉的单个格式</param>
        /// <returns>替换后的字符</returns>
        /// <remarks>
        /// DecodeFilter 方法是为了防止提交恶意代码而使用的，可以过滤 Script,Table,Class,Style,XML,NAMESPACE,MARQUEE,FONT,Object等标签的内容
        /// </remarks>
        /// <example>
        /// 以下示例演示了如何使用 DecodeFilter 过滤包含Script脚本的内容：<br />
        /// <code>		///		
        ///		str = DecodeFilter(str,"SCRIPT");
        /// </code>
        /// </example>
        public static string DecodeFilter(string html, string filter)
        {
            string str = html;
            System.Text.RegularExpressions.Regex r;
            System.Text.RegularExpressions.Match m;
            switch (filter.ToUpper())
            {
                case "SCRIPT":
                    //不允许使用javascript,vbscript等，事件onclick,ondlbclick等
                    str = Regex.Replace(str, "</?script[^>]*>", "");
                    r = new Regex(@"</?script[^>]*>", RegexOptions.IgnoreCase);
                    for (m = r.Match(str); m.Success; m = m.NextMatch())
                    {
                        str = str.Replace(m.Groups[0].ToString(), "");
                    }
                    r = new Regex(@"(javascript|jscript|vbscript|vbs):", RegexOptions.IgnoreCase);
                    for (m = r.Match(str); m.Success; m = m.NextMatch())
                    {
                        str = str.Replace(m.Groups[0].ToString(), m.Groups[1].ToString() + "：");
                    }
                    r = new Regex(@"on(mouse|exit|error|click|key)", RegexOptions.IgnoreCase);
                    for (m = r.Match(str); m.Success; m = m.NextMatch())
                    {
                        str = str.Replace(m.Groups[0].ToString(), "");
                    }
                    r = new Regex(@"&#", RegexOptions.IgnoreCase);
                    for (m = r.Match(str); m.Success; m = m.NextMatch())
                    {
                        str = str.Replace(m.Groups[0].ToString(), "");
                    }
                    break;
                case "TABLE":
                    //不允许使用table,th,td,tr标签
                    str = Regex.Replace(str, "</?table[^>]*>", "");
                    str = Regex.Replace(str, "</?tr[^>]*>", "");
                    str = Regex.Replace(str, "</?th[^>]*>", "");
                    str = Regex.Replace(str, "</?td[^>]*>", "");
                    str = Regex.Replace(str, "</?tbody[^>]*>", "");
                    break;
                case "CLASS":
                    //不允许使用 class= 这样的标签
                    r = new Regex(@"(<[^>]+) class=[^ |^>]*([^>]*>)", RegexOptions.IgnoreCase);
                    for (m = r.Match(str); m.Success; m = m.NextMatch())
                    {
                        str = str.Replace(m.Groups[0].ToString(), m.Groups[0].ToString() + " " + m.Groups[1].ToString());
                    }
                    break;
                case "STYLE":
                    //不允许使用 style= 这样的标签
                    r = new Regex("(<[^>]+) style=\"[^\"]*\"([^>]*>)", RegexOptions.IgnoreCase);
                    for (m = r.Match(str); m.Success; m = m.NextMatch())
                    {
                        str = str.Replace(m.Groups[0].ToString(), m.Groups[0].ToString() + " " + m.Groups[1].ToString());
                    }
                    break;
                case "XML":
                    //不允许使用 xml 标签
                    str = Regex.Replace(str, "<\\?xml[^>]*>", "");
                    break;
                case "NAMESPACE":
                    //不允许使用 <o:p></o:p> 这种格式
                    str = Regex.Replace(str, @"<\/?[a-z]+:[^>]*>", "");
                    break;
                case "FONT":
                    //不允许使用 font 标签，不建议使用
                    str = Regex.Replace(str, "</?font[^>]*>", "");
                    break;
                case "MARQUEE":
                    //不允许使用 marquee 标签，也就没有移动滚动的特殊
                    str = Regex.Replace(str, "</?marquee[^>]*>", "");
                    break;
                case "OBJECT":
                    //不允许 object, param, embed 标签，不能嵌入对象
                    str = Regex.Replace(str, "</?object[^>]*>", "");
                    str = Regex.Replace(str, "</?param[^>]*>", "");
                    str = Regex.Replace(str, "</?embed[^>]*>", "");
                    break;
            }
            return str;
        }
        #endregion

        #region 字符加密
        /// <summary>
        /// SHA1
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Entrypt(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "sha1");

        }
        /// <summary>
        /// MD5
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Entrypt_MD5(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5");
        }
        #endregion

        #region 返回日期格式
        /// <summary>
        /// 返回日期格式：1=年份；2=年-月；3=年-月-日；
        /// </summary>
        /// <param name="sign">标记</param>
        /// <returns></returns>
        public static string CreateDateTimeDirectory(System.String sign)
        {
            string result = System.String.Empty;
            if (sign.Equals("1"))
            {
                result = DateTime.Now.Year.ToString();
            }
            else if (sign.Equals("2"))
            {
                result = System.String.Concat(DateTime.Now.Year.ToString(), "-", DateTime.Now.Month.ToString("00"));
            }
            else if (sign.Equals("3"))
            {
                result = System.String.Concat(DateTime.Now.Year.ToString(), "-", DateTime.Now.Month.ToString("00"), "-", DateTime.Now.Day.ToString("00"));
            }
            return result;
        }
        #endregion

        #region 截取字符
        /// <summary>
        ///  截取字符
        /// </summary>
        /// <param name="content">需要截取的字符</param>
        /// <param name="length">截取长度</param>
        /// <returns></returns>
        public static string TopString(string content, int length)
        {
            string result;
            if (content.Length > length)
            {
                result = content.Substring(0, length - 1) + "…";
            }
            else result = content;
            return result;
        }
        #endregion

        #region 生成一个随机不重复的字符串
        /// <summary>
        /// 生成一个随机不重复的字符串，用于文件命名
        /// </summary>
        /// <returns>返回</returns>
        public static string RadomFileName()
        {
            return Entrypt(DateTime.Now.ToUniversalTime().ToString().Replace("-", "").Replace(":", "").Replace(" ", "") + GetRandomNext(5).ToString());
        }
        #endregion

        #region 随机数
        /// <summary>
        /// 生成小于10位长度的随机数
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static int GetRandomNext(int Length)
        {
            if (Length > 9)
                throw new System.IndexOutOfRangeException("Length的长度不能大于10");
            Guid gu = Guid.NewGuid();
            string str = "";
            for (int i = 0; i < gu.ToString().Length; i++)
            {
                if (isNumber(gu.ToString()[i]))
                {
                    str += ((gu.ToString()[i]));
                }
            }
            int guid = int.Parse(str.Replace("-", "").Substring(0, Length));
            if (!guid.ToString().Length.Equals(Length))
                guid = GetRandomNext(Length);
            return guid;
        }
        #endregion

        #region 字符URL编码
        public static string UrlEnCode(string str)
        {
            return System.Web.HttpUtility.UrlEncode(str);
        }
        #endregion

    }

}