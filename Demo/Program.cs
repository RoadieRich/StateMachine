using RoadieRichStateMachine;

Console.Out.WriteLine("Using function states");

using (StateMachine funcSm = new())
{
	var initFuncState = new FunctionState((vars) => vars["x"] = 0);
	var funcState = new FunctionState((vars) => Console.Write($"{vars["x"]} "));
	var incrementFuncState = new FunctionState((vars) => vars["x"] = vars["x"] + 1);
	var evenFuncState = new FunctionState((vars) => Console.WriteLine("is even"));
	var oddFuncState = new FunctionState((vars) => Console.WriteLine("is odd"));

	initFuncState.AddTransitionTo(funcState, (vars) => true);

	incrementFuncState.AddTransitionTo(StateMachine.ExitState, (vars) => vars["x"] > 10)
					  .AddTransitionTo(funcState, (vars) => true);

	funcState.AddTransitionTo(evenFuncState, (vars) => vars["x"] % 2 == 0)
			 .AddTransitionTo(oddFuncState, (vars) => vars["x"] % 2 == 1);

	evenFuncState.AddTransitionTo(incrementFuncState, (vars) => true);

	oddFuncState.AddTransitionTo(incrementFuncState, (vars) => true);


	funcSm.InitialState = initFuncState;
	funcSm.Run();
}
Console.Out.WriteLine();
Console.Out.WriteLine("Using class states");

using (var classSM = new StateMachine())
{
	var mainState = new MainState();
	var oddState = new OddState();
	var evenState = new EvenState();
	var incrementState = new IncrementState();

	mainState.AddTransitionTo(oddState, (vars) => vars["x"] % 2 == 1);
	mainState.AddTransitionTo(evenState, (vars) => vars["x"] % 2 == 0);

	oddState.AddTransitionTo(incrementState, null);

	evenState.AddTransitionTo(incrementState, null);

	incrementState.AddTransitionTo(StateMachine.ExitState, (vars) => vars["x"] > 10);
	incrementState.AddTransitionTo(mainState, null);

	classSM.InitialState = mainState;

	// you can also pass in a vars dictionary
	classSM.Run(new Dictionary<string, dynamic> { ["x"] = 0 });
}