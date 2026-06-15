using System.Collections.Generic;
using System.Linq;

namespace SportTracker_WindowsForms.Repositories
{
    public class SportRepository
    {
        private List<Athlete> athletes = new List<Athlete>();
        private List<Training> trainings = new List<Training>();

        public void AddAthlete(Athlete a) => athletes.Add(a);
        public void AddTraining(Training t) => trainings.Add(t);

        public List<Athlete> GetAthletes() => athletes;
        public List<Training> GetTrainings() => trainings;

        public void RemoveAthlete(int id)
        {
            var item = athletes.FirstOrDefault(x => x.Id == id);
            if (item != null) athletes.Remove(item);
        }

        public void RemoveTraining(int id)
        {
            var item = trainings.FirstOrDefault(x => x.Id == id);
            if (item != null) trainings.Remove(item);
        }
    }
}