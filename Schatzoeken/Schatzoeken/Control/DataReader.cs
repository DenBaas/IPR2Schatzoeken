using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Windows.Storage;

namespace Schatzoeken.Control
{
    public class DataReader
    {
        private  string pad = @"players.txt";
        private readonly StorageFolder dataPath;
        private StorageFile routePath;
        private StorageFile players;
        List<Model.Person> persons = new List<Model.Person>();
        private static DataReader datareader = null;

        private DataReader()
        {
            dataPath = ApplicationData.Current.LocalFolder;
            initDataConnector();
            //save();
        }

        public static DataReader GetDataReader()
        {
            if (datareader == null)
                datareader = new DataReader();
            return datareader;
        }

        private async Task initDataConnector()
        {
            //players = await dataPath.GetFileAsync(pad);
            //players.OpenReadAsync();
            //Debug.Print("o");
            await load();
        }

        private async Task load()
        {
            try
            {
                var file = await dataPath.GetFileAsync(pad);
                var lines = await FileIO.ReadLinesAsync(file);
                for (int i = 0; i < lines.Count - 1; i += 2)
                {
                    string name = lines[i] as string;
                    int score = int.Parse(lines[i + 1] as string);
                    persons.Add(new Model.Person(name, score));
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.StackTrace);
            }
        }

        public List<Model.Person> GetPersonsFromHighscore()
        {
            return persons;
        }

        private async void save()
        {
            var _Option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _File = await dataPath.CreateFileAsync(pad, _Option);
            string fileText = "";
            foreach (Model.Person person in persons)
                fileText += person.Name + "\r\n" + person.getScore().ToString() + "\r\n";
            await Windows.Storage.FileIO.WriteTextAsync(_File, fileText);
        }

        public async void Save(Model.Person person)
        {
            persons.Add(person);
            persons = persons.OrderBy(p => p.getScore()).ToList();
            save();
        }
    }    
}
