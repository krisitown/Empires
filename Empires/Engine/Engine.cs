using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.IO;
using Empires.IO.Interfaces;
using Empires.Models;
using Empires.Models.Units;
using Empires.Persistance;

namespace Empires.Engine
{
    public class Engine
    {
        public Engine()
        {
        }

        IReader reader = new Reader();
        IWriter writer = new Writer();

        public void Run()
        {
            string line = reader.ReadLine();
            while (line != "armistice")
            {
                string[] tokens = line.Split(' ');
                switch (tokens[0])
                {
                    case "build":
                        CreateBuilding(tokens[1]);
                        EmpiresData.TurnPass();
                        break;
                    case "skip":
                        EmpiresData.TurnPass();
                        break;
                    case "empire-status":
                        PrintStatus();
                        EmpiresData.TurnPass();
                        break;
                }
                line = reader.ReadLine();
            }
        }

        private void PrintStatus()
        {
            int[] resources = EmpiresData.GetResources();
            int[] unitCount = new int[2];

            StringBuilder sb = new StringBuilder();
            sb.Append("Treasury:\n--Gold: ");
            sb.AppendLine(resources[0].ToString());
            sb.Append("--Steel: ");
            sb.AppendLine(resources[1].ToString());
            sb.AppendLine("Buildings:");
            foreach (var building in EmpiresData.Buildings)
            {
                sb.AppendLine(building.ToString());
            }
            if (EmpiresData.Buildings.Count == 0)
            {
                sb.AppendLine("N/A");
            }
            sb.AppendLine("Units:");
            foreach (var unit in EmpiresData.Units)
            {
                if (unit is Archer)
                {
                    unitCount[0]++;
                }
                else
                {
                    unitCount[1]++;
                }
            }
            if (EmpiresData.Units.Count == 0)
            {
                sb.AppendLine("N/A");
            }
            else
            {
                if (EmpiresData.Units[0] is Archer)
                {
                    if (unitCount[0] != 0)
                    {
                        sb.AppendLine("--Archer: " + unitCount[0]);
                    }
                    if (unitCount[1] != 0)
                    {
                        sb.AppendLine("--Swordsman: " + unitCount[1]);
                    }
                }
                else
                {
                    if (unitCount[1] != 0)
                    {
                        sb.AppendLine("--Swordsman: " + unitCount[1]);
                    }
                    if (unitCount[0] != 0)
                    {
                        sb.AppendLine("--Archer: " + unitCount[0]);
                    }
                }
            }
            writer.WriteLine(sb.ToString());
        }

        private void CreateBuilding(string type)
        {
            if (type.ToUpperInvariant() == "ARCHERY")
            {
                EmpiresData.AddBuilding(new Archery());
            }
            if (type.ToUpperInvariant() == "BARRACKS")
            {
                EmpiresData.AddBuilding(new Barracks());
            }
        }
    }
}
