namespace RoadieRichStateMachine
{
	public class Transition
	{
		public Transition(State to, TransitionConditionDelegate? condition)
		{
			To = to;
			Condition = condition;
		}
		public State? To { get; }
		public TransitionConditionDelegate? Condition { get; }
		public bool CheckCondition(Dictionary<string, dynamic> vars)
		{
			return (Condition == null || Condition(vars));
		}

	}
}
