using ElectronicDevices.Models;
using System.Collections.Generic;

namespace ElectronicDevices.Interfaces
{
    public interface IKindRepository
    {
        public IEnumerable<Kind> Kinds { get; set; }
    }
}
