namespace BandB
{

    
    class EnemySkeleton : Entity
    {
        public int health;

        public EnemySkeleton(char[] _visualRepresentation) : base(_visualRepresentation)
        {
            health = 30;
        }
    }
}


