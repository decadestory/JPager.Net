using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JPager.Net;
using JPager.Net.Web.Models;

namespace JPager.Net.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(UserParams param)
        {
            param.PageSize = 10;
            var list = PageContent();
            var query = param.Name!=null ? 
                list.Where(t=>t.Name.Contains(param.Name)).ToList() :
                list.ToList();
            var data = query.Skip(param.Skip).Take(param.PageSize);
            var count = query.Count;

            var res = new PagerResult<User> { Code = 0, DataList = data, Total = count,
                PageSize = param.PageSize,PageIndex = param.PageIndex,RequestUrl = param.RequetUrl};

            return View(res);
        }

        public List<User> PageContent()
        {
            var list = new List<User>();
            for (var t = 0; t < 10000; t++)
            {
                list.Add(new User
                {
                    Id = t,
                    Name = "Jerry" + t,
                    Age = t + 10,
                    Score = t,
                    AddTime = DateTime.Now
                });
            }

            return list;
        }
    }
}