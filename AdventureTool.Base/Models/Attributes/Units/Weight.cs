using System;
using AdventureTool.Repositories.Database;
using Realms;

namespace AdventureTool.Base.Models.Attributes.Units
{
    public class Weight : RealmObject, IEntity
    {
        public string Id { get; set; }
        public string Provider { get; set; }
        public bool Deleted { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int WeightInStrone { get; set; }
        public int WeightInSkrupel => WeightInStrone / 100; //1g
        public int WeightInUnzue => WeightInStrone / 40; //25g
        public int WeightInDoppelZentner => WeightInStrone * 1000; //25g
    }
}
