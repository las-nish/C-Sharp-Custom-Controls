using System.Drawing;
using System.Windows.Forms;

namespace Project.CustomControls
{
    class Menu_Strip : MenuStrip
    {
        public Menu_Strip()
        {
            // Set Renderer
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var r = new Rectangle(3, 2, this.Width, this.Height);
            e.Graphics.FillRectangle(Brushes.Transparent, r);
        }
    }
}
