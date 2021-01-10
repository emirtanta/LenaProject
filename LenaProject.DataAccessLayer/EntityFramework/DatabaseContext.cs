
using LenaProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenaProject.DataAccessLayer.EntityFramework
{
    public class DatabaseContext : DbContext
    {
       
        public DbSet<LenaUser> LenaUsers { get; set; }

        //veritabanı içinde veri olmadan oluşturulmuştu.İçerisine örnek veriler ekleme işlemi için silip tekrar yüklenmesi gerektiğinden dolayı aşağıdaki kod bloğu oluşturuldu.Bu bölüm isteğe bağlı olup kullanılmayabilir
        public DatabaseContext()
        {
            Database.SetInitializer(new MyInitializer());
        }
    }
}
