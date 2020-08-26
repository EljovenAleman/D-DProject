using System.Collections.Generic;

namespace BandB
{
    static class World
    {
        public static List<Entity> entities = new List<Entity>();



        static public void AddEntity(Entity entity)
        {
            entities.Add(entity);
        }

    }
}


