using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace XN.Framework.WorkflowCore.Steps
{
    /// <summary>
    ///  信息收发步骤，该步骤中应是 数据接收或者发送 的方法 
    /// </summary>
    public class MsgTransceiver : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {

            return ExecutionResult.Next();
        }
    }
}
