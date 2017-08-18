using System;

namespace AdventureTool.Repositories.Database
{
    public interface IEntity
    {
        string Id { get; set; }

        string Provider { get; set; }

        bool Deleted { get; set; }

        DateTimeOffset LastModified { get; set; }
    }
}
