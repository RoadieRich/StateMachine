﻿using RoadieRichStateMachine;

class EvenState : State
{
	protected override void Enter(IDictionary<string, dynamic> vars) { }

	protected override void Exit(IDictionary<string, dynamic> vars) { }

	protected override void Inner(IDictionary<string, dynamic> vars)
	{
		Console.WriteLine(" is even");
	}
}
