namespace BandB
{
    class Entity
    {
        public Position position;
        public char entitysHead = 'O';
        public char[] visualRepresentation;
        public int[,] visualRepresentationPosition;

        public Entity(char[] _visualRepresentation)
        {
            visualRepresentation = _visualRepresentation;
            
        }

        public void Move(int x, int y) 
        {
            position.x = x;
            position.y = y;
        }

        
    }

}


