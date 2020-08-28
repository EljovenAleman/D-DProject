using System;
using System.Collections.Generic;

namespace BandB
{
    static class Scenarios
    {
        static int selectedOption = 0;
        public static int stageNumber = 3;
        public static int enviromentalEvent = 0;

        static public int CheckForEvent(Entity player)
        {
            int eventNumber = 0;
            if (stageNumber == 1 && player.position.y >= 5 && player.position.y <= 10 &&
                 player.position.x >= 45 && player.position.x <= 65)
            {
                eventNumber = 1;
                return eventNumber;
            }
            else if(stageNumber == 2 && player.position.y >= 10 && player.position.y<=14 &&
                player.position.x >=22 && player.position.x <= 27)
            {
                eventNumber = 2;
                return eventNumber;
            }
            

                return eventNumber;
        }

        static public bool CheckForEnviromentalEvent(Entity player)
        {
            if (stageNumber == 2 && player.position.x >= 36 && player.position.x <= 45 &&
                player.position.y >= 14 && player.position.y <= 21)
            {
                enviromentalEvent = 1;
                return true;
            }
            else if (stageNumber == 2 && player.position.x > 65)
            {
                enviromentalEvent = 2;
                return true;
            }
            else if (stageNumber == 3 && player.position.x > 15)
            {
                enviromentalEvent = 3;
                return true;
            }

            return false;
        }

        //Scenario1 es entrar en la cueva
        static public void ActivateScenario1()
        {
            string menuDialogue = "You see an entrance in the cavern in front of you. Do you enter?";
            string[] options = new string[2];

            options[0] = "1 Yes";
            options[1] = "2 No";

            Graphics.DrawMenu(options, menuDialogue);

            string line = Console.ReadLine();
            selectedOption = int.Parse(line);
            if(selectedOption == 1)
            {
                Console.Write("You enter the cavern");
                stageNumber = 2;
                Console.ReadKey();
                Console.Clear();
                
            }
            else if (selectedOption == 2)
            {
                Console.Write("You do not enter the cavern");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static public void ActivateScenario2()
        {
            string menuDialogue = "There is something strange about this algae in the wall...";
            string[] options = new string[2];

            options[0] = "1 Pull";
            options[1] = "2 Leave";

            Graphics.DrawMenu(options, menuDialogue);

            string line = Console.ReadLine();
            selectedOption = int.Parse(line);
            if (selectedOption == 1)
            {
                Console.WriteLine("As you pull from the algae, something comes off");
                Console.WriteLine();
                Console.WriteLine("You have aquired a fire bomb");
                Console.ReadKey();
                Console.Clear();

            }
            else if (selectedOption == 2)
            {
                Console.Write("You leave the algae alone");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static public void ActivateEnviromentalEvent(Entity player)
        {
            if(enviromentalEvent == 1)
            {
                ActivateEnviromentalEvent1(player);
            }
            else if (enviromentalEvent == 2)
            {
                ActivateEnviromentalEvent2(player);
            }
            else if (enviromentalEvent == 3)
            {
                ActivateEnviromentalEvent3(player);
            }
        }

        static private void ActivateEnviromentalEvent1(Entity player)
        {
            enviromentalEvent = 0;
            int rollValue = 0;
            string menuDialogue = "You are about to fall on a very deep hole. You have to make a decision";
            string[] options = new string[3];

            options[0] = "1 Perception";
            options[1] = "2 Strength";
            options[2] = "3 Dexerity";
            
            Graphics.DrawMenu(options, menuDialogue);

            string line = Console.ReadLine();
            selectedOption = int.Parse(line);

            if(selectedOption == 1)
            {
                rollValue = RNG.RollD20();
            }
            if (selectedOption == 2)
            {
                rollValue = RNG.RollD20();
            }
            if (selectedOption == 3)
            {
                rollValue = RNG.RollD20();
            }

            if(selectedOption == 1)
            {
                if(rollValue<6)
                {
                    string rollQuality = "low";
                    EnviromentalEvent1Perception(rollQuality, rollValue);                                       
                }
                else if(rollValue<15)
                {
                    string rollQuality = "medium";
                    EnviromentalEvent1Perception(rollQuality, rollValue);
                    player.Move(player.position.x - 2, player.position.y);
                }
                else if(rollValue>=15)
                {
                    string rollQuality = "high";
                    EnviromentalEvent1Perception(rollQuality, rollValue);
                    player.Move(player.position.x + 12, player.position.y);

                }
            }
        }

        static private void EnviromentalEvent1Perception(string rollQuality, int rollValue)
        {
            Console.WriteLine();
            Console.WriteLine("Rolled D20: " + rollValue);

            if(rollQuality=="low")
            {
                Console.WriteLine("As you walk further into the cavern, you don't even notice the enormous hole on the ground");
                Console.WriteLine("you fall into your death");
                Console.ReadKey();
                Console.Clear();
            }
            else if(rollQuality=="medium")
            {
                Console.WriteLine("You barely see hole with the corner of your eye and manage to trip backwards saving yourself");                
                Console.ReadKey();
                Console.Clear();
            }
            else if(rollQuality=="high")
            {
                Console.WriteLine("You already knew there was a hole on the ground and jump towards it");
                Console.WriteLine("doing a backflip in the air and gracefully landing on the other side");               
                Console.ReadKey();
                Console.Clear();
            }
        }

        static private void ActivateEnviromentalEvent2(Entity player)
        {
            player.Move(10, 10);
            stageNumber = 3;
        }

        static private void ActivateEnviromentalEvent3(Entity player)
        {

            EnemySkeleton enemy1 = new EnemySkeleton(ModelCreator.CreateSkeletonModel());
            EnemySkeleton enemy2 = new EnemySkeleton(ModelCreator.CreateSkeletonModel());
            EnemySkeleton enemy3 = new EnemySkeleton(ModelCreator.CreateSkeletonModel());

            enemy1.Move(23, 13);
            enemy2.Move(23, 19);
            enemy3.Move(33, 16);

            List<EnemySkeleton> enemies = new List<EnemySkeleton>();
            enemies.Add(enemy1);
            enemies.Add(enemy2);
            enemies.Add(enemy3);
                                  
            foreach(EnemySkeleton enemy in enemies)
            {
                enemy.visualRepresentationPosition = ModelCreator.CreateSkeletonModelPosition(enemy);
            }

            World.AddEntity(enemy1);
            World.AddEntity(enemy2);
            World.AddEntity(enemy3);
            Graphics.DrawEntities(World.entities,3);

            StartFight(player, enemies);

            stageNumber = 4;

            

        }


        //Hay que resolver un problema que pasa cuando golpeas al "tercer enemigo"
        static void StartFight(Entity player, List<EnemySkeleton> enemies)
        {
            int target = 0;
            int numberRolled = 0;
            int enemiesLeft = 3;
            int naturalRolled = 0;

            
            

            Console.SetCursorPosition(10, 24);
            Console.WriteLine("Two melee and 1 range Tutorial Skeletons appear in front of you.");
            Console.WriteLine("Get ready!");
            Console.ReadKey();
            Graphics.ClearMenu();

            while (enemiesLeft>0)
            {
                target = AskToSelectTargetToAttack(enemiesLeft, enemies);
                Graphics.ClearMenu();

                string menuDialogue = "Perform an Action";

                string[] optionsAvailable = new string[3];
                optionsAvailable[0] = "1 Strenght";
                optionsAvailable[1] = "2 Dexerity";

                Graphics.DrawMenu(optionsAvailable, menuDialogue);

                string line = Console.ReadLine();
                selectedOption = int.Parse(line);
                if (selectedOption == 1)
                {
                    numberRolled = RNG.RollD20() + player.strenght;
                    naturalRolled = numberRolled - player.strenght;
                    Console.WriteLine("Rolled D20+" + player.strenght + "=" + numberRolled + "(" +naturalRolled+ ")");
                    if(SuccesfullHit(numberRolled))
                    {
                        enemies[target].health =- numberRolled - 5;
                    }
                    else
                    {
                        Console.WriteLine("You missed the hit!");
                    }
                    
                }
                else if (selectedOption == 2)
                {
                    numberRolled = RNG.RollD20() + player.dexerity;
                    if (SuccesfullHit(numberRolled))
                    {
                        enemies[target].health = -numberRolled - 5;
                    }
                    else
                    {
                        Console.WriteLine("You missed the hit!");
                    }
                }

                foreach (EnemySkeleton enemy in enemies)
                {
                    if(enemy.health<1)
                    {                        
                        enemy.entitysHead = 'X';                       
                        
                    }
                }

                Graphics.DrawEntities(World.entities,3);
            }    
        }

        static int AskToSelectTargetToAttack(int enemiesLeft, List<EnemySkeleton> enemies)
        {
            string menuDialogue = "Select a target to attack!";

            string[] optionsAvailable = new string[enemiesLeft];
            
            if (enemiesLeft == 1)
            {
                optionsAvailable[0] = "1 First enemy";                
            }
            if (enemiesLeft == 2)
            {
                optionsAvailable[0] = "1 First enemy";
                optionsAvailable[1] = "2 Second enemy";
            }
            if(enemiesLeft==3)
            {
                optionsAvailable[0] = "1 First enemy";
                optionsAvailable[1] = "2 Second enemy";
                optionsAvailable[2] = "3 Third enemy";
            }

            Graphics.DrawMenu(optionsAvailable, menuDialogue);
            string line = Console.ReadLine();
            int selectedOption = int.Parse(line);

            return selectedOption;
        }

        static bool SuccesfullHit(int numberRolled)
        {
            if (numberRolled > 9)
            {
                return true;
            }

            return false;
        }

    }
        

    
}


