using System;
using System.Data;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using NAudio.CoreAudioApi;

namespace Mario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SetAudioVolumeToMax()
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            MMDevice device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            float volume = 1.0f; // 100% volume

            // Set the volume for both the left and right channels
            device.AudioEndpointVolume.MasterVolumeLevelScalar = volume;
        }

        private void LockCursorToCenter()
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            int centerX = screenWidth / 2;
            int centerY = screenHeight / 2;

            // Set the cursor position to the center of the screen
            Cursor.Position = new Point(centerX, centerY);

            // Set the clip region to prevent the cursor from leaving the center area
            Rectangle clipRect = new Rectangle(centerX, centerY, 1, 1);
            Cursor.Clip = clipRect;
        }


        // Example usage: call this function when you want to set the volume to 100%
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        private void PlayMarioMP3()
        {
            string filePath = "mario.wav";

            // Create a new instance of SoundPlayer
            SoundPlayer player = new SoundPlayer();

            try
            {
                // Set the sound file path
                player.SoundLocation = filePath;

                // Load the MP3 file
                player.Load();

                // Play the MP3 file
                player.Play();
            }
            catch (Exception ex)
            {
                // Handle any errors that may occur
                MessageBox.Show("An error occurred while playing the MP3 file: " + ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetAudioVolumeToMax();
            LockCursorToCenter();
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            PlayMarioMP3();
        }
    }
}
