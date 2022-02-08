using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftGruppFördjupning
{
    /// <summary>
    /// Tillåter oss att skapa objekt till spelet
    /// </summary>
    public abstract class GameObject
    {
        public Position position;
        public char Appearance { get; set; }

        //Låter oss skapa en symbol för instanser som ärver av GameObject
        //Låter oss sätta värdet på X och Y
        public GameObject(char Appearance)
        {
            this.Appearance = Appearance;
            position = new Position();
        }
        public abstract void Update();

    }
}
