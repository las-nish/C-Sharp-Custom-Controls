using System.Drawing;
using System.Windows.Forms;

namespace Project.CustomControls
{
    class List_View : ListView
    {
        #region Define Colors
        public Color BodyColor { get; set; }
        public Color TextColor { get; set; }
        #endregion

        public List_View()
        {
            this.ForeColor = TextColor;
            this.BackColor = BodyColor;
            this.Scrollable = false;
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
            BodyColor = Color.FromArgb(15, 17, 18);
            TextColor = Color.FromArgb(255, 255, 255);
        }
        #endregion
    }
}
