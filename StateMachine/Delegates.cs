namespace RoadieRichStateMachine
{
	public delegate bool TransitionConditionDelegate(Dictionary<string, dynamic> vars);
	public delegate void FunctionStateFunctionDelegate(Dictionary<string, dynamic> vars);
}
