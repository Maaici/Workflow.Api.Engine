using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using Workflow.Models;

namespace XN.Framework.Workflow.Steps
{
    /// <summary>
    ///  信息收发步骤，该步骤中应是 数据接收或者发送 的方法 
    /// </summary>
    public class MsgTransceiver : StepBody
    {
        //传入参数
        public WorkflowArgs Args { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            foreach (var  item in Args.MyProperty) {
                //根据item里面的方法名和参数等 执行对应的操作

            }
            return ExecutionResult.Next();
        }
    }
}
