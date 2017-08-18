using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureTool.Repositories.Database;
using Realms;

namespace AdventureTool.Base.Models.Player
{
    public class PlayerEntity : RealmObject, IEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Provider { get; set; }
        public bool Deleted { get; set; }
        public DateTimeOffset LastModified { get; set; }
    }
}
