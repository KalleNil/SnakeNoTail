using System;
using System.Collections.Generic;
using System.Text;

namespace UppgiftGruppFördjupning
{
    //// <summary>
    //// Genererar Consol med angiven strorlek.
    //// Ser till att spelaren håller sig inom ramen utav genererad spelplan.
    //// Ger disitinkt färg till spelaren samt "Score".
    //// </summary>
    class ConsoleRenderer
    {
        private GameWorld world;

        public ConsoleRenderer(GameWorld gameWorld)
        {

            // Konfiguerering utav Consolen till spelplanens storlek

            Console.SetWindowSize(31, 12);

            //Ändrar spelplanens bakgrund 
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("                                ");
            Console.WriteLine("                                ");
            Console.WriteLine("                                ");
            Console.WriteLine("                                ");
            Console.WriteLine("                                ");
            Console.WriteLine("                                ");
            Console.WriteLine("                                ");
            Console.WriteLine("                                ");
            Console.WriteLine("                                ");
            Console.WriteLine("                                ");
            Console.WriteLine("                                ");
            world = gameWorld;

        }
        //Rendering utav spelvärld samt poängräkningen
        public void Render()
        {

             foreach (var obj in world.AllObjects)
             {

                //kollar ifall spelaren är utanför spelplanen
                if (obj.position.X < 0)
                {
                   obj.position.X = 0;
                }
                if (obj.position.X >= world.width)
                {
                    obj.position.X = world.width;
                }
                if (obj.position.Y < 0)
                {
                    obj.position.Y = 0;
                }
                if (obj.position.Y >= world.height)
                {
                    obj.position.Y = world.height;
                }
                // Färgsättning utav spelobjekt samt poängtavla
                Console.SetCursorPosition(1, 11);
                Console.Write("score: " + world.points+"");
                Console.SetCursorPosition(obj.position.X, obj.position.Y);
                if(obj is Player)
                {
                    
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(obj.Appearance);
                }
                if (obj is Food && obj is not Wall)
                {
                    
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(obj.Appearance);
                }
                if (obj is Wall)
                {
                    
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(obj.Appearance);
                }

             }
        }
        //Generera tomma ytor
        public void RenderBlank()
        {

            foreach (var obj in world.AllObjects)
            {
                Console.SetCursorPosition(obj.position.X, obj.position.Y);
                Console.Write("   ");

            }
        }
    }
}
