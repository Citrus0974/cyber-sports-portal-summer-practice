using CyberSportsPortal.Data.Model.Views;
using System.Collections.Generic;

namespace CyberSportsPortal.Core.Services;

public class PlayerTasksService
{
    // Задание 5
    public List<PlayerView> FilterPlayers(List<PlayerView> players, string filter)
    {
        List<PlayerView> result = new List<PlayerView>();

        if (players == null)
        {
            return result;
        }

        if (filter == "")
        {
            return players;
        }

        foreach (PlayerView player in players)
        {
            if (player.NickName != null)
            {
                if (player.NickName.Contains(filter))
                {
                    result.Add(player);
                    continue;
                }
            }

            if (player.CombinedName != null)
            {
                if (player.CombinedName.Contains(filter))
                {
                    result.Add(player);
                }
            }
        }
        return result;
    }
}