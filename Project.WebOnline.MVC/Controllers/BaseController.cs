using Project.CheckOut.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WebOnline.MVC.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected readonly IUnitOfWork _unit;
        //protected readonly ILog _log;

        public BaseController(/*ILog log,*/ IUnitOfWork unit)
        {
            //_log = log;
            _unit = unit;
        }
    }
}
