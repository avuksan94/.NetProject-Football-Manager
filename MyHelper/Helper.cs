using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace MyHelper
{
    public class Helper
    {
        public static ImageList GetImageListDefault(string path)
        {
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(50, 50);

            string[] imageFiles = Directory.GetFiles(path, "*.png");
            foreach (string imageFile in imageFiles)
            {
               Image image = Image.FromFile(imageFile);
                imageList.Images.Add(image);
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
                        Image image = Image.FromStream(fs);
                        imageList.Images.Add(image);
                        fs.Close();
                    }
                }
            }

            return imageList;
        }
    }
}