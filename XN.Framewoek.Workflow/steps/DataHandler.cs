using System;
using System.Collections.Generic;
using System.Linq;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using Workflow.Models;
using AssemblyOperator;

namespace XN.Framework.Workflow.Steps
{
    /// <summary>
    /// 数据的处理步骤，该步骤中应是对 接收到的或者数据库查找出来的数据 进行操作的方法
    /// </summary>
    public class DataHandler : StepBody
    {
        //传入参数
        public WorkflowArgs Args { get; set; }

        //
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            //改步骤总是中间步骤
            var data = Args.MyProperty.Where(x => x.StpeType == StpeTypes.Step2);
            foreach (var item in data)
            {
                //根据item里面的方法名和参数等 执行对应的操作
                AssemblyExecuter.Execute(item);
            }
            return ExecutionResult.Next();
        }
    }
}
