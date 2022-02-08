using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftGruppFördjupning
{
    /// <summary>
    /// ger tillgång till position och appearence via GameObject klassen
    /// </summary>
    public class Food : GameObject
    {
        //ärver Appearence från GameObject konstruktorn samt sätter värdet för X och Y
        public Food(char Appearence, int positionenX, int positionenY) : base(Appearence)
        {
            position.X = positionenX;
            position.Y = positionenY;
        }
        public override void Update()
        {
            

        }
    }
}
