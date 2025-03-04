using Core.Entities.Concrete;
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
        public static string AuthorizationDenied="Yetkiniz yok";
        public static string UserRegistered="Kayıt başarılı, Giriş Yapın";
        public static string UserNotFound="Bilgiler Yanlış Girildi,Tekrar Deneyiniz";
        public static string PasswordError="Bilgiler Yanlış Girildi,Tekrar Deneyiniz";
        public static string SuccessfulLogin="Giriş Başarılı";
        public static string UserAlreadyExists;
        public static string AccessTokenCreated;
        public static string BlogAdd ="Blog eklendi";
        public static string UserRoleErrorMesage="Bir hatadan dolayı, Rol eklenemedi";
        public static string BlogNotAdd="Project Eklenemedi";
        public static string UpdateBlog = "Blog Güncellendi";
        public static string ProjectGüncellendi = "Proje güncellendi";
        public static string ProjectGüncellenemedi = "Proje güncelenemedi, sonra tekrar deneyin";
        public static string ProjectDelete=  "Proje silindi";
        public static string ProjectNotDelete = "Proje silinemedi, sonra tekrar deneyin";
        public static string DeleteBlog = "Blog silindi";
        public static string DeleteBlogNot = "Blog silinemedi, sonra tekrar deneyin";

    }
}
