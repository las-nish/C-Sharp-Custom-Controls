using System.Drawing;
using System.Windows.Forms;

namespace Project.CustomControls
{
    class Text_Box : TextBox
    {
        #region Define Colors
        public Color BodyColor { get; set; }
        public Color TextColor { get; set; }
        #endregion

        public Text_Box()
        {
            this.Font = _FONT.FN_Regular(8);
            this.BorderStyle = BorderStyle.FixedSingle;

            this.BackColor = BodyColor;
            this.ForeColor = TextColor;
        }

        #region Themes
        public void Light()
        {
            BodyColor = Color.FromArgb(255, 255, 255);
            TextColor = Color.FromArgb(10, 10, 10);
        }

        public void Dark()
        {
            BodyColor = Color.FromArgb(51, 51, 55);
            TextColor = Color.FromArgb(255, 255, 255);
        }

        public void DarkBlue()
        {
            BodyColor = Color.FromArgb(32, 35, 38);
            TextColor = Color.FromArgb(255, 255, 255);
        }
        #endregion

    }
}
