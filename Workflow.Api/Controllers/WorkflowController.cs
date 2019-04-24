using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Workflow.Api.Controllers
{
    public class WorkflowController : Controller
    {
        public bool Execute(string workflowName)
        {
            return View();
        }
    }
}