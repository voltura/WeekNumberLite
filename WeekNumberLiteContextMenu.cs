#region Using statements

using System;
using System.Windows.Forms;

#endregion Using statements

namespace WeekNumberLite
{
    internal class WeekNumberLiteContextMenu : IDisposable
    {
        #region Internal context menu

        internal ContextMenu ContextMenu { get; private set; }

        #endregion Internal context menu

        #region Internal contructor

        internal WeekNumberLiteContextMenu()
        {

            CreateContextMenu();
        }

        #endregion Internal constructor

        #region Private event handling

        private static void ExitMenuClick(object o, EventArgs e)
        {

            Application.Exit();
        }

        private void AboutClick(object o, EventArgs e)
        {

            MenuItem mi = (MenuItem)o;
            try
            {
                mi.Enabled = false;
                Forms.MessageForm.LogAndDisplayLinkMessage(Resources.About, Resources.APPLICATION_URL);
            }
            finally
            {
                EnableMenuItem(mi);
            }
        }

        #endregion Private event handling

        #region Private method for context menu creation

        internal void CreateContextMenu()
        {

            ContextMenu = new ContextMenu(new MenuItem[2]
            {
                new MenuItem(Resources.AboutMenu, AboutClick)
                {
                    DefaultItem = true
                },
                new MenuItem(Resources.ExitMenu, ExitMenuClick)
            });
        }

        #endregion Private method for context menu creation

        #region Private helper methods for menu items

        private static void EnableMenuItem(MenuItem mi)
        {
            if (mi != null)
            {
                mi.Enabled = true;
            }
        }

        #endregion Private helper methods for menu items

        #region IDisposable methods

        /// <summary>
        /// Disposes the context menu
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            CleanupContextMenu();
        }

        private void CleanupContextMenu()
        {

            ContextMenu?.Dispose();
            ContextMenu = null;
        }

        #endregion IDisposable methods
    }
}