using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UppgiftGruppFördjupning
{
    /// <summary>
    /// Skapar spelplanen med höjd och bredd
    /// Generarar nya objekt till spelplanen
    /// </summary>
    class GameWorld
    {
        //definierar bredden och höjden för spelplanen

        public int width { get; set; }
        public int height { get; set; }

        //definierar poängen som spelaren samlat ihop
        public int points { get; set; }
        public List<GameObject> AllObjects = new List<GameObject>();

        //låter oss sätta värdet för bredden och höjden vid en instans av GameWorld
        public GameWorld(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        
        public void Update()
        {
            foreach (var obj in AllObjects)
            {
                obj.Update();
            }
            //ToList skapar en separat lista för att kunna modifiera innehållet på AllObjects i våra foreach loopar
            foreach (GameObject player in AllObjects.ToList())
            {
                if (player is Player)
                {
                    foreach (GameObject food in AllObjects.ToList())
                    {
                        //is not statement för att hindra de ärvda väggarna att räknas som "food" vid kollision med spelaren
                        if (food is Food && food is not Wall)
                        {
                            if(food.position.X == player.position.X && player.position.Y == food.position.Y)
                            {

                                
                                AllObjects.Remove(food);
                                Random rand = new Random();
                                Food äpplev2 = new Food('+', rand.Next(width), rand.Next(height));
                                points++;
                                Wall väggv2 = new Wall('|', rand.Next(width), rand.Next(height));
                                AllObjects.Add(äpplev2);
                                AllObjects.Add(väggv2);
                            }
                        }
                    }
                    //Minskar spelarens poäng vid kollision med en vägg och minskar därmed även frameraten 
                    foreach (GameObject wall in AllObjects.ToList())
                    {
                        if(wall is Wall){
                            if (wall.position.X == player.position.X && player.position.Y == wall.position.Y)
                            {
                                if (points > 0)
                                {
                                    points--;
                                }
                            }

                        }
                    }
                }
            }
        }
    }
}
