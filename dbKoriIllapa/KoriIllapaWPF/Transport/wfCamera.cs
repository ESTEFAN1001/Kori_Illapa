using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoriIllapaWPF.Transport
{
    public partial class wfCamera : Form
    {
        bool camera = false;
        private string PathTemp = @"C:\KoriIllapa\Images\Temp\";
        private bool HayDispositivos;
        private FilterInfoCollection MisDispositivos;
        private VideoCaptureDevice MyWebCam;

        public wfCamera()
        {
            InitializeComponent();
        }
        public wfCamera(bool camera)
        {
            InitializeComponent();
            this.camera = camera;
        }
        private void CerrarWebCam()
        {
            if (MyWebCam != null && MyWebCam.IsRunning)
            {
                MyWebCam.SignalToStop();
                MyWebCam = null;
            }
        }

        private void Capturando(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            imgLive.Image = Imagen;
        }

        public void CargaDispositivos()
        {
            MisDispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (MisDispositivos.Count > 0)
            {
                HayDispositivos = true;
                for (int i = 0; i < MisDispositivos.Count; i++)
                {
                    cbxCameras.Items.Add(MisDispositivos[i].Name.ToString());
                }
                cbxCameras.Text = MisDispositivos[0].Name.ToString();
            }
            else
            {
                HayDispositivos = false;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            CerrarWebCam();
            int i = cbxCameras.SelectedIndex;
            string NombreVideo = MisDispositivos[0].MonikerString;
            MyWebCam = new VideoCaptureDevice(NombreVideo);
            MyWebCam.NewFrame += new NewFrameEventHandler(Capturando);
            MyWebCam.Start();
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            if (MyWebCam != null && MyWebCam.IsRunning)
            {
                imgCaptura.Image = imgLive.Image;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (imgCaptura.Image != null)
            {
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                File.Delete(PathTemp + "temp.jpg");
                imgLive.Image.Save(PathTemp + "temp.jpg", ImageFormat.Jpeg);

                CerrarWebCam();
                camera = true;
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            File.Delete(PathTemp + "temp.jpg");
        }

        private void wfCamera_Load(object sender, EventArgs e)
        {
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            CargaDispositivos();
        }

        private void wfCamera_FormClosed(object sender, FormClosedEventArgs e)
        {
            CerrarWebCam();
        }
    }
}
