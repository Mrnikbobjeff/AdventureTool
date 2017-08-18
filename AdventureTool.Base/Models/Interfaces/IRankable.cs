using AdventureTool.Repositories.Database;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureTool.Base.Models.Attributes;

namespace AdventureTool.Base.Models.Interfaces
{
    interface IRankable
    {
        Rank Rank { get; set; }
    }
}
