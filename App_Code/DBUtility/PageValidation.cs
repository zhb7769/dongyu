using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace HengTuo
{
    public static class PageValidation
    {
        /// <summary>
        /// 页面sql防注入
        /// </summary>
        /// <param name="pg"></param>
        public static void Sqlzy(Page pg)
        {
            #region GET方式
            string URL = pg.Request.Url.ToString();//地址
            if (CheckData(URL))
            {
                pg.Response.Redirect("Err.html");
                return;
            }
            #endregion

            #region POST方式
            if (pg.Request.RequestType == "POST")//检查控件
            {
                NameValueCollection postData;
                try
                {
                    postData = pg.Request.Form;
                }
                catch
                {
                    pg.Response.Redirect("Err.html");
                    return;
                }
                string InputStr = "";
                foreach (string postKey in postData)
                {
                    try
                    {
                        Control ctl = pg.FindControl(postKey);
                        if (ctl as HiddenField != null && ctl.ID.IndexOf("hidd_zNodes") < 0)
                        {
                            InputStr = ((HiddenField)ctl).Value;
                        }
                        if (ctl as HtmlInputHidden != null)
                        {
                            InputStr = ((HtmlInputHidden)ctl).Value;
                        }
                        if (ctl as TextBox != null && ctl.ID.IndexOf("CKEditor") < 0)
                        {
                            InputStr = ((TextBox)ctl).Text;
                        }
                        if (ctl as HtmlInputControl != null)
                        {
                            InputStr = ((HtmlInputControl)ctl).Value;
                        }
                        if (ctl as HtmlTextArea != null)
                        {
                            InputStr = ((HtmlTextArea)ctl).Value;
                        }
                    }
                    catch { }

                    if (CheckData(InputStr))
                    {
                        pg.Response.Redirect("Err.html");
                        return;
                    }
                }
            }
            #endregion

            //#region Cookie
            //for (int i = 0; i < pg.Request.Cookies.Count; i++)
            //{
            //    if (CheckData(pg.Request.Cookies[i].Value))
            //    {
            //        pg.Response.Redirect("Err.html");
            //        return;
            //    }
            //}
            //#endregion

        }

        #region 校验
        private const string StrRegex = @"<[^>]+?style=[\w]+?:expression\(|\b(alert|confirm|prompt)\b|^\+/v(8|9)|<[^>]*?=[^>]*?&#[^>]*?>|\b(and|or)\b.{1,6}?(=|>|<|\bin\b|\blike\b)|/\*.+?\*/|<\s*script\b|<\s*img\b|\bEXEC\b|UNION.+?SELECT|UPDATE.+?SET|INSERT\s+INTO.+?VALUES|(SELECT|DELETE).+?FROM|(CREATE|ALTER|DROP|TRUNCATE)\s+(TABLE|DATABASE)";
        /// <summary>
        /// 校验数据
        /// </summary>
        /// <param name="inputData">需要校验的数据</param>
        /// <returns></returns>
        public static bool CheckData(string inputData)
        {
            if (Regex.IsMatch(inputData, StrRegex))
            {
                return true;
            }
            else
            {
                return CheckSql(inputData);
            }
        }
        private const string StrSql = "event夢load夢 on夢and夢 or夢+夢..夢%夢xor夢exec夢select夢drop夢alter夢create夢count夢exists夢union夢order夢mid夢asc夢*夢substring夢master夢execute夢xp_cmdshel夢insert夢update夢delete夢join夢declare夢chr夢char夢sp_oacreate夢wscript.shell夢xp_regwrite夢'夢;夢--夢%夢truncate夢declar夢restore夢backup夢net +user夢net +localgroup +administrators";
        /// <summary>
        /// 校验数据sql
        /// </summary>
        /// <param name="inputData">需要校验的数据</param>
        /// <returns></returns>
        public static bool CheckSql(string inputData)
        {
            string[] jk_sql = StrSql.Split('夢');
            bool b = false;
            foreach (string jk in jk_sql)
            {
                if (inputData.ToLower().Contains(jk))
                {
                    b = true;
                    break;
                }
            }
            return b;
        }
        #endregion
    }
}
