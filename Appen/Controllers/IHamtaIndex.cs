using System;
using System.Collections.Generic;

namespace Appen.Controllers
{
    public interface IHamtaIndex
    {
        IEnumerable<string> Hamta();
        IEnumerable<string> HamtaHusdjur();
    }
}
