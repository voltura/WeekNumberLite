#region Using statements

using System;
using System.Drawing;
using System.Globalization;

#endregion Using statements

namespace WeekNumberLite
{
    internal static class WeekIcon
    {
        #region Icon Size

        private const int _iconSize = (int)IconSize.Icon512;

        #endregion Icon Size

        #region Internal static functions

        internal static Icon GetIcon(int weekNumber)
        {
            Icon icon = null;
            using (Bitmap bitmap = new Bitmap(_iconSize, _iconSize))
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.TextContrast = 1;
                DrawBackgroundOnGraphics(graphics, _iconSize);
                DrawWeekNumberLiteOnGraphics(weekNumber, graphics, _iconSize);
                IntPtr bHicon = bitmap.GetHicon();
                Icon newIcon = Icon.FromHandle(bHicon);
                icon = new Icon(newIcon, _iconSize, _iconSize);
                CleanupIcon(ref newIcon);
            }
            return icon;
        }

        internal static void CleanupIcon(ref Icon icon)
        {
            if (icon is null) return;
            NativeMethods.DestroyIcon(icon.Handle);
            icon.Dispose();
        }

        #endregion Internal static functions

        #region Privare static helper methods

        private static void DrawBackgroundOnGraphics(Graphics graphics, int size = 0)
        {
            if (size == 0) size = _iconSize;
            Color backgroundColor = Color.Black;
            Color foregroundColor = Color.LightGray;
            using (SolidBrush foregroundBrush = new SolidBrush(foregroundColor))
            using (SolidBrush backgroundBrush = new SolidBrush(backgroundColor))
            {
                float inset = (float)Math.Abs(size * .03125);
                graphics?.FillRectangle(backgroundBrush, inset, inset, size - inset, size - inset);
                using (Pen pen = new Pen(foregroundColor, inset * 2))
                    graphics?.DrawRectangle(pen, inset, inset, size - inset * 2, size - inset * 2);
                float leftInset = (float)Math.Abs(size * .15625);
                graphics?.FillRectangle(foregroundBrush, leftInset, inset / 2, inset * 3, inset * 5);
                float rightInset = (float)Math.Abs(size * .75);
                graphics?.FillRectangle(foregroundBrush, rightInset, inset / 2, inset * 3, inset * 5);
            }
        }

        private static void DrawWeekNumberLiteOnGraphics(int WeekNumberLite, Graphics graphics, int size = 0)
        {
            if (size == 0) size = _iconSize;
            float fontSize = (float)Math.Abs(size * .78125);
            float insetX = (float)-(size > (int)IconSize.Icon16 ? Math.Abs(fontSize * .12) : Math.Abs(fontSize * .07));
            float insetY = (float)(size > (int)IconSize.Icon16 ? Math.Abs(fontSize * .2) : Math.Abs(fontSize * .08));
            Color foregroundColor = Color.White;
            using (Font font = new Font(FontFamily.GenericMonospace, fontSize, FontStyle.Bold,
                GraphicsUnit.Pixel, 0, false))
            using (Brush brush = new SolidBrush(foregroundColor))
                graphics?.DrawString(WeekNumberLite.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0'), font, brush, insetX, insetY);
        }

        #endregion Private static helper methods
    }
}