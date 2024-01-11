using RoadieRichStateMachine;


class IncrementState : State
{
	protected override void Enter(IDictionary<string, dynamic> vars) { }

	protected override void Exit(IDictionary<string, dynamic> vars) { }

	protected override void Inner(IDictionary<string, dynamic> vars)
	{
		vars["x"]++;
	}
}
