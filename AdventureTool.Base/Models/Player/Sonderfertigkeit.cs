﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureTool.Base.Models.Attributes;
using AdventureTool.Base.Models.Interfaces;
using AdventureTool.Repositories.Database;
using Realms;

namespace AdventureTool.Base.Models.Player
{
    class Sonderfertigkeit : RealmObject, IEntity, IRankable
    {
        public string Id { get; set; }
        public string Provider { get; set; }
        public bool Deleted { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Rank Rank { get; set; }
    }
}
