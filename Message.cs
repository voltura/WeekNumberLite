#region Using statements

using System;
using System.Windows.Forms;

#endregion Using statements

namespace WeekNumberLite
{
    internal static class Message
    {
        #region Internal readonly strings

        internal static readonly string[] SWEDISH_DAY_OF_WEEK_PREFIX = { "Söndagen ", "Måndagen ", "Tisdagen ", "Onsdagen ", "Torsdagen ", "Fredagen ", "Lördagen " };
        internal static readonly string CAPTION = $"{Resources.ProductName} {Resources.Version} {Application.ProductVersion}";

        #endregion Internal readonly strings

        #region Show Information or Error dialog methods

        internal static void Show(string text, Exception ex = null)
        {
            var message = ex is null ? text : $"{text}\r\n{ex}";
            Forms.MessageForm.DisplayMessage(message, !(ex is null));
        }

        #endregion Show Information or Error dialog methods
    }
}
