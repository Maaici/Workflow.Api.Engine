using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;

namespace XN.Framewoek.Workflow
{
    public class WorkflowExecutor
    {
        private IWorkflowHost workflowHost;
        public WorkflowExecutor(IWorkflowHost _workflowHost)
        {
            workflowHost = _workflowHost;
        }

        /// <summary>
        /// 执行工作流（）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public async Task<string> ExecuteWorkflow(string id, int? version = 0, object data = null, string reference = null)
        {
            //根据工作流ID，获取需要执行的步骤，传递到三大步骤中，动态执行

            //异常情况日志记录
            //workflowHost.OnStepError +=  ;

            return await workflowHost.StartWorkflow(id, version, data, reference); ;
        }

    }
}
