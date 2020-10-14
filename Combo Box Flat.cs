using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Project.CustomControls
{
    class Combo_Box_Flat : ComboBox
    {
        internal class Methods
        {
            /// <summary>
            /// The Method to draw the image from encoded base64 string.
            /// </summary>
            /// <param name="G">The Graphics to draw the image.</param>
            /// <param name="base64Image">The Encoded base64 image.</param>
            /// <param name="rect">The Rectangle area for the image.</param>
            public void DrawImageFromBase64(Graphics G, string base64Image, Rectangle rect)
            {
                Image im = null;
                using (var ms = new System.IO.MemoryStream(Convert.FromBase64String(base64Image)))
                {
                    im = Image.FromStream(ms);
                    ms.Close();
                }
                G.DrawImage(im, rect);
            }

            /// <summary>
            /// The Method to draw the image with custom color.
            /// </summary>
            /// <param name="G"> The Graphic to draw the image.</param>
            /// <param name="r"> The Rectangle area of image.</param>
            /// <param name="image"> The image that the custom color applies on it.</param>
            /// <param name="c">The Color that be applied to the image.</param>
            /// <remarks></remarks>
            public void DrawImageWithColor(Graphics G, Rectangle r, Image image, Color c)
            {
                var ptsArray = new[]
                {
            new[] {Convert.ToSingle(c.R / 255.0), 0f, 0f, 0f, 0f},
            new[] {0f, Convert.ToSingle(c.G / 255.0), 0f, 0f, 0f},
            new[] {0f, 0f, Convert.ToSingle(c.B / 255.0), 0f, 0f},
            new[] {0f, 0f, 0f, Convert.ToSingle(c.A / 255.0), 0f},
            new[]
            {
                Convert.ToSingle( c.R/255.0),
                Convert.ToSingle( c.G/255.0),
                Convert.ToSingle( c.B/255.0), 0f,
                Convert.ToSingle( c.A/255.0)
            }
            };
                var imgAttribs = new ImageAttributes();
                imgAttribs.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Default);
                G.DrawImage(image, r, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imgAttribs);
                image.Dispose();
            }

            /// <summary>
            /// The Method to draw the image with custom color.
            /// </summary>
            /// <param name="G"> The Graphic to draw the image.</param>
            /// <param name="r"> The Rectangle area of image.</param>
            /// <param name="image"> The Encoded base64 image that the custom color applies on it.</param>
            /// <param name="c">The Color that be applied to the image.</param>
            /// <remarks></remarks>
            public void DrawImageWithColor(Graphics G, Rectangle r, string image, Color c)
            {
                var im = ImageFromBase64(image);
                var ptsArray = new[]
                {
            new[] {Convert.ToSingle(c.R / 255.0), 0f, 0f, 0f, 0f},
            new[] {0f, Convert.ToSingle(c.G / 255.0), 0f, 0f, 0f},
            new[] {0f, 0f, Convert.ToSingle(c.B / 255.0), 0f, 0f},
            new[] {0f, 0f, 0f, Convert.ToSingle(c.A / 255.0), 0f},
            new[]
            {
                Convert.ToSingle( c.R/255.0),
                Convert.ToSingle( c.G/255.0),
                Convert.ToSingle( c.B/255.0), 0f,
                Convert.ToSingle( c.A/255.0)
            }
            };
                var imgAttribs = new ImageAttributes();
                imgAttribs.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Default);
                G.DrawImage(im, r, 0, 0, im.Width, im.Height, GraphicsUnit.Pixel, imgAttribs);
            }

            /// <summary>
            /// The String format to provide the alignment.
            /// </summary>
            /// <param name="horizontal">Horizontal alignment.</param>
            /// <param name="vertical">Horizontal alignment. alignment.</param>
            /// <returns>The String format.</returns>
            public StringFormat SetPosition(StringAlignment horizontal = StringAlignment.Center, StringAlignment vertical = StringAlignment.Center)
            {
                return new StringFormat
                {
                    Alignment = horizontal,
                    LineAlignment = vertical
                };
            }

            /// <summary>
            /// The Matrix array of single from color.
            /// </summary>
            /// <param name="c">The Color.</param>
            /// /// <param name="alpha">The Opacity.</param>
            /// <returns>The Matrix array of single from the given color</returns>
            public float[][] ColorToMatrix(float alpha, Color c)
            {
                return new[]
                {
            new [] {Convert.ToSingle(c.R / 255),0,0,0,0},
            new [] {0,Convert.ToSingle(c.G / 255),0,0,0},
            new [] {0,0,Convert.ToSingle(c.B / 255),0,0},
            new [] {0,0,0,Convert.ToSingle(c.A / 255),0},
            new [] {
                Convert.ToSingle(c.R / 255),
                Convert.ToSingle(c.G / 255),
                Convert.ToSingle(c.B / 255),
                alpha,
                Convert.ToSingle(c.A / 255)
            }
        };
            }


            public void DrawImageWithTransparency(Graphics G, float alpha, Image image, Rectangle rect)
            {
                var colorMatrix = new ColorMatrix { Matrix33 = alpha };
                var imageAttributes = new ImageAttributes();
                imageAttributes.SetColorMatrix(colorMatrix);
                G.DrawImage(image, new Rectangle(rect.X, rect.Y, image.Width, image.Height), rect.X, rect.Y, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
                imageAttributes.Dispose();
            }



            /// <summary>
            /// The Image from encoded base64 image.
            /// </summary>
            /// <param name="base64Image">The Encoded base64 image</param>
            /// <returns>The Image from encoded base64.</returns>
            public Image ImageFromBase64(string base64Image)
            {
                using (var ms = new System.IO.MemoryStream(Convert.FromBase64String(base64Image)))
                {
                    return Image.FromStream(ms);
                }
            }

            /// <summary>
            /// Turns the rectangle to rounded rectangle.
            /// Credits : Aeonhack
            /// </summary>
            /// <param name="r">The Rectangle to fill.</param>
            /// <param name="curve">The Rounding border radius.</param>
            /// <param name="topLeft">Wether the top left of rectangle be round or not.</param>
            /// <param name="topRight">Wether the top right of rectangle be round or not.</param>
            /// <param name="bottomLeft">Wether the bottom left of rectangle be round or not.</param>
            /// <param name="bottomRight">Wether the bottom right of rectangle be round or not.</param>
            /// <returns>the rounded rectangle base one given rectangle</returns>
            public GraphicsPath RoundRec(Rectangle r, int curve, bool topLeft = true, bool topRight = true,
              bool bottomLeft = true, bool bottomRight = true)
            {
                var createRoundPath = new GraphicsPath(FillMode.Winding);
                if (topLeft)
                {
                    createRoundPath.AddArc(r.X, r.Y, curve, curve, 180f, 90f);
                }
                else
                {
                    createRoundPath.AddLine(r.X, r.Y, r.X, r.Y);
                }
                if (topRight)
                {
                    createRoundPath.AddArc(r.Right - curve, r.Y, curve, curve, 270f, 90f);
                }
                else
                {
                    createRoundPath.AddLine(r.Right - r.Width, r.Y, r.Width, r.Y);
                }
                if (bottomRight)
                {
                    createRoundPath.AddArc(r.Right - curve, r.Bottom - curve, curve, curve, 0f, 90f);
                }
                else
                {
                    createRoundPath.AddLine(r.Right, r.Bottom, r.Right, r.Bottom);
                }
                if (bottomLeft)
                {
                    createRoundPath.AddArc(r.X, r.Bottom - curve, curve, curve, 90f, 90f);
                }
                else
                {
                    createRoundPath.AddLine(r.X, r.Bottom, r.X, r.Bottom);
                }
                createRoundPath.CloseFigure();
                return createRoundPath;
            }

            /// <summary>
            /// Turns the rectangle to rounded rectangle.
            /// Credits : Aeonhack
            /// </summary>
            /// <param name="x">The x-coordinate of the upper-left corner of this Rectangle/param>
            /// <param name="y">The y-coordinate of the upper-left corner of this Rectangle</param>
            /// <param name="width">The Width of the rectangle</param>
            /// <param name="height">The Height of the rectangle</param>
            /// <param name="curve">The Rounding border radius.</param>
            /// <param name="topLeft">Wether the top left of rectangle be round or not.</param>
            /// <param name="topRight">Wether the top right of rectangle be round or not.</param>
            /// <param name="bottomLeft">Wether the bottom left of rectangle be round or not.</param>
            /// <param name="bottomRight">Wether the bottom right of rectangle be round or not.</param>
            /// <returns>the rounded rectangle base one given dimensions</returns>
            /// <returns>the rounded rectangle base one given details</returns>
            public GraphicsPath RoundRec(int x, int y, int width, int height, int curve, bool topLeft = true, bool topRight = true,
              bool bottomLeft = true, bool bottomRight = true)
            {
                var r = new Rectangle(x, y, width, height);
                var createRoundPath = new GraphicsPath(FillMode.Winding);
                if (topLeft)
                {
                    createRoundPath.AddArc(r.X, r.Y, curve, curve, 180f, 90f);
                }
                else
                {
                    createRoundPath.AddLine(r.X, r.Y, r.X, r.Y);
                }
                if (topRight)
                {
                    createRoundPath.AddArc(r.Right - curve, r.Y, curve, curve, 270f, 90f);
                }
                else
                {
                    createRoundPath.AddLine(r.Right - r.Width, r.Y, r.Width, r.Y);
                }
                if (bottomRight)
                {
                    createRoundPath.AddArc(r.Right - curve, r.Bottom - curve, curve, curve, 0f, 90f);
                }
                else
                {
                    createRoundPath.AddLine(r.Right, r.Bottom, r.Right, r.Bottom);
                }
                if (bottomLeft)
                {
                    createRoundPath.AddArc(r.X, r.Bottom - curve, curve, curve, 90f, 90f);
                }
                else
                {
                    createRoundPath.AddLine(r.X, r.Bottom, r.X, r.Bottom);
                }
                createRoundPath.CloseFigure();
                return createRoundPath;
            }
        }



























        public Color SelectedItemBackColor { get; set; }
        public Color BackgroundColor { get; set; }
        public Color SelectedItemForeColor { get; set; }
        public Color DisabledBackColor { get; set; }
        public Color BorderColor { get; set; }
        public Color DisabledBorderColor { get; set; }
        public Color ArrowColor { get; set; }
        public Color DisabledForeColor { get; set; }



        private readonly Methods _mth;

        private int _startIndex;

        public Combo_Box_Flat()
        {
            SetStyle
               (
               ControlStyles.AllPaintingInWmPaint |
               ControlStyles.UserPaint |
               ControlStyles.ResizeRedraw |
               ControlStyles.OptimizedDoubleBuffer |
               ControlStyles.SupportsTransparentBackColor,
               true);
            UpdateStyles();
            Font = _FONT.FN_Regular(9);
            BackColor = Color.Transparent;
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 20;
            _startIndex = 0;
            CausesValidation = false;
            AllowDrop = true;
            DropDownStyle = ComboBoxStyle.DropDownList;

            _mth = new Methods();
        }



        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            var G = e.Graphics;

            try
            {
                var itemState = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
                using (var bg = new SolidBrush(itemState ? SelectedItemBackColor : BackgroundColor))
                using (var tc = new SolidBrush(itemState ? SelectedItemForeColor : ForeColor))
                {
                    using (var f = new Font(Font.Name, 9))
                    {
                        G.FillRectangle(bg, e.Bounds);
                        G.DrawString(GetItemText(Items[e.Index]), f, tc, e.Bounds, _mth.SetPosition(StringAlignment.Near));
                    }
                }

            }
            catch
            {
                // 
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            var G = e.Graphics;
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            var downArrow = '▼';
            G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            using (var bg = new SolidBrush(Enabled ? BackgroundColor : DisabledBackColor))
            {
                using (var p = new Pen(Enabled ? BorderColor : DisabledBorderColor))
                {
                    using (var s = new SolidBrush(Enabled ? ArrowColor : DisabledForeColor))
                    {
                        using (var tb = new SolidBrush(Enabled ? ForeColor : DisabledForeColor))
                        {
                            using (var f = _FONT.FN_Regular(9))
                            {
                                G.FillRectangle(bg, rect);
                                G.TextRenderingHint = TextRenderingHint.AntiAlias;
                                G.DrawString(downArrow.ToString(), f, s, new Point(Width - 22, 8));
                                G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                                G.DrawString(Text, f, tb, new Rectangle(7, 0, Width - 1, Height - 1), _mth.SetPosition(StringAlignment.Near));
                                G.DrawRectangle(p, rect);
                            }
                        }
                    }
                }
            }
        }

        private void UpdateProperties()
        {
            Invalidate();
        }

        #region Themes
        public void Light()
        {
            ForeColor = Color.FromArgb(10, 10, 10);
            BackColor = Color.FromArgb(255, 255, 255);
            BackgroundColor = Color.FromArgb(255, 255, 255);
            BorderColor = Color.FromArgb(219, 221, 230);
            ArrowColor = Color.FromArgb(113, 113, 113);
            SelectedItemBackColor = Color.FromArgb(204, 206, 219);
            SelectedItemForeColor = Color.FromArgb(10, 10, 10);
            UpdateProperties();
        }

        public void Dark()
        {
            ForeColor = Color.FromArgb(255, 255, 255);
            BackColor = Color.FromArgb(51, 51, 55);
            BackgroundColor = Color.FromArgb(51, 51, 55);
            BorderColor = Color.FromArgb(63, 63, 70);
            ArrowColor = Color.FromArgb(85, 85, 85);
            SelectedItemBackColor = Color.FromArgb(18, 18, 18);
            SelectedItemForeColor = Color.FromArgb(85, 85, 85);
            UpdateProperties();
        }

        public void DarkBlue()
        {
            ForeColor = Color.FromArgb(255, 255, 255);
            BackColor = Color.FromArgb(32, 35, 38);
            BackgroundColor = Color.FromArgb(32, 35, 38);
            BorderColor = Color.FromArgb(34, 60, 76);
            ArrowColor = Color.FromArgb(220, 220, 220);
            SelectedItemBackColor = Color.FromArgb(21, 23, 24);
            SelectedItemForeColor = Color.FromArgb(255, 255, 255);
            UpdateProperties();
        }
        #endregion
    }
}
