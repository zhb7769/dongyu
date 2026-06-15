using System;
namespace NetWise.Entity
{
    /// <summary>
    /// Contact:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Contact
    {
        public Contact()
        { }
        #region Model
        private int _id;
        private string _cn_company;
        private string _en_company;
        private string _cn_address;
        private string _en_address;
        private string _cn_companytel;
        private string _en_companytel;
        private string _cn_phone;
        private string _en_phone;
        private string _fax;
        private string _postcode;
        private string _email;
        private string _website;
        private string _qq;
        private string _skype;
        private string _cn_content;
        private string _en_content;
        private string _cn_person;
        private string _en_person;
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
        public string CN_Company
        {
            set { _cn_company = value; }
            get { return _cn_company; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EN_Company
        {
            set { _en_company = value; }
            get { return _en_company; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CN_Address
        {
            set { _cn_address = value; }
            get { return _cn_address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EN_Address
        {
            set { _en_address = value; }
            get { return _en_address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CN_CompanyTel
        {
            set { _cn_companytel = value; }
            get { return _cn_companytel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EN_CompanyTel
        {
            set { _en_companytel = value; }
            get { return _en_companytel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CN_Phone
        {
            set { _cn_phone = value; }
            get { return _cn_phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EN_Phone
        {
            set { _en_phone = value; }
            get { return _en_phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PostCode
        {
            set { _postcode = value; }
            get { return _postcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Website
        {
            set { _website = value; }
            get { return _website; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SKYPE
        {
            set { _skype = value; }
            get { return _skype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CN_Content
        {
            set { _cn_content = value; }
            get { return _cn_content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EN_Content
        {
            set { _en_content = value; }
            get { return _en_content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CN_Person
        {
            set { _cn_person = value; }
            get { return _cn_person; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EN_Person
        {
            set { _en_person = value; }
            get { return _en_person; }
        }
        #endregion Model

    }
}


