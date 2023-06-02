using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareVVNZ.AppCode
{
    class RoleApp
    {
        public List<Role> GetRoleList()
        {
            List<Role> RoleList = new List<Role>();
            RoleList.Add(new Role(1, "Системний адміністратор"));
            //RoleList.Add(new Role(2, "Користувач"));
            RoleList.Add(new Role(2, "Викладач"));
            RoleList.Add(new Role(3, "Студент"));
            return RoleList;
        }

    }
}

public class Role
{
    private int _RoleId;
    private string _RoleName;
    public Role()
    {
        _RoleId = 0;
        _RoleName = String.Empty;
    }
    public Role(int RoleId, string RoleName)
    {
        _RoleId = RoleId;
        _RoleName = RoleName;
    }

    public int RoleId
    {
        set { _RoleId = value; }
        get { return _RoleId; }
    }
    public string RoleName
    {
        set { _RoleName = value; }
        get { return _RoleName; }
    }
}
