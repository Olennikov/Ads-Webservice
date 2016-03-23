using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace RentService.Controller
{
    public class CaptchaImage
    {
        Random rnd = new Random(); 
        string imagesDirectory = @"C:\Programming\RentService\RentService\Helpers\CaptchaImg\";


        /// <summary>
        /// Generate captcha key
        /// </summary>
        /// <param name="width">bitmap width</param>
        /// <param name="height">bitmap height</param>
        /// <param name="size"> captcha key length</param>
        /// <param name="token">random token would be name of a ready captcha image</param>
        /// <returns>random letters and numbers for captcha(string)</returns>
        public string GenerateKeyImage(int width, int height, int size, string token)
        {
            var bitmap = new Bitmap(width, height);
            string key = new Helpers.RandomKey().GenerateKey(size);

            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawString(key, new Font("Tahoma", 30), Brushes.Black, 0, 0);
            }

            bitmap = GenerateNoiseImage(bitmap);

            bitmap.Save(string.Format(@"{0}{1}.jpg", imagesDirectory, token), ImageFormat.Jpeg);
            return key;
        }


        /// <summary>
        /// Generate second layer (img) - noise
        /// </summary>
        /// <param name="back"></param>
        /// <returns></returns>
        private Bitmap GenerateNoiseImage(Bitmap back)
        {
            var finalBmp = new Bitmap(back.Width, back.Height);

            for (int x = 0; x < back.Width; x++)
            {
                for (int y = 0; y < back.Height; y++)
                {
                    int[] nums = new int[3];

                    for (int i = 0; i < nums.Length; i++)
                    {
                        nums[i] = rnd.Next(0, 256);
                    }

                    finalBmp.SetPixel(x, y, Color.FromArgb(255, nums[0], nums[1], nums[2]));
                }
            }

            return MergeImages(back, finalBmp);
        }


        /// <summary>
        /// Merge Front and Back (letters and noise)
        /// </summary>
        /// <param name="back"></param>
        /// <param name="front"></param>
        /// <returns></returns>
        private Bitmap MergeImages(Bitmap back, Bitmap front)
        {
            using (Graphics g = Graphics.FromImage(back))
            {
                //create a color matrix object  
                ColorMatrix mtx = new ColorMatrix();

                //set the opacity  
                mtx.Matrix33 = 0.35f;

                //create image attributes  
                ImageAttributes attributes = new ImageAttributes();

                //set the color(opacity) of the image  
                attributes.SetColorMatrix(mtx, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                //now draw the image  
                g.DrawImage(front, new Rectangle(0, 0, back.Width, back.Height), 0, 0, front.Width, front.Height, GraphicsUnit.Pixel, attributes);
            }

            return back;
        }       
    }
}