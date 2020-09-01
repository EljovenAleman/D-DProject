using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace BandB
{
    class Game
    {
        private int movePlayerToStage2 = 0;
        private int movePlayerToStage3 = 0;
                       

        public void Start()
        {
            Rogue player = new Rogue(ModelCreator.CreateBasicPlayerModel());
            EntityPositioner.PositionatePlayer(player);
            player.visualRepresentationPosition = ModelCreator.CreateBasicPlayerModelPosition(player);
            World.AddEntity(player);

            Graphics.DrawEntities(World.entities, 1);
            Graphics.DrawLineSeparator();

            while (Scenarios.gameOnCourse)
            {                                                        
                if(Scenarios.CheckForEnviromentalEvent(player))
                {
                    Scenarios.ActivateEnviromentalEvent(player);
                }
                
                if (Input.UserPressedGameKey())
                {
                    player.ProcessInputAction(Input.GetInputAction(), player);
                    if (Scenarios.stageNumber == 2)
                    {
                        movePlayerToStage2++;
                        if (movePlayerToStage2 == 1)
                        {                            
                            player.Move(15, 18);
                            player.GoUp();
                            player.GoRight();
                        }
                    }
                    else if(Scenarios.stageNumber == 3)
                    {
                        movePlayerToStage3++;
                        if(movePlayerToStage3 == 1)
                        {
                            player.GoUp();
                            player.GoRight();
                        }
                    }
                    Graphics.DrawEntities(World.entities, Scenarios.stageNumber);
                    Graphics.DrawLineSeparator();                    
                }                                
            }

            if(Scenarios.gameWon==false)
            {
                Console.SetCursorPosition(10,24);
                Console.WriteLine("You are dead");
            }
            else
            {
                Console.SetCursorPosition(10, 24);
                Console.WriteLine("Congratulations! You won!!");
            }
            Console.ReadKey();
        }

        /*public void ActivateMenuControl(Entity player, string[] options)
        {
            while(menuActive)
            {
                if (Input.UserPressedGameKey())
                {
                    //Estoy pasando un InputAction y dice que no puedo pasar un argumento de tipo Entity??

                    player.ProcessMenuAction(Input.GetInputAction(), options);
                    Graphics.DrawEntities(World.entities, 1);
                    Graphics.DrawLineSeparator();
                }
            }
        }*/

    }

    

    
        

    
}


