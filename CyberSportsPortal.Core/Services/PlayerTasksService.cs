using CyberSportsPortal.Data.Model.Views;
using System.Collections.Generic;
using System.Linq;

namespace CyberSportsPortal.Core.Services;

public class PlayerTasksService
{
    // Задание 5.
    public List<PlayerView> FilterPlayers(List<PlayerView> players, string filter)
    {

        if (players == null)
        {
            return new List<PlayerView>();
        }

        if (filter == "")
        {
            return players;
        }

        filter = filter.ToLower();
        return players.Where(p => p.NickName.ToLower().Contains(filter) || p.CombinedName.ToLower().Contains(filter)).ToList();
    }
}