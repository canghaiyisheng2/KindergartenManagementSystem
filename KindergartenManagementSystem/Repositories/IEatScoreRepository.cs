using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindergartenManagementSystem.Data;
using KindergartenManagementSystem.Models;

namespace KindergartenManagementSystem.Repositories
{
    public interface IEatScoreRepository
    {
        IEnumerable<EatScore> GetAll();
        IEnumerable<EatScore> GetScoreByStuId(int stu_id);
        void InsertEatScore(EatScore eatScore);
        int GetIndexNum();
        EatScore GetScoreDetails(int stu_id, string date);
    }
}
