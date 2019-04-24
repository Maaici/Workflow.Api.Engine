using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace XN.Framework.WorkflowCore.Steps
{
    /// <summary>
    /// 数据的处理步骤，该步骤中应是对 接收到的或者数据库查找出来的数据 进行操作的方法
    /// </summary>
    public class DataHandler : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            return ExecutionResult.Next();
        }
    }
}
