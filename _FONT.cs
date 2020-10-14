using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Project.CustomControls
{
    class _FONT
    {
        #region Get Fonts
        public static Font GetFont(byte[] fontbyte, float size)
        {
            using (PrivateFontCollection privateFontCollection = new PrivateFontCollection())
            {
                byte[] fnt = fontbyte;
                IntPtr buffer = Marshal.AllocCoTaskMem(fnt.Length);
                Marshal.Copy(fnt, 0, buffer, fnt.Length);
                privateFontCollection.AddMemoryFont(buffer, fnt.Length);
                return new Font(privateFontCollection.Families[0].Name, size);
            }
        }
        #endregion

        #region Fonts for Code Editor and Terminal
        public static Font FC_Light(float size)
        {
            /* Use this font for Terminal */
            return GetFont(CustomResources.Fonts.FiraCode_Light, size);
        }
        public static Font FC_Regular(float size)
        {
            /* Use this font for Code Editing */
            return GetFont(CustomResources.Fonts.FiraCode_Regular, size);
        }
        public static Font FC_Medium(float size)
        {
            return GetFont(CustomResources.Fonts.FiraCode_Medium, size);
        }
        public static Font FC_Bold(float size)
        {
            return GetFont(CustomResources.Fonts.FiraCode_Bold, size);
        }
        public static Font FC_Retina(float size)
        {
            return GetFont(CustomResources.Fonts.FiraCode_Retina, size);
        }
        #endregion

        #region Fonts for Normal Use
        public static Font FN_Regular(float size)
        {
            return GetFont(CustomResources.Fonts.micross, size);
        }
        #endregion
    }
}
