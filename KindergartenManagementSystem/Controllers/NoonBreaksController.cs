using KindergartenManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KindergartenManagementSystem.Data;
using Microsoft.AspNetCore.Authorization;

namespace KindergartenManagementSystem.Controllers
{
    [Authorize]
    public class NoonBreaksController : Controller
    {
        

        private KindergartenMSContext db;

        public NoonBreaksController(KindergartenMSContext _db)
        {
            db = _db;
        }

        // GET: 管理午休信息列表视图
        public ActionResult Index()
        {
            var list = db.NoonBreak.ToList();//获取所有的记录列表
            ViewBag.auth = User.Claims.ElementAt(1).Value;
            return View(list);
        }

        // GET: 查询视图
        public ActionResult Search()
        {
            return View();
        }
        public ActionResult SearchList(int? StudentId,string StudentName)
        {
            var query = db.NoonBreak.AsParallel();//获取查询集合
            if(StudentId!=null&&StudentId>0)
            {
                //输入了学生ID
                query = query.Where(x => x.StudentId == StudentId);
            }
            if(!string.IsNullOrWhiteSpace(StudentName))
            {
                //输入了学生姓名
                query = query.Where(x => x.StudentName == StudentName);
            }
            return View(query.ToList());//将查询到的信息返回给视图
        }
        // GET: NoonBreaks/Details/5  详情视图
        public ActionResult Details(int? id)
        {
            //通过ID获取午休信息返回给视图
            NoonBreak noonBreak = db.NoonBreak.Find(id);

            ViewBag.auth = User.Claims.ElementAt(1).Value;
            return View(noonBreak);
        }

        [Authorize(Roles = "teacher")]
        // GET: NoonBreaks/Create  添加信息视图
        public ActionResult Create()
        {
            return View();
        }

        // POST: NoonBreaks/Create
        //添加信息 post提交方法
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "teacher")]
        public ActionResult Create([Bind(include: "Id,StudentId,StudentName,Sex,Age,TeacherName,ClassName,IsHalfSleep,IsSelfDress,IsMakeBed,GetupInto,Healthy,Abnormal,TotalFen")] NoonBreak noonBreak)
        {
            if (ModelState.IsValid)
            {
                //添加时将添加日期设置为当前时间
                noonBreak.CreateTime = DateTime.Now;
                db.NoonBreak.Add(noonBreak);//将信息添加到实体
                db.SaveChanges();//保存到数据库
                return RedirectToAction("Index");//添加完成也没跳转到管理视图
            }

            return View(noonBreak);
        }

        // GET: NoonBreaks/Edit/5
        //编辑信息视图
        [Authorize(Roles = "teacher")]
        public ActionResult Edit(int? id)
        {
            //通过ID获取午休信息返回给视图
            NoonBreak noonBreak = db.NoonBreak.Find(id);
             
            return View(noonBreak);
        }

        // POST: NoonBreaks/Edit/5
        // 编辑信息post提交方法
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "teacher")]
        public ActionResult Edit([Bind(include: "Id,StudentId,StudentName,Sex,Age,TeacherName,ClassName,IsHalfSleep,IsSelfDress,IsMakeBed,GetupInto,Healthy,Abnormal,TotalFen,CreateTime")] NoonBreak noonBreak)
        {
            if (ModelState.IsValid)
            {
                db.Entry(noonBreak).State = EntityState.Modified;//从编辑视图传递的实体是编辑状态
                db.SaveChanges();//保存到数据库
                return RedirectToAction("Index");//添加完成也没跳转到管理视图
            }
            return View(noonBreak);
        }

        // GET: NoonBreaks/Delete/5
        //删除视图
        [Authorize(Roles = "teacher")]
        public ActionResult Delete(int? id)
        {
             
            NoonBreak noonBreak = db.NoonBreak.Find(id);
            
            return View(noonBreak);
        }

        // POST: NoonBreaks/Delete/5
        //删除方法
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "teacher")]
        public ActionResult DeleteConfirmed(int id)
        {
            //找到要删除的对象
            NoonBreak noonBreak = db.NoonBreak.Find(id);
            db.NoonBreak.Remove(noonBreak);//调用remove删除
            db.SaveChanges();//保存到数据库
            return RedirectToAction("Index");//添加完成也没跳转到管理视图
        }

    }
}
