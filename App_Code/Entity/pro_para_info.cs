using System;
namespace NetWise.Entity
{
    /// <summary>
    /// pro_para_info:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class pro_para_info
    {
        public pro_para_info()
        { }
        #region Model
        private int _para_id;
        private int _pro_id;
        private string _para_left;
        private string _para_EN_left;
        private string _para_right;
        private string _para_EN_right;
        private DateTime? _create_time;
        /// <summary>
        /// 
        /// </summary>
        public int para_id
        {
            set { _para_id = value; }
            get { return _para_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int pro_id
        {
            set { _pro_id = value; }
            get { return _pro_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string para_left
        {
            set { _para_left = value; }
            get { return _para_left; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string para_right
        {
            set { _para_right = value; }
            get { return _para_right; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string para_EN_left
        {
            set { _para_EN_left = value; }
            get { return _para_EN_left; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string para_EN_right
        {
            set { _para_EN_right = value; }
            get { return _para_EN_right; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? create_time
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        #endregion Model

    }
}


