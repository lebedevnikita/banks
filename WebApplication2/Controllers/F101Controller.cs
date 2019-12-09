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
    public class F101Controller : ApiController


    {


        [Route("api/F101/actives/{dt}")]
        [HttpGet]
        public IEnumerable<t_application_F101_actives> F101_actives(string dt)
        {
            using (BANKSEntities entities = new BANKSEntities())
            {

                SqlParameter parameter = new SqlParameter("@dt", dt);
                return entities.Database.SqlQuery<t_application_F101_actives>("SELECT [ID],[label],[val] FROM t_application_F101_actives   where [label]>=@dt", parameter).ToList();




            }

        }


        [Route("api/F101/passives/{dt}")]
        [HttpGet]
        public IEnumerable<t_application_F101_passives> F101_passives(string dt)
        {
            using (BANKSEntities entities = new BANKSEntities())
            {

                SqlParameter parameter = new SqlParameter("@dt", dt);
                return entities.Database.SqlQuery<t_application_F101_passives>("SELECT [ID],[label],[val]FROM t_application_F101_passives   where [label]>=@dt", parameter).ToList();




            }

        }

        [Route("api/F101/actives_top_n/{dt_slice}/{dt_from}/{top_n}")]
        [HttpGet]
        public IEnumerable<t_application_F101_actives_top_n> F101_actives_top_n(string dt_slice, string dt_from, int top_n)
        {
            using (BANKSEntities entities = new BANKSEntities())
            {

                SqlParameter parameter = new SqlParameter("@dt_slice", dt_slice);
                SqlParameter parameter2 = new SqlParameter("@dt_from", dt_from);
                SqlParameter parameter3 = new SqlParameter("@top_n", top_n);
                return entities.Database.SqlQuery<t_application_F101_actives_top_n>("exec p_application_dataset_F101_actives_top_n @dt_slice,@dt_from,@top_n ", parameter, parameter2, parameter3).ToList();




            }

        }


        [Route("api/F101/passives_top_n/{dt_slice}/{dt_from}/{top_n}")]
        [HttpGet]
        public IEnumerable<t_application_F101_passives_top_n> F101_passives_top_n(string dt_slice, string dt_from, int top_n)
        {
            using (BANKSEntities entities = new BANKSEntities())
            {

                SqlParameter parameter = new SqlParameter("@dt_slice", dt_slice);
                SqlParameter parameter2 = new SqlParameter("@dt_from", dt_from);
                SqlParameter parameter3 = new SqlParameter("@top_n", top_n);
                return entities.Database.SqlQuery<t_application_F101_passives_top_n>("exec p_application_dataset_F101_passives_top_n  @dt_slice,@dt_from,@top_n ", parameter, parameter2, parameter3).ToList();




            }

        }








        [Route("api/F101/bank_actives/{dt}/{bank}")]
        [HttpGet]
        public IEnumerable<t_application_F101_actives_top_n> F101_bank_actives(string dt, string bank)
        {
            using (BANKSEntities entities = new BANKSEntities())
            {

                SqlParameter parameter = new SqlParameter("@dt", dt);
                SqlParameter parameter2 = new SqlParameter("@bank", bank);
                return entities.Database.SqlQuery<t_application_F101_actives_top_n>("SELECT * FROM t_application_F101_actives_top_n   where [dt]>=@dt and ShortName=@bank", parameter, parameter2).ToList();




            }

        }



        [Route("api/F101/bank_passives/{dt}/{bank}")]
        [HttpGet]
        public IEnumerable<t_application_F101_passives_top_n> F101_bank_passives(string dt, string bank)
        {
            using (BANKSEntities entities = new BANKSEntities())
            {

                SqlParameter parameter = new SqlParameter("@dt", dt);
                SqlParameter parameter2 = new SqlParameter("@bank", bank);
                return entities.Database.SqlQuery<t_application_F101_passives_top_n>("SELECT * FROM t_application_F101_passives_top_n   where [dt]>=@dt and ShortName=@bank", parameter, parameter2).ToList();




            }

        }

        /*
                [Route("api/F101/all_banks/{dt_from}/{dt_to}")]
                [HttpGet]
                public IEnumerable<t_application_F101_all_banks> F101_all_banks(string dt_from, string dt_to)
                {
                    using (BANKSEntities entities = new BANKSEntities())
                    {

                        SqlParameter parameter = new SqlParameter("@dt_from", dt_from);
                        SqlParameter parameter2 = new SqlParameter("@dt_to", dt_to);
                        return entities.Database.SqlQuery<t_application_F101_all_banks>("SELECT * FROM t_application_F101_all_banks   where [dt] between @dt_from and @dt_to ", parameter, parameter2).ToList();

                    }

                }
         */

        public partial class F101_allbanks
        {
            public Nullable<System.DateTime> dt { get; set; }
            public string pln { get; set; }
            public Nullable<long> ap { get; set; }
            public int tip { get; set; }
            public string IndCode { get; set; }
            public string regn { get; set; }
            public Nullable<long> col_1 { get; set; }
            public Nullable<long> col_2 { get; set; }
            public Nullable<long> col_3 { get; set; }

            
        }



     

        [Route("api/F101/data/{MODE}/{tip}/{str}/{dt_from}/{dt_to}")]
        [HttpGet]
        public IEnumerable<F101_allbanks> F101_data(string MODE, int tip, string str, string dt_from, string dt_to)
        {
            using (BANKSEntities entities = new BANKSEntities())
            {


                    SqlParameter parameter1 = new SqlParameter("@MODE", MODE);
                    SqlParameter parameter2 = new SqlParameter("@tip", tip);
                    SqlParameter parameter3 = new SqlParameter("@str", str);
                    SqlParameter parameter4 = new SqlParameter("@dt_from", dt_from);
                    SqlParameter parameter5 = new SqlParameter("@dt_to", dt_to);
                    return entities.Database.SqlQuery<F101_allbanks>("exec [dbo].[p_application_dataset_F101] @MODE,@tip, @str, @dt_from ,@dt_to", parameter1, parameter2, parameter3, parameter4, parameter5).ToList();

            }

        }



     






    }
}
