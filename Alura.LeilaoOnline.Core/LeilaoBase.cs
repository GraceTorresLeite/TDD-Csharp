using System.Collections.Generic;

namespace Alura.LeilaoOnline.Core
{
    public class LeilaoBase
    {
        public IEnumerable<Lance> Lances => _lances;

        public IEnumerable<Lance> _lances { get; private set; }
    }
}