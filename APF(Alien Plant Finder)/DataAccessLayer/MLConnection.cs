using System;

namespace APF_Alien_Plant_Finder_
{
    internal class MLConnection
    {
        ScriptEngine engine = Python.CreateEngine();
        ScriptSource source = engine.CreateScriptSourceFromFile("connectionClass.py");
        ScriptScope scope = engine.CreateScope();

        ObjectOperations op = engine.Operations;

        source.Execute(scope);
        object model = scope.GetVariable("Model");
        object instance = op.Call(model);
        object method = op.GetMember(instance, "returnPrediction");
        string result = (string)op.Call(method, img);


    }
}
