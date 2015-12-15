using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Models.Interfaces
{
    public interface IBuilding
    {
        IUnit ProduceUnit();
        IResource ProduceResource();
        void TurnPass();
        int TurnsPassed { get; }
        bool CanProduceUnit { get; }
        bool CanProduceResource { get; }
    }
}
