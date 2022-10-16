using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Record
{
    [BsonId]
    public ObjectId Id { get; set; }

    public string Word { get; set; }

    public string Translation { get; set; }

    public string User { get; set; }

    public DateTime CreateDateTime { get; set; }
}
