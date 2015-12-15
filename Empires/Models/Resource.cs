using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Enumarations;
using Empires.Models.Interfaces;

namespace Empires.Models
{
    public class Resource : IResource
    {
        private int quantity;

        public Resource(int quantity, ResourceType resType)
        {
            this.Quantity = quantity;
            this.ResourceType = resType;
        }

        public ResourceType ResourceType { get; private set; }

        public int Quantity
        {
            get { return this.quantity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The quantity of a resource cannot be negative");
                }
                this.quantity = value;
            }
        }
    }
}
