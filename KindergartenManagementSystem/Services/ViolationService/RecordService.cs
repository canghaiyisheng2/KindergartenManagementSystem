using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindergartenManagementSystem.Data;
using KindergartenManagementSystem.Models.ViolationModels;
using Microsoft.EntityFrameworkCore;

namespace KindergartenManagementSystem.Services.ViolationService
{
    public class RecordService : IRecordService
    {
        private KindergartenMSContext _context;

        public RecordService(KindergartenMSContext context)
        {
            _context = context;
        }
        public Record GetRecordsById(int id)
        {
            return _context.Records.FirstOrDefault(c => c.childId == id);
        }
        public IEnumerable<Record> GetRecords()
        {
            return _context.Records.ToList();
        }
        public void CreateRecord(Record record)
        {
            _context.Records.Add(record);
            _context.SaveChanges();
        }
        public void DeleteRecord(int id)
        {
            var record = _context.Records.FirstOrDefault(c => c.childId == id);
            _context.Records.Remove(record);
            _context.SaveChanges();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
