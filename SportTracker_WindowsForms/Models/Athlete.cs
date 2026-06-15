public class Athlete
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SportType { get; set; }

    public override string ToString()
    {
        return $"[СПОРТСМЕН] {Id}: {Name} ({SportType})";
    }
}