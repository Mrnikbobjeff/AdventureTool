using System;
using AdventureTool.Repositories.Database;
using Realms;

namespace AdventureTool.Base.Models.Attributes.Units
{
    public class Length : RealmObject, IEntity
    {
        public string Id { get; set; }
        public string Provider { get; set; }
        public bool Deleted { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SizeInSchritt { get; set; } //Meters

        public int SizeInSpann => SizeInSchritt / 5; //20cm
        public int SizeInFinger => SizeInSchritt / 50; //2cm
        public int SizeInHalbfinger=> SizeInSchritt / 100; //1cm
        public int SizeInMeilen => SizeInSchritt * 1000; //1km
    }
}
