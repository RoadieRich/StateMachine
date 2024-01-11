namespace RoadieRichStateMachine
{
	public delegate bool TransitionConditionDelegate(IDictionary<string, dynamic> vars);
	public delegate void FunctionStateFunctionDelegate(IDictionary<string, dynamic> vars);
}
