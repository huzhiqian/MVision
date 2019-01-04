using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Halcon.MVision.Controls
{
    [DesignTimeVisible(true)]
    [ToolboxBitmap(typeof(HalComboBox), "Bitmaps.HalComboBox.png")]
    [ToolboxItem(true)] //在vs控件箱中可见
    public class HalComboBox:ComboBox
    {

        public HalComboBox() : base()
        { }

    }
}
