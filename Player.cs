using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftGruppFördjupning
{
    /// <summary>
    /// Bestämmer hur spelaren rör sig på spelplanen.
    /// Ärver positionsuppgifter ifrån "GameObject".
    /// </summary>
    /// Ge värden åt riktningar
    class Player : GameObject
    {
        // Ge värden åt riktningar
        public enum Direction
        {
            upp,
            ner,
            vänster,
            höger
        }

        public Direction dir;
        // konstruktor för åt vilket håll spelaren färdas
        public Player(Direction direction, char Appearance) : base(Appearance)
        {
            dir = direction;

        }

        // Lyssnar efter input som säger åt vilket håll man ska röra sig i X-Y led
        public override void Update()
        {

            switch (dir)
            {
                case Direction.upp:
                    position.Y -= 1;
                    break;
                case Direction.ner:
                    position.Y += 1;
                    break;
                case Direction.vänster:
                    position.X -= 1;
                    break;
                case Direction.höger:
                    position.X += 1;
                    break;
                default:
                    break;
            }


        }
    }
}
