using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using goalswithfriends.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace goalswithfriends.Controllers
{
    public static class SessionExtensions
    {
        // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // This helper function simply serializes theobject to JSON and stores it as a string in session
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        
        // generic type T is a stand-in indicating that we need to specify the type on retrieval
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            // Upon retrieval the object is deserialized based on the type we specified
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
    public class HomeController : Controller
    {

        private goalswithfriendsContext _context;
        public HomeController(goalswithfriendsContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<CurrentUser> ret = HttpContext.Session.GetObjectFromJson<List<CurrentUser>>("curr");
            if(ret == null)
            {
                CurrentUser newcurr = new CurrentUser();
                newcurr.id = 0;
                ViewBag.CurrentUser = newcurr;
                List<object> temp = new List<object>();
                temp.Add(newcurr);
                HttpContext.Session.SetObjectAsJson("curr", temp);
                return View();
            }
            else if (ret.Count == 0)
            {
                ViewBag.CurrentUser = ret[0];
                return View();
            }
            else  if (ret[0].id == 0)
            {
                ViewBag.CurrentUser = ret[0];
                return View();
            }
            else
            {
                ViewBag.CurrentUser = ret[0];
                return View("IndexLOGGEDIN");
            }
        }


        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            List<CurrentUser> ret = HttpContext.Session.GetObjectFromJson<List<CurrentUser>>("curr");
            if(ret == null)
            {
                CurrentUser newcurr = new CurrentUser();
                newcurr.id = 0;
                ViewBag.CurrentUser = newcurr;
                List<object> temp = new List<object>();
                temp.Add(newcurr);
                HttpContext.Session.SetObjectAsJson("curr", temp);
                return View();
            }
            else if (ret.Count == 0)
            {
                ViewBag.CurrentUser = ret[0];
                return View();
            }
            else
            {
                ViewBag.CurrentUser = ret[0];
                return View();
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult ProcessLogin(string inEmail, string inPass)
        {
            
            List<CurrentUser> ret = HttpContext.Session.GetObjectFromJson<List<CurrentUser>>("curr");
            ViewBag.CurrentUser = ret[0];
            Users check = _context.users.SingleOrDefault(x => x.email == inEmail);
            if (check != null && inPass != null)
            {
                var hasher = new PasswordHasher<Users>();
                if(0 != hasher.VerifyHashedPassword(check, check.password, inPass))
                {
                    CurrentUser curr = new CurrentUser();
                    curr.id = check.id;
                    curr.name = check.first_name+" "+check.last_name;
                    curr.username = check.username;
                    ViewBag.CurrentUser = curr;
                    List<object> temp = new List<object>();
                    temp.Add(curr);
                    HttpContext.Session.SetObjectAsJson("curr", temp);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.LogError = "The Email or Password was incorrect.";
                    return View("login");
                }
                
            }
            else 
            {
                ViewBag.LogError = "Missing Email or Password.";
                return View("login");
            }
        }

        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            List<CurrentUser> ret = HttpContext.Session.GetObjectFromJson<List<CurrentUser>>("curr");
            if(ret == null)
            {
                CurrentUser newcurr = new CurrentUser();
                newcurr.id = 0;
                ViewBag.CurrentUser = newcurr;
                List<object> temp = new List<object>();
                temp.Add(newcurr);
                HttpContext.Session.SetObjectAsJson("curr", temp);
                return View();
            }
            else if (ret.Count == 0)
            {
                ViewBag.CurrentUser = ret[0];
                return View();
            }
            else
            {
                ViewBag.CurrentUser = ret[0];
                return View();
            }
        }

        [HttpPost]
        [Route("register")]
        public IActionResult register(Users inp)
        {
            List<CurrentUser> ret = HttpContext.Session.GetObjectFromJson<List<CurrentUser>>("curr");
            ViewBag.CurrentUser = ret[0];
            if(ModelState.IsValid)
            {
                PasswordHasher<Users> Hasher = new PasswordHasher<Users>();
                inp.password = Hasher.HashPassword(inp, inp.password);
                inp.privacy = true;
                _context.Add(inp);
                _context.SaveChanges();
                Users check = _context.users.SingleOrDefault(x => x.email == inp.email);
                CurrentUser newcurr = new CurrentUser();
                newcurr.id = check.id;
                newcurr.name = check.first_name+" "+check.last_name;
                List<object> temp = new List<object>();
                temp.Add(newcurr);
                HttpContext.Session.SetObjectAsJson("curr", temp);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.CurrentUser = ret[0];
                return View("Register");
            }
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("");
        }
        

        [HttpGet]
        [Route("Home")]
        public IActionResult Home()
        {
            List<CurrentUser> ret = HttpContext.Session.GetObjectFromJson<List<CurrentUser>>("curr");
            if (ret[0].id == 0)
            {
                return RedirectToAction("");
            }
            else
            {
                ViewBag.CurrentUser = ret[0];
                return View();
            }
        }

        [HttpPost]
        [Route("/joinprivate")]
        public IActionResult JoinPrivate(int privid, string privpass) {
            List<CurrentUser> ret = HttpContext.Session.GetObjectFromJson<List<CurrentUser>>("curr");
            if (ret[0].id == 0 || ret[0] == null)
            {
                ViewBag.CurrentUser = ret[0];
                return RedirectToAction("");
            }
            else
            {
                ViewBag.CurrentUser = ret[0];
                Groups check = _context.groups.SingleOrDefault(x => x.id == privid);
                Members memcheck = _context.members.SingleOrDefault(g => g.groupid == check.id && g.memberid == ret[0].id);
                if(memcheck != null) {
                    return RedirectToAction("");
                }
                if (check != null && privpass != null)
                {
                    if(check.password == privpass)
                    {
                        Members memba = new Members();
                        memba.groupid = check.id;
                        memba.memberid = ret[0].id;
                        _context.Add(memba);
                        _context.SaveChanges();
                        return Redirect($"/group/{check.id}");
                    }
                    else
                    {
                        return RedirectToAction("");
                    }    
                }
                else 
                {
                    return RedirectToAction("");
                }
            }
        }

        [HttpGet]
        [Route("test")]
        public IActionResult Test() {
            List<CurrentUser> ret = HttpContext.Session.GetObjectFromJson<List<CurrentUser>>("curr");
            if (ret[0] == null)
            {
                CurrentUser newcurr = new CurrentUser();
                newcurr.id = 0;
                ViewBag.CurrentUser = newcurr;
                return View();
            }
            else if (ret[0].id == 0)
            {

                ViewBag.CurrentUser = ret[0];
                return View();
            }
            else
            {
                ViewBag.CurrentUser = ret[0];
                return View();
            }
        }

        [HttpGet]
        [Route("group/create")]
        public IActionResult NewGroup() {
            List<CurrentUser> ret = HttpContext.Session.GetObjectFromJson<List<CurrentUser>>("curr");
            if (ret[0].id == 0)
            {
                return RedirectToAction("");
            }
            else
            {
                ViewBag.CurrentUser = ret[0];
                return View();
            }
        }

        [HttpPost]
        [Route("group/create")]
        public IActionResult CreateGroup(Groups inp)
        {
            List<CurrentUser> ret = HttpContext.Session.GetObjectFromJson<List<CurrentUser>>("curr");
            ViewBag.CurrentUser = ret[0];
            if (ret[0].id == 0)
            {
                return RedirectToAction("");
            }
            else
            {
                if(ModelState.IsValid)
                {
                    inp.ownerid = ret[0].id;
                    _context.Add(inp);
                    _context.SaveChanges();
                    Groups curr = _context.groups.OrderByDescending(g => g.created_at).FirstOrDefault();
                    Members owner = new Members();
                    owner.groupid = curr.id;
                    owner.memberid = ret[0].id;
                    _context.Add(owner);
                    _context.SaveChanges();
                    return Redirect($"/group/{curr.id}");
                }
                else
                {
                    return View("NewGroup");
                }

            }
        }
        

        [HttpGet]
        [Route("profile/{id}")]
        public IActionResult Profile(int id)
        {
            Users showuser = _context.users.Include(u => u.goals).Include(u => u.groups).SingleOrDefault(u => u.id == id);
            List<CurrentUser> ret = HttpContext.Session.GetObjectFromJson<List<CurrentUser>>("curr");
            if(showuser.privacy == true)
            {
                if (ret[0].id == 0 || ret[0] == null)
                {
                    return RedirectToAction("");
                }
                else
                {
                    ViewBag.Profile = showuser;
                    ViewBag.CurrentUser = ret[0];
                    return View();
                }
            }
            else {
                ViewBag.Profile = showuser;
                ViewBag.CurrentUser = ret[0];
                return View();
            }
        }

        [HttpGet]
        [Route("profile/{id}/managegoals")]
        public IActionResult ManageGoals(int id)
        {
            List<CurrentUser> ret = HttpContext.Session.GetObjectFromJson<List<CurrentUser>>("curr");
            if (ret[0] == null)
            {
                CurrentUser newcurr = new CurrentUser();
                newcurr.id = 0;
                ViewBag.CurrentUser = newcurr;
                return RedirectToAction("");
            }
            else if (ret[0].id == 0)
            {
                return RedirectToAction("");
            }
            else if(ret[0].id != id)
            {
                return RedirectToAction("");
            }
            else
            {
                ViewBag.CurrentUser = ret[0];
                return View();
            }
        }

        [HttpGet]
        [Route("profile/{id}/managegroups")]
        public IActionResult ManageGroups(int id)
        {
            List<CurrentUser> ret = HttpContext.Session.GetObjectFromJson<List<CurrentUser>>("curr");
            if (ret[0] == null)
            {
                CurrentUser newcurr = new CurrentUser();
                newcurr.id = 0;
                ViewBag.CurrentUser = newcurr;
                return RedirectToAction("");
            }
            else if (ret[0].id == 0)
            {
                return RedirectToAction("");
            }
            else if(ret[0].id != id)
            {
                return RedirectToAction("");
            }
            else
            {
                ViewBag.CurrentUser = ret[0];
                return View();
            }
        }

        [HttpGet]
        [Route("/profile/{id}/edit")]
        public IActionResult EditProfile(int id) {
            List<CurrentUser> ret = HttpContext.Session.GetObjectFromJson<List<CurrentUser>>("curr");
            if (ret[0] == null)
            {
                CurrentUser newcurr = new CurrentUser();
                newcurr.id = 0;
                ViewBag.CurrentUser = newcurr;
                return RedirectToAction("");
            }
            else if (ret[0].id == 0 || ret[0].id != id)
            {
                return RedirectToAction("");
            }
            else
            {
                Users showuser = _context.users.Include(u => u.goals).Include(u => u.groups).SingleOrDefault(u => u.id == id);
                ViewBag.Profile = showuser;
                ViewBag.CurrentUser = ret[0];

                return View("UpdateInfo");
            }
        }

        [HttpPost]
        [Route("/profile/{id}/update")]
        public IActionResult UpdateProfile(int id, UpdateUser inp, string bio) {
            List<CurrentUser> ret = HttpContext.Session.GetObjectFromJson<List<CurrentUser>>("curr");
            Users showuser = _context.users.Include(u => u.goals).Include(u => u.groups).SingleOrDefault(u => u.id == id);            
            if (ret[0] == null)
            {
                return RedirectToAction("");
            }
            else if (ret[0].id == 0 || ret[0].id != id)
            {
                return RedirectToAction("");
            }
            else
            {
                if(ModelState.IsValid)
                {
                    Users check = _context.users.SingleOrDefault(x => x.id == id);
                    check.first_name = inp.first_name;
                    check.last_name = inp.last_name;
                    check.privacy = inp.privacy;
                    check.bio = bio;
                    _context.SaveChanges();
                    return Redirect($"/profile/{id}");
                }
                else
                {
                    ViewBag.Profile = showuser;
                    ViewBag.CurrentUser = ret[0];
                    return View("UpdateInfo");
                }

            }
        }

        [HttpGet]
        [Route("group/{groupid}")]
        public IActionResult ViewGroup(int groupid)
        {
            List<CurrentUser> ret = HttpContext.Session.GetObjectFromJson<List<CurrentUser>>("curr");
            ViewBag.UserLevel = 2;
            if(ret[0] == null || ret[0].id == 0) {
                ViewBag.UserLevel = 0;
            }
            Groups curr = _context.groups.SingleOrDefault(g => g.id == groupid);
            if(curr == null) {
                return RedirectToAction("");
            }
            Users owner = _context.users.SingleOrDefault(u => u.id == curr.ownerid);
            Members check = _context.members.SingleOrDefault(g => g.groupid == groupid && g.memberid == ret[0].id);
            if(check == null) {
                ViewBag.UserLevel = 1;
            }
            List<Members> memlist = _context.members.Where(g => g.groupid == groupid).Include(m => m.member).ToList();

            List<Members> sorted = memlist.OrderByDescending(o => o.created_at).Take(5).ToList();

            if(curr.password != null && check == null) {
                return RedirectToAction("");
            }
            else {
                ViewBag.Owner = owner;
                ViewBag.RecMems = sorted;
                ViewBag.CurrentGroup = curr;
                ViewBag.CurrentUser = ret[0];
                return View();
            }
        }

        [HttpGet]
        [Route("/group/{groupid}/join")]
        public IActionResult JoinGroup(int groupid) {
            List<CurrentUser> ret = HttpContext.Session.GetObjectFromJson<List<CurrentUser>>("curr");
            if (ret[0].id == 0 || ret[0] == null)
            {
                ViewBag.CurrentUser = ret[0];
                return RedirectToAction("");
            }
            else {
                ViewBag.CurrentUser = ret[0];
                Groups check = _context.groups.SingleOrDefault(x => x.id == groupid);
                if (check != null || check.password == null)
                {
                    Members memba = new Members();
                    memba.groupid = check.id;
                    memba.memberid = ret[0].id;
                    _context.Add(memba);
                    _context.SaveChanges();
                    return Redirect($"/group/{groupid}");  
                }
                else 
                {
                    return Redirect($"/group/{groupid}");
                }
            }
        }

        [HttpGet]
        [Route("/group/{groupid}/leave")]
        public IActionResult LeaveGroup(int groupid) {
            List<CurrentUser> ret = HttpContext.Session.GetObjectFromJson<List<CurrentUser>>("curr");
            if (ret[0].id == 0 || ret[0] == null)
            {
                ViewBag.CurrentUser = ret[0];
                return RedirectToAction("");
            }
            else {
                ViewBag.CurrentUser = ret[0];
                Groups check = _context.groups.SingleOrDefault(x => x.id == groupid);
                if(check != null) {
                    if(check.ownerid == ret[0].id) {
                        return Redirect($"/group/{groupid}");
                    }
                    else {
                        Members torem = _context.members.SingleOrDefault(m => m.memberid == ret[0].id && m.groupid == groupid);
                        _context.members.Remove(torem);
                        _context.SaveChanges();
                        return Redirect($"/group/{groupid}");
                    }
                }
                else {
                    return RedirectToAction("");
                }
            }
        }

        [HttpGet]
        [Route("/group/{groupid}/delete")]
        public IActionResult DelGroup(int groupid) {
            List<CurrentUser> ret = HttpContext.Session.GetObjectFromJson<List<CurrentUser>>("curr");
            if (ret[0].id == 0 || ret[0] == null)
            {
                ViewBag.CurrentUser = ret[0];
                return RedirectToAction("");
            }
            else {
                ViewBag.CurrentUser = ret[0];
                Groups check = _context.groups.SingleOrDefault(x => x.id == groupid);
                if(check != null) {
                    if(check.ownerid != ret[0].id) {
                        return Redirect($"/group/{groupid}");
                    }
                    else {
                        Groups torem = _context.groups.SingleOrDefault(m => m.id == groupid);
                        _context.groups.Remove(torem);
                        _context.SaveChanges();
                        return RedirectToAction("");
                    }
                }
                else {
                    return RedirectToAction("");
                }
            }
        }

        [HttpGet]
        [Route("goal/create")]
        public IActionResult NewGoal() {
            List<CurrentUser> ret = HttpContext.Session.GetObjectFromJson<List<CurrentUser>>("curr");
            if (ret[0].id == 0)
            {
                return RedirectToAction("");
            }
            else
            {
                ViewBag.CurrentUser = ret[0];
                return View("MakeUGoal");
            }
        }

        [HttpGet]
        [Route("/group/{groupid}/all")]
        public IActionResult ViewAll(int groupid) {
            List<CurrentUser> ret = HttpContext.Session.GetObjectFromJson<List<CurrentUser>>("curr");
            if (ret[0] == null)
            {
                return RedirectToAction("");
            }
            List<Members> memlist = _context.members.Where(g => g.groupid == groupid).Include(m => m.member).ToList();
            Groups curr = _context.groups.SingleOrDefault(g => g.id == groupid);
            if(curr.password != null) {
                Members check = _context.members.SingleOrDefault(g => g.groupid == groupid && g.memberid == ret[0].id);
                if(check == null) {
                    return RedirectToAction("");
                }
                ViewBag.AllUsers = memlist;
                ViewBag.CurrentUser = ret[0];
                return View("ViewAllUsers");
            }
            else {
                ViewBag.AllUsers = memlist;
                ViewBag.CurrentGroup = curr;
                ViewBag.CurrentUser = ret[0];
                return View("ViewAllUsers");
            }
        }


        

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
