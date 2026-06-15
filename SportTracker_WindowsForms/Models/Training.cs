using System;

public class Training
{
    public int Id { get; set; }
    public int AthleteId { get; set; }
    public int Duration { get; set; }
    public string Notes { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;

    public override string ToString()
    {
        return $"[ТРЕНИРОВКА] {Id}: ATH {AthleteId} | {Duration} мин | {Notes}";
    }
}