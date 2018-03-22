using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Library of things, Communication between the layers done here! Set-Get methods!
/// </summary>
namespace PlantaModel
{
    public class PlantaLibrary
    {
        //Public class NAME
        //SetName
        //GetName

        //PLANT DELETE
        public class DeletePlant
        {
            List<string> plantNicknames = new List<string>();

            public void SetPlantNickname(string plantnickname)
            {
                plantNicknames.Add(plantnickname);
            }
            public List<string> GetPlantNickname()
            {
                return plantNicknames;
            }
        }
        //PLANT ADD
        public class AllPlantNames
        {
            List<string> plantNames = new List<string>();

            public void SetPlantName(string plantname)
            {
                plantNames.Add(plantname);
            }
            public List<string> GetPlantName()
            {
                return plantNames;
            }
        }
    }
}
