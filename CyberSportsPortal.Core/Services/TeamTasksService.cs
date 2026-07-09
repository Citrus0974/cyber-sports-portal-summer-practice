using CyberSportsPortal.Data;
using CyberSportsPortal.Data.Model.Views;
using System.Collections.Generic;
using System.Linq;

namespace CyberSportsPortal.Core.Services;

public class TeamTasksService(CyberSportsContext context)
{
    private readonly CyberSportsContext _context = context;

    // Задание 2
    public int GetTeamIncomeForYear(int teamId, int year)
    {
        var team = _context.Teams
            .FirstOrDefault(x => x.Id == teamId);

        if (team == null)
        {
            return 0;
        }

        return team.TeamTournamentResults
            .Where(result => result.Tournament.StartDate.Year == year &&
                             result.Tournament.EndDate.Year == year)
            .Select(result => result.Tournament.TournamentPrizes
                .FirstOrDefault(p => p.Place == result.Place)?.Prize ?? 0)
            .Sum();
    }

    public List<RatingView> GetNewRatings(List<MatchHistoryView> matches, List<RatingView> oldRatings)
    {
        return oldRatings;
    }
}