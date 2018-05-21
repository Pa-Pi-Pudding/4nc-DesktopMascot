using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopMascot
{
    class TestCharacterSet : CharacterSet
    {
        public TestCharacterSet(int id) : base(id)
        {
            characterName = "TestCharacter1";
        }
    }
}
