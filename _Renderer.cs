using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Project.CustomControls
{
    class _Renderer
    {
    }

    #region Bitmap Extension
    internal static class BitmapExtensions
    {
        internal static Bitmap SetColor(this Bitmap bitmap, Color color)
        {
            var newBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    var pixel = bitmap.GetPixel(i, j);
                    if (pixel.A > 0)
                        newBitmap.SetPixel(i, j, color);
                }
            }
            return newBitmap;
        }

        internal static Bitmap ChangeColor(this Bitmap bitmap, Color oldColor, Color newColor)
        {
            var newBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    var pixel = bitmap.GetPixel(i, j);
                    if (pixel == oldColor)
                        newBitmap.SetPixel(i, j, newColor);
                }
            }
            return newBitmap;
        }
    }
    #endregion

    // Dark Menu Bar and Tool Bar
    #region DarkMenuRenderer
    public class DarkMenuRenderer : ToolStripRenderer
    {

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderMenuItemBackground(e);

            if (e.Item.Enabled)
            {
                if (e.Item.IsOnDropDown == false && e.Item.Selected)
                {
                    var rect = new Rectangle(2, 1, e.Item.Width - 5, e.Item.Height - 3);
                    var rect2 = new Rectangle(2, 1, e.Item.Width - 5, e.Item.Height - 3);
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(15, 15, 15)), rect);
                    e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Transparent)), rect2);
                    e.Item.ForeColor = Color.White;
                }
                else
                {
                    e.Item.ForeColor = Color.FromArgb(220, 220, 220);
                }

                if (e.Item.IsOnDropDown && e.Item.Selected)
                {
                    var rect = new Rectangle(2, 0, e.Item.Width - 5, e.Item.Height - 1);
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(15, 15, 15)), rect);
                    e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Transparent)), rect);
                    e.Item.ForeColor = Color.FromArgb(220, 220, 220);
                }
                if ((e.Item as ToolStripMenuItem).DropDown.Visible && e.Item.IsOnDropDown == false)
                {
                    var rect = new Rectangle(2, 1, e.Item.Width - 5, e.Item.Height - 3);
                    var rect2 = new Rectangle(2, 1, e.Item.Width - 5, e.Item.Height - 3);
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(28,28,28) /* 28,28,28 */ ), rect);
                    e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Transparent)), rect2);
                    e.Item.ForeColor = Color.FromArgb(220, 220, 220);
                }
            }
        }
        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            base.OnRenderSeparator(e);
            var DarkLine = new SolidBrush(Color.FromArgb(51, 51, 55));
            var rect = new Rectangle(30, 3, e.Item.Width - 32, 1);
            e.Graphics.FillRectangle(DarkLine, rect);
        }


        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            base.OnRenderItemCheck(e);

            if (e.Item.Selected)
            {
                var rect = new Rectangle(4, 2, 18, 18);
                var rect2 = new Rectangle(5, 3, 16, 16);
                SolidBrush b = new SolidBrush(Color.FromArgb(40, 40, 40));
                SolidBrush b2 = new SolidBrush(Color.Transparent);

                e.Graphics.FillRectangle(b, rect);
                e.Graphics.FillRectangle(b2, rect2);
                e.Graphics.DrawImage(e.Image, new Point(5, 3));
            }
            else
            {
                var rect = new Rectangle(4, 2, 18, 18);
                var rect2 = new Rectangle(5, 3, 16, 16);
                SolidBrush b = new SolidBrush(Color.FromArgb(40, 40, 40));
                SolidBrush b2 = new SolidBrush(Color.Transparent);

                e.Graphics.FillRectangle(b, rect);
                e.Graphics.FillRectangle(b2, rect2);
                e.Graphics.DrawImage(e.Image, new Point(5, 3));
            }
        }
        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            base.OnRenderImageMargin(e);

            var rect = new Rectangle(0, 0, e.ToolStrip.Width, e.ToolStrip.Height);

            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, 30, 30)), rect);

            var DarkLine = new SolidBrush(Color.FromArgb(30, 30, 30));
            var rect3 = new Rectangle(0, 0, 26, e.AffectedBounds.Height);
            e.Graphics.FillRectangle(DarkLine, rect3);

            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(30, 30, 30))), 28, 0, 28, e.AffectedBounds.Height);

            var rect2 = new Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Transparent)), rect2);
        }
    }
    #endregion

    #region DarkToolStripRenderer
    public class DarkToolStripRenderer : ToolStripSystemRenderer
    {
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            // base.OnRenderToolStripBorder(e); 
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            // base.OnRenderToolStripBackground(e);

            var g = e.Graphics;

            if (e.ToolStrip.GetType() == typeof(ToolStripOverflow))
            {
                using (var p = new Pen(Color.Transparent /* 28,28,28 */ ))
                {
                    var rect = new Rectangle(e.AffectedBounds.Left, e.AffectedBounds.Top, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1);
                    g.DrawRectangle(p, rect);
                }
            }
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            var g = e.Graphics;

            var castItem = (ToolStripSeparator)e.Item;
            if (castItem.IsOnDropDown)
            {
                base.OnRenderSeparator(e);
                return;
            }

            var rect = new Rectangle(3, 3, 2, e.Item.Height - 4);

            using (var p = new Pen(Color.FromArgb(70, 70, 74)))
            {
                g.DrawLine(p, rect.Left, rect.Top, rect.Left, rect.Height);
            }

            using (var p = new Pen(Color.FromArgb(40, 40, 40)))
            {
                g.DrawLine(p, rect.Left + 1, rect.Top, rect.Left + 1, rect.Height);
            }
        }

        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
            var g = e.Graphics;

            var rect = new Rectangle(0, 1, e.Item.Width, e.Item.Height - 2);

            if (e.Item.Selected || e.Item.Pressed)
            {
                using (var b = new SolidBrush(Color.FromArgb(25, 25, 25)))
                {
                    g.FillRectangle(b, rect);
                }
            }
        }

        // Grip Style
        protected override void OnRenderGrip(ToolStripGripRenderEventArgs e)
        {
            if (e.GripStyle == ToolStripGripStyle.Hidden)
                return;

            var g = e.Graphics;

            using (var img = CustomResources.Renderer.grip.SetColor(Color.FromArgb(60, 60, 60)))
            {
                g.DrawImageUnscaled(img, new Point(e.AffectedBounds.Left, e.AffectedBounds.Top));
            }
        }

        // Render button selected and pressed state
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderButtonBackground(e);
            var rectBorder = new Rectangle(0, 0, e.Item.Width - 0, e.Item.Height - 0);
            var rect = new Rectangle(0, 0, e.Item.Width - 0, e.Item.Height - 0);
            Brush b2 = new System.Drawing.Drawing2D.LinearGradientBrush(e.Item.ContentRectangle, Color.FromArgb(28,28,28), Color.FromArgb(28,28,28), 90);
            Brush b4 = new System.Drawing.Drawing2D.LinearGradientBrush(e.Item.ContentRectangle, Color.FromArgb(28,28,28), Color.FromArgb(28,28,28), 90);

            if (e.Item.Selected == true || (e.Item as ToolStripButton).Checked)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), rect);
                e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(50, 50, 50))), rectBorder);
                e.Item.ForeColor = Color.White;
            }
            else
            {
                e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(50, 50, 50))), rectBorder);
                e.Graphics.FillRectangle(b4, rect);
            }

            if (e.Item.Pressed)
            {
                using (var b = new LinearGradientBrush(rect, Color.FromArgb(40, 40, 40), Color.FromArgb(40, 40, 40), 90))
                {
                    using (var b3 = new SolidBrush(Color.Transparent))
                    {
                        e.Graphics.FillRectangle(b3, rectBorder);
                        e.Graphics.FillRectangle(b, rect);
                    }
                }
            }
        }
    }
    #endregion

}
