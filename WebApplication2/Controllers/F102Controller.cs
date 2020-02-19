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
    public class F102Controller : ApiController


    {


        [Route("api/F102/data/{slice}/{field_id}/{regn}/{dt_from}/{dt_to}")]
        [HttpGet]
        public IEnumerable<p_application_dataset_F102_Result> F102_data(string slice, int field_id, string regn, string dt_from, string dt_to)
        {
            using (BANKSEntities entities = new BANKSEntities())
            {

                SqlParameter parameter1 = new SqlParameter("@slice", slice);
                SqlParameter parameter2 = new SqlParameter("@field_id", field_id);
                SqlParameter parameter3 = new SqlParameter("@regn", regn);
                SqlParameter parameter4 = new SqlParameter("@dt_from", dt_from);
                SqlParameter parameter5 = new SqlParameter("@dt_to", dt_to);
                return entities.Database.SqlQuery<p_application_dataset_F102_Result>("exec [dbo].[p_application_dataset_F102] @slice,@field_id, @regn, @dt_from ,@dt_to", parameter1, parameter2, parameter3, parameter4, parameter5).ToList();


            }

        } 






    }
}
