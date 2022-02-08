using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftGruppFördjupning
{
    /// <summary>
    /// Ger oss nödvändig funktionallitet för ett väggobjekt via arv från Food
    /// </summary>
    public class Wall:Food
    {
        public Wall(char Appearance, int positionenX, int positionenY) : base(Appearance, positionenX, positionenY)
        {

        }
    }
}
