﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantaLogic;
using PlantaModel;
using System.IO;
/// <summary>
/// Connection to the .txt files
/// </summary>
namespace PlantaDAL
{
    public class PlantaDatabase
    {
        //..GetList(..) = Main reader, Reads the .txt of everything
        //..SetList(..) = Main writer, Writes the .txt of user
        List<string> allFiles = new List<string>();

        //DELETE PLANTS
        public void DeletePlant(PlantaModel.PlantaLibrary.DeletePlant lib, string username)
        {
            //GetList("..\\..\\..\\" + username + ".txt");
            GetList("..\\..\\..\\Kim.txt");
            char delim = '+';
            for (int i = 0; i < allFiles.Count; i++)
            {
                string[] numberStrings = allFiles[i].Split(delim);
                lib.SetPlantNickname(numberStrings[0]);
            }
        }

        public void DeleteUserPlant(string nickname, string username)
        {
            List<string> userPlants = new List<string>();
            StreamReader reader = new StreamReader("..\\..\\..\\Kim.txt");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (WordInLine(line, nickname))
                {
                    continue;
                }
                userPlants.Add(line);
            }
            reader.Close();

            StreamWriter sw = new StreamWriter("..\\..\\..\\Kim.txt");
            for (int i = 0; i < userPlants.Count; i++)
            {
                sw.WriteLine(userPlants[i]);
            }

            sw.Close();
        }

        //ADD PLANTS
        public void AddPlantNames(PlantaModel.PlantaLibrary.AllPlantNames lib, string filename)
        {
            GetList(filename);
            char delim = '+';
            for (int i = 0; i < allFiles.Count; i++)
            {
                string[] numberStrings = allFiles[i].Split(delim);
                lib.SetPlantName(numberStrings[0]);
            }
        }

        public bool nicknameExists(string nickname, string username)
        {
            GetList("..\\..\\..\\" + username + ".txt");
            string[] files = allFiles.ToArray();
            char delim = '+';
            bool exists = false;
            for (int i = 0; i < files.Length; i++)
            {
                string[] numberStrings = files[i].Split(delim);
                if (numberStrings[0] == nickname)
                {
                    exists = true;
                }
            }
            return exists;
        }

        public void AddUserPlant(string selectedNewPlant, string nickname, string username)
        {
            //check the wiki for the selectednewplant
            //save the lines in an array
            //string join the array into the userfile together with the nickname
            //plantnickname, plantname, waterinterval, lastwatered, iconNr
            string plantWikiLine = "";

            StreamReader reader = new StreamReader("..\\..\\..\\Plant_Wiki.txt");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (WordInLine(line, selectedNewPlant))
                {
                    plantWikiLine = line;
                    break;
                }
            }
            reader.Close();
            //Split plant wikiline
            char delim = '+';
            string[] numberStrings = plantWikiLine.Split(delim);

            //Fill new line
            string[] newplant = new string[4];
            newplant[0] = nickname;
            newplant[1] = numberStrings[0];
            newplant[2] = numberStrings[2];
            newplant[3] = DateTime.Today.ToString("dd/MM/yyyy");
            // icons 
            string addedLine = string.Join("+", newplant);

            StreamWriter sw = File.AppendText("..\\..\\..\\Kim.txt");
            sw.WriteLine(addedLine);
            sw.Close();


        }

        static bool WordInLine(string line, string word)
        {
            bool c = line.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0;
            if (c)
            {
                return true;
            }

            return false;
        }

        public void GetList(string filename)
        {
            if (File.Exists(filename))
            {
                int row_count = 0;

                StreamReader reader = new StreamReader(filename);
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    allFiles.Add(line);
                    row_count++;
                }
                reader.Close();
            }
        }
    }
}
