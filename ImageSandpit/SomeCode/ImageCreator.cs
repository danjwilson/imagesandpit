using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web;

namespace ImageSandpit
{
    public class ImageCreator
    {
        public string GetImage(string fileName = @"SandyBeach.jpg", float maxWidth = 1000, float maxHeight = 1000, string effect = "new")
        {
            using (Image i = Image.FromFile(HttpContext.Current.Server.MapPath("/Images/" + fileName)))
            {
                float imageWidth = i.PhysicalDimension.Width;
                float imageHeight = i.PhysicalDimension.Height;
                float percentage = maxWidth / imageWidth;
                float newWidth = imageWidth * percentage;
                float newHeight = imageHeight * percentage;

                if (newHeight > maxHeight)
                {
                    percentage = maxHeight / newHeight;

                    newWidth = newWidth * percentage;
                    newHeight = newHeight * percentage;
                }

                using (Bitmap b = new Bitmap((int)newWidth, (int)newHeight))
                {
                    using (Graphics g = Graphics.FromImage(b))
                    {
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                        g.DrawImage(i, new Rectangle(0, 0, b.Width, b.Height));

                        if (effect == "new")
                        {
                            using (Image j = Image.FromFile(HttpContext.Current.Server.MapPath("/Images/") + "rabbit.png", true))
                            {
                                g.DrawImage(j, new Rectangle((int)newWidth/2, (int)newHeight/2, 200, 200));

                            }
                        }
                        
                        Image newImage = Image.FromHbitmap(b.GetHbitmap());

                        string newImageFile = "/Images/rabbit_new.jpg";
                        string newImageFileFullPath = HttpContext.Current.Server.MapPath(newImageFile);
                        newImage.Save(newImageFileFullPath);

                        return newImageFile;

                    }
                }
            }
        }
    }
}