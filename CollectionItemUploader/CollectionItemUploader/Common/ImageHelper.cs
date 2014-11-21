using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionItemUploader.Common
{
    public static class ImageHelper
    {
        /// <summary>
        /// Muda o tamanho da imagem e retorna um Array de bytes contendo a imagem com o novo tamanho, completando o tamanho com fundo branco
        /// </summary>
        /// <param name="image">Array de bytes contendo o conteúdo da Imagem atual</param>
        /// <param name="maxWidth">Largura máxima desejada em pixels</param>
        /// <param name="maxHeight">Altura máxima desejada em pixels</param>
        /// <returns>Retorna array de bytes com o conteúdo da imagem redimensionada</returns>
        public static byte[] ResizeImage(byte[] image, int maxWidth, int maxHeight)
        {
            using (var inputStream = new MemoryStream(image))
            {
                using (Image oldImage = Image.FromStream(inputStream))
                {
                    int sourceWidth = oldImage.Width;
                    int sourceHeight = oldImage.Height;
                    int destX = 0;
                    int destY = 0;

                    float nPercent = 0;
                    float nPercentW = ((float)maxWidth / (float)sourceWidth);
                    float nPercentH = ((float)maxHeight / (float)sourceHeight);

                    if (nPercentH < nPercentW)
                    {
                        nPercent = nPercentH;
                        destX = Convert.ToInt16((maxWidth - (sourceWidth * nPercent)) / 2);
                    }
                    else
                    {
                        nPercent = nPercentW;
                        destY = Convert.ToInt16((maxHeight - (sourceHeight * nPercent)) / 2);
                    }

                    int destWidth = (int)(sourceWidth * nPercent);
                    int destHeight = (int)(sourceHeight * nPercent);

                    using (Bitmap newImage = new Bitmap(maxWidth, maxHeight, PixelFormat.Format24bppRgb))
                    {
                        using (System.Drawing.Graphics canvas = System.Drawing.Graphics.FromImage(newImage))
                        {
                            canvas.SmoothingMode = SmoothingMode.HighQuality;
                            canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            canvas.Clear(Color.White);
                            canvas.DrawImage(oldImage, new Rectangle(destX, destY, destWidth, destHeight), new Rectangle(0, 0, sourceWidth, sourceHeight), GraphicsUnit.Pixel);

                            MemoryStream stream = new MemoryStream();
                            newImage.Save(stream, ImageFormat.Jpeg);
                            return stream.GetBuffer();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Muda o tamanho da imagem e retorna um Array de bytes contendo a imagem com o novo tamanho, ele não preênche o fundo branco.
        /// </summary>
        /// <param name="image">Array de bytes contendo o conteúdo da Imagem atual</param>
        /// <param name="maxWidth">Largura máxima desejada em pixels</param>
        /// <param name="maxHeight">Altura máxima desejada em pixels</param>
        /// <returns>Retorna array de bytes com o conteúdo da imagem redimensionada</returns>
        public static byte[] ResizeImageWithoutWhiteBg(byte[] image, int maxWidth, int maxHeight, ImageFormat imageFormat)
        {
            using (var inputStream = new MemoryStream(image))
            {
                using (Image oldImage = Image.FromStream(inputStream))
                {
                    Size newSize = new Size();
                    newSize.Width = (int)(oldImage.Width * (float)maxHeight / (float)oldImage.Height);
                    newSize.Height = maxHeight;
                    if (newSize.Width > maxWidth)
                    {
                        // Resize with width instead
                        newSize.Height = (int)(oldImage.Height * (float)maxWidth / (float)oldImage.Width);
                        newSize.Width = maxWidth;
                    }

                    using (Bitmap newImage = new Bitmap(newSize.Width, newSize.Height, PixelFormat.Format32bppArgb))
                    {
                        using (System.Drawing.Graphics canvas = System.Drawing.Graphics.FromImage(newImage))
                        {
                            canvas.SmoothingMode = SmoothingMode.AntiAlias;
                            canvas.CompositingQuality = CompositingQuality.HighQuality;
                            canvas.CompositingMode = CompositingMode.SourceCopy;
                            canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;

                            if (imageFormat == ImageFormat.Jpeg)
                                canvas.Clear(Color.White);

                            canvas.DrawImage(oldImage, new Rectangle(new Point(0, 0), newSize));

                            MemoryStream stream = new MemoryStream();
                            newImage.Save(stream, imageFormat);
                            return stream.GetBuffer();
                        }
                    }
                }
            }
        }

        public static Image CropResize(Image imgToDeal, Size size)
        {
            var img = ResizeImageBySmaller(imgToDeal, size);

            int x = 0;
            int y = 0;

            if (img.Height > img.Width)
            {
                y = (img.Height - size.Height) / 2;
            }
            else
            {
                x = (img.Width - size.Width) / 2;
            }


            img = CropImage(img, new Rectangle(x, y, size.Width, size.Height));

            return img;
        }

        public static Image ResizeImageBySmaller(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH > nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);
            destHeight = destHeight < size.Height ? size.Height : destHeight;

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }


        public static Image ResizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }

        private static Image CropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea,
            bmpImage.PixelFormat);
            return (Image)(bmpCrop);
        }
    }
}
