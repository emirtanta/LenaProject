
using LenaProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenaProject.DataAccessLayer.EntityFramework
{
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        //veritabanındaki tabloların içerisine örnek data eklemek için tanımlandı(isteğe bağlı)
        protected override void Seed(DatabaseContext context)
        {
            //adding admin user
            LenaUser admin = new LenaUser()
            {
                Name = "Cem",
                Surname = "Can",
                Email = "cemcan@hotmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                Username = "cemcan",
                Password = "123456",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "cemcan"
            };

            //yeni bir kullanıcı (satandart kullanıcı)
            LenaUser standartUser = new LenaUser()
            {
                Name = "Ali",
                Surname = "Veli",
                Email = "aliveli@hotmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                Username = "aliveli",
                Password = "654321",
                CreatedOn = DateTime.Now.AddHours(1),
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "aliveli"
            };

            context.LenaUsers.Add(admin);
            context.LenaUsers.Add(standartUser);
            
        }
    }
}
