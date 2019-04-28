using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Workflow.Models;

namespace AssemblyOperator
{
    /// <summary>
    /// 程序集调用,写死，用作测试
    /// </summary>
    public class AssemblyExecuter
    {
        static Assembly  assembly  = Assembly.LoadFrom("D:\\Souce\\TestAssembly.dll");

        public static void Execute(WorkflowArg arg) {
            Type type = assembly.GetTypes()[0];
            object obj = Activator.CreateInstance(type);
            MethodInfo meth = type.GetMethod(arg.FunctionName);
            //参数列表
            meth?.Invoke(obj,arg.Params.Select(x => x.PramsValue).ToArray());
        }

    }
}
