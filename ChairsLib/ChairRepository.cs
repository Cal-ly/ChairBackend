namespace ChairLib;

public class ChairRepository
{
    private readonly List<Chair> _chairs = [];
    private int _nextId = 1;

    public ChairRepository()
    {
        Add(new Chair { Model = "The Egg", MaxWeight = 100, HasPillow = true });
        Add(new Chair { Model = "Swan", MaxWeight = 120, HasPillow = false });
        Add(new Chair { Model = "E27", MaxWeight = 130, HasPillow = true });
    }

    public List<Chair> GetAll() => _chairs;

    public Chair? GetById(int id) => _chairs.FirstOrDefault(c => c.Id == id) ?? throw new ArgumentException("No chairs with that Id");

    public Chair Add(Chair chair)
    {
        ArgumentNullException.ThrowIfNull(chair);
        chair.Validate();

        chair.Id = _nextId++;
        _chairs.Add(chair);
        return chair;
    }

    public Chair? Delete(int id)
    {
        var chair = GetById(id);
        if (chair != null)
        {
            _chairs.Remove(chair);
        }
        return chair;
    }
}
