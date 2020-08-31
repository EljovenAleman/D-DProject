using System;
using System.Collections.Generic;

namespace BandB
{
    static class Scenarios
    {
        static int target = 0;
        static int numberRolled = 0;
        static int enemiesLeft = 3;
        static int naturalRolled = 0;
        static bool stillFighting = true;
        static int enemiesToKill = 3;
        static int selectedOption = 0;
        public static int stageNumber = 1;
        public static int enviromentalEvent = 0;
        public static bool gameOnCourse = true;
        public static bool gameWon = false;
        public static bool healingPotionObtained = false;

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
            else if(stageNumber == 4 && player.position.x> 40)
            {
                enviromentalEvent = 4;
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
                if(healingPotionObtained==false)
                {
                    Console.WriteLine("As you pull from the algae, something comes off");
                    Console.WriteLine();
                    Console.WriteLine("You have adquired a healing potion!");
                    healingPotionObtained = true;
                    Console.ReadKey();
                    Graphics.ClearMenu();
                }
                else
                {
                    Console.Write("You already checked this algae and found a healing potion");
                    Console.ReadKey();
                    Graphics.ClearMenu();
                }
                

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
            else if (enviromentalEvent == 4)
            {
                ActivateEnviromentalEvent4(player);
            }
        }

        //--

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
                rollValue = RNG.RollD20()+player.perception;
            }
            else if (selectedOption == 2)
            {
                rollValue = RNG.RollD20()+player.strenght;
            }
            else if (selectedOption == 3)
            {
                rollValue = RNG.RollD20()+player.dexerity;
            }

            if(selectedOption == 1)
            {
                if(rollValue<7)
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
            else if(selectedOption == 2)
            {
                if (rollValue < 7)
                {
                    string rollQuality = "low";
                    EnviromentalEvent1Strength(rollQuality, rollValue);
                }
                else if (rollValue < 15)
                {
                    string rollQuality = "medium";
                    EnviromentalEvent1Strength(rollQuality, rollValue);
                    player.Move(player.position.x - 2, player.position.y);
                }
                else if (rollValue >= 15)
                {
                    string rollQuality = "high";
                    EnviromentalEvent1Strength(rollQuality, rollValue);
                    player.Move(player.position.x + 12, player.position.y);

                }
            }
            else if (selectedOption == 3)
            {
                if (rollValue < 9)
                {
                    string rollQuality = "low";
                    EnviromentalEvent1Dexerity(rollQuality, rollValue);
                }
                else if (rollValue < 15)
                {
                    string rollQuality = "medium";
                    EnviromentalEvent1Dexerity(rollQuality, rollValue);
                    player.Move(player.position.x - 2, player.position.y);
                }
                else if (rollValue >= 15)
                {
                    string rollQuality = "high";
                    EnviromentalEvent1Dexerity(rollQuality, rollValue);
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
                gameOnCourse = false;
                gameWon = false;
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
                Console.WriteLine("You clearly see a big hole on the ground a mean it's really fucking obvious");
                Console.WriteLine("you walk through the safe space on the left like a normal human being");               
                Console.ReadKey();
                Console.Clear();
            }
        }

        static private void EnviromentalEvent1Strength(string rollQuality, int rollValue)
        {
            Console.WriteLine();
            Console.WriteLine("Rolled D20: " + rollValue);

            if (rollQuality == "low")
            {
                Console.WriteLine("As you fall you your best to grab to the edge of the hole, but you are too weak");
                Console.WriteLine("you fall into your death");
                gameOnCourse = false;
                gameWon = false;
                Console.ReadKey();
                Console.Clear();
            }
            else if (rollQuality == "medium")
            {
                Console.WriteLine("You extend your arms and manage to grab on a hanging algae, lucky for you it is strong enough");
                Console.WriteLine("You climb your way back to the surface");
                Console.ReadKey();
                Console.Clear();
            }
            else if (rollQuality == "high")
            {
                Console.WriteLine("As you fall you punch a hole in the wall because you are FUCKING STRONG");
                Console.WriteLine("then climb your way up");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static private void EnviromentalEvent1Dexerity(string rollQuality, int rollValue)
        {
            Console.WriteLine();
            Console.WriteLine("Rolled D20: " + rollValue);

            if (rollQuality == "low")
            {
                Console.WriteLine("As you aproach to the big gap on the ground you try go for a jump and trip over a rock");
                Console.WriteLine("you fall into your death");
                gameOnCourse = false;
                gameWon = false;
                Console.ReadKey();
                Console.Clear();
            }
            else if (rollQuality == "medium")
            {
                Console.WriteLine("As you aproach to the big gap on the ground you go for a jump and make it just far enough");
                Console.WriteLine("for you to grab on the ledge on the other side of the hole an climb your way up");
                Console.ReadKey();
                Console.Clear();
            }
            else if (rollQuality == "high")
            {
                Console.WriteLine("You stand on the edge of the hole facing backwards and jump");
                Console.WriteLine("doing a backflip in the air and gracefully landing on the other side");
                Console.WriteLine("you are awesome");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //--

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

        static private void ActivateEnviromentalEvent4(Entity player)
        {
            gameOnCourse = false;
            gameWon = true;
        }



       
        static void StartFight(Entity player, List<EnemySkeleton> enemies)
        {                                    
            Console.SetCursorPosition(10, 24);
            Console.WriteLine("Two melee and 1 range Tutorial Skeletons appear in front of you.");
            Console.WriteLine("Get ready!");
            Console.ReadKey();
            Graphics.ClearMenu();

            while (stillFighting)
            {
                target = AskToSelectTargetToAttack(enemiesLeft, enemies);
                Graphics.ClearMenu();

                AskToPerformAnAction();

                string line = Console.ReadLine();
                selectedOption = int.Parse(line);
                if (selectedOption == 1)
                {
                    numberRolled = RNG.RollD20() + player.strenght;
                    naturalRolled = numberRolled - player.strenght;
                    Console.WriteLine("Rolled D20+" + player.strenght + "=" + numberRolled + "(" +naturalRolled+ ")");

                    if(SuccesfullHit(numberRolled, selectedOption))
                    {
                        SucessfullAtackPromp(enemies, selectedOption);
                    }
                    else
                    {
                        Console.WriteLine("You missed the hit!");
                        Console.ReadKey();
                        Graphics.ClearMenu();
                    }
                    
                }
                else if (selectedOption == 2)
                {
                    numberRolled = RNG.RollD20() + player.dexerity;
                    naturalRolled = numberRolled - player.dexerity;
                    Console.WriteLine("Rolled D20+" + player.dexerity + "=" + numberRolled + "(" + naturalRolled + ")");

                    if (SuccesfullHit(numberRolled, selectedOption))
                    {
                        SucessfullAtackPromp(enemies, selectedOption);
                    }
                    else
                    {
                        Console.WriteLine("You missed the hit!");
                        Console.ReadKey();
                        Graphics.ClearMenu();
                    }
                }

                enemiesToKill = 3;
                CheckForDeadEnemies(enemies);               

                if (enemiesToKill == 0)
                {
                    stillFighting = false;
                }

                Graphics.DrawEntities(World.entities,3);

                EnemyTurnToAttack(player, enemies);

                CheckIfPlayerIsAlive(player);

            }
            if(gameOnCourse == true)
            {
                Console.SetCursorPosition(10, 24);
                Console.WriteLine("Your enemies are no more.");
                Console.ReadKey();
                Graphics.ClearMenu();
            }
            
        }

        //el enemiesLeft no hace nada porque no se eliminar Enemy de una lista sin que tire error
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

        static bool SuccesfullHit(int numberRolled, int selectedOption)
        {
            if(selectedOption==1 && numberRolled >= 15)
            {
                return true;
            }
            else if(selectedOption == 2 && numberRolled >= 7)
            {
                return true;
            }
            else if(selectedOption == 3 && numberRolled >= 10)
            {
                return true;
            }

            return false;
        }

        static void AskToPerformAnAction()
        {
            string menuDialogue = "Perform an Action";

            string[] optionsAvailable = new string[3];
            optionsAvailable[0] = "1 Strenght";
            optionsAvailable[1] = "2 Dexerity";

            Graphics.DrawMenu(optionsAvailable, menuDialogue);
        }

        static void SucessfullAtackPromp(List<EnemySkeleton> enemies, int selectedOption)
        {
            int damageDone = 0;
            if(selectedOption==1)
            {
                damageDone = numberRolled;
            }
            else if(selectedOption == 2)
            {
                damageDone = numberRolled - 6;
            }            
            enemies[target - 1].health = enemies[target - 1].health - damageDone;
            Console.WriteLine("Damage Done= " + damageDone);
            Console.WriteLine("Skeleton health: " + enemies[target - 1].health);
            Console.ReadKey();
            Graphics.ClearMenu();
        }

        static void CheckForDeadEnemies(List<EnemySkeleton> enemies)
        {
            foreach (EnemySkeleton enemy in enemies)
            {
                if (enemy.health < 1)
                {
                    enemy.entitysHead = 'X';
                    enemiesToKill--;
                }
            }
        }

        static void EnemyTurnToAttack(Entity player, List<EnemySkeleton> enemies)
        {
            Console.SetCursorPosition(0, 26);
            int enemyTotalDamage = 0;
            numberRolled = 0;
            int damageDone = 0;
            for(int f = 0; f<enemiesToKill; f++)
            {
                numberRolled = RNG.RollD20();
                if(SuccesfullHit(numberRolled, 3))
                {
                    damageDone = numberRolled - 5;
                    enemyTotalDamage = enemyTotalDamage + damageDone;

                    Console.WriteLine("Enemy " + (f+1) + " damage dealt: " + damageDone);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("You dodge enemy " + (f+1) + "'s hit!");
                    Console.ReadKey();
                }                
            }

            player.health = player.health - enemyTotalDamage;
            Console.WriteLine("Your health is: " + player.health);
            Console.ReadKey();
            Graphics.ClearMenu();

        }

        static void CheckIfPlayerIsAlive(Entity player)
        {
            if(player.health<1)
            {
                if(healingPotionObtained == true)
                {
                    Console.SetCursorPosition(0,27);
                    Console.WriteLine("You use the healing potion");
                    player.health = 30;
                    healingPotionObtained = false;
                    Console.WriteLine("Your health is: " + player.health);
                    Console.ReadKey();
                    Graphics.ClearMenu();
                }
                else
                {
                    stillFighting = false;
                    gameOnCourse = false;
                    gameWon = false;
                }
                
            }
        }

    }
        

    
}


