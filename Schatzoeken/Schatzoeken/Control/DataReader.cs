using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Windows.Storage;
using Schatzoeken.Model;

namespace Schatzoeken.Control
{
    public class DataReader
    {
        private string padPlayers = @"players.txt";
        private readonly StorageFolder dataPath;
        List<Person> persons = new List<Person>();
        //singleton
        private static DataReader datareader = null;

        private DataReader()
        {
            dataPath = ApplicationData.Current.LocalFolder;
            initDataConnector();
        }

        public static DataReader GetDataReader()
        {
            if (datareader == null)
                datareader = new DataReader();
            return datareader;
        }

        private async Task initDataConnector()
        {
            await loadPersons();
        }

        private async Task loadPersons()
        {
            try
            {
                var file = await dataPath.GetFileAsync(padPlayers);
                var lines = await FileIO.ReadLinesAsync(file);
                if (lines.Count < 2)
                    return;
                for (int i = 0; i < lines.Count - 1; i += 2)
                {
                    string name = lines[i] as string;
                    int score = int.Parse(lines[i + 1] as string);
                    persons.Add(new Model.Person(name, score));
                }
            }
            catch (FormatException e)
            {
                Debug.Print(e.StackTrace);
            }
        }

        public List<Model.Person> GetPersonsFromHighscore()
        {
            //werkt niet
            persons.OrderBy(p => p.GetScore()).ToList().Reverse();
            return persons;
        }

        private async void savePerson()
        {
            var _Option = Windows.Storage.CreationCollisionOption.ReplaceExisting;
            var _File = await dataPath.CreateFileAsync(padPlayers, _Option);
            string fileText = "";
            foreach (Model.Person person in persons)
                fileText += person.Name + "\r\n" + person.GetScore().ToString() + "\r\n";
            await Windows.Storage.FileIO.WriteTextAsync(_File, fileText);
        }

        public async void SavePerson(Model.Person person)
        {
            persons.Add(person);
            savePerson();
        }
    }    
}
