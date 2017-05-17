using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio;
using MathNet.Numerics.IntegralTransforms;

namespace Ocarina_Computer_Controller
{
    
    class Main
    {
        WaveInEvent micIn;

        float[] sampleBuffer = new float[4412];

        public Main()
        {
            micIn = new WaveInEvent();
        }

        public void Run()
        {
            micIn.DeviceNumber = 0;
            micIn.WaveFormat = new WaveFormat();
            micIn.DataAvailable += new EventHandler<WaveInEventArgs>(OnDataRecieved);
            micIn.StartRecording();
        }

        void OnDataRecieved(object sender, WaveInEventArgs e)
        {
            for (int i = 0; i < e.Buffer.Length/4; i++)
            {
                sampleBuffer[i] = Convert.ToSingle(e.Buffer[i] + e.Buffer[i + 1] + e.Buffer[i + 2] + e.Buffer[i + 3]);
            }
            Fourier.ForwardReal(sampleBuffer, 4410);
        }
    }
}
