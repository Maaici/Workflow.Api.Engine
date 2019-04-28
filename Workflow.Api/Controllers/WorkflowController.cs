using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Workflow.Models;
using WorkflowCore.Interface;
using XN.Framewoek.Workflow;

namespace Workflow.Api.Controllers
{
    /// <summary>
    /// 执行工作流
    /// </summary>
    [Route("api/[controller]/[action]")]
    public class WorkflowController : Controller
    {
        private readonly IWorkflowHost workflowHost;
        private readonly IWorkflowRegistry registry;
        public WorkflowController(IWorkflowHost _iworkflowHost, IWorkflowRegistry _registry)
        {
            workflowHost = _iworkflowHost;
            registry = _registry;
            //workflowHost.Start();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="workflowID">需要执行的工作流,应可以通过该名称的找到所维护的详细信息</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Execute(string workflowID)
        {
            //从数据库获取到参数的传入流名称的相关数据,包括它属于入库流程  还是  出库流程 ,以及所有需要执行到的所有方法和对应的参数
            #region 根据 workflowName 获取工作流详细信息

            //一些数据库查询操作

            #endregion

            #region 伪造一些数据用于测试

            string workflowName = "ReceiveWorkflow"; //设置它是一个接收(入库)流程

            //创造一些需要执行的方法和对应参数
            WorkflowArgs data = new WorkflowArgs();
            data.MyProperty = new List<WorkflowArg>();
            var s1 = new List<Parameters>() { new Parameters { PramsValue = "1" } };
            var s2 = new List<Parameters>() { new Parameters { PramsValue = "2" } };
            var s3 = new List<Parameters>() { new Parameters { PramsValue = "3" } };
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    var ss = new WorkflowArg { FunctionName = "ExceudeRecorder1", StpeType = StpeTypes.Step1, Params = s1 };
                    data.MyProperty.Add(ss);
                }
                for (int i = 0; i < 4; i++)
                {
                    var ss = new WorkflowArg { FunctionName = "ExceudeRecorder2", StpeType = StpeTypes.Step2, Params = s2 };
                    data.MyProperty.Add(ss);
                }
                for (int i = 0; i < 5; i++)
                {
                    var ss = new WorkflowArg { FunctionName = "ExceudeRecorder3", StpeType = StpeTypes.Step3, Params = s3 };
                    data.MyProperty.Add(ss);
                }
            }
            catch(Exception ex) {
                return BadRequest(ex.Message);
            }
            
            
            #endregion


            var def = registry.GetDefinition(workflowName, 1);
            if (def == null)
                return BadRequest(String.Format($"没有找到名称为[ {workflowName} ],版本号为[ 1 ]的工作流定义! "));
            WorkflowExecutor executor = new WorkflowExecutor(workflowHost);
            var errMsg = executor.ExecuteWorkflow(workflowName, data);
            return Ok(errMsg);
        }
    }
}