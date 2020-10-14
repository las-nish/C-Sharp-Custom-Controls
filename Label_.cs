using System.Drawing;
using System.Windows.Forms;

namespace Project.CustomControls
{
    class Label_ : Label
    {
        public Label_()
        {
            this.BackColor = Color.Transparent;
            this.Font = _FONT.FN_Regular(8); // Set Font Size
        }

        #region Themes
        public void Light()
        {
            this.ForeColor = Color.FromArgb(0, 0, 0);
        }

        public void Dark()
        {
            this.ForeColor = Color.FromArgb(255, 255, 255);
        }

        public void DarkBlue()
        {
            this.ForeColor = Color.FromArgb(255, 255, 255);
        }
        #endregion
    }
}
