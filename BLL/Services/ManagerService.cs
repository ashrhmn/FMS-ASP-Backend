using BLL.Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class ManagerService
    {
        public static object ManagerProfile(int id)
        {
            var data = UserModel.FromDb(DataAccessFactory.UserDataAccess().GetById(id), false);
            var d = new 
            {
                Id = data.Id,
                Name = data.Name,
                Username = data.Username,
                DateOfBirth = data.DateOfBirth,
                Email = data.Email,
                Phone = data.Phone,
                Address = data.Address
            };

            return d;

        }
        public static bool UpdateProfile(int id, UserModel userModel)
        {
            var data = UserModel.FromDb(DataAccessFactory.UserDataAccess().GetById(id), false);
            userModel.Username = data.Username;
            userModel.Password = data.Password;
            userModel.FamilyId = data.FamilyId;
            userModel.CityId = data.CityId;
            userModel.Role = data.Role;
            return DataAccessFactory.UserDataAccess().Update(id, userModel.GetDbModel());
        }
        public static string ChangePass(int id, string OldPassword, string Password, string ConPassword)
        {
            if (Password.Equals(ConPassword))
            {
                var data = UserModel.FromDb(DataAccessFactory.UserDataAccess().GetById(id), false);

                bool isCorrectPassword = BCrypt.Net.BCrypt.Verify(OldPassword, data.Password);

                if (isCorrectPassword)
                {
                    var user = new UserModel()
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Username = data.Username,
                        Password = BCrypt.Net.BCrypt.HashPassword(Password, 12),  // this Bcrypt
                        Address = data.Address,
                        DateOfBirth = data.DateOfBirth,
                        CityId = data.CityId,
                        FamilyId = data.FamilyId,
                        Role = data.Role,
                        Email = data.Email,
                        Phone = data.Phone
                    };
                    DataAccessFactory.UserDataAccess().Update(id, user.GetDbModel());

                    return "Password Changed Successfully";
                }
                return "Old Password is not correct";

            }
            return "Password & Confirm Password Not Matched";
        }

        public static List<object> UserlistSearch(string Uname, string Purchase)
        {
            List<UserModel> data;
            if (Uname == "" && Purchase != "true")
            {
                //data = (from u in db.Users where u.Role == 2 select u).ToList();
                data = DataAccessFactory.UserDataAccess()
                    .GetAll().Where(u => u.Role == 2)
                    .Select(u=>UserModel.FromDb(u)).ToList();
            }
            else if (Uname != "" && Purchase != "true")
            {
                //data = (from u in db.Users where u.Role == 2 && u.Username.Contains(Uname) select u).ToList();
                data = (from u in DataAccessFactory.UserDataAccess().GetAll() where u.Role == 2 && u.Username.Contains(Uname) select UserModel.FromDb(u)).ToList(); 

            }
            else if (Uname == "" && Purchase == "true")
            {
                //data = db.PurchasedTickets.Select(pb => pb.User).ToList();
                data = DataAccessFactory.TicketDataAccess().GetAll().Select(pb=> UserModel.FromDb(pb.User, true)).ToList();

            }
            else if (Uname != "" && Purchase == "true")
            {
                //data = db.PurchasedTickets.Select(pb => pb.User).Where(pw => pw.Username.Contains(Uname)).ToList();
                data = DataAccessFactory.TicketDataAccess().GetAll().Select(pb => UserModel.FromDb(pb.User)).Where(pw => pw.Username.Contains(Uname)).ToList();
            }
            else
            {
                data = null;
            }
            if (data != null)
            {
                //var dataa = data.Distinct().ToList();


                var users = new List<UserModel>();
                foreach (var disUser in data)
                {
                    if (!users.Select(u => u.Id).ToList().Contains(disUser.Id))
                    {
                        var user = new UserModel()
                        {
                            Name = disUser.Name,
                            Username = disUser.Username,
                            Id = disUser.Id
                           // PurchasedTickets = PurchasedTicketModel.FromDb(DataAccessFactory.TicketDataAccess().GetAll(),true).Where(p => p.PurchasedBy == disUser).ToList(),
                        }; //UserModel.FromDb(DataAccessFactory.UserDataAccess().GetById(id), false);
                    users.Add(user);

                    }
                }
                var userlist = new List<object>();
                foreach (var u in users)
                {
                    var us = new
                    {
                        Id = u.Id,
                        Name = u.Name,
                        Username = u.Username
                    };
                    userlist.Add(us);
                }
                return userlist;
            }
            return null;
        }

         public static List<object> FlightManagerlistSearch(string Uname)
        {
            if (Uname == "" )
            {
                //var data = (from u in db.Users where u.Role == 3 select u).ToList();
                var data = DataAccessFactory.UserDataAccess().GetAll().Where(u => u.Role == 3).Select(u=>UserModel.FromDb(u)).ToList();

                var users = new List<object>();
                foreach (var u in data)
                {
                    //var trans = (from t in db.Transports where t.CreatedBy == u.Id select t).FirstOrDefault();
                    //var trans = DataAccessFactory.TransportDataAccess().GetAll().Where(t => t.CreatedBy == u.Id).ToList();
                    var user = new 
                    {
                        Id = u.Id,
                        Name = u.Name,
                        Username = u.Username,
                       // PurchasedTickets = trans == null ? new List<int>() : trans.TransportSchedules.Select(e => e.Id).ToList(),

                    };
                    users.Add(user);

                }

                return users;
            }
            else if (Uname != "")
            {
                //var data = (from u in db.Users where u.Role == 3 && u.Username.Contains(Uname) select u).ToList();
                var data = (from u in DataAccessFactory.UserDataAccess().GetAll() where u.Role == 3 && u.Username.Contains(Uname) select UserModel.FromDb(u)).ToList();

                var users = new List<object>();
                foreach (var u in data)
                {
                    //var trans = (from t in db.Transports where t.CreatedBy == u.Id select t).FirstOrDefault();
                     //var trans = DataAccessFactory.TransportDataAccess().GetAll().Where(t => t.CreatedBy == u.Id).ToList();
                    var user = new
                    {
                        Id = u.Id,
                        Name = u.Name,
                        Username = u.Username,
                        //PurchasedTickets = trans == null ? new List<int>() : trans.TransportSchedules.Select(e => e.Id).ToList(),

                    };
                    users.Add(user);
                }

                return users;
            }
            return null;
        }

        public static object GetUser(int id)
        {
            var data = UserModel.FromDb(DataAccessFactory.UserDataAccess().GetById(id), true);
            var d = new
            {
                Id = data.Id,
                Name = data.Name,
                Username = data.Username,
                DateOfBirth = data.DateOfBirth,
                Email = data.Email,
                Phone = data.Phone,
                Address = data.Address,
                Role = data.RoleEnum.Value
            };

            return d;

        }

        public static bool UpdateUserdetails(int id, UserModel userModel)
        {
            var role = (from r in DataAccessFactory.UserRoleEnumDataAccess().GetAll() where r.Value == userModel.RoleValue select UserRoleEnumModel.FromDb(r)).FirstOrDefault();
            var data = UserModel.FromDb(DataAccessFactory.UserDataAccess().GetById(id), false);
            userModel.Username = data.Username;
            userModel.Password = data.Password;
            userModel.FamilyId = data.FamilyId;
            userModel.CityId = data.CityId;
            userModel.Role = role.Id;
            return DataAccessFactory.UserDataAccess().Update(id, userModel.GetDbModel());
        }


        public static object UserTicketList(int id)
        {
            var user = (from u in DataAccessFactory.UserDataAccess().GetAll() where u.Id == id select UserModel.FromDb(u)).FirstOrDefault();
            var puchasetickets = (from pt in DataAccessFactory.TicketDataAccess().GetAll() where pt.PurchasedBy == id select PurchasedTicketModel.FromDb(pt)).ToList();
            //var pdetails = new List<PurchasedTicketModel>();

            var pdetails = new List<object>();
            foreach (var p in puchasetickets)
            {
                var fromstopage = (from fs in DataAccessFactory.StoppageDataAccess().GetAll() where fs.Id == p.FromStoppageId select StoppageModel.FromDb(fs, true)).FirstOrDefault();
                var tostopage = (from ts in DataAccessFactory.StoppageDataAccess().GetAll() where ts.Id == p.ToStoppageId select StoppageModel.FromDb(ts, true)).FirstOrDefault();

                var seatinfo = (from s in DataAccessFactory.SeatInfoDataAccess().GetAll() where s.TicketId == p.Id select SeatInfoModel.FromDb(s, true)).FirstOrDefault();
                //var transport = (from t in DataAccessFactory.TransportDataAccess().GetAll() where )
                var FromRootFare = fromstopage.FareFromRoot;
                var ToRootFare = tostopage.FareFromRoot;
                var baseFare = Math.Abs((FromRootFare ?? -1) - (ToRootFare ?? -1));
                var cost = 0;
                if(seatinfo != null)
                {
                    if (seatinfo.SeatClassEnum != null && seatinfo.SeatClassEnum.Value == "Business")
                    {
                        cost = baseFare * 15;
                    }
                    else if (seatinfo.SeatClassEnum != null && seatinfo.SeatClassEnum.Value == "Economic")
                    {
                        cost = baseFare * 10;
                    }
                    else
                    {
                        cost = baseFare * 12;
                    }


                    var pdetaill = new
                    {
                        Ticket_Id = p.Id,
                        Flight_Name = seatinfo.Transport.Name,
                        FromStopageName = fromstopage.Name,
                        ToStopageName = tostopage.Name,
                        Start_Time = seatinfo.StartTime,
                        Age_class = seatinfo.AgeClassEnum.Value,
                        Seat_class = seatinfo.SeatClassEnum.Value,
                        Cost = cost

                    };
                    pdetails.Add(pdetaill);
                }
             

                var pdetail = new
                {
                    Ticket_Id = p.Id,
                    Flight_Name = "no seat define",
                    FromStopageName = fromstopage.Name,
                    ToStopageName  = tostopage.Name,
                    Start_Time = "no seat define",
                    Age_class = "no seat define",
                    Seat_class = "no seat define",
                    Cost = cost

                };
                pdetails.Add(pdetail);


            }

            var userdetail = new
            {
                Id = user.Id,
                Name = user.Name,
                Username= user.Username,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                phone = user.Phone,
                Address = user.Address,
                Ticket = pdetails.ToList(),
            };

            return userdetail;
        }

        public static string UpdateTicket(int id, string ageClass, string seatClass )
        {
            var seatval = (from s in DataAccessFactory.SeatClassEnumDataAccess().GetAll() where s.Value == seatClass select SeatClassEnumModel.FromDb(s)).FirstOrDefault();
            var ageval = (from a in DataAccessFactory.AgeClassEnumDataAccess().GetAll() where a.Value == ageClass select AgeClassEnumModel.FromDb(a)).FirstOrDefault();
            var data = (from s in DataAccessFactory.SeatInfoDataAccess().GetAll() where s.TicketId == id select SeatInfoModel.FromDb(s, true)).FirstOrDefault();
            var price = 0;
            if(seatval.Id == 1 && data.SeatClass != 1)
            {
                if (data.SeatClass == 2)
                {
                    price = price + 2000;
                }
                else{
                    price = price + 1000;
                }
            }
            else if(seatval.Id == 2 && data.SeatClass != 2)
            {
                if (data.SeatClass == 1)
                {
                    price = price - 2000;
                }
                else
                {
                    price = price - 1000;
                }
            }
            else if(seatval.Id == 3 && data.SeatClass != 3)
            {
                if (data.SeatClass == 1)
                {
                    price = price - 1000;
                }
                else
                {
                    price = price + 1000;
                }
            }
            
            data.SeatClass = seatval.Id;
            data.AgeClass = ageval.Id;

            DataAccessFactory.SeatInfoDataAccess().Update(data.Id, data.GetDbModel());
            if(price < 0)
            {
                price = Math.Abs(price);
                return "Ticket Updated Successfully, Customer will get " + price + " TK";
            }
            else
            {
                return "Ticket Updated Successfully, Customer have to pay extra " + price + " TK";
            }
            
        }


        public static List<object> GetAllTransportSchedule()
        {
            var data = DataAccessFactory.TransportScheduleDataAccess().GetAll().Select(transports => TransportScheduleModel.FromDb(transports, true)).ToList();
            var flights = new List<object>();
            foreach (var f in data)
            {

                var FromRootFare = f.FromStoppage.FareFromRoot;
                var ToRootFare = f.ToStoppage.FareFromRoot;
                var baseFare = Math.Abs((FromRootFare ?? -1) - (ToRootFare ?? -1));
                
                var bcost = baseFare * 15;
               
                var ecost = baseFare * 10;
               
                var pecost = baseFare * 12;

                



                var flight = new
                {
                    Flight_Id = f.Id,
                    Flight_Name = f.Transport.Name,
                    FromStopage= f.FromStoppage.Name,
                    ToStopage = f.ToStoppage.Name,
                    Day = f.Day,
                    Time = (f.Time)/100,
                    MaximumSeat = f.Transport.MaximumSeat,
                    EconomyClass_Cost = ecost,
                    PremiumEconomyClass_Cost = pecost,
                    BusinessClass_Cost = bcost,
                };
                flights.Add(flight);

            }
            return flights;
        }


        public static string CancelTicket(int id, int tid)
        {

            
            var tickets = (from t in DataAccessFactory.TicketDataAccess().GetAll() where t.PurchasedBy == id select PurchasedTicketModel.FromDb(t)).ToList();

            if (tickets.Count() > 1)
            {
                
                var tickett = (from t in DataAccessFactory.TicketDataAccess().GetAll() where t.Id == tid select PurchasedTicketModel.FromDb(t)).FirstOrDefault();               
                var seat = (from s in DataAccessFactory.SeatInfoDataAccess().GetAll() where s.TicketId == tid select SeatInfoModel.FromDb(s)).FirstOrDefault();

                
                if (seat != null) DataAccessFactory.SeatInfoDataAccess().Delete(seat.Id);

                
                if (tickett != null) DataAccessFactory.TicketDataAccess().Delete(tickett.Id);

                

                return "Ticket Cancel Successfully";
                
            }

            return "Ticket Cannot be Canceled";
 

        }

        public static string AddUser(UserModel userModel)
        {
            var role = (from r in DataAccessFactory.UserRoleEnumDataAccess().GetAll() where r.Value == userModel.RoleValue select UserRoleEnumModel.FromDb(r)).FirstOrDefault();
            userModel.Role = role.Id;
            userModel.Password = BCrypt.Net.BCrypt.HashPassword(userModel.Password, 12);

            if (DataAccessFactory.UserDataAccess().Add(userModel.GetDbModel()))
            {
                return "User Account Created Successfully";
            };
            return "User Account Not Created";

        }


        public static bool DeleteUser(int id)
        {
            return DataAccessFactory.UserDataAccess().Delete(id);
        }


        public static List<object> AircraftListSearch(string Name)
        {
            List<TransportModel> data;
            if (Name == "")
            {
                data = DataAccessFactory.TransportDataAccess().GetAll().Select(transport => TransportModel.FromDb(transport, true)).ToList();
            }
            else if(Name != "")
            {
                data = DataAccessFactory.TransportDataAccess().GetAll().Select(transport => TransportModel.FromDb(transport, true)).Where(transport => transport.Name.Contains(Name)).ToList();
            }
            else
            {
                data = null;
            }

            if(data != null)
            {

                var trans = new List<object>();
                foreach(var d in data)
                {
                    var schedules= new List<object>();
                    foreach(var t in d.TransportSchedules){

                        var Schedule = new
                        {
                            FlightId = t.Id,
                            FromStopage = t.FromStoppage.Name,
                            ToStopage = t.ToStoppage.Name,
                            Day = t.Day,
                            Time = (t.Time) / 100
                        };
                        
                        schedules.Add(Schedule);

                    }

                    var tran = new
                    {
                        Name = d.Name,
                        MaximumSeat = d.MaximumSeat,
                        CreatedBy = d.CreatedByUser.Name,
                        FlightSchedules = schedules
                    };
                    trans.Add(tran);

                }
                return trans;
                
            }
            return null;


        }








    }
}
