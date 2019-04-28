using System;
using System.Collections.Generic;
using System.Text;

namespace XN.Framewoek.Workflow.models
{
    /// <summary>
    /// 工作流参数集合
    /// </summary>
    public class WorkflowArgs
    {
        public List<WorkflowArg> MyProperty { get; set; }

        //可用于接收返回值，实现步骤之间参数传递
        public object i_e_param { get; set; }
    }


    /// <summary>
    /// 工作流参数
    /// </summary>
    public class WorkflowArg
    {
        public StpeTypes StpeType { get; set; }
        public string FunctionName { get; set; }
        public List<Parameter> Params { get; set; }
    }

    /// <summary>
    /// 方法参数列表
    /// </summary>
    public class Parameter
    {
        public string paramName { get; set; }
        public TypeCode ParamType { get; set; }
        public object PramsValue { get; set; }
    }

    /// <summary>
    /// 属于第几个步骤
    /// </summary>
    public enum StpeTypes
    {
        Step1 = 1,
        Step2 = 2,
        Step3 = 3
    }

}
