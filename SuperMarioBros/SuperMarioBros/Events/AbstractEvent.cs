using SuperMarioBros.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Events
{
    public abstract class AbstractEvent : IEvent
    {
        public static List<IEvent> Events = new List<IEvent>();

        public static void UpdateAllEvents()
        {
            for (int i = 0; i < Events.Count; i++)
            {
                Events[i].Update();
            }
        }
        public abstract void Update();
    }
}
