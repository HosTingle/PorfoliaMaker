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
        public static string UserRegisteredError = "Kayıt olurken hata oluştu, daha sonra tekrar deneyiniz.";
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

        public static string UserInfoApplicantSuccess = "Başvuru bilgileri güncellendi";

        public static string UserInfoPersonalSucces = "Kişisel bilgileri güncellendi";

        public static string UserInfoAboutSucces = "Bilgiler güncellendi"; 

        public static string UserInfoAboutError = "Bilgiler güncellenirken hata oluştu";

        public static string UpdateEducation = "Eğitim bilgileri güncellendi";

        public static string UpdateErrorEducation= "Eğitim bilgileri güncellenirken hata oluştu";

        public static string UpdateForeignError = "Yabancı diller güncellenirken hata oluştu";

        public static string UpdateForeign = "Yabancı diller güncellendi";

        public static string UpdateWorkExp = "İş deniyimi bilgileri güncellendi";

        public static string UpdateWorkExpError = "İş deniyimi bilgileri güncellenirken hata oluştu";

        public static string UpdateCertificateError = "Sertifikalar güncellenirken hata oluştu";

        public static string UpdateCertificate = "Sertifika bilgileri güncellendi";

        public static string UserInfoApplicantError = "Başvuru bilgileri güncellenirken hata oluştu";

        public static string UpdateSocialLinks = "Linkler güncellendi";

        public static string UnAuthorizedAccess = "Yetkisiz İstek";
    }
}

