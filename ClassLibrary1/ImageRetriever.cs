using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWorker
{
    public class ImageRetriever
    {
        public static ImageList GetImageListDefault(string path)
        {
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(50, 50);

            string[] imageFiles = Directory.GetFiles(path, "*.png");
            foreach (string imageFile in imageFiles)
            {
                Image image = Image.FromFile(imageFile);
                string imageName = Path.GetFileNameWithoutExtension(imageFile);
                //MessageBox.Show(imageName);
                imageList.Images.Add(imageName, image);
            }

            return imageList;
        }

        public static ImageList GetImageList()
        {
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(50, 50);
            string profilePicDirPath = Path.Combine(System.Windows.Forms.Application.StartupPath, "ProfilePictures");

            if (!Directory.Exists(profilePicDirPath))
            {
                Directory.CreateDirectory(profilePicDirPath);
            }
            else
            {
                string[] imageFiles = Directory.GetFiles(profilePicDirPath, "*.png");
                foreach (string imageFile in imageFiles)
                {
                    using (FileStream fs = new FileStream(imageFile, FileMode.Open, FileAccess.Read))
                    {
                        foreach (string fileName in imageFiles)
                        {
                            Image image = Image.FromStream(fs);
                            string imageName = Path.GetFileNameWithoutExtension(fileName);
                            //MessageBox.Show(imageName);
                            imageList.Images.Add(imageName, image);
                        }

                        fs.Close();
                    }
                }
            }

            return imageList;
        }
    }
}
