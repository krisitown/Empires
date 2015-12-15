using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Enumarations;

namespace Empires.Models.Interfaces
{
    public interface IResource
    {
        ResourceType ResourceType { get; }
        int Quantity { get; set; }
    }
}
