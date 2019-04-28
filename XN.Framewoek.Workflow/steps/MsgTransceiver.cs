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
    ///  信息收发步骤，该步骤中应是 数据接收或者发送 的方法 
    /// </summary>
    public class MsgTransceiver : StepBody
    {
        //传入参数
        public WorkflowArgs Args { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            //传入参数中是全部要执行的方法,需要进行筛选,根据当前是入库还是进库流程来判断
            List<WorkflowArg> data;
            if (context.Workflow.WorkflowDefinitionId == "ReceiveWorkflow")
            {
                //如果是入库流程 则 MsgTransceiver => DataHandler => DbOperater
                data = Args.MyProperty.Where(x => x.StpeType == StpeTypes.Step1).ToList();
            }
            else
            {
                //反之则 DbOperater => DataHandler => MsgTransceiver
                data = Args.MyProperty.Where(x => x.StpeType == StpeTypes.Step3).ToList();
            }
            foreach (var  item in data) {
                //根据item里面的方法名和参数等 执行对应的操作
                AssemblyExecuter.Execute(item);
            }
            return ExecutionResult.Next();
        }
    }
}
