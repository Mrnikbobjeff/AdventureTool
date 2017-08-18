using System;
using AdventureTool.Repositories.Database;
using Realms;

namespace AdventureTool.Base.Models.Attributes.Units
{
    public class Date : RealmObject, IEntity
    {
        public string Id { get; set; }
        public string Provider { get; set; }
        public bool Deleted { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public DateTime GregorianDate { get; set; }
        public DateTime DSADate => GregorianDate - TimeSpan.FromDays(365);
    }
}
