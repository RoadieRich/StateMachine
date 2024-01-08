using RoadieRichStateMachine;


class IncrementState : State
{
	protected override void Enter(Dictionary<string, dynamic> vars) { }

	protected override void Exit(Dictionary<string, dynamic> vars) { }

	protected override void Inner(Dictionary<string, dynamic> vars)
	{
		vars["x"]++;
	}
}
