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
    public class Archery : Building
    {
        public Archery()
        {
            turnsToProduceResource = 3;
            turnsToProduceUnit = 4;
            TurnsPassed = -1;
        }

        public override IUnit ProduceUnit()
        {
            return new Archer();
        }

        public override IResource ProduceResource()
        {
            return new Resource(5, ResourceType.Gold);
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
                turnsToProduceResource = 2;
            }
            else
            {
                CanProduceResource = false;
            }
            if (this.turnsToProduceUnit == 0)
            {
                //ProduceUnit();
                CanProduceUnit = true;
                turnsToProduceUnit = 3;
            }
            else
            {
                CanProduceUnit = false;
            }
        }

        public override string ToString()
        {
            return string.Format("--Archery: {0} turns ({1} turns until Archer, {2} turns until Gold)", this.TurnsPassed,
                this.turnsToProduceUnit, this.turnsToProduceResource);

        }
    }
}
