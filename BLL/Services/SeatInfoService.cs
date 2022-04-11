
﻿using BLL.Entities;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
 {
     public class SeatInfoService
     {
        public static List<SeatInfoModel> GetAllSeatInfos()
        {
            return DataAccessFactory.SeatInfoDataAccess().GetAll().Select(seatinfo => SeatInfoModel.FromDb(seatinfo, true)).ToList();
        }

        public static SeatInfoModel GetSeatInfo(int id)
        {
            return SeatInfoModel.FromDb(DataAccessFactory.SeatInfoDataAccess().GetById(id), true);
        }

        public static bool AddSeatInfo(SeatInfoModel seatinfoModel)
        {
            return DataAccessFactory.SeatInfoDataAccess().Add(seatinfoModel.GetDbModel());
        }

        public static bool UpdateSeatInfo(int id, SeatInfoModel seatinfoModel)
        {
            return DataAccessFactory.SeatInfoDataAccess().Update(id, seatinfoModel.GetDbModel());
        }

        public static bool DeleteSeatInfo(int id)
        {
            return DataAccessFactory.SeatInfoDataAccess().Delete(id);
        }


    }
 }
