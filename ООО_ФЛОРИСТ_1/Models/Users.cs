using System;
using System.Collections.Generic;
using System.Linq;

namespace ООО_ФЛОРИСТ_1.Models
{
    public partial class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
        }

        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserPatronymic { get; set; }
        public int UserRole { get; set; }
        public string UserSurname { get; set; }
        public string FIO //дополнительное поле для записи ФИО в одном
        {
            get
            {
                return $"{UserSurname} { UserName} { UserPatronymic}";
            }

        }
        public string dolgnost //дополниетльное поле для записи должности
        {
            get
            {
                Roles role = App.context.Roles.ToList().Find(u => u.RoleId == UserRole);
                return $"{role.RoleName}";
            }
        }
        public virtual Roles UserRoleNavigation { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
