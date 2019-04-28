using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using Workflow.Models;
using XN.Framework.Workflow.Steps;

namespace XN.Framewoek.Workflow.flows
{
    /// <summary>
    /// 接收(入库)流程的步骤执行顺序应是 : MsgTransceiver => DataHandler => DbOperater
    /// </summary>
    public class ReceiveWorkflow : IWorkflow<WorkflowArgs>
    {
        public string Id => "ReceiveWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<WorkflowArgs> builder)
        {
            builder
                .StartWith<MsgTransceiver>()
                .Input(step => step.Args, data => data)
                //.OnError(WorkflowErrorHandling.Retry)
                .Then<DataHandler>()
                .Input(step => step.Args, data => data)
                .Then<DbOperater>()
                .Input(step => step.Args, data => data);
        }
    }
}
