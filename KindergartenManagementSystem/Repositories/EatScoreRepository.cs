using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindergartenManagementSystem.Data;
using KindergartenManagementSystem.Models;

namespace KindergartenManagementSystem.Repositories
{
    public class EatScoreRepository:IEatScoreRepository
    {
        private EatScoreContext _context;
        
        public EatScoreRepository(EatScoreContext context)
        {
            _context = context;
        }
        
        public IEnumerable<EatScore> GetAll()
        {
            return _context.EatScores.GroupBy(a=>a.StuId).Select(b=>b.First()).ToList();
        }

        public IEnumerable<EatScore> GetScoreByStuId(int stu_id)
        {
            return _context.EatScores.Where<EatScore>(e => e.StuId == stu_id).ToList();
        }

        public void InsertEatScore(EatScore eatScore)
        {
            // 数据库设置： set identity_insert EatScores ON;
            _context.Add(eatScore);
            _context.SaveChanges();
        }

        public int GetIndexNum()
        {
            return _context.EatScores.Select(s=>s.Id).Max();
        }

        public EatScore GetScoreDetails(int stu_id, string date)
        {
            return _context.EatScores.Where<EatScore>(a => a.StuId == stu_id && a.Date == date).FirstOrDefault();
        }
    }
}
