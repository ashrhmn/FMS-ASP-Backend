﻿namespace Web_API.Models
{
    public static class RoleConst
    {
        public static string User()
        {
            return "user";
        }
        public static string Admin { set; get; } = "admin";
        public static string FlightManager { set; get; } = "flight_manager";
    }
}