using Newtonsoft.Json;
using QuickPic_Survey_Spa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace QuickPic_Survey_Spa.Controllers
{
    public class QuestionsController : Controller
    {
        string baseUrl = "https://localhost:44315/api";
        // GET: Questions
        public async Task<ActionResult> Index()
        {

            IEnumerable<Question> res = null;
            string requestUrl = baseUrl + "/respondent";
             var client = new HttpClient();
            var response = await client.GetStringAsync(requestUrl);
            List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(response);
            
            //  var json = JsonObject.Parse(questions);
            return View(questions);
        }

        // GET: Questions/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Questions/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Questions/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Questions/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
