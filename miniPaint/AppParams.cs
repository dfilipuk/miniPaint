using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace miniPaint
{
    class CAppParams
    {
        public static int ParamsAmo = 16;
        public bool IsMaximized { get; set; }
        public Size WindowSize { get; set; }
        public Point WindowLocation { get; set; }
        public Color PictureBackgroundColor { get; set; }
        public Color[] Colors { get; set; }

        const int COLORS_AMO = 10;

        public CAppParams()
        {
            Colors = new Color[COLORS_AMO];
        }
    }
}
