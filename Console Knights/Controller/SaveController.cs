using Console_Knights.Assets;
using Console_Knights.Memory;
using Console_Knights.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Knights.Controller
{
    public class SaveController : SaveModel
    {
        private static SaveController instance = null;
        private static readonly object padlock = new object();

        public static SaveController Instance
        {
            get
            {
                lock (padlock)
                {

                    if (instance == null)
                        instance = new SaveController();
                    return instance;
                }
            }
        }

        private void LoadSave(string selectedSave)
        {
            string loadedSaveData = null;
            using (var sr = new StreamReader(selectedSave))
            {
                loadedSaveData = sr.ReadToEnd();
            }
            Hero = JsonConvert.DeserializeObject<Hero>(loadedSaveData);
        }
        public void Save()
        {
            var data = CheckSaves();
            if (data != null)
            {
                Console.WriteLine("Select save to load: ");
                var choose = Console.ReadLine();
                var saveToLoad = data.Select(x => x).Where(x => x.Key == choose).FirstOrDefault().Value;
                if (saveToLoad != null)
                    LoadSave(saveToLoad);
                else
                    Console.WriteLine("Incorect save to load !");
            }
        }
        private Dictionary<string, string> CheckSaves()
        {
            if (Directory.Exists(savePath))
            {
                var counter = 0;
                Dictionary<string, string> loadedSaves = new Dictionary<string, string>();
                string[] filePaths = Directory.GetFiles(savePath);
                foreach (string filePath in filePaths)
                {
                    counter++;
                    loadedSaves.Add(counter.ToString(), filePath);
                    Console.WriteLine(filePath);
                }
                return loadedSaves;
            }
            else
                return null;
        }
        public void CreateSave(AppMemory appMemory)
        {
            Hero = appMemory.mainHero;
            var jsondata = JsonConvert.SerializeObject(Hero);
            using (var sw = new StreamWriter(".", true))
            {
                var fileName = $@"save_{DateTime.Now.ToString("yyyy-MM-dd")}.json";
                sw.Write(jsondata);
                sw.Close();
            }
        }
    }
}
