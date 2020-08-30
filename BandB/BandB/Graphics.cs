using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace BandB
{
    static class Graphics
    {
        public static char[,] matrix = new char[40, 90];


        public static void DrawEntities(List<Entity> entities, int stageNumber)
        {
            Console.SetCursorPosition(0, 0);
            ResetScreen();
            GenerateStage(stageNumber);
            PositionateHeads(entities);
            PositionateVisuals(entities);
            ShowVisuals();
        }


        public static void DrawMenu(String[] optionsAvailable, string menuDialogue)
        {
            Console.SetCursorPosition(10, 24);
            Console.Write(menuDialogue);

            for (int f = 0; f < optionsAvailable.Length; f++)
            {
                Console.SetCursorPosition(5, 26 + f);
                Console.WriteLine(optionsAvailable[f]);
            }
        }

        //arreglar esto con un for()
        public static void ClearMenu()
        {
            Console.SetCursorPosition(10, 24);
            Console.Write("                                                                        ");
            Console.Write("                                                                        ");
            Console.Write("                                                                        ");
            Console.Write("                                                                        ");
            Console.Write("                                                                        ");
            Console.Write("                                                                        ");
            Console.Write("                                                                        ");
            Console.Write("                                                                        ");          
            Console.Write("                                                                        ");          
            Console.Write("                                                                        ");          
            Console.Write("                                                                        ");          
            Console.Write("                                                                        ");          
            Console.Write("                                                                        ");          
            Console.Write("                                                                        ");          
            Console.Write("                                                                        ");          
            Console.Write("                                                                        ");          
            Console.Write("                                                                        ");          
            Console.Write("                                                                        ");          
            Console.Write("                                                                        ");          
        }

        public static void ClearScreen()
        {
            Console.Clear();
        }

        private static void ResetScreen()
        {
            for (int f = 0; f < 22; f++)
            {
                for (int c = 0; c < 80; c++)
                {
                    matrix[f, c] = ' ';
                }
            }
        }

        private static void PositionateHeads(List<Entity> entities)
        {
            foreach (Entity entity in entities)
            {
                matrix[entity.position.y, entity.position.x] = entity.entitysHead;
            }
        }

        private static void ShowVisuals()
        {
            for (int f = 0; f < 22; f++)
            {
                for (int c = 0; c < 79; c++)
                {
                    Console.Write(matrix[f, c]);
                }
                Console.WriteLine();
            }
        }

        private static void GenerateStage(int stageNumber)
        {
            if (stageNumber == 1)
            {
                GenerateStageOne();
            }
            else if (stageNumber == 2)
            {
                GenerateStageTwo();
            }
            else if (stageNumber == 3 || stageNumber == 4)
            {
                GenerateStageThree();
            }

        }

        private static void PositionateVisuals(List<Entity> entities)
        {
            foreach(Entity entity in entities)
            {
                for(int f=0; f<4; f++)
                {
                    matrix[entity.visualRepresentationPosition[f,0], entity.visualRepresentationPosition[f,1]] = entity.visualRepresentation[f];
                }

            }
        }

        public static void DrawLineSeparator()
        {
            Console.SetCursorPosition(0, 23);
            for(int f=0; f<79;f++)
            {
                Console.Write("-");
            }
        }

        private static void GenerateStageOne()
        {
            //hacer que acá dibuje una montaña simple
            //esto hace una linea en diagonal
            for(int f=0; f<10;f++)
            {
                matrix[0 + f, 55 - f] = '(';
                matrix[0 + f, 55 + f] = ')';                
            }
            for (int f = 0; f < 5; f++)
            {
                matrix[5 + f, 45 - f] = '(';
                matrix[7 + f, 66 + f] = ')';
            }

            matrix[6, 46] = '(';
            matrix[8, 65] = ')';

            matrix[9, 52] = 'o';
            matrix[8, 52] = 'o';
            matrix[7, 53] = 'o';
            matrix[6, 54] = 'o';
            matrix[5, 55] = 'o';
            matrix[6, 56] = 'o';
            matrix[7, 57] = 'o';
            matrix[7, 59] = 'o';
            matrix[8, 59] = 'o';
            matrix[9, 59] = 'o';
           

        }

        private static void GenerateStageTwo()
        {
            //algas colgando de la pared
            for(int f=0; f<8;f=f+2)
            {
                matrix[f, 5] = 'S';
                matrix[f+1, 6] = 'S';

                matrix[f, 40] = 'S';
                matrix[f + 1, 41] = 'S';
            }
            for (int f = 0; f < 6; f = f + 2)
            {
                matrix[f, 13] = 'S';
                matrix[f + 1, 14] = 'S';

                matrix[f, 59] = 'S';
                matrix[f + 1, 60] = 'S';
            }
            for (int f = 0; f < 12; f = f + 2)
            {
                matrix[f, 25] = 'S';
                matrix[f + 1, 26] = 'S';
            }

            //agujero en el suelo
            //subida
            matrix[21, 36] = 'C';
            matrix[20, 35] = 'C';
            matrix[19, 36] = 'C';
            matrix[18, 36] = 'C';
            matrix[17, 36] = 'C';
            matrix[16, 37] = 'C';
            matrix[15, 38] = 'C';
            matrix[14, 38] = 'C';
            //bajada a la derecha
            matrix[14, 39] = 'C';
            matrix[15, 40] = 'C';
            matrix[16, 41] = 'C';
            matrix[17, 41] = 'C';
            matrix[18, 42] = 'C';
            matrix[19, 42] = 'C';
            matrix[19, 43] = 'C';
            matrix[20, 44] = 'C';
            matrix[21, 45] = 'C';
            //algas bajando por el agujero
            matrix[17, 37] = '|';
            matrix[18, 37] = '|';

            matrix[16, 40] = '|';
            matrix[17, 40] = '|';

            matrix[20, 42] = '|';
            matrix[21, 42] = '|';

            matrix[14, 39] = 'C';
            matrix[14, 39] = 'C';
            matrix[14, 39] = 'C';
            matrix[14, 39] = 'C';
            matrix[14, 39] = 'C';
            matrix[14, 39] = 'C';

            for(int f=0;f<79;f++)
            {
                matrix[12, f] = '-';
            }
        }

        private static void GenerateStageThree()
        {
            for(int f=10; f<79;f=f+10)
            {
                matrix[2, f] = '^';
                matrix[3, f] = '^';
                matrix[4, f] = '^';
                matrix[5, f] = 'u';
                matrix[6, f] = '|';
                matrix[7, f] = '|';
            }

            for (int f = 0; f < 79; f++)
            {
                matrix[12, f] = '-';
            }
        }



    }
}


