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

            profileViewModel.profileModel = GetAllProfileMembers();
            profileViewModel.AllColumnSelectList = GetAllProfileSelectList();
            profileViewModel.AllFilterSelectList = GetAllFilterSelectList();
            return View(profileViewModel);
        }

        [HttpPost]
        public ActionResult Index(string SelectColumn, string SelectFilter, string SearchTerm)
        {

            ProfileViewModel profileViewModel = new ProfileViewModel();

            profileViewModel.profileModel = GetAllProfileMembers();
            profileViewModel.AllColumnSelectList = GetAllProfileSelectList();
            profileViewModel.AllFilterSelectList = GetAllFilterSelectList();

            return View(profileViewModel);
        }

        public List<ProfileModel> GetAllProfileMembers()
        {
            var profiles = mm.Profiles.Select(x => new ProfileModel()
            {
                Id = x.Id,
                Email = x.Email,
                MailUpID = x.MailUpID,
                OptIn = x.OptIn,
                Deleted = x.Deleted,
                Created = x.Created,
                Updated = x.Updated,
                ExternalId = x.ExternalId,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                Address = x.Address,
                Address2 = x.Address2,
                Postcode = x.Postcode,
                City = x.City,
                Country = x.Country,
                Phone = x.Phone,
                Mobile = x.Mobile,
                CVRnummer = x.CVRnummer,
                BrugerID = x.BrugerID,
                Medlemsstatus = x.Medlemsstatus,
                Foreningsnummer = x.Foreningsnummer,
                Foedselsaar = x.Foedselsaar,
                HektarDrevet = x.HektarDrevet,
                AntalAndetKvaeg = x.AntalAndetKvaeg,
                AntalAmmekoeer = x.AntalAmmekoeer,
                AntaMalkekoeer = x.AntaMalkekoeer,
                AntalSlagtesvin = x.AntalSlagtesvin,
                AntalSoeer = x.AntalSoeer,
                AntalAarssoeer = x.AntalAarssoeer,
                AntalPelsdyr = x.AntalPelsdyr,
                AntalHoens = x.AntalHoens,
                AntalKyllinger = x.AntalKyllinger,
                Ecology = x.Ecology,
                Sektion_SSJ = x.Sektion_SSJ,
                Driftform_planteavl = x.Driftform_planteavl,
                Driftform_Koed_Koer = x.Driftform_Koed_Koer,
                Driftform_Mælk = x.Driftform_Mælk,
                Driftform_Svin = x.Driftform_Svin,
                Driftform_Pelsdyr = x.Driftform_Pelsdyr,
                Driftform_Aeg_Kylling = x.Driftform_Aeg_Kylling,
                Driftstoerrelse_Planteavl = x.Driftstoerrelse_Planteavl,
                Driftstoerrelse_Koed_Koer = x.Driftstoerrelse_Koed_Koer,
                Driftfstoerrelse_Mælk = x.Driftfstoerrelse_Mælk,
                Driftstoerrelse_Svin = x.Driftstoerrelse_Svin,
                Driftstoerrelse_Pelsdyr = x.Driftstoerrelse_Pelsdyr,
                Driftstoerrelse_Aeg_Kylling = x.Driftstoerrelse_Aeg_Kylling,
                AntalSlagtekvaeg = x.AntalSlagtekvaeg,
            }).OrderBy(x => x.Id).Take(500).ToList();

            return profiles;
        }

        public List<SelectListItem> GetAllProfileSelectList()
        {
            List<SelectListItem> entities = new List<SelectListItem>();

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
