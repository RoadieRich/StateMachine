using RoadieRichStateMachine;

class MainState : State
{
	protected override void Enter(IDictionary<string, dynamic> vars) { }

	protected override void Exit(IDictionary<string, dynamic> vars) { }

	protected override void Inner(IDictionary<string, dynamic> vars)
	{
		Console.Out.Write(vars["x"]);
	}
}
