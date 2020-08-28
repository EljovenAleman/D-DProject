namespace BandB
{
    static class ModelCreator
    {
        static public char[] CreateBasicPlayerModel()
        {
            char[] BodyModel = new char[4];

            BodyModel[0] = '|';
            BodyModel[1] = 'A';
            BodyModel[2] = '/';
            BodyModel[3] = '\\';

            return BodyModel;
        }

        static public char[] CreateSkeletonModel()
        {
            char[] BodyModel = new char[4];

            BodyModel[0] = '8';
            BodyModel[1] = 'A';
            BodyModel[2] = '/';
            BodyModel[3] = '\\';

            return BodyModel;
        }

        static public int[,] CreateBasicPlayerModelPosition(Classes player)
        {
            int[,] BodyModelPosition = new int[4, 2];

            BodyModelPosition[0, 0] = player.position.y + 1;
            BodyModelPosition[0, 1] = player.position.x;

            BodyModelPosition[1, 0] = player.position.y + 2;
            BodyModelPosition[1, 1] = player.position.x;

            BodyModelPosition[2, 0] = player.position.y + 1;
            BodyModelPosition[2, 1] = player.position.x - 1;

            BodyModelPosition[3, 0] = player.position.y + 1;
            BodyModelPosition[3, 1] = player.position.x + 1;

            return BodyModelPosition;
        }

        static public int[,] CreateSkeletonModelPosition(EnemySkeleton enemy)
        {
            int[,] BodyModelPosition = new int[4, 2];

            BodyModelPosition[0, 0] = enemy.position.y + 1;
            BodyModelPosition[0, 1] = enemy.position.x;

            BodyModelPosition[1, 0] = enemy.position.y + 2;
            BodyModelPosition[1, 1] = enemy.position.x;

            BodyModelPosition[2, 0] = enemy.position.y + 1;
            BodyModelPosition[2, 1] = enemy.position.x - 1;

            BodyModelPosition[3, 0] = enemy.position.y + 1;
            BodyModelPosition[3, 1] = enemy.position.x + 1;

            return BodyModelPosition;
        }
    }
        

    
}


