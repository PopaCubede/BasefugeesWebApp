using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BasefugeesWebApp.ViewModels
{
    public class SearchSettingViewModel
    {
        public string SearchEntered { get; set; }

        [BindProperty, Required]
        public string TypeSearched { get; set; }
    }
}
