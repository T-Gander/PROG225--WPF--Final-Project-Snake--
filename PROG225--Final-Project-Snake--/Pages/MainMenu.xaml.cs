﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PROG225__Final_Project_Snake__.Pages
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        static DispatcherTimer videoTimer;
        int videoCount = 0;

        public MainMenu()
        {
            InitializeComponent();

            videoTimer = new DispatcherTimer();
            videoTimer.Interval = new TimeSpan(0,0,1);
            videoTimer.Tick += VideoTimer_Tick;
            videoTimer.Start();
        }

        private void VideoTimer_Tick(object? sender, EventArgs e)
        {
            if(videoCount == 20)
            {
                backgroundVideo.Position = new TimeSpan(0,0,0);
                videoCount = 0;
            }
            else
            videoCount++;

            Debug.WriteLine($"{videoCount}");
        }
    }
}
