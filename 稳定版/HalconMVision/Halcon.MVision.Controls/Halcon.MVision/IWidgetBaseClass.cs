//Halcon.MVision.IWidgetBaseClass
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halcon.MVision
{
    /// <summary>
    /// 控件装饰借口
    /// </summary>
   public interface IWidgetBaseClass
    {
        object Subject
        {
            get;
            set;
        }

        string Path
        {
            get;
            set;
        }

        string ToolTipText
        {
            get;
            set;
        }

        bool ShowToolTips
        {
            get;
            set;
        }

        /// <summary>
        /// 启用或禁用电动指示
        /// </summary>
        bool Electric
        {
            get;
            set;
        }
    }
}
