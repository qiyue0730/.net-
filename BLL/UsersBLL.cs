using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsersBLL
    {
        public static DataSet SelectuserIdDAL(Model.Users us)
        {
            return DAL.UsersDAL.SelectuserIdDAL(us);
        }
        public static int UpdateloaBLL(Model.Users us)
        {
            return DAL.UsersDAL.UpdateloaDAL(us);
        }
        public static int UpdateuserBLL(Model.Users us)
        {
            return DAL.UsersDAL.UpdateuserDAL(us);
        }
        public static DataSet SelecttwoBLL()
        {
            return DAL.UsersDAL.SelecttwoDAL();
        }
        public static int DeleteBLL(Model.Users us)
        {
            return DAL.UsersDAL.DeleteDAL(us);
        }
        public static int InsertBLL(Model.Users Users)//添加
        {

            int rows = DAL.UsersDAL.InsertDAL(Users);
            return rows;
        }
        public static DataSet SelectNameBLL(Model.Users Name)//判断用户
        {
            return DAL.UsersDAL.SelectNameDAL(Name);
        }
        public static int UserDelBLL(Model.Users UserDel)
        {
            return DAL.UsersDAL.UserDelDAL(UserDel);
        }
        public static DataSet UserNameBLL(Model.Users UserName)
        {
            return DAL.UsersDAL.UserNameDAL(UserName);
        }
        public static DataSet SelectUserBLL()
        {
            return DAL.UsersDAL.SelectUsersDAL();
        }

        public static DataSet Denglu1BLL(Model.Users d1)//登录
        {
            return DAL.UsersDAL.Denglu1DAL(d1);
        }
        public static DataSet SelectIdBLL(Model.Users SelectIdUsers)//根据用户名查询
        {
            return DAL.UsersDAL.SelectIdDAL(SelectIdUsers);
        }
        public static DataSet SelidBLL(Model.Users SelectIdUsers)//根据用户名查询
        {
            return DAL.UsersDAL.SelidDAL(SelectIdUsers);
        }
        public static int UsersUpIdBLL(Model.Users UsersUp, Model.Userinfo UserUp)//密码错误，根据手机号修改
        {
            return DAL.UsersDAL.UsersUpIdDAL(UserUp, UsersUp);
        }
        public static int UsersUpIphotoBLL(Model.Users UserIphon)
        {
            return DAL.UsersDAL.UsersUpIphotoDAL(UserIphon);
        }
        public static int UsersUpISVIPBLL(Model.Users UsersUpIS)
        {
            return DAL.UsersDAL.UsersUpISVIPDAL(UsersUpIS);
        }
    }
}
