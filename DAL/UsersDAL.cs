using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsersDAL
    {
        //管理员
        public static DataSet SelectuserIdDAL(Model.Users us)
        {
            string sql = string.Format("select * from Users where UserId='{0}'", us.UserId);
            return DBHelper.GetDataSet(sql);
        }
        public static int UpdateloaDAL(Model.Users us)
        {
            string sql = string.Format("update Users set  LOA='{0}' where UserId='{1}'", us.LOA, us.UserId);
            return DBHelper.zsg(sql);
        }
        public static int UpdateuserDAL(Model.Users us)
        {
            string sql = string.Format("update Users set  Username='{0}',Userpwd='{1}',LOA='{2}' where UserId='{3}'", us.Username, us.Userpwd, us.LOA, us.UserId);
            return DBHelper.zsg(sql);
        }
        public static DataSet SelecttwoDAL()
        {
            string sql = "select * from Users us left join Userinfo ui on us.UserId=ui.UserId";
            return DBHelper.GetDataSet(sql);
        }
        public static int DeleteDAL(Model.Users us)
        {
            string sql = string.Format("delete from Users where UserId='{0}'", us.UserId);
            return DBHelper.zsg(sql);
        }


        //普通用户
        public static int InsertDAL(Model.Users Users)//注册
        {
            string sql = string.Format("insert into Users values('{0}','{1}','{2}','{3}')",Users.Username,Users.Userpwd,Users.LOA,Users.Isvip);
            return DBHelper.zsg(sql);
        }
        public static int UserDelDAL(Model.Users UserDel)
        {
            string sql = string.Format("delete from Users where UserId={0}",UserDel.UserId);
            return DBHelper.zsg(sql);
        }
        public static DataSet SelectNameDAL(Model.Users Name)//判断用户名是否存在
        {
            string sql = string.Format("select count(*) from Users where Username='{0}'",Name.Username);
            return DBHelper.GetDataSet(sql);
        }
        public static DataSet UserNameDAL(Model.Users UserName)
        {
            string sql = string.Format("select * from Users where Username='{0}'",UserName.Username);
            return DBHelper.GetDataSet(sql);
        }
        //查询方法
        public static DataSet SelectUsersDAL()
        {
            string sql = "select * from Users";
            return DBHelper.GetDataSet(sql);
        }

        public static DataSet Denglu1DAL(Model.Users d1)//登录
        {
            string sql = string.Format("select * from Users where Username='{0}' and Userpwd='{1}'",d1.Username,d1.Userpwd);
            return DBHelper.GetDataSet(sql);
        }
        public static DataSet SelectIdDAL(Model.Users SelectIdUsers)//根据用户名查询
        {
            string sql = string.Format("select * from Users where Username='{0}'", SelectIdUsers.Username);
            return DBHelper.GetDataSet(sql);
        }
        public static DataSet SelidDAL(Model.Users SelectIdUsers)//根据用户名查询
        {
            string sql = string.Format("select UserId,Isvip from Users where Username='{0}'", SelectIdUsers.Username);
            return DBHelper.GetDataSet(sql);
        }
        public static int UsersUpIdDAL(Model.Userinfo UserUp, Model.Users UsersUp)//密码错误，根据手机号修改
        {
            string sql = string.Format(" update Users set Username='{0}',Userpwd='{1}' where UserId=(select UserId from Userinfo where Useriphon='{2}') ", UsersUp.Username, UsersUp.Userpwd, UserUp.Useriphon);
            return DBHelper.zsg(sql);
        }
        public static int UsersUpIphotoDAL(Model.Users UserIphon)
        {
            string sql = string.Format("update Users set Username='{0}',Userpwd='{1}' where UserId='{2}'", UserIphon.Username, UserIphon.Userpwd, UserIphon.UserId);
            return DBHelper.zsg(sql);
        }
        public static int UsersUpISVIPDAL(Model.Users UsersUpIS) 
        {
            string sql = string.Format("update [dbo].[Users] set Isvip='1' where UserId='{0}'", UsersUpIS.UserId);
            return DBHelper.zsg(sql);
        }
    }
}
