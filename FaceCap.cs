using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.CvEnum; // HAAR_DETECTION_TYPE
using Emgu.CV.Features2D;
using System.IO;

namespace FaceCap
{
    public partial class FaceCap : Form
    {
        Timer timer1 = new Timer();
        int counter = 0;
        private Capture cap;
        //private bool capInProgress;
        private HaarCascade haar;
        static int i = 0;
        //Bitmap[] ExtFaces;
        //int FaceNo;
        Image<Bgr, byte> ImageFrame;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, t;
        string name, names = null;

        //Default values of haarCascade
        private int windowSize = 25;
        private Double ScaleRate = 1.1;
        private int minNeighbors = 3;

       /* private void StartFrame(object sender, EventArgs arg)
        {
            ImageFrame = cap.QueryFrame();
            faceImageBox.Image = ImageFrame;
        }*/

        private void ProcessFrame(object sender, EventArgs arg)
        {

            NamePersons.Add("");


            //Get the current frame frm capture device
            ImageFrame = cap.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
            gray = ImageFrame.Convert<Gray, Byte>();

            //Face Detector
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(haar, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));

            //Action for each element detected
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t = t + 1;
                result = ImageFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //draw the face detected in the 0th (gray) channel with red color
                ImageFrame.Draw(f.rect, new Bgr(Color.Blue), 2);

                try
                {
                    if (trainingImages.ToArray().Length != 0)
                    {
                        //TermCriteria for face recognition with numbr of trained images like maxIteration
                        MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                        //Eigen face recognizer
                        EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                           trainingImages.ToArray(),
                           labels.ToArray(),
                           3500,
                           ref termCrit);

                        name = recognizer.Recognize(result);

                        //Draw the label for each face detected and recognized
                        ImageFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.Red));

                    }
                }
                catch (Exception ie)
                {
                    MessageBox.Show(ie.ToString());
                }

                NamePersons[t - 1] = name;
                NamePersons.Add("");


                //Set the number of faces detected on the scene
                // labelmin.Text = facesDetected[0].Length.ToString();

            }
            t = 0;

            //Names concatenation of persons recognized
            /*for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
            {
                names = names + NamePersons[nnn] + ", ";
            }*/

            //Show the faces procesed and recognized
            faceImageBox.Image = ImageFrame;
            // labelscal.Text = names;
            names = "";
            //Clear the list(vector) of names
            NamePersons.Clear();

        }

        public FaceCap()
        {
            InitializeComponent();
            //Load haarcascades for face detection
            //haar = new HaarCascade("haarcascade_frontalface_default.xml");
            //eye = new HaarCascade("haarcascade_eye.xml");
            try
            {
                //Load of previus trainned faces and labels for each image
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;
                int tf;
                for (tf = 1; tf < NumLabels + 1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }
                MessageBox.Show(NumLabels.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

      /*  private void btnStart_Click(object sender, EventArgs e)
        {
            //Initialize the capture device
            cap = new Capture();
            cap.QueryFrame();
            //Initialize the Frame Grab event
            Application.Idle += new EventHandler(StartFrame);
        }*/



        private void closeApp()
        {
            if (cap != null)
                cap.Dispose();
        }

        private void FaceCap_Load(object sender, EventArgs e)
        {
            haar = new HaarCascade("haarcascade_frontalface_alt_tree.xml");
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            timer1.Interval = 2000;
            timer1.Start();
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (counter < 20)
            {

                try
                {
                    // int n = 0;

                    //MessageBox.Show("for Image" + (n + 1));
                    //Trained face counter
                    ContTrain = ContTrain + 1;

                    //Get a gray frame from capture device
                    gray = cap.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                    //Face Detector
                    MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(haar, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));

                    if (facesDetected[0].Length > 0)
                    {
                        //Action for each element detected
                        foreach (MCvAvgComp f in facesDetected[0])
                        {
                            TrainedFace = ImageFrame.Copy(f.rect).Convert<Gray, byte>();
                            break;
                        }
                        ImageFrame = cap.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                        DetectFaces();

                        //resize face detected image for force to compare the same size with the 
                        //test image with cubic interpolation type method
                        TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                        trainingImages.Add(TrainedFace);
                        labels.Add(textBox1.Text);
                        ++counter;
                        // ++n;

                        //Show face added in gray scale
                        imageBox1.Image = TrainedFace;


                        //Write the number of triained faces in a file text for further load
                        File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

                        //Write the labels of triained faces in a file text for further load
                        for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                        {
                            trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                            File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                        }
                        MessageBox.Show(textBox1.Text + "´s face detected and added :)", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Enable the face detection first", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


                faceImageBox.Image = ImageFrame;
            }
            else
            {
                counter = 0;
                timer1.Stop();
                MessageBox.Show("Your registered successfully!!");
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string s = txtPicName.Text;
            try
            {
                Image InputImg = Image.FromFile(s);
                ImageFrame = new Image<Bgr, byte>(new Bitmap(InputImg));
                faceImageBox.Image = ImageFrame.Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                DetectFaces();
            }
            catch (FileNotFoundException f)
            {
                MessageBox.Show("No image with name:" + s + " exists");
            }
        }

        private void DetectFaces()
        {
            Image<Gray, byte> grayframe = ImageFrame.Convert<Gray, byte>();

            //Assign user-defined Values to parameter variables:
            minNeighbors = int.Parse(comboBoxMinNeigh.Text);
            windowSize = int.Parse(textBoxWinSiz.Text);
            ScaleRate = Double.Parse(comboBoxScIncRte.Text);

            var faces = grayframe.DetectHaarCascade(haar, ScaleRate, minNeighbors, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(windowSize, windowSize))[0];

            //MessageBox.Show("Totoal Faces Detected: " + faces.Length.ToString());
           // if (faces.Length > 1)
            //{

//            }
            //draw a green rectangle on each detected face in image
  //          else
    //        {
            int n = 0;
                foreach (var face in faces)
                {
                    ImageFrame.Draw(face.rect, new Bgr(Color.Red), 3);
                    ++n;

                }
                //Display the detected faces in imagebox
                faceImageBox.Image = ImageFrame.Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                MessageBox.Show("Detected faces are: " + n);
      //      }

        }

        private void btnRecog_Click(object sender, EventArgs e)
        {
            cap = new Capture();
            cap.QueryFrame();


            //Initialize the Frame Grab event
            Application.Idle += new EventHandler(ProcessFrame);
        }

        private void btnPicRecog_Click(object sender, EventArgs e)
        {
            NamePersons.Add("");

            //Convert it to Grayscale
            gray = ImageFrame.Convert<Gray, Byte>();

            //Face Detector
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(haar, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));

            //Action for each element detected
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t = t + 1;
                result = ImageFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //draw the face detected in the 0th (gray) channel with blue color
                ImageFrame.Draw(f.rect, new Bgr(Color.Blue), 2);

                try
                {
                    if (trainingImages.ToArray().Length != 0)
                    {
                        //TermCriteria for face recognition with numbr of trained images like maxIteration
                        MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                        //Eigen face recognizer

                        EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                        trainingImages.ToArray(),
                        labels.ToArray(),
                        3000,
                        ref termCrit);

                        name = recognizer.Recognize(result);

                        //Draw the label for each face detected and recognized
                        ImageFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.Red));

                    }
                }
                catch (Exception ie)
                {
                    MessageBox.Show(ie.ToString());
                }
                NamePersons[t - 1] = name;
                NamePersons.Add("");


                //Set the number of faces detected on the scene
                // labelmin.Text = facesDetected[0].Length.ToString();

            }
            t = 0;

            //Names concatenation of persons recognized
            /*for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
            {
                names = names + NamePersons[nnn] + ", ";
            }*/

            //Show the faces procesed and recognized
            faceImageBox.Image = ImageFrame;
            // labelscal.Text = names;
            names = "";
            //Clear the list(vector) of names
            NamePersons.Clear();
        }

        private void btnYale_Click(object sender, EventArgs e)
        {
           
            for (int l = 0; l < 12; ++l)
            {
                string fil = "TrainYale/face" + (l+1) + ".bmp";
                Image InputImg = Image.FromFile(fil);
                ImageFrame = new Image<Bgr, byte>(new Bitmap(InputImg));
                faceImageBox.Image = ImageFrame;

                //Get a gray frame from capture device
                gray = ImageFrame.Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC).Convert<Gray, byte>();

                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(haar, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));

                    //Action for each element detected
                    foreach (MCvAvgComp f in facesDetected[0])
                    {
                        TrainedFace = ImageFrame.Copy(f.rect).Convert<Gray, byte>();
                        ImageFrame.Draw(f.rect, new Bgr(Color.Blue), 2);
                        trainingImages.Add(TrainedFace);
                        labels.Add(textBox1.Text);
                        break;
                    }

                    //resize face detected image for force to compare the same size with the 
                    //test image with cubic interpolation type method
                    //TrainedFace = result.Resize(320, 243, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    


                    //Show face added in gray scale
                    imageBox1.Image = TrainedFace;
                
                    //Write the number of triained faces in a file text for further load
                    File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");
                    for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                    {
                        trainingImages.ToArray()[i - 1].Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC).Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                        File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                    }

            }

        }
    }
}
