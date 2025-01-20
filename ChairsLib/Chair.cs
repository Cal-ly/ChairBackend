namespace ChairLib;

public class Chair
{
    public int Id { get; set; }
    public string Model { get; set; } = string.Empty;
    public int MaxWeight { get; set; }
    public bool HasPillow { get; set; }

    public void Validate()
    {
        ValidateModel();
        ValidateWeight();
    }

    /// <summary>
    /// Validates the Model property, to be at least 2 chars long.
    /// </summary>
    /// <remarks>
    /// The null check is by-and-large redundant, since the property is set to "string.Empty" when created. But it's a good practice to have it.
    /// </remarks>
    public void ValidateModel()
    {
        if (string.IsNullOrWhiteSpace(Model) || Model.Length < 2)
            throw new ArgumentException("Model must be at least 2 characters long.");
    }

    public void ValidateWeight()
    {
        if (MaxWeight < 50)
            throw new ArgumentException("MaxWeight must be at least 50.");
    }

    public override string ToString() =>
        $"Id: {Id}, Model: {Model}, MaxWeight: {MaxWeight}, HasPillow: {HasPillow}";
}
