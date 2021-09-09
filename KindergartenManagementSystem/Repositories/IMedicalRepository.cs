using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindergartenManagementSystem.Models;

namespace KindergartenManagementSystem.Services
{
    public interface IMedicalRepository
    {
        List<Medical> GetAll();
        Medical GetMedicalById(int? id);
        void AddMedical(Medical Medical);
        bool RemoveMedical(int id);
    }
}
