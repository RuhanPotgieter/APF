using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APF_Alien_Plant_Finder_.PresentationLayer
{
    public partial class DroneControlScreen : Form
    {
        public DroneControlScreen()
        {
            Thread t = new Thread(new ThreadStart(StartForrm));
            
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
           
            
        }

        public void StartForrm()
        {
            Application.Run(new SplashScreen());
        }
        
        
    }
    
}
