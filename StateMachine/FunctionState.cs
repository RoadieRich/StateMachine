namespace RoadieRichStateMachine
{
	public sealed class FunctionState : State
	{
		public Action<Dictionary<string, dynamic>>? EnterFunc { get; init; }

		public Action<Dictionary<string, dynamic>>? ExitFunc { get; init; }
		public Action<Dictionary<string, dynamic>> InnerFunc { get; init; }

		public FunctionState(Action<Dictionary<string, dynamic>> innerFunc)
		{
			InnerFunc = innerFunc;
		}

		public FunctionState(Action<Dictionary<string, dynamic>>? enterFunc, Action<Dictionary<string, dynamic>> innerFunc, Action<Dictionary<string, dynamic>>? exitFunc)
		{
			EnterFunc = enterFunc;
			ExitFunc = exitFunc;
			InnerFunc = innerFunc;
		}


		protected override void Enter(Dictionary<string, dynamic> vars)
		{
			if (EnterFunc != null)
				EnterFunc(vars);
		}

		protected override void Exit(Dictionary<string, dynamic> vars)
		{
			if(ExitFunc != null)
				ExitFunc(vars);
		}

		protected override void Inner(Dictionary<string, dynamic> vars)
		{
			InnerFunc(vars);
		}
	}
}
