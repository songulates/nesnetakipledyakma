using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using AForge;
using AForge.Imaging.Filters;
using AForge.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;
using System.IO.Ports;

namespace aforge
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection VideoCapTureDevices;
        private VideoCaptureDevice Finalvideo;
        public Form1()
        {
            InitializeComponent();
        }
        int R; 
        int G;
        int B;
        private void Form1_Load(object sender, EventArgs e)
        {
            VideoCapTureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in VideoCapTureDevices)
            {

                comboBox1.Items.Add(VideoCaptureDevice.Name);
                comboBox2.DataSource = SerialPort.GetPortNames();
            }
            comboBox1.SelectedIndex = 0;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Finalvideo = new VideoCaptureDevice(VideoCapTureDevices[comboBox1.SelectedIndex].MonikerString);
            Finalvideo.NewFrame += new NewFrameEventHandler(Finalvideo_NewFrame);
            Finalvideo.DesiredFrameRate = 20;//saniyede kaç görüntü almasını istiyoruz. FPS
            Finalvideo.DesiredFrameSize = new Size(300, 300);//görüntü boyutları
            Finalvideo.Start();
        }

        private void Finalvideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            Bitmap image1 = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = image;
            EuclideanColorFiltering filter = new EuclideanColorFiltering();
            filter.CenterColor = new RGB(Color.FromArgb(R, G, B));
            filter.Radius = 100;
           //filtre uygula
            filter.ApplyInPlace(image1);

            nesnebul(image1);

        }
        public void nesnebul(Bitmap image)
        {
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.MinWidth = 5; 
            blobCounter.MinHeight = 5;
            blobCounter.FilterBlobs = true;
            blobCounter.ObjectsOrder = ObjectsOrder.Size;
            BitmapData objectsData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, image.PixelFormat);
            // grayscaling
            Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
            UnmanagedImage grayImage = grayscaleFilter.Apply(new UnmanagedImage(objectsData));
            // unlock image
            image.UnlockBits(objectsData);
            blobCounter.ProcessImage(image);
            Rectangle[] rects = blobCounter.GetObjectsRectangles();
            Blob[] blobs = blobCounter.GetObjectsInformation();
            this.pictureBox2.Image = image;
            
            if (rects.Length > 0) 
            {
                Rectangle objectRect = rects[0];
                Graphics g = pictureBox1.CreateGraphics();
                using (Pen pen = new Pen(Color.FromArgb(252, 3, 26), 2))
                {

                    if ((objectRect.X < 100) && (objectRect.Y < 100))

                    {
                        g.DrawRectangle(pen, objectRect);
                        serialPort1.Write("1");
                    }

                    else
                    {
                        g.DrawRectangle(pen, objectRect);
                        serialPort1.Write("0");
                    }
                    if ((objectRect.X >= 100) && (objectRect.Y < 100) && (objectRect.X < 200))
                    {
                        g.DrawRectangle(pen, objectRect);
                        serialPort1.Write("2");
                    }

                    else
                    {
                        g.DrawRectangle(pen, objectRect);
                        serialPort1.Write("3");
                    }
                    if ((objectRect.X >= 200) && (objectRect.Y < 100) && (objectRect.X < 300))
                    {
                        g.DrawRectangle(pen, objectRect);
                        serialPort1.Write("4");
                    }

                    else
                    {
                        g.DrawRectangle(pen, objectRect);
                        serialPort1.Write("5");
                    }
                    if ((objectRect.X < 100) && (objectRect.Y > 100) && (objectRect.Y < 200))
                    {
                        g.DrawRectangle(pen, objectRect);
                        serialPort1.Write("6");
                    }

                    else
                    {
                        g.DrawRectangle(pen, objectRect);
                        serialPort1.Write("7");
                    }
                    if ((objectRect.X >= 100) && (objectRect.Y >100) && (objectRect.X < 200) && (objectRect.Y <= 200))
                    {
                        g.DrawRectangle(pen, objectRect);
                        serialPort1.Write("8");
                    }

                    else
                    {
                        g.DrawRectangle(pen, objectRect);
                        serialPort1.Write("9");
                    }
                     if ((objectRect.X >= 200) && (objectRect.Y > 100) && (objectRect.X < 300) && (objectRect.Y <= 200))
                        {
                        g.DrawRectangle(pen, objectRect);
                        serialPort1.Write("x");
                    }

                    else
                    {
                        g.DrawRectangle(pen, objectRect);
                        serialPort1.Write("y");
                    }
                   
                        if ((objectRect.X < 100) && (objectRect.Y > 200) && (objectRect.Y <= 300))
                        {
                        g.DrawRectangle(pen, objectRect);
                        serialPort1.Write("z");
                    }

                    else
                    {
                        g.DrawRectangle(pen, objectRect);
                        serialPort1.Write("t");
                    }
                    if ((objectRect.X >= 100) && (objectRect.Y > 200) && (objectRect.X < 200) && (objectRect.Y <= 300))
                    {
                        g.DrawRectangle(pen, objectRect);
                        serialPort1.Write("s");
                    }

                    else
                    {
                        g.DrawRectangle(pen, objectRect);
                        serialPort1.Write("m");
                    }
                    if ((objectRect.X >= 200) && (objectRect.Y > 200) && (objectRect.X < 300) && (objectRect.Y <= 300))
                    {
                        g.DrawRectangle(pen, objectRect);
                        serialPort1.Write("c");
                    }

                    else
                    {
                        g.DrawRectangle(pen, objectRect);
                        serialPort1.Write("i");
                    }
                }

                int objectX = objectRect.X + (objectRect.Width / 2);
                int objectY = objectRect.Y + (objectRect.Height / 2);
                g.Dispose();
                if (radioButton1.Checked)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        richTextBox1.Text = objectRect.Location.ToString() + "\n" + richTextBox1.Text + "\n"; ;
                    });
                }

              

            }

        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            R = trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            G = trackBar2.Value;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            B = trackBar3.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (Finalvideo.IsRunning)
            {
                Finalvideo.Stop();
            }
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 9600;
            serialPort1.PortName = "COM5";
            serialPort1.Open();
            if (serialPort1.IsOpen) MessageBox.Show("port açıldı");
        }
    }

}
