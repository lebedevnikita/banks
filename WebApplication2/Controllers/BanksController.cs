using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BankDataAccess;

namespace WebApplication2.Controllers
{
    public class BanksController : ApiController
    {




        /*

         [Route("api/Banks/allbanks/{shortname}/take_cnt_rows/{cnt_rows}")]
         [HttpGet]
         public IEnumerable<t_BIC_CO> Allbanks(string shortname,int cnt_rows)
         {
             using (BANKSEntities entities = new BANKSEntities())
             {

                 SqlParameter parameter = new SqlParameter("@shortname", shortname);
                 return entities.Database.SqlQuery<t_BIC_CO>("SELECT [ID],[DU],[ShortName],[Bic],[RegNum],[RegNum_date],[IntCode],[RegNumber],LOAD_DT FROM [BANKS].[dbo].[t_BIC_CO]   where [shortname] like N'%'+@shortname+'%'", parameter).ToList().Take(cnt_rows);




             }

         }





         [Route("api/Banks/bankinfo/{regnumber}")]
         [HttpGet]
         public IEnumerable<t_BIC_CO> bankinfo( int regnumber)
         {
             using (BANKSEntities entities = new BANKSEntities())
             {

                 SqlParameter parameter = new SqlParameter("@regnumber", regnumber);
                 return entities.Database.SqlQuery<t_BIC_CO>("SELECT [ID],[DU],[ShortName],[Bic],[RegNum],[RegNum_date],[IntCode],[RegNumber],LOAD_DT FROM [BANKS].[dbo].[t_BIC_CO]   where [regnumber] =@regnumber", parameter).ToList();




             }

         }

     */

        [Route("api/Banks/bankinfo/{MODE}/{shortname}/{n}")]
        [HttpGet]
        public IEnumerable<t_BIC_CO> bankinfo(string MODE , string shortname  , int n )
        {
            using (BANKSEntities entities = new BANKSEntities())
            {
                if (MODE == "bankinfo")
                {
                    SqlParameter parameter1 = new SqlParameter("@MODE", MODE);
                    SqlParameter parameter2 = new SqlParameter("@regnumber", n);
                    return entities.Database.SqlQuery<t_BIC_CO>(" exec  p_application_bankinfo @MODE,  null, @regnumber", parameter1, parameter2).ToList();
                }

                else

                {
                    SqlParameter parameter1 = new SqlParameter("@MODE", MODE);
                    SqlParameter parameter2 = new SqlParameter("@shortname", shortname);
                    return entities.Database.SqlQuery<t_BIC_CO>(" exec p_application_bankinfo @MODE,  @shortname, null", parameter1, parameter2).ToList().Take(n);
                }


            }

        }



    }
}
