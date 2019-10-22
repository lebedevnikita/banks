using BankDataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{



    public class SystemController : ApiController
    {

        public partial class t_dates
        {

            public string obj { get; set; }
            public string dt { get; set; }
            public string dt_mmmmYYYY { get; set; }


        }

        [Route("api/Banks/dates/{obj}")]
        [HttpGet]
        public IEnumerable<t_dates> dates(string obj)
        {
            using (BANKSEntities entities = new BANKSEntities())
            {
               
                    SqlParameter parameter1 = new SqlParameter("@obj", obj);
                    return entities.Database.SqlQuery<t_dates>(" SELECT [obj] ,[dt] ,[dt_mmmmYYYY]  FROM [BANKS].[dbo].[t_dates] where obj=@obj", parameter1).ToList();

            }

        }





    }
}
