namespace RoadieRichStateMachine
{
	/// <summary>
	/// The core State Machine class
	/// </summary>
	public class StateMachine : IDisposable
	{
		private bool disposedValue;

		/// <summary>
		/// <see cref="State"/> the state machine starts in
		/// </summary>
		public State InitialState { get; set; } = ExitState;

		/// <summary>
		/// Time to pause between executions of <see cref="State.Inner(IDictionary{string, dynamic})"/>
		/// </summary>
		public int Delay { get; set; } = 0;

		/// <summary>
		/// Raised before a State is started
		/// </summary>
		public event StateEventHandler? StateStarting;

		/// <summary>
		/// Raised when a State has finished
		/// </summary>
		public event StateEventHandler? StateFinished;

		/// <summary>
		/// If a state's <see cref="Transition"/> points to this state, the state machine is terminated.
		/// </summary>
		public static ExitState ExitState { get; } = new();

		/// <summary>
		/// Start the state machine
		/// </summary>
		/// <param name="vars">A variable context to intialize with</param>
		public void Run(IDictionary<string, dynamic>? vars = null)
		{
			var state = InitialState;
			IDictionary<string, dynamic> myVars = vars ?? new Dictionary<string, dynamic>();
			
			while (state != ExitState)
			{
				StateStarting?.Invoke(this, new StateEventArgs(state));
				State nextState = state.RunAndGetNextState(Delay, myVars);
				StateFinished?.Invoke(this, new StateEventArgs(state));
				state = nextState;
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				disposedValue = true;
				if (disposing)
				{
					((IDisposable)InitialState).Dispose();
				}

				// TODO: free unmanaged resources (unmanaged objects) and override finalizer
				// TODO: set large fields to null
			}
		}

		// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		// ~StateMachine()
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
