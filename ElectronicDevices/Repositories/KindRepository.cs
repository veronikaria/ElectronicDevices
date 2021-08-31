using ElectronicDevices.EF;
using ElectronicDevices.Interfaces;
using ElectronicDevices.Models;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicDevices.Repositories
{
    public class KindRepository : IKindRepository
    {
        private readonly ApplicationContext context;

        public KindRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public IEnumerable<Kind> Kinds 
        {
            get => this.context.Kinds.ToList(); 
        }
    }
}
