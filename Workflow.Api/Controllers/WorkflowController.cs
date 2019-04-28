using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Workflow.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class WorkflowController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workflowName"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Execute(string workflowName)
        {
            return true;
        }
    }
}