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
    public class AdminController : Controller
    {

        string baseUrl = "https://localhost:44315/api";
        // GET: Admin
        public async Task<ActionResult> Index()
        {
            IEnumerable<AdminRespondentResult> res = null;
            string requestUrl = baseUrl + "/admin";
            var client = new HttpClient();
            var response = await client.GetStringAsync(requestUrl);
            List<AdminRespondentResult> respondentResults = JsonConvert.DeserializeObject<List<AdminRespondentResult>>(response);

            foreach(var item in respondentResults)
            {
                if(item.RespondentsWeight == item.Expectation)
                {
                    item.Accuracy = 100.00;
                    item.ExpectationGap = 0;
                }
                else
                {
                    int maximum = 10;
                    var diff = item.Expectation - item.RespondentsWeight;
                    item.ExpectationGap = -diff;
                    item.Accuracy = (diff * maximum) * 100;
                }
            }

            //  var json = JsonObject.Parse(questions);
            return View(respondentResults);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
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

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
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
