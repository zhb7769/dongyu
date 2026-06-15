using System;
namespace NetWise.Entity
{
    /// <summary>
    /// Admin:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Admin
    {
        public Admin()
        { }
        #region Model
        private int _id;
        private string _adminname;
        private string _adminpwd;
        private int _isdelete;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AdminName
        {
            set { _adminname = value; }
            get { return _adminname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AdminPWD
        {
            set { _adminpwd = value; }
            get { return _adminpwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsDelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        #endregion Model

    }
}

