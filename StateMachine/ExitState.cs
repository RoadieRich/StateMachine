namespace RoadieRichStateMachine
{
	public sealed class ExitState : State
	{
		internal ExitState() : base("Exit State") { }

		protected override void Enter(IDictionary<string, dynamic> vars) => throw new NotImplementedException();

		protected override void Exit(IDictionary<string, dynamic> vars) => throw new NotImplementedException();

		protected override void Inner(IDictionary<string, dynamic> vars) => throw new NotImplementedException();

		[Obsolete("You cannot add transitions to ExitState", true)] public new State AddTransitionTo(State to, TransitionConditionDelegate condition) => throw new InvalidOperationException();
		[Obsolete("You cannot add transitions to ExitState", true)] public new State AddTransitionTo(State to, TransitionConditionDelegateWithVars condition) => throw new InvalidOperationException();
		[Obsolete("You cannot add transitions to ExitState", true)] public new State AlwaysTransitionTo(State to) => throw new InvalidOperationException();
	}
}
