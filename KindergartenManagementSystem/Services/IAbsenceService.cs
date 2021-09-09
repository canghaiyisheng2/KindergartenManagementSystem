using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KindergartenManagementSystem.Models;
using KindergartenManagementSystem.Models.shared;


namespace KindergartenManagementSystem.Services
{
    public interface IAbsenceService
    {
        bool add(Absence absence);

        IQueryable<Absence> studentListAbsence(string username);

        Absence query(int absenceID);

        bool studentReportedBackFromLeave(int absenceID);

        IQueryable<Absence> teacherListAbsence(string username);

        bool teacherAcceptAbsence(int absenceID);

        bool teacherRejectAbsence(int absenceID, string rejectMessage);

        bool hasAuthorityToReview(int absenceID, string username);
    }
}
