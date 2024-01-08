namespace RoadieRichStateMachine
{
	/// <summary>
	/// Base class for states
	/// </summary>
	public abstract class State : IDisposable
	{
		private readonly List<Transition> transitions = new();
		private bool disposedValue;

		/// <summary>
		/// Adds a state this state can transition to
		/// </summary>
		/// <param name="to">state to transition to</param>
		/// <param name="condition">condition to transition.  Evaluated each time <see cref="Inner(Dictionary{string, dynamic})"/> is run.  If true, the state machine moves to the associated state.  Use <c>null</c> to always transition.</param>
		/// <remarks>Transition conditions are evaulated in the order they are added.</remarks>
		public void AddTransitionTo(State to, TransitionConditionDelegate? condition)
		{
			transitions.Add(new Transition(to, condition));
		}

		/// <summary>
		/// Adds a state this state can transition to
		/// </summary>
		/// <param name="to">state to transition to</param>
		/// <param name="condition">condition to transition.  Evaluated each time <see cref="Inner(Dictionary{string, dynamic})"/> is run.  If true, the state machine moves to the associated state.  Use <c>null</c> to always transition.</param>
		/// <remarks>Transition conditions are evaulated in the order they are added.</remarks>
		public void AddTransitionTo(State to, TransitionConditionDelegateWithVars? condition)
		{
			transitions.Add(new Transition(to, condition));
		}

		/// <summary>
		/// Adds a state this state will always transition to if this transition is reached
		/// </summary>
		/// <param name="to">state to transition to</param>
		public void AddTransitionTo(State to)
		{
			transitions.Add(new Transition(to));
		}

		internal State RunAndGetNextState(Dictionary<string, dynamic> vars)
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

		protected internal State? GetNextState(Dictionary<string, dynamic> vars)
		{
			foreach (var transition in transitions)
			{
				if (transition.CheckCondition(vars))
					return transition.To;
			}
			return null;
		}

		/// <summary>
		/// Called when the State Machine enters the state 
		/// </summary>
		/// <param name="vars">A <see cref="Dictionary{string, dynamic}"/> of variables to be used in execution</param>
		protected abstract void Enter(Dictionary<string, dynamic> vars);

		/// <summary>
		/// This method is executed repeatedly while the state machine is in this state
		/// </summary>
		/// <param name="vars">A <see cref="Dictionary{string, dynamic}"/> of variables to be used in execution</param>
		protected abstract void Inner(Dictionary<string, dynamic> vars);

		/// <summary>
		/// Called before the state machine exits this state
		/// </summary>
		/// <param name="vars">A <see cref="Dictionary{string, dynamic}"/> of variables to be used in execution</param>
		protected abstract void Exit(Dictionary<string, dynamic> vars);

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				disposedValue = true; //moved here to prevent infinite loop
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
