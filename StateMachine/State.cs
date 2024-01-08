namespace RoadieRichStateMachine
{
	public abstract class State
	{
		private readonly List<Transition> transitions = new();
		public void AddTransitionTo(State to, TransitionConditionDelegate? condition)
		{
			transitions.Add(new Transition(to, condition));
		}

		public State RunAndGetNextState(Dictionary<string, dynamic> vars)
		{
			Enter(vars);
			State? next = null;
			while (next == null)
			{
				Inner(vars);
				next = GetNextState(vars);
			}
			Exit(vars);
			return next;
		}

		protected State? GetNextState(Dictionary<string, dynamic> vars)
		{
			foreach (var transition in transitions)
			{
				if (transition.CheckCondition(vars))
					return transition.To;
			}
			return null;
		}

		protected abstract void Enter(Dictionary<string, dynamic> vars);
		protected abstract void Inner(Dictionary<string, dynamic> vars);
		protected abstract void Exit(Dictionary<string, dynamic> vars);
	}
}
