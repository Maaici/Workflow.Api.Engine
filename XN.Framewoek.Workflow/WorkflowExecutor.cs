using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;

namespace XN.Framewoek.Workflow
{
    public class WorkflowExecutor
    {
        private IWorkflowHost workflowHost;
        /// <summary>
        /// 接收一个工作流主机来创建实例
        /// </summary>
        /// <param name="_workflowHost"></param>
        public WorkflowExecutor(IWorkflowHost _workflowHost)
        {
            workflowHost = _workflowHost;
        }

        /// <summary>
        /// 执行工作流
        /// </summary>
        /// <param name="flowName">应该传入"ReceiveWorkflow" 或 "SendWorkflow" 其他均为非法 </param>
        /// <param name="data">包含全部要执行的方法名及对应的参数</param>
        /// <returns></returns>
        public async Task<string> ExecuteWorkflow(string flowName,object data = null)
        {
            //订阅异常事件
            workflowHost.OnStepError += WorkflowHost_OnStepError;
            return await workflowHost.StartWorkflow(flowName, 1, data, null); 
        }


        //异常处理程序
        private void WorkflowHost_OnStepError(WorkflowCore.Models.WorkflowInstance workflow, WorkflowCore.Models.WorkflowStep step, Exception exception)
        {
            //异常情况日志记录
            FileStream fs = new FileStream("D:\\Souce\\logs.txt", FileMode.Append);
            byte[] fileStream = Encoding.UTF8.GetBytes( System.DateTime.Now.ToString("G") + $": 工作流[ {workflow.Id} ]在运行到步骤 [ {step.Name} ] 时发生异常: { exception.Message }   \n ");
            fs.Write(fileStream, 0, fileStream.Length);
            fs.Close();
        }
    }
}
