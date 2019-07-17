using a4aerotask.BLL;
using a4aerotask.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace a4aerotask.Controllers
{
    public class AgentController : Controller
    {
        AgentBLL agentBLL = new AgentBLL();
        // GET: Agent
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveAgent(Agent objAgent)
        {
            bool status = false;
            string message = "failed";
            var result = 0;

            objAgent.CreatedOnUtc = DateTime.Now;
            objAgent.UpdatedOnUtc = DateTime.Now;
            objAgent.Deleted = false;
            if (objAgent.SMTPPort != 0 && objAgent.UploadImage != null)

            {
                string fileName = Path.GetFileNameWithoutExtension(objAgent.UploadImage.FileName);
                string extension = Path.GetExtension(objAgent.UploadImage.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                objAgent.PicPath = fileName;
                objAgent.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/AppFile/Images"), fileName));



            }
            else
            {
                objAgent.PicPath = string.Empty;
            }

            result = agentBLL.SaveAgent(objAgent);

            if (result > 0)
            {
                status = true;
                message = "successfully saved";
            }


            return new JsonResult { Data = new { status = status, message = message } };
        }
        public JsonResult GetAgentInfo()
        {
            List<Agent> listagnt = agentBLL.GetAgentInfo();
            return Json(new { data = listagnt }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAgentInfoById(Agent objAgent)
        {
            Agent listAgent = agentBLL.GetAgentInfoById(objAgent);
            return Json(listAgent, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AgentUpdate(Agent objAgent)
        {
            bool status = false;
            string message = "failed";

            objAgent.UpdatedOnUtc = DateTime.Now;
            objAgent.Deleted = false;
          objAgent.CreatedOnUtc = DateTime.Now;
            if (objAgent.SMTPPort != 0 && objAgent.UploadImage != null)

            {
                string fileName = Path.GetFileNameWithoutExtension(objAgent.UploadImage.FileName);
                string extension = Path.GetExtension(objAgent.UploadImage.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                objAgent.PicPath = fileName;
                objAgent.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/AppFile/Images"), fileName));

                var result = agentBLL.AgentUpdate(objAgent);
                if (result > 0)
                {
                    status = true;
                    message = "successfully updated";
                }

            }
            else
            {
                var result = agentBLL.AgentUpdate(objAgent);
                if (result > 0)
                {
                    status = true;
                    message = "successfully updated";
                }
            }
            return new JsonResult { Data = new { status = status, message = message } };
        }
        [HttpPost]
        public ActionResult DeleteAgent(Agent objAgent)
        {
            bool status = false;
            string message = "failed";
            objAgent.Deleted = true;
            var result = agentBLL.DeleteAgent(objAgent);
            if (result > 0)
            {
                status = true;
                message = "successfully deleted";
            }
            return new JsonResult { Data = new { status = status, message = message } };
        }

    }
}