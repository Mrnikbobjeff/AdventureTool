using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureTool.Base.Models.Attributes;
using AdventureTool.Base.Models.Attributes.Interfaces;
using AdventureTool.Base.Models.Attributes.Units;
using AdventureTool.Repositories.Database;
using Realms;

namespace AdventureTool.Base.Models.Player
{
    class CharacterInfo : RealmObject, IEntity, ILengthMeasurement, IWeighable
    {
        public string Id { get; set; }
        public string Provider { get; set; }
        public bool Deleted { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public Length Length { get; set; }
        public uint HairColor { get; set; }

        public uint EyeColor { get; set; }
        public Weight Weight { get; set; }

        public string Stand { get; set; }
        public string Titel { get; set; }
    }
}
