using DL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using MyWorker;
using DL.Model;

namespace BL.Services
{
    public class DataService
    {
        public const char DELIMITER = '|';
        string cbPath = Path.Combine(Application.StartupPath, Constants.COMBO_BOXES);

        public IDictionary<string, SortedSet<Player>> MenPlayers;
        public IDictionary<string, SortedSet<Player>> FemalePlayers;

        public DataService() 
        {
            CheckIfExists();
        }

        public void SaveLocal(Dictionary<string, Control> controlDict)
        {
            using (StreamWriter comboBoxWriter = new StreamWriter(cbPath))
            {
                foreach (KeyValuePair<string, Control> kvp in controlDict)
                {
                    if (kvp.Value is ComboBox)
                    {
                        ComboBox comboBox = (ComboBox)kvp.Value;
                        comboBoxWriter.Write($"{kvp.Key}|{comboBox.SelectedIndex.ToString()}{Environment.NewLine}");
                    }
                }
                comboBoxWriter.Close();
            }
            
        }

        public void LoadLocal(Dictionary<string, Control> controlDict)
        {

            using (StreamReader comboBoxReader = new StreamReader(cbPath))
            {
                string line;
                while ((line = comboBoxReader.ReadLine()) != null)
                {
                    string[] data = line.Split(DELIMITER);
                    foreach (KeyValuePair<string, Control> kvp in controlDict)
                    {
                        if (kvp.Value is ComboBox)
                        {
                            if (kvp.Value.Name == data[0])
                            {
                                int selectedInd = int.Parse(data[1]);
                                ComboBox comboBox = (ComboBox)kvp.Value;
                                comboBox.SelectedIndex = selectedInd;
                            }
                        }
                    }
                }
                comboBoxReader.Close();
            }
        }

        public void CheckIfExists() 
        {
            if (!File.Exists(cbPath))
            {
                File.Create(cbPath).Close();
            }
        }

    }
}
