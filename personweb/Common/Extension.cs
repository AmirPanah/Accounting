﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Common
{
   public static class Extension
    {
        public static Int32 ToInt(this string s)
        {
            return (s.Length > 0 ? Int32.Parse(s) : 0);
        }
        public static string ToFarsiNumber(this string s)
        {
            return PersonTools.FarsiNum(s);
        }
        public static string ToMD5(this string s)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(s, "MD5");
        }
    }
}
