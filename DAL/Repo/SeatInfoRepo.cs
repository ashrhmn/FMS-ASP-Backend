﻿using DAL.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class SeatInfoRepo : IRepository<SeatInfo, int>
    {
        private readonly FmsEntities db;

        public SeatInfoRepo(FmsEntities db)
        {
            this.db = db;
        }

        public bool Add(SeatInfo obj)
        {
            if (obj == null) return false;
            db.SeatInfos.Add(obj);
            return db.SaveChanges() != 0;
        }

        public bool Delete(int id)
        {
            var seat = db.SeatInfos.FirstOrDefault(s => s.Id == id);
            if (seat == null) return false;
            db.SeatInfos.Remove(seat);
            return db.SaveChanges() != 0;
        }

        public List<SeatInfo> GetAll()
        {
            return db.SeatInfos.ToList();
        }

        public SeatInfo GetById(int id)
        {
            return db.SeatInfos.FirstOrDefault(s => s.Id == id);
        }

        public bool Update(SeatInfo obj)
        {
            var seat = db.SeatInfos.FirstOrDefault(s => s.Id == obj.Id);
            if (seat == null) return false;
            db.Entry(seat).CurrentValues.SetValues(obj);
            return db.SaveChanges() != 0;
        }
    }
}
