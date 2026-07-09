using CyberSportsPortal.Data.Entities;
using CyberSportsPortal.Data.Model.Enums;
using CyberSportsPortal.Data.Model.Views;
using System;
using System.Collections.Generic;

namespace CyberSportsPortal.Core.Services;

public class TournamentTasksService
{
    // Задание 1
    public string GetTournamentStatus(Tournament tournament)
    {
        if (tournament == null)
            {
                return string.Empty; 
            }
        var currentDate = DateTime.Now;
        if (currentDate < tournament.StartDate)
            {
                return "Не начался";
            }
        else if (currentDate > tournament.EndDate)
                {
                    return "Окончен";
                }
        else
            {
                return "В процессе";
            }
    }

    // Задание 3
    public int GetPlayersFromCountryCount(List<Player> players, Country country)
    {
        if (players == null || players.Count == 0)
        {
            return 0;
        }

        int count = 0;
        foreach (var player in players)
        {
            if (player.Country == country)
            {
                count++;
            }
        }

        return count;
    }

    // Задание 4
    public string GetTeamParticipantsNameString(List<string> teamNames)
    {
        if (teamNames == null || teamNames.Count == 0)
        {
            return string.Empty;
        }

        string result = string.Empty;
        for (int i = 0; i < teamNames.Count; i++)
        {
            result += teamNames[i];

            if (i < teamNames.Count - 1)
            {
                result += ", ";
            }
        }

        return result;
    }

    public int ComparePrizes(string prizeA, string prizeB)
    {
        if (prizeA == prizeB)
            return 0;
        if (prizeA[prizeA.Length - 1] > prizeB[prizeB.Length - 1])
            return 1;
        else
            return -1;
    }

    public Dictionary<int, decimal> GetTournamentVictoryProbabilities(List<TeamWithVictoryProbabilities> teams, Dictionary<int, int> standings)
    {
        return new Dictionary<int, decimal>();
    }
}