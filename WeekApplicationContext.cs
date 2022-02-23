﻿#region Using statements

using System;
using System.Windows.Forms;

#endregion Using statements

namespace WeekNumberLite
{
    internal class WeekApplicationContext : ApplicationContext
    {
        #region Internal Taskbar GUI

        internal IGui Gui;

        #endregion Internal Taskbar GUI

        #region Private variables

        private readonly Timer _timer;
        private int _currentWeek;

        #endregion Private variables

        #region Constructor

        internal WeekApplicationContext()
        {
            try
            {

                Application.ApplicationExit += OnApplicationExit;
                _currentWeek = Week.Current();
                Gui = new TaskbarGui(_currentWeek);
                _timer = GetTimer;
            }
            catch (Exception ex)
            {
                _timer?.Stop();

                Message.Show(Resources.UnhandledException, ex);
                Application.Exit();
            }
        }

        #endregion Constructor

        #region Private Timer property

        private Timer GetTimer
        {
            get
            {
                if (_timer != null)
                {
                    return _timer;
                }
                int calculatedInterval = 86400000 - ((DateTime.Now.Hour * 3600000) + (DateTime.Now.Minute * 60000) + (DateTime.Now.Second * 1000));
                Timer timer = new Timer
                {
                    Interval = calculatedInterval,
                    Enabled = true
                };
                timer.Tick += OnTimerTick;
                return timer;
            }
        }

        #endregion Private Timer property

        #region Private event handlers

        private void OnApplicationExit(object sender, EventArgs e)
        {

            Cleanup(false);
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            UpdateIcon();
        }

        private void UpdateIcon()
        {
            if (_currentWeek == Week.Current())
            {
                return;
            }
            _timer?.Stop();
            Application.DoEvents();
            try
            {
                _currentWeek = Week.Current();
                Gui?.UpdateIcon(_currentWeek);
            }
            catch (Exception ex)
            {
                Message.Show(Resources.FailedToSetIcon, ex);
                Cleanup();
                throw;
            }
            if (_timer != null)
            {
                int calculatedInterval = 86400000 - ((DateTime.Now.Hour * 3600000) + (DateTime.Now.Minute * 60000) + (DateTime.Now.Second * 1000));
                _timer.Interval = calculatedInterval;
                _timer.Start();
            }
        }

        #endregion Private event handlers

        #region Private methods

        private void Cleanup(bool forceExit = true)
        {

            _timer?.Stop();
            _timer?.Dispose();
            Gui?.Dispose();
            Gui = null;
            if (forceExit)
            {
                Application.Exit();
            }
        }

        #endregion Private methods
    }
}