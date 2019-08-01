using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Post
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private System.Timers.Timer aTimer = new Timer();
        private int delayLength = 2;
        private string labelProperty;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            Device.StartTimer(TimeSpan.FromSeconds(delayLength), () =>
            {
                text.Text = " timer is up.";
                
                return false; // True = Repeat again, False = Stop the timer
            });
            text.Text = "Is your posture correct?";

            
        }
        public string LabelProperty
        {
            get { return labelProperty; }
            set
            {
                labelProperty = value;
                OnPropertyChanged(nameof(LabelProperty));
            }
        }

        private void OnYesButtonClicked(object sender, EventArgs e)
        {
            text.Text = "Stand up straight.";
            delayLength /= 2;
            if (delayLength < 2)
                delayLength = 2000;
        }
        private void OnFixButtonClicked(object sender, EventArgs e)
        {
            LabelProperty = "Great job!";
            delayLength *= 2;
        }

        private void OnOneMoreButtonClicked(object sender, EventArgs e)
        {
            string a = "";
            if (string.IsNullOrEmpty(a))
                text.Text = "the string is null";
            else
                text.Text = "the string is not null";
        }
      

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            aTimer.Stop();
            
            text.Text = "Is your posture correct?";
            aTimer.Dispose();
        }

    }
}
