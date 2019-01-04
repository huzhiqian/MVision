using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace Halcon.MVision.Controls
{
    [DesignTimeVisible(true)]
    [ToolboxBitmap(typeof(HalNumericUpDown), "Bitmaps.HalNumericUpDown.png")]
    [ToolboxItem(true)]     //在vs控件箱中显示控件
   public class HalNumericUpDown : NumericUpDown
    {


        public HalNumericUpDown() : base()
        {

        }
    }
}
