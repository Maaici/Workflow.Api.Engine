using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using XN.Framewoek.Workflow.models;

namespace XN.Framework.Workflow.Steps
{
    /// <summary>
    /// 数据库操作步骤，该步骤中包括的应是数据的查找/修改/新增等方法
    /// </summary>
    public class DbOperater : StepBody
    {
        //传入参数
        public WorkflowArgs Args { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            foreach (var item in Args.MyProperty)
            {
                //根据item里面的方法名和参数等 执行对应的操作

            }
            return ExecutionResult.Next();
        }
    }
}
