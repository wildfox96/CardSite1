using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CardSite1.Infrastructure;
using CardSite1.Filters;

namespace CardSite1.Controllers
{
    [Culture]
    [PageAuthorize(Roles = "Owner,Admin")]
    public class OwnerController : Controller
    {
    }
}