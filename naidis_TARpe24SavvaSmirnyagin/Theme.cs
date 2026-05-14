using System;
using System.Collections.Generic;
using System.Text;

namespace naidis_TARpe24SavvaSmirnyagin
{
    public class Theme
    {
        public Color BackgroundColor { get; set; }
        public Color TextColor { get; set; }
        public string FontName { get; set; }

        public Theme(Color bg, Color text, string font)
        {
            BackgroundColor = bg;
            TextColor = text;
            FontName = font;
        }

        public void Apply(ContentPage page)
        {
            page.BackgroundColor = BackgroundColor;
        }
    }
}