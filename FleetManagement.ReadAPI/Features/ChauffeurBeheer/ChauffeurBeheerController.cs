﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.ChauffeurBeheer
{
    public class ChauffeurBeheerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
