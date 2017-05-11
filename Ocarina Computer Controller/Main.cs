using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace Ocarina_Computer_Controller
{
    class Main
    {
        WaveIn micIn;

        public Main()
        {
            micIn = new WaveIn();
        }

        public void Run()
        {
            micIn.DataAvailable += new EventHandler<WaveInEventArgs>(OnDataRecieved);
            micIn.StartRecording();
        }

        void OnDataRecieved(object sender, WaveInEventArgs e)
        {

        }
    }
}
