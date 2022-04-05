using System;
using DomainModels.Models.Entities;
using RuneCube.Constants.PlayerConstants;

namespace RuneCube.Utilities.LeaderBoardUtilities
{
    public class LeaderBoardGetter
    {
        public static LeaderBoard GetLeaderBoard
            (string username1,string username2,string role1,string spentTime,string isFinished)
        {
            LeaderBoard leaderBoard = new();
            if (role1.ToUpper() == PlayerRoles.Explorer.ToUpper())
            {
                leaderBoard.Explorer = username1;
                leaderBoard.Solver = username2;
            }
            else
            {
                leaderBoard.Explorer = username2;
                leaderBoard.Solver = username1;
            }
            leaderBoard.IsFinished = Convert.ToBoolean(isFinished);
            leaderBoard.SpentTime = spentTime;
            return leaderBoard;
        }
    }
}
