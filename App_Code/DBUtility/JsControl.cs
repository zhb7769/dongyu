using NetWise.DataAccess;
using System.Data;
using System.Text;
using System.Web.UI;

namespace NetWise.DBUtility
{
    /// <summary>
    ///JsControl 的摘要说明
    /// </summary>
    public class JsControl
    {
        public JsControl()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 显示消息提示对话框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void Show(System.Web.UI.Page page, string msg)
        {
            ClientScriptManager cs = page.ClientScript;
            cs.RegisterStartupScript(page.GetType(), "message", "<script type=\"text/javascript\">alert('" + msg.ToString() + "');</script>");
        }

        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        public static void Show(System.Web.UI.Page page, string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script type=\"text/javascript\">\r\n");
            Builder.AppendFormat("alert('{0}');", msg);
            Builder.AppendFormat("top.location.href='{0}'", url);
            Builder.Append("</script>");

            ClientScriptManager cs = page.ClientScript;
            cs.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

        }

        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        /// <param name="target">跳转目标窗口</param>
        public static void Show(System.Web.UI.Page page, string msg, string url, string target)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script type=\"text/javascript\">\r\n");
            Builder.AppendFormat("alert('{0}');\r\n", msg);
            Builder.AppendFormat(target + ".location.href='{0}';\r\n", url);
            Builder.Append("</script>\r\n");
            page.Response.Clear();
            page.Response.Write(Builder.ToString());
            page.Response.End();
        }
        public static void ShowReload(System.Web.UI.Page page, string msg, string script)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script type=\"text/javascript\">\r\n");
            Builder.AppendFormat("alert('{0}');\r\n", msg);
            Builder.Append(script);
            Builder.Append("</script>\r\n");
            page.Response.Clear();
            page.Response.Write(Builder.ToString());
            page.Response.End();
        }

        /// <summary>
        /// 输出自定义脚本信息
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="script">输出脚本</param>
        public static void ResponseScript(System.Web.UI.Page page, string script)
        {
            ClientScriptManager cs = page.ClientScript;
            cs.RegisterStartupScript(page.GetType(), "message", "\r\n<script type=\"text/javascript\">\r\n" + script + "\r\n</script>\r\n");
        }


        /// <summary>
        /// 绑定左侧菜单
        /// </summary>
        /// <returns></returns>
        public static string BindLeftMenu(bool isEn)
        {
            var productClass = new ProductClass();
            var categoryStr = new StringBuilder();
            DataTable topCategory = productClass.GetList("ParentId=0").Tables[0];
            if (topCategory.Rows.Count > 0)
            {
                categoryStr.Append("<ul>");
                foreach (DataRow dr in topCategory.Rows)
                {
                    categoryStr.AppendFormat("<li class=\"cl01\"><a href=\"product.aspx?id={0}\">{1}</a></li>",
                        dr["ID"], isEn ? dr["EN_Name"] : dr["CN_Name"]);
                    DataTable subCategory = productClass.GetList("ParentId=" + dr["ID"]).Tables[0];
                    if (subCategory.Rows.Count > 0)
                    {
                        foreach (DataRow item in subCategory.Rows)
                        {
                            categoryStr.AppendFormat("<li class=\"cl02\"><a href=\"product.aspx?id={0}\">{1}</a></li>",
                                item["ID"], isEn ? item["EN_Name"] : item["CN_Name"]);
                        }
                    }
                }
                categoryStr.Append("</ul>");
            }
            return categoryStr.ToString();
        }
    }
}