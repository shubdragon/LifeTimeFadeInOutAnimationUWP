using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LifeTimeFadeINFadeOutAnimation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();            
            Storyboard ChangeChapterSB = new Storyboard();
            FadeOutThemeAnimation FOTA = new FadeOutThemeAnimation();
            ChangeChapterSB.Children.Add(FOTA);
            Storyboard.SetTarget(FOTA, Chapter);

            Storyboard ChangeChapterIB = new Storyboard();
            FadeInThemeAnimation FITA = new FadeInThemeAnimation();
            ChangeChapterIB.Children.Add(FITA);
            Storyboard.SetTarget(FITA, Chapter);

            DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
            timer.Tick += async delegate (object sender, object e)
            {
                ChangeChapterSB.Begin();
                await Task.Delay(1000);
                ChangeChapterIB.Begin();
            };
            timer.Start();            
        }
    }
}
