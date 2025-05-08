namespace FullVsPartialModelClassForJsonDeserialize;

public class FullModel
{
  public string Id { get; set; }
  public DateTime Timestamp { get; set; }
  public bool IsActive { get; set; }
  public string Balance { get; set; }
  public string Picture { get; set; }
  public int Age { get; set; }
  public string EyeColor { get; set; }
  public string Name { get; set; }
  public string Gender { get; set; }
  public string Company { get; set; }
  public string Email { get; set; }
  public string Phone { get; set; }
  public string Address { get; set; }
  public string About { get; set; }
  public DateTime Registered { get; set; }
  public double Latitude { get; set; }
  public double Longitude { get; set; }
  public List<string> Tags { get; set; }
  public List<Friend> Friends { get; set; }
  public string Greeting { get; set; }
  public string FavoriteFruit { get; set; }
  public ComplexDataObject ComplexData { get; set; }
  public List<ActivityLogEntry> ActivityLog { get; set; }
}

public class Friend
{
  public int Id { get; set; }
  public string Name { get; set; }
}

public class ComplexDataObject
{
  public string NestedValue1 { get; set; }
  public int NestedValue2 { get; set; }
  public DeeplyNestedObject DeeplyNested { get; set; }
}

public class DeeplyNestedObject
{
  public string PropertyA { get; set; }
  public List<int> PropertyB { get; set; }
  public SubPropertyCObject PropertyC { get; set; }
}

public class SubPropertyCObject
{
  public bool SubProp1 { get; set; }
  public string SubProp2 { get; set; }
}

public class ActivityLogEntry
{
  public string LogId { get; set; }
  public string ActivityType { get; set; }
  public string Details { get; set; }
  public DateTime OccurredAt { get; set; }
  public List<RelatedItem> RelatedItems { get; set; }
}

public class RelatedItem
{
  public string ItemId { get; set; }
  public string ItemType { get; set; }
}