using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using Workflow.Models;
using XN.Framework.Workflow.Steps;
using System.Linq;

namespace XN.Framewoek.Workflow.flows
{
    /// <summary>
    /// 发送(出库)流程的步骤执行顺序应是 :DbOperater  => DataHandler => MsgTransceiver
    /// </summary>
    public class SendWorkflow : IWorkflow<WorkflowArgs>
    {
        public string Id => "SendWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<WorkflowArgs> builder)
        {
            builder
                .StartWith<DbOperater>()
                .Input(step => step.Args, data => data)
                .Then<DataHandler>()
                .Input(step => step.Args, data => data)
                .Then<MsgTransceiver>()
                .Input(step => step.Args, data => data);
        }
    }
}
