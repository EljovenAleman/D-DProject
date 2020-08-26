using System;

namespace BandB
{


    class Classes : Entity
    {
        public int inteligence;
        public int strenght;
        public int dexerity;
        public int stealth;
        public int perception;

        public int health;
        public Classes(char[] _visualRepresentation) : base(_visualRepresentation)
        {

        }

        public void ProcessInputAction(InputAction pressedKey, Entity player)
        {
            if (pressedKey == InputAction.MoveRight)
            {
                GoRight();
            }
            else if (pressedKey == InputAction.MoveLeft)
            {
                GoLeft();
            }
            else if (pressedKey == InputAction.MoveUp)
            {
                GoUp();
            }
            else if (pressedKey == InputAction.MoveDown)
            {
                GoDown();
            }
            else if (pressedKey == InputAction.PerformAction)
            {
                Inspect(player);
            }

        }

        public void ProcessMenuAction(InputAction pressedKey, string[] options)
        {

        }
        

    

        //Exploring control
         private void GoRight()
         {
             Move(this.position.x + 1, this.position.y);

             //this.visualRepresentationPosition[0, 0] = this.position.y + 1;
             this.visualRepresentationPosition[0, 1] = this.position.x;

             //this.visualRepresentationPosition[1, 0] = this.position.y + 2;
             this.visualRepresentationPosition[1, 1] = this.position.x;

             //this.visualRepresentationPosition[2, 0] = this.position.y + 1;
             this.visualRepresentationPosition[2, 1] = this.position.x - 1;

             //this.visualRepresentationPosition[3, 0] = this.position.y + 1;
             this.visualRepresentationPosition[3, 1] = this.position.x + 1;



         }

         private void GoLeft()
         {
             Move(this.position.x - 1, this.position.y);
              //this.visualRepresentationPosition[0, 0] = this.position.y + 1;
             this.visualRepresentationPosition[0, 1] = this.position.x;

             //this.visualRepresentationPosition[1, 0] = this.position.y + 2;
             this.visualRepresentationPosition[1, 1] = this.position.x;

             //this.visualRepresentationPosition[2, 0] = this.position.y + 1;
             this.visualRepresentationPosition[2, 1] = this.position.x - 1;

             //this.visualRepresentationPosition[3, 0] = this.position.y + 1;
             this.visualRepresentationPosition[3, 1] = this.position.x + 1;

         }

         private void GoUp()
         {
              Move(this.position.x, this.position.y - 1);

              this.visualRepresentationPosition[0, 0] = this.position.y + 1;
              //this.visualRepresentationPosition[0, 1] = this.position.x;

              this.visualRepresentationPosition[1, 0] = this.position.y + 2;
              //this.visualRepresentationPosition[1, 1] = this.position.x;

              this.visualRepresentationPosition[2, 0] = this.position.y + 1;
              //this.visualRepresentationPosition[2, 1] = this.position.x - 1;

              this.visualRepresentationPosition[3, 0] = this.position.y + 1;
              //this.visualRepresentationPosition[3, 1] = this.position.x + 1;



         }

         private void GoDown()
         {
             Move(this.position.x, this.position.y + 1);

             this.visualRepresentationPosition[0, 0] = this.position.y + 1;
             //this.visualRepresentationPosition[0, 1] = this.position.x;

             this.visualRepresentationPosition[1, 0] = this.position.y + 2;
             //this.visualRepresentationPosition[1, 1] = this.position.x;

             this.visualRepresentationPosition[2, 0] = this.position.y + 1;
             //this.visualRepresentationPosition[2, 1] = this.position.x - 1;

             this.visualRepresentationPosition[3, 0] = this.position.y + 1;
             //this.visualRepresentationPosition[3, 1] = this.position.x + 1;



         }

         private void Inspect(Entity player)
         {
            int eventNumber = Scenarios.CheckForEvent(player);
                        
            if(eventNumber == 1)
            {
                Scenarios.ActivateScenario1();
            }
            if(eventNumber == 2)
            {
                Scenarios.ActivateScenario2();
            }
         }

         

    }
}
    



