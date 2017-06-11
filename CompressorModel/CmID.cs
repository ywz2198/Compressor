using System;
using System.Collections.Generic;
using System.Text;

namespace CompressorModel
{
    /// <summary>
    /// 空压机试验性能数据表
    /// </summary>
    public class CmID
    {
     
        #region Model
        private string _cmid;
        private string _type;
        private string _time;
        private string _image;
        private string _operation;
        private string _code;
        /// <summary>
        /// 生产出的具体空压机的代号
        /// </summary>
        public string Cmid
        {
            get
            {
                return _cmid;
            }

            set
            {
                _cmid = value;
            }
        }
        /// <summary>
        /// 空压机型号
        /// </summary>
        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }
        /// <summary>
        /// 制作日期
        /// </summary>
        public string Time
        {
            get
            {
                return _time;
            }

            set
            {
                _time = value;
            }
        }
        /// <summary>
        /// 试验性能报告PDF文档
        /// </summary>
        public string Image
        {
            get
            {
                return _image;
            }

            set
            {
                _image = value;
            }
        }
        /// <summary>
        /// 当天所有操作员名字
        /// </summary>
        public string Operation
        {
            get
            {
                return _operation;
            }

            set
            {
                _operation = value;
            }
        }
        /// <summary>
        /// 生产批号
        /// </summary>
        public string Code
        {
            get
            {
                return _code;
            }

            set
            {
                _code = value;
            }
        }
        #endregion
    }
}
