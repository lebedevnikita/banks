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
    public class Form101IndicatorsController : ApiController
    {


        /*весь справочник статей баланса*/
        [Route("api/Form101Indicators/allForm101Indicators")]
        [HttpGet]
        public IEnumerable<t_Form101Indicators> allForm101Indicators(string indcode)
        {
            using (BANKSEntities entities = new BANKSEntities())
            {


                return entities.t_Form101Indicators.ToList();


            }

        }





        /*поиск статьи баланса по indcode*/
        [Route("api/Form101Indicators/IndCode/{indcode}")]
        [HttpGet]
        public t_Form101Indicators IndCode(string indcode)
        {
            using (BANKSEntities entities = new BANKSEntities())
            {


                return entities.t_Form101Indicators.FirstOrDefault(x => x.IndCode == indcode);


            }

        }

        /*поиск статьи баланса по name*/
        [Route("api/Form101Indicators/name/{name}")]
        [HttpGet]
        public t_Form101Indicators name(string name)
        {
            using (BANKSEntities entities = new BANKSEntities())
            {


                return entities.t_Form101Indicators.FirstOrDefault(x => x.Name == name);


            }

        }


        /*поиск статьи баланса like indcode + top N*/
        [Route("api/Form101Indicators/likeIndCode/{indcode}/take_cnt_rows/{cnt_rows}")]
        [HttpGet]
        public IEnumerable<t_Form101Indicators> likeIndCode_take_cnt_rows(string indcode, int cnt_rows)
        {
            using (BANKSEntities entities = new BANKSEntities())
            {

                SqlParameter parameter = new SqlParameter("@IndCode", indcode);
                return entities.Database.SqlQuery<t_Form101Indicators>("SELECT [IndID],[IndCode],[Name],[IndType],[IndChapter] FROM [BANKS].[dbo].[t_Form101Indicators]   where [IndCode] like N'%'+@IndCode+'%'", parameter).ToList().Take(cnt_rows);


            }

        }

        /*поиск статьи баланса like indcode*/
        [Route("api/Form101Indicators/likeIndCode/{indcode}")]
        [HttpGet]
        public IEnumerable<t_Form101Indicators> likeIndCode(string indcode)
        {
            using (BANKSEntities entities = new BANKSEntities())
            {

                SqlParameter parameter = new SqlParameter("@IndCode", indcode);
                return entities.Database.SqlQuery<t_Form101Indicators>("SELECT [IndID],[IndCode],[Name],[IndType],[IndChapter] FROM [BANKS].[dbo].[t_Form101Indicators]   where [IndCode] like N'%'+@IndCode+'%'", parameter).ToList();


            }

        }





        /*поиск статьи баланса like name + top N*/
        [Route("api/Form101Indicators/likename/{name}/take_cnt_rows/{cnt_rows}")]
        [HttpGet]
        public IEnumerable<t_Form101Indicators> likename_take_cnt_rows(string name, int cnt_rows)
        {
            using (BANKSEntities entities = new BANKSEntities())
            {

                SqlParameter parameter = new SqlParameter("@name", name);
                return entities.Database.SqlQuery<t_Form101Indicators>("SELECT [IndID],[IndCode],[Name],[IndType],[IndChapter] FROM [BANKS].[dbo].[t_Form101Indicators]   where [Name] like N'%'+@name+'%'", parameter).ToList().Take(cnt_rows);


            }

        }

        /*поиск статьи баланса like name */
        [Route("api/Form101Indicators/likeIndCode/{name}")]
        [HttpGet]
        public IEnumerable<t_Form101Indicators> likename(string name)
        {
            using (BANKSEntities entities = new BANKSEntities())
            {


                SqlParameter parameter = new SqlParameter("@name", name);
                return entities.Database.SqlQuery<t_Form101Indicators>("SELECT [IndID],[IndCode],[Name],[IndType],[IndChapter] FROM [BANKS].[dbo].[t_Form101Indicators]   where [Name] like N'%'+@name+'%'", parameter).ToList();


            }

        }





        
        /*поиск статьи баланса начинается на indcode + top N*/
        [Route("api/Form101Indicators/starts_at_IndCode/{indcode}/take_cnt_rows/{cnt_rows}")]
        [HttpGet]
        public IEnumerable<t_Form101Indicators> starts_at_IndCode_take_cnt_rows(string indcode, int cnt_rows)
        {
            using (BANKSEntities entities = new BANKSEntities())
            {

                SqlParameter parameter = new SqlParameter("@IndCode", indcode);
                return entities.Database.SqlQuery<t_Form101Indicators>("SELECT [IndID],[IndCode],[Name],[IndType],[IndChapter] FROM [BANKS].[dbo].[t_Form101Indicators]   where [IndCode] like N''+@IndCode+'%'", parameter).ToList().Take(cnt_rows);


            }

        }

        /*поиск статьи баланса начинается на indcode*/
        [Route("api/Form101Indicators/starts_at_IndCode/{indcode}")]
        [HttpGet]
        public IEnumerable<t_Form101Indicators> starts_at_IndCode(string indcode)
        {
            using (BANKSEntities entities = new BANKSEntities())
            {

                SqlParameter parameter = new SqlParameter("@IndCode", indcode);
                return entities.Database.SqlQuery<t_Form101Indicators>("SELECT [IndID],[IndCode],[Name],[IndType],[IndChapter] FROM [BANKS].[dbo].[t_Form101Indicators]   where [IndCode] like N''+@IndCode+'%'", parameter).ToList();


            }

        }




        /*поиск статьи баланса начинается на name + top N*/
        [Route("api/Form101Indicators/likename/{name}/take_cnt_rows/{cnt_rows}")]
        [HttpGet]
        public IEnumerable<t_Form101Indicators> starts_at_name_take_cnt_rows(string name, int cnt_rows)
        {
            using (BANKSEntities entities = new BANKSEntities())
            {

                SqlParameter parameter = new SqlParameter("@name", name);
                return entities.Database.SqlQuery<t_Form101Indicators>("SELECT [IndID],[IndCode],[Name],[IndType],[IndChapter] FROM [BANKS].[dbo].[t_Form101Indicators]   where [Name] like N''+@name+'%'", parameter).ToList().Take(cnt_rows);


            }

        }

        /*поиск статьи баланса начинается на name*/
        [Route("api/Form101Indicators/likeIndCode/{name}")]
        [HttpGet]
        public IEnumerable<t_Form101Indicators> starts_at_name(string name)
        {
            using (BANKSEntities entities = new BANKSEntities())
            {


                SqlParameter parameter = new SqlParameter("@name", name);
                return entities.Database.SqlQuery<t_Form101Indicators>("SELECT [IndID],[IndCode],[Name],[IndType],[IndChapter] FROM [BANKS].[dbo].[t_Form101Indicators]   where [Name] like N''+@name+'%'", parameter).ToList();


            }

        }




    }
}
