﻿using AdventureTool.Repositories.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureTool.Base.Models.Interfaces;
using Realms;

namespace AdventureTool.Base.Models.Player
{
    class Talent : RealmObject, IEntity, IDisability
    {
        public string Id { get; set; }
        public string Provider { get; set; }
        public bool Deleted { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AddModifier { get; set; }
        public int MultModifier { get; set; }
        public int Taw { get; set; }
        public IList<Eigenschaft> ProbenEigenschaften { get; }
    }
}
