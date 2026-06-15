using System.Collections.Generic;
using System.Linq;

public class SportService
{
    private List<Athlete> athletes = new List<Athlete>();
    private List<Training> trainings = new List<Training>();

    private int nextAthleteId = 1;
    private int nextTrainingId = 1;

    public List<Athlete> GetAthletes() => athletes;
    public List<Training> GetTrainings() => trainings;

    public void AddAthlete(string name, string sport)
    {
        athletes.Add(new Athlete
        {
            Id = nextAthleteId++,
            Name = name,
            SportType = sport
        });
    }

    public void AddTraining(int athleteId, int duration, string notes)
    {
        trainings.Add(new Training
        {
            Id = nextTrainingId++,
            AthleteId = athleteId,
            Duration = duration,
            Notes = notes
        });
    }

    public void RemoveAthlete(int id)
    {
        athletes.RemoveAll(x => x.Id == id);
        trainings.RemoveAll(x => x.AthleteId == id);
    }

    public void RemoveTraining(int id)
    {
        trainings.RemoveAll(x => x.Id == id);
    }

    public string GetStats()
    {
        return $"Спортсменов: {athletes.Count}\nТренировок: {trainings.Count}";
    }
}