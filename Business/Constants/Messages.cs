﻿using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UserAdded = "User eklendi";
        public static string UserNameInvalid = "User ismi geçersiz";
        public static string MainIntanceTime="Sistem Bakımda";
        public static string UsersList="Userlar Listelendi";
        public static string MessageFAS = "Kişi eklenme sayısı dolu";
        public static string? AuthorizationDenied="Yetkiniz yok";
        internal static string UserRegistered;
        public static string UserNotFound="Bilgiler Yanlış Girildi,Tekrar Deneyiniz";
        public static string PasswordError="Bilgiler Yanlış Girildi,Tekrar Deneyiniz";
        public static string SuccessfulLogin="Giriş Başarılı";
        internal static string UserAlreadyExists;
        internal static string AccessTokenCreated;
        internal static string BlogAdd="Blog eklendi";
    }
}
