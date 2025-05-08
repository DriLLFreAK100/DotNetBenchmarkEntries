namespace FullVsPartialModelClassForJsonDeserialize;

public class PartialModel
{
  public string Id { get; set; }
  public DateTime Timestamp { get; set; }
  public string Name { get; set; }
  public List<PartialFriend> Friends { get; set; }
  public PartialComplexDataObject ComplexData { get; set; }
  public List<PartialActivityLogEntry> ActivityLog { get; set; }
}

public class PartialFriend
{
  public int Id { get; set; }
  public string Name { get; set; }
}

public class PartialComplexDataObject
{
  public string NestedValue1 { get; set; }
  public int NestedValue2 { get; set; }
  public PartialDeeplyNestedObject DeeplyNested { get; set; }
}

public class PartialDeeplyNestedObject
{
  public string PropertyA { get; set; }
  public List<int> PropertyB { get; set; }
  public PartialSubPropertyCObject PropertyC { get; set; }
}

public class PartialSubPropertyCObject
{
  public bool SubProp1 { get; set; }
  public string SubProp2 { get; set; }
}

public class PartialActivityLogEntry
{
  public string LogId { get; set; }
  public string ActivityType { get; set; }
  public DateTime OccurredAt { get; set; }
  public List<PartialRelatedItem> RelatedItems { get; set; }
}

public class PartialRelatedItem
{
  public string ItemId { get; set; }
  public string ItemType { get; set; }
}