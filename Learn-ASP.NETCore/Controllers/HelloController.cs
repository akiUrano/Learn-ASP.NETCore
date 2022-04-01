using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Learn_ASP.NETCore.Controllers
{
    public class HelloController : Controller
    {
        public List<string> _list;
        public HelloController()
        {
            _list = new List<string>();
            _list.Add("JAPAN");
            _list.Add("USA");
            _list.Add("UK");
        }
        [Route("Hello/{id?}/{name?}")]
        [HttpGet("Hello/{id?}/{name?}")]
        public IActionResult Index(int id, string name)
        {
            ViewData["Message"] = id + "," + name;
            ViewData["name"] = "";
            ViewData["mail"] = "";
            ViewData["tel"] = "";
            ViewData["list"] = new string[] { };
            ViewData["listdata"] = _list;
            HttpContext.Session.SetInt32("id", id);
            HttpContext.Session.SetString("name", name);
            MyData ob = new MyData(id, name);
            HttpContext.Session.Set("object", ObjectToBytes(ob));
            ViewData["header"] = new string[] { "id", "name", "mail" };
            ViewData["data"] = new string[][]
            {
                new string []{"1","Taro","taro@yamada"}
                , new string []{"2","Hanako","hanako@flower"}
                , new string []{"3","Sachiko","sachiko@happy"}
            };
            return View();
        }
        [HttpGet]
        public IActionResult Other()
        {
            ViewData["id"] = HttpContext.Session.GetInt32("id");
            ViewData["name"] = HttpContext.Session.GetString("name");
            byte[] ob = HttpContext.Session.Get("object");
            ViewData["object"] = BytesToObject(ob);
            return View("Index");
        }
        private byte[] ObjectToBytes(Object ob)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, ob);
            return ms.ToArray();
        }
        private Object BytesToObject(byte[] arr)
        {
            var ms = new MemoryStream();
            var bf = new BinaryFormatter();
            ms.Write(arr, 0, arr.Length);
            ms.Seek(0, SeekOrigin.Begin);
            return (Object)bf.Deserialize(ms);
        }
        [HttpPost]
        public IActionResult Form(string name, string mail, string tel, string[] list)
        {
            ViewData["name"] = name;
            ViewData["mail"] = mail;
            ViewData["tel"] = tel;
            var message = "";
            foreach (var item in list)
            {
                message += item + ",";
            }
            ViewData["list"] = list;
            ViewData["listdata"] = _list;
            ViewData["Message"] = name + "," + mail + "," + tel + "," + message;
            return View("Index");
        }
    }
    [Serializable]
    class MyData
    {
        public int Id = 0;
        public string Name = "";
        public MyData(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        public override string ToString()
        {
            return "<" + Id + ":" + Name + ">";
        }

    }
}
