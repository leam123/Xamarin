using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Essentials;

using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.Reflection;
using System.IO;


namespace MazingPatuti
{
    public partial class MainPage : ContentPage
    {
        DisplayInfo mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
        SKBitmap patuti;
        int patutiX = 0, patutiY = 0, targetX = 0, targetY = 0, direction = 0;
        bool patutiMoving = false, tocheck = false;


        public MainPage()
        {
            InitializeComponent();
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("MazingPatuti.idle1.png")) 
            {

                patuti = SKBitmap.Decode(stream);
                var dstInfo = new SKImageInfo((int)(mainDisplayInfo.Width / 12),
                    (int)(patuti.Height * (mainDisplayInfo.Width / 12)) / patuti.Width);

                patuti = patuti.Resize(dstInfo, SKBitmapResizeMethod.Hamming);
                targetX = patutiX = patuti.Width;
            
            }

        }

        private void canvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e) {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();

            canvas.DrawBitmap(patuti, patutiX, patutiY);

            if (patutiMoving)
            {
                switch (direction)
                {
                    case 1: // up
                        if (patutiY > targetY)
                            patutiY -= 2;
                        else
                        {
                            patutiMoving = false;
                            tocheck = true;
                        }
                        break;
                    case 2: // down
                        if (patutiY < targetY)
                            patutiY += 2;
                        else
                        {
                            patutiMoving = false;
                            tocheck = true;
                        }
                        break;
                    case 3: // left
                        if (patutiX > targetX)
                            patutiX -= 2;
                        else
                        {
                            patutiMoving = false;
                            tocheck = true;
                        }
                        break;
                    case 4: // right
                        if (patutiX < targetX)
                            patutiX += 2;
                        else
                        {
                            patutiMoving = false;
                            tocheck = true;
                        }
                        break;
                }
            }
        }

        private async void moveController(object sender, EventArgs e) {
            if (patutiMoving)
            {
                return;
            }

            Button button = (Button) sender;
            string buttonText = button.Text.ToString();

            switch (buttonText) {
                case "R":  //4
                    if (patutiX >= (patuti.Width * 10))
                    {
                        return;
                    }
                    direction = 4;
                    patutiMoving = true;
                    targetX = patutiX - patuti.Width;
                    break;
                case "L": //3
                    if (patutiX <= patuti.Width) {
                        return;
                    }
                    direction = 3;
                    patutiMoving = true;
                    targetX = patutiX - patuti.Width;
                    break;
                case "U": //1
                    direction = 1;
                    patutiMoving = true;
                    targetY = patutiY + patuti.Width;
                    break;
                case "D": //2
                    direction = 2;
                    patutiMoving = true;
                    targetY = patutiY + patuti.Width;
                    break;

            }
        }
    }
}
