using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindergartenManagementSystem.Models.ViolationModels;

namespace KindergartenManagementSystem.Services.ViolationService
{
    public interface IRecordService
    {
        IEnumerable<Record> GetRecords();
        Record GetRecordsById(int id);
        void CreateRecord(Record record);
        void DeleteRecord(int id);
        void SaveChanges();
    }
}
