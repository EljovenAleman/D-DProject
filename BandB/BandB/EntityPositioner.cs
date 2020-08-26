using System.Collections.Generic;

namespace BandB
{
    static class EntityPositioner
    {
        public static void PositionatePlayer(Classes player)
        {
            //Chequear los numeros
            player.Move(10, 10);
        }

        public static void PositionateEnemies(List<EnemySkeleton> enemies)
        {            
            foreach(EnemySkeleton enemy in enemies)
            {
                enemy.Move(enemy.position.x, enemy.position.y);
            }
        }
        
    }
}


