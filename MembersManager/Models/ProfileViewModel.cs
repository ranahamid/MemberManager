using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MembersManager.Models
{
    public class ProfileViewModel
    {
        public List<MembersManager.Models.Entities.Profile> ProfileData { get; set; }
       // public List<ProfileModel> profileModel { get; set; }

        public List<SelectListItem> AllColumnSelectList = new List<SelectListItem>();
        public string SelectColumn { get; set; }

        public List<SelectListItem> AllFilterSelectList = new List<SelectListItem>();
        public string SelectFilter { get; set; }

        public string SearchTerm { get; set; }

    }

   

}