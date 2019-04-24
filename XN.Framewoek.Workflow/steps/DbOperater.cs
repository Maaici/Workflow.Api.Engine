using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace XN.Framework.WorkflowCore.Steps
{
    /// <summary>
    /// 数据库操作步骤，该步骤中包括的应是数据的查找/修改/新增等方法
    /// </summary>
    public class DbOperater : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            return ExecutionResult.Next();
        }
    }
}
