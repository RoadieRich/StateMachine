namespace RoadieRichStateMachine
{
	/// <summary>
	/// Determines whether to take a certain transition
	/// </summary>
	/// <param name="vars">A dictionary of variables shared between all states and transitions</param>
	/// <returns>true if the transition should be taken</returns>
	public delegate bool TransitionConditionDelegate(Dictionary<string, dynamic> vars);

	/// <summary>
	/// A function run by <see cref="FunctionState"/>
	/// </summary>
	/// <param name="vars">A dictionary of variables shared between all states and transitions</param>
	public delegate void FunctionStateFunctionDelegate(Dictionary<string, dynamic> vars);
}
