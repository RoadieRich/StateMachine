namespace RoadieRichStateMachine
{
	public abstract class State : IDisposable
	{
		private readonly List<Transition> transitions = new();
		private bool disposedValue;

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

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				disposedValue = true;
				if (disposing)
				{
					foreach(var transition in transitions)
					{
						((IDisposable)transition).Dispose();
					}
				}

				// TODO: free unmanaged resources (unmanaged objects) and override finalizer
				// TODO: set large fields to null
			}
		}

		// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		// ~State()
		// {
		//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		//     Dispose(disposing: false);
		// }

		void IDisposable.Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
