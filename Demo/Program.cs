using RoadieRichStateMachine;

internal class Program
{
	private static void Main(string[] args)
	{
		StateMachine funcSm = new();

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

		var classSM = new StateMachine();

		var initState = new InitState();
		var mainState = new MainState();
		var oddState = new OddState();
		var evenState = new EvenState();
		var incrementState = new IncrementState();

		initState.AddTransitionTo(mainState, null);
		
		mainState.AddTransitionTo(oddState, (vars) => vars["x"] % 2 == 1);
		mainState.AddTransitionTo(evenState, (vars) => vars["x"] % 2 == 0);

		oddState.AddTransitionTo(incrementState, null);

		evenState.AddTransitionTo(incrementState, null);

		incrementState.AddTransitionTo(StateMachine.ExitState, (vars) => vars["x"] > 10);
		incrementState.AddTransitionTo(mainState, null);

		classSM.InitialState = initState;
		classSM.Run();
	}
	class InitState : State
	{
		protected override void Enter(Dictionary<string, dynamic> vars)
		{
			vars["x"] = 0;
		}

		protected override void Exit(Dictionary<string, dynamic> vars) { }

		protected override void Inner(Dictionary<string, dynamic> vars)	{}
	}
	class MainState : State
	{
		protected override void Enter(Dictionary<string, dynamic> vars) { }

		protected override void Exit(Dictionary<string, dynamic> vars) { }

		protected override void Inner(Dictionary<string, dynamic> vars)
		{
			Console.Out.Write(vars["x"]);
		}
	}

	class OddState : State
	{
		protected override void Enter(Dictionary<string, dynamic> vars) { }

		protected override void Exit(Dictionary<string, dynamic> vars) { }

		protected override void Inner(Dictionary<string, dynamic> vars)
		{
			Console.WriteLine(" is odd");
		}
	}
	class EvenState : State
	{
		protected override void Enter(Dictionary<string, dynamic> vars) { }

		protected override void Exit(Dictionary<string, dynamic> vars) { }

		protected override void Inner(Dictionary<string, dynamic> vars)
		{
			Console.WriteLine(" is even");
		}
	}
	class IncrementState : State
	{
		protected override void Enter(Dictionary<string, dynamic> vars) { }

		protected override void Exit(Dictionary<string, dynamic> vars) { }

		protected override void Inner(Dictionary<string, dynamic> vars)
		{
			vars["x"]++;
		}
	}
}