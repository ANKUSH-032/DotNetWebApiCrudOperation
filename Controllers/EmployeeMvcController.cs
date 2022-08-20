using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApiEmployee.Models;

namespace WebApiEmployee.Controllers
{
    public class EmployeeMvcController : Controller
    {
        // GET: EmployeeMvc
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<CrudEmployeedb> lists = new List<CrudEmployeedb>();
            client.BaseAddress = new Uri("https://localhost:44393/api/EmployeeApiDb");
            var responce = client.GetAsync("EmployeeApiDb");
            responce.Wait();

            var test = responce.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<CrudEmployeedb>>();
                display.Wait();
                lists = display.Result;
            }
            return View(lists);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CrudEmployeedb create)
        {

            client.BaseAddress = new Uri("https://localhost:44393/api/EmployeeApiDb");
            var responce = client.PostAsJsonAsync<CrudEmployeedb>("EmployeeApiDb", create);
            responce.Wait();

            var test = responce.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");

        }
        public ActionResult Details(int id)
        {
            CrudEmployeedb crd = null;
            client.BaseAddress = new Uri("https://localhost:44393/api/EmployeeApiDb");
            var responce = client.GetAsync("EmployeeApiDb?id=" + id.ToString());
            responce.Wait();

            var test = responce.Result;
            if (test.IsSuccessStatusCode)
            {
                var dispaly = test.Content.ReadAsAsync<CrudEmployeedb>();
                dispaly.Wait();
                crd = dispaly.Result;
            }

            return View(crd);
        }
        public ActionResult Edit(int id)
        {
            CrudEmployeedb crd = null;
            client.BaseAddress = new Uri("https://localhost:44393/api/EmployeeApiDb");
            var responce = client.GetAsync("EmployeeApiDb?id=" + id.ToString());
            responce.Wait();

            var test = responce.Result;
            if (test.IsSuccessStatusCode)
            {
                var dispaly = test.Content.ReadAsAsync<CrudEmployeedb>();
                dispaly.Wait();
                crd = dispaly.Result;
            }

            return View(crd);
        }
        [HttpPost]
        public ActionResult Edit(CrudEmployeedb crd)
        {
            client.BaseAddress = new Uri("https://localhost:44393/api/EmployeeApiDb");
            var responce = client.PutAsJsonAsync<CrudEmployeedb>("EmployeeApiDb", crd);
            responce.Wait();

            var test = responce.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
        }
        public ActionResult Delete(int id)
        {
            CrudEmployeedb crd = null;
            client.BaseAddress = new Uri("https://localhost:44393/api/EmployeeApiDb");
            var responce = client.GetAsync("EmployeeApiDb?id=" + id.ToString());
            responce.Wait();

            var test = responce.Result;
            if (test.IsSuccessStatusCode)
            {
                var dispaly = test.Content.ReadAsAsync<CrudEmployeedb>();
                dispaly.Wait();
                crd = dispaly.Result;
            }

            return View(crd);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44393/api/EmployeeApiDb");
            var responce = client.DeleteAsync("EmployeeApiDb/" + id.ToString());
            responce.Wait();

            var test = responce.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Delete");
        }

    }
}