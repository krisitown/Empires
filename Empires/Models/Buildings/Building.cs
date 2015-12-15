using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Models.Interfaces;

namespace Empires.Models
{
    public abstract class Building : IBuilding
    {
        internal int turnsToProduceUnit;
        internal int turnsToProduceResource;

        public abstract IUnit ProduceUnit();
        public abstract IResource ProduceResource();
        public abstract void TurnPass();

        public int TurnsPassed { get; internal set; }
        public bool CanProduceUnit { get; internal set; }
        public bool CanProduceResource { get; internal set; }
    }
}
