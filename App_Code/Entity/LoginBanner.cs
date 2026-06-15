using System;
namespace NetWise.Entity
{
    /// <summary>
    /// LoginBanner:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class LoginBanner
    {
        public LoginBanner()
        { }
        #region Model
        private int _b_id;
        private string _b_title;
        private string _b_pic;
        private string _b_add;
        private string _b_style;
        private int _b_sort;
        /// <summary>
        /// 
        /// </summary>
        public int B_ID
        {
            set { _b_id = value; }
            get { return _b_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Title
        {
            set { _b_title = value; }
            get { return _b_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Pic
        {
            set { _b_pic = value; }
            get { return _b_pic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Add
        {
            set { _b_add = value; }
            get { return _b_add; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B_Style
        {
            set { _b_style = value; }
            get { return _b_style; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int B_Sort
        {
            set { _b_sort = value; }
            get { return _b_sort; }
        }
        #endregion Model

    }
}


