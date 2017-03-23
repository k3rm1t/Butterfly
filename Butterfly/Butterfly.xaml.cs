using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Butterfly
{
    public sealed partial class Butterfly : UserControl
    {
        // Animate butterfly timer
        private DispatcherTimer timer;
        //offser to show sprite
        private int currentFrame = 0;
        private int direction = 1;
        private int frameHeigth = 132;

        // speed, acceolerata, angle
        private readonly double MaxSpeed = 10.0;
        private readonly double Accelerate = 0.5;
        private readonly double AngleStep = 5;
        private double Angle = 0;
        private double Speed = 0;
        // location
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        public Butterfly()
        {
            this.InitializeComponent();
            // animate
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 125);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            // frame
            if (direction == 1) currentFrame ++;
            else if (direction == -1) currentFrame --;
            // border value
            if (currentFrame == 0 || currentFrame == 4)
            {
                direction = -1 * direction; // 1 or -1
            }
            //set offset
            SpriteSheetOffset.Y = currentFrame * -frameHeigth;
        }

        // Show butterfly
        public void SetLocation()
        {
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }

        // Move
        // Rotation
    }
}
