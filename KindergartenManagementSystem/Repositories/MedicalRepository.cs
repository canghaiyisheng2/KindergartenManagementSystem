using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindergartenManagementSystem.Data;
using KindergartenManagementSystem.Models;
using KindergartenManagementSystem.Models.shared;
using Microsoft.EntityFrameworkCore;

namespace KindergartenManagementSystem.Services
{
    public class MedicalRepository : IMedicalRepository
    {
        KindergartenMSContext _context;

        public MedicalRepository(KindergartenMSContext context)
        {
            _context = context;
        }

        public List<Medical> GetAll()
        {
            return _context.medicals.ToList();
        }

        public Medical GetMedicalById(int? id)
        {
            if (id == null) return null;
            return _context.medicals.FirstOrDefault(m => m.id == id);
        }

        public void AddMedical(Medical Medical)
        {
            _context.medicals.Add(Medical);
            _context.SaveChanges();
        }

        public bool RemoveMedical(int id)
        {
            var studentMed = _context.medicals.SingleOrDefault(m => m.id == id);
            _context.medicals.Remove(studentMed);
            int entries = _context.SaveChanges();
            if (entries > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
