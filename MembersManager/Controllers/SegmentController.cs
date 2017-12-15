using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using MembersManager.Models;
using MembersManager.Models.Entities;

namespace MembersManager.Controllers
{
    public class SegmentController : Controller
    {
        MemberManagerEntities mm = new MemberManagerEntities();
        // GET: Segment
        public ActionResult Index()
        {
            //return View(mm.Segments.Select(s => new SegmentViewModels()
            //{
            //    Id = s.ID,
            //    Name = s.Name,
            //    MailUpGroupID = s.MailUpGroupID,
            //    Query = s.Query
            //}).ToList());


            ProfileViewModel profileViewModel = new ProfileViewModel();
            
            //profileViewModel.profileModel = GetAllProfileMembers();

            List<MembersManager.Models.Entities.Profile> profile = new List<Profile>();
            profile = mm.Profiles.SqlQuery("Select TOP 500 * from Profiles order by Id").ToList();
            profileViewModel.ProfileData = profile;


            profileViewModel.AllColumnSelectList = GetAllProfileSelectList();
            profileViewModel.AllFilterSelectList = GetAllFilterSelectList();
            return View(profileViewModel);
        }

        [HttpPost]
        public ActionResult Index(ProfileViewModel model/*string SelectColumn, string SelectFilter, string SearchTerm*/)
        {

            ProfileViewModel profileViewModel = new ProfileViewModel();
        
            profileViewModel.ProfileData = GetSearchProfileMembers(model.SelectColumn, model.SelectFilter, model.SearchTerm);
            //end list

            profileViewModel.AllColumnSelectList = GetAllProfileSelectList();
            profileViewModel.AllFilterSelectList = GetAllFilterSelectList();

            return View(profileViewModel);
        }

        public List<MembersManager.Models.Entities.Profile> GetSearchProfileMembers(string SelectColumn, string SelectFilter, string SearchTerm)
        {
            List<MembersManager.Models.Entities.Profile> list = new List<Profile>();
            string firstQuery = "Select TOP 500 * from Profiles";

            //Type t = typeof(Profile);

            //foreach (var prop in t.GetProperties())
            //{
            //    dict.Add(new KeyValuePair<string, string>(prop.Name, prop.PropertyType.Name));
            //}

            //string dataType = string.Empty;
            //foreach (KeyValuePair<string, string> item in dict)
            //{
            //    if (item.Key == SelectColumn)
            //    {
            //        dataType = item.Value;
            //        break;
            //    }
            //}

            string Query = string.Empty;

            if (SelectFilter == "1")
            {
                //equal
                Query = string.Format("{0} where {1} = '{2}' order by Id ", firstQuery, SelectColumn, SearchTerm);
                list = mm.Profiles.SqlQuery(Query).ToList();
            }

            else if (SelectFilter == "2")
            {
                //not equal
                Query = string.Format("{0} where {1} != '{2}' order by Id ", firstQuery,SelectColumn, SearchTerm);
                list = mm.Profiles.SqlQuery(Query).ToList();
            }

            else if (SelectFilter == "3")
            {
                //in
                string[] words = SearchTerm.Split(',');
                string terms=string.Empty;
                var index = 0;
                foreach (string word in words)
                {
                    if (index > 0)
                    {
                        terms = terms + ",";                        
                    }
                    //sw.Write(itemChecked.ToString());
                    index++;
                    terms = terms+ string.Format("'{0}'",word);
                }
                // IN ('Germany', 'France', 'UK')
                Query = string.Format("{0} where {1} IN ({2}) order by Id ", firstQuery, SelectColumn, terms);
                list = mm.Profiles.SqlQuery(Query).ToList();
            }

            else if (SelectFilter == "4")
            {
                //not in
                string[] words = SearchTerm.Split(',');
                string terms = string.Empty;
                var index = 0;
                foreach (string word in words)
                {
                    if (index > 0)
                    {
                        terms = terms + ",";
                    }
                    //sw.Write(itemChecked.ToString());
                    index++;
                    terms = terms + string.Format("'{0}'", word);
                }
                // IN ('Germany', 'France', 'UK')
                Query = string.Format("{0} where {1} NOT IN ({2}) order by Id ", firstQuery, SelectColumn, terms);
                list = mm.Profiles.SqlQuery(Query).ToList();
            }

            else if (SelectFilter == "5")
            {
                //less
                Query = string.Format("{0} where {1} < '{2}' order by Id ", firstQuery, SelectColumn, SearchTerm);
                list = mm.Profiles.SqlQuery(Query).ToList();
            }

            else if (SelectFilter == "6")
            {
                //less or equal
                Query = string.Format("{0} where {1} <= '{2}' order by Id ", firstQuery, SelectColumn, SearchTerm);
                list = mm.Profiles.SqlQuery(Query).ToList();
            }
            else if (SelectFilter == "7")
            {
                //greater
                Query = string.Format("{0} where {1} > '{2}' order by Id ", firstQuery, SelectColumn, SearchTerm);
                list = mm.Profiles.SqlQuery(Query).ToList();
            }
            else if (SelectFilter == "8")
            {
                //greater or equal
                Query = string.Format("{0} where {1} >= '{2}' order by Id ", firstQuery, SelectColumn, SearchTerm);
                list = mm.Profiles.SqlQuery(Query).ToList();
            }

            else if (SelectFilter == "9")
            {
                //between
                //WHERE column_name BETWEEN value1 AND value2;

                string[] words = SearchTerm.Split(',');       
                string term1 = (words[0] !=null) ? words[0] : string.Empty;
                string term2 = (words[1] != null) ? words[1] : string.Empty;
              
                Query = string.Format("{0} where {1} BETWEEN '{2}' AND '{3}' order by Id ", firstQuery, SelectColumn, term1,term2);
                list = mm.Profiles.SqlQuery(Query).ToList();
            }
            else if (SelectFilter == "10")
            {
                //not between
                //WHERE column_name BETWEEN value1 AND value2;

                string[] words = SearchTerm.Split(',');
                string term1 = (words[0] != null) ? words[0] : string.Empty;
                string term2 = (words[1] != null) ? words[1] : string.Empty;

                Query = string.Format("{0} where {1} NOT BETWEEN '{2}' AND '{3}' order by Id ", firstQuery, SelectColumn, term1, term2);
                list = mm.Profiles.SqlQuery(Query).ToList();
            }
            else if (SelectFilter == "11")
            {
                //greater or equal
                Query = string.Format("{0} where {1} IS  NULL  order by Id ", firstQuery, SelectColumn);
                list = mm.Profiles.SqlQuery(Query).ToList();
            }
            else if (SelectFilter == "12")
            {
                //greater or equal
                Query = string.Format("{0} where {1} IS NOT NULL order by Id ", firstQuery, SelectColumn);
                list = mm.Profiles.SqlQuery(Query).ToList();
            }

            else
            {
                list= mm.Profiles.SqlQuery("{0} order by Id").ToList(); 
            }

            //insert query to db
            if(Query!=string.Empty)
            {
                //db add
                MembersManager.Models.Entities.Segment segment = new Segment()
                {
                    Name            = null,
                    Query           = Query,
                    MailUpGroupID   = null,
                };
                try
                {
                    mm.Segments.Add(segment);
                    mm.SaveChanges();
                }
                catch(Exception e)
                {
                   var error= e.ToString();
                }
               
            }
            //end
            return list;
        }
              

        IDictionary<string, string> dict = new Dictionary<string, string>();

        public List<SelectListItem> GetAllProfileSelectList()
        {
            List<SelectListItem> entities = new List<SelectListItem>();



            //get all column name
            var columnNames = typeof(Profile).GetProperties().Select(property => property.Name).ToArray();

            //var query = (from x in mm.Profiles
            //            select x).Take(0);
            //Models.Entities.Profile spr = query.SingleOrDefault();
            //var columnNames = typeof(Models.Entities.Profile).GetProperties().Select(property => property.Name).ToArray();

            foreach (var column in columnNames)
            {
                entities.Add(new SelectListItem()
                {
                    Value = column.ToString(),
                    Text = column.ToString(),
                }
              );
            }

            return entities;
        }

        public List<SelectListItem> GetAllFilterSelectList()
        {
            List<SelectListItem> entities = new List<SelectListItem>();

            entities.Add(new SelectListItem() { Text = "equal", Value = "1" });
            entities.Add(new SelectListItem() { Text = "not equal", Value = "2" });
            entities.Add(new SelectListItem() { Text = "in", Value = "3" });
            entities.Add(new SelectListItem() { Text = "not in", Value = "4" });
            entities.Add(new SelectListItem() { Text = "less", Value = "5" });
            entities.Add(new SelectListItem() { Text = "less or equal", Value = "6" });
            entities.Add(new SelectListItem() { Text = "greater", Value = "7" });
            entities.Add(new SelectListItem() { Text = "greater or equal", Value = "8" });
            entities.Add(new SelectListItem() { Text = "between", Value = "9" });
            entities.Add(new SelectListItem() { Text = "not between", Value = "10" });
            entities.Add(new SelectListItem() { Text = "is null", Value = "11" });
            entities.Add(new SelectListItem() { Text = "is not null", Value = "12" });        

            return entities;
        }

        // GET: Segment/Details/5
        public ActionResult Details(string id)
        {

            return View();
        }


        public ActionResult Create()
        {
            return View();
        }


        // GET: Segment/Create
        [HttpPost]
        public ActionResult Create(SegmentViewModels model)
        {
            mm.Segments.Add(new Segment()
            {
                Name = model.Name,
                MailUpGroupID = model.MailUpGroupID,
                Query = model.Query
            });

            mm.SaveChanges();

            return View();
        }


        // GET: Segment/Edit/5
        public ActionResult Edit(string id)
        {

            return View();
        }


        // GET: Segment/Delete/5
        public ActionResult Delete(string id)
        {

            return View();
        }


        protected override void Dispose(bool disposing)
        {

            base.Dispose(disposing);
        }
    }
}
