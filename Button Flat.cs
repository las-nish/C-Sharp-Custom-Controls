using System.Drawing;
using System.Windows.Forms;

namespace Project.CustomControls
{
    class Button_Flat : Button
    {
        public Button_Flat()
        {
            this.FlatStyle = FlatStyle.Flat;

            this.FlatAppearance.BorderColor = Color.FromArgb(0, 122, 204);
            this.FlatAppearance.BorderSize = 1; // 1 Pixel Size Border

            this.BackColor = Color.FromArgb(0, 122, 204);
            this.ForeColor = Color.FromArgb(255, 255, 255);
        }
    }
}
