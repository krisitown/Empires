using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Empires.Enumarations;
using Empires.Models.Interfaces;

namespace Empires.Persistance
{
    static class EmpiresData
    {
        readonly static List<IBuilding> buildings = new List<IBuilding>();
        readonly static List<IUnit> units = new List<IUnit>();
        readonly static List<IResource> resources = new List<IResource>();

        public static void AddBuilding(IBuilding building)
        {
            if (building == null)
            {
                throw new ArgumentNullException("Cannot add a building with a value of null");
            }
            buildings.Add(building);
        }

        public static void AddUnit(IUnit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException("Cannot add a unit with the value of null");
            }
            units.Add(unit);
        }

        public static void TurnPass()
        {
            foreach (var building in buildings)
            {
                building.TurnPass();
                if (building.CanProduceResource)
                {
                    resources.Add(building.ProduceResource());
                }
                if (building.CanProduceUnit)
                {
                    AddUnit(building.ProduceUnit());
                }
            }
        }

        public static int[] GetResources()
        {
            int goldQuantity = 0;
            int steelQuantity = 0;

            foreach (var resource in resources)
            {
                if (resource.ResourceType == ResourceType.Gold)
                {
                    goldQuantity += resource.Quantity;
                }
                else
                {
                    steelQuantity += resource.Quantity;
                }
            }

            return new int[] {goldQuantity, steelQuantity};
        }

        public static List<IBuilding> Buildings
        {
            get { return buildings; }
        }

        public static List<IUnit> Units
        {
            get { return units; }
        }
    }
}
