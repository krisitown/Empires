using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Enumarations;
using Empires.Models.Interfaces;
using Empires.Models.Units;

namespace Empires.Models
{
    public class Barracks : Building
    {

        public Barracks()
        {
            turnsToProduceResource = 4;
            turnsToProduceUnit = 5;
            TurnsPassed = -1;
        }

        public override IUnit ProduceUnit()
        {
            return new Swordsman();
        }

        public override IResource ProduceResource()
        {
            return new Resource(10, ResourceType.Steel);
        }

        public override void TurnPass()
        {
            TurnsPassed++;
            turnsToProduceResource--;
            turnsToProduceUnit--;
            if (this.turnsToProduceResource == 0)
            {
                //ProduceResource();
                CanProduceResource = true;
                turnsToProduceResource = 3;
            }
            else
            {
                CanProduceResource = false;
            }
            if (this.turnsToProduceUnit == 0)
            {
                //ProduceUnit();
                CanProduceUnit = true;
                turnsToProduceUnit = 4;
            }
            else
            {
                CanProduceUnit = false;
            }
        }

        public override string ToString()
        {
            return string.Format("--Barracks: {0} turns ({1} turns until Swordsman, {2} turns until Steel)", this.TurnsPassed,
                this.turnsToProduceUnit, this.turnsToProduceResource);

        }
    }
}
