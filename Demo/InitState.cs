using RoadieRichStateMachine;

class InitState : State
	{
		protected override void Enter(Dictionary<string, dynamic> vars)
		{
			vars["x"] = 0;
		}

		protected override void Exit(Dictionary<string, dynamic> vars) { }

		protected override void Inner(Dictionary<string, dynamic> vars)	{}
	}
