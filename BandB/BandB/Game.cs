using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace BandB
{
    class Game
    {
        private int movePlayerToStage2 = 0;
        

        public void Start()
        {
            Rogue player = new Rogue(ModelCreator.CreateBasicPlayerModel());
            EntityPositioner.PositionatePlayer(player);
            player.visualRepresentationPosition = ModelCreator.CreateBasicPlayerModelPosition(player);
            World.AddEntity(player);

            Graphics.DrawEntities(World.entities, 1);
            Graphics.DrawLineSeparator();

            while (true)
            {                                        
                if(Scenarios.stageNumber==2)
                {
                    movePlayerToStage2++;
                    if (movePlayerToStage2 == 1)
                    {
                        player.Move(10, 10);
                    }
                }
                if(Scenarios.CheckForEnviromentalEvent(player))
                {
                    Scenarios.ActivateEnviromentalEvent(player);
                }
                
                if (Input.UserPressedGameKey())
                {
                    player.ProcessInputAction(Input.GetInputAction(), player);
                    Graphics.DrawEntities(World.entities, Scenarios.stageNumber);
                    Graphics.DrawLineSeparator();
                    
                }                                
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


