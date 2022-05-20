#region Using statements

using System;
using System.Threading;
using System.Windows.Forms;

#region Test code
/*
using System.Reflection;
using System.Runtime.InteropServices;
using System.Drawing;
*/
#endregion Test code

#endregion Using statements

namespace WeekNumberLite
{
    internal class TaskbarGui : IDisposable, IGui
    {
        #region Private variables

        private NotifyIcon _notifyIcon;
        private readonly WeekNumberLiteContextMenu _contextMenu;
        private int _latestWeek;

        #endregion Private variables

        #region Constructor

        internal TaskbarGui(int week)
        {
            _latestWeek = week;
            _contextMenu = new WeekNumberLiteContextMenu();
            _notifyIcon = GetNotifyIcon(_contextMenu.ContextMenu);
            UpdateIcon(week, ref _notifyIcon);
        }

        #endregion Constructor

        #region Public UpdateIcon method

        /// <summary>
        /// Updates icon on GUI with given week number
        /// </summary>
        /// <param name="weekNumber">The week number to display on icon</param>
        public void UpdateIcon(int weekNumber) => UpdateIcon(weekNumber, ref _notifyIcon);

        #endregion Public UpdateIcon method

        #region Private UpdateIcon method

        private void UpdateIcon(int weekNumber, ref NotifyIcon notifyIcon)
        {
            try
            {
                string weekDayPrefix = string.Empty;
                string longDateString = DateTime.Now.ToLongDateString();
                const string SWEDISH_LONG_DATE_PREFIX_STRING = "den ";
                if (Thread.CurrentThread.CurrentUICulture.Name == Resources.Swedish || longDateString.StartsWith(SWEDISH_LONG_DATE_PREFIX_STRING))
                    weekDayPrefix = Message.SWEDISH_DAY_OF_WEEK_PREFIX[(int)DateTime.Now.DayOfWeek];
                notifyIcon.Text = $"{Resources.Week} {weekNumber}\r\n{weekDayPrefix}{DateTime.Now.ToLongDateString()}";
                System.Drawing.Icon prevIcon = notifyIcon.Icon;
                notifyIcon.Icon = WeekIcon.GetIcon(weekNumber);
                WeekIcon.CleanupIcon(ref prevIcon);
            }
            finally
            {
                if (_latestWeek != weekNumber) _latestWeek = weekNumber;
            }
        }

        #endregion Private UpdateIcon method

        #region Private helper property to create NotifyIcon

        private static NotifyIcon GetNotifyIcon(ContextMenu contextMenu) => new NotifyIcon { Visible = true, ContextMenu = contextMenu };

        #endregion Private helper property to create NotifyIcon

        #region IDisposable methods

        /// <summary>
        /// Disposes the GUI resources
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            CleanupNotifyIcon();
            _contextMenu.Dispose();
        }

        private void CleanupNotifyIcon()
        {
            if (_notifyIcon is null) return;
            _notifyIcon.Visible = false;
            if (_notifyIcon.Icon != null)
            {
                NativeMethods.DestroyIcon(_notifyIcon.Icon.Handle);
                _notifyIcon.Icon?.Dispose();
            }
            _notifyIcon.ContextMenu?.MenuItems.Clear();
            _notifyIcon.ContextMenu?.Dispose();
            _notifyIcon.Dispose();
            _notifyIcon = null;
        }

        #endregion IDisposable methods
    }
}