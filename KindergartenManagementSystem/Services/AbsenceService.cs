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
    public class AbsenceService : IAbsenceService
    {
        KindergartenMSContext _context;

        public AbsenceService(KindergartenMSContext context)
        {
            _context = context;
        }

        public IQueryable<Absence> studentListAbsence(string username)
        {
            return from b in _context.Absences
                   where b.starter == username
                   select b;
        }

        // 添加请假申请
        public bool add(Absence absence)
        {
            absence.rejectReason = "";
            absence.status = (int)AbsenceStatus.TO_BE_REVIEWED;
            _context.Absences.Add(absence);
            _context.SaveChanges();
            return true;
        }

        public Absence query(int absenceID)
        {
            return _context.Absences.Find(absenceID);
        }

        public bool studentReportedBackFromLeave(int absenceID)
        {
            Absence absence = _context.Absences.Find(absenceID);
            if (absence.status == (int)AbsenceStatus.COMPLETED)
            {
                return false;
            }
            else
            {
                absence.status = (int)AbsenceStatus.COMPLETED;
                _context.Entry(absence).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
        }

        public IQueryable<Absence> teacherListAbsence(string username)
        {
            User user = _context.Users.Find(username);
            Teacher teacher = _context.Teachers.Find(user.banding);
            return from a in _context.Absences
                   join b in _context.Users on a.starter equals b.user_name
                   join c in _context.Children on b.banding equals c.id
                   where c.cla == teacher.cla
                   select a;
        }

        public bool teacherAcceptAbsence(int absenceID)
        {
            Absence absence = _context.Absences.Find(absenceID);
            if (absence.status == (int)AbsenceStatus.TO_BE_REVIEWED)
            {
                absence.status = (int)AbsenceStatus.ACCEPTED;
                _context.Entry(absence).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool teacherRejectAbsence(int absenceID, string rejectMessage)
        {
            Absence absence = _context.Absences.Find(absenceID);
            if (absence.status == (int)AbsenceStatus.TO_BE_REVIEWED)
            {
                absence.status = (int)AbsenceStatus.REJECTED;
                absence.rejectReason = rejectMessage;
                _context.Entry(absence).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool hasAuthorityToReview(int absenceID, string username)
        {
            Teacher teacher = _context.Teachers.Find(_context.Users.Find(username).banding);
            Child child = _context.Children.Find(_context.Users.Find(_context.Absences.Find(absenceID).starter).banding);
            return child.cla.CompareTo(teacher.cla) == 0;
        }
    }
}
