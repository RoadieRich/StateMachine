A simple state machine library.  Can use states that are defined using delegates, or more powerful custom class states.

```C#

using (StateMachine funcSm = new())
{
	var initFuncState = new FunctionState((vars) => vars["x"] = 0);
	var funcState = new FunctionState((vars) => Console.Write($"{vars["x"]} "));
	var incrementFuncState = new FunctionState((vars) => vars["x"] = vars["x"] + 1);
	var evenFuncState = new FunctionState((vars) => Console.WriteLine("is even"));
	var oddFuncState = new FunctionState((vars) => Console.WriteLine("is odd"));

	initFuncState.AddTransitionTo(funcState, (vars) => true);

	incrementFuncState.AddTransitionTo(StateMachine.ExitState, (vars) => vars["x"] > 10);
	incrementFuncState.AddTransitionTo(funcState, (vars) => true);

	funcState.AddTransitionTo(evenFuncState, (vars) => vars["x"] % 2 == 0);
	funcState.AddTransitionTo(oddFuncState, (vars) => vars["x"] % 2 == 1);

	evenFuncState.AddTransitionTo(incrementFuncState, (vars) => true);

	oddFuncState.AddTransitionTo(incrementFuncState, (vars) => true);


	funcSm.InitialState = initFuncState;
	funcSm.Run();
}
```