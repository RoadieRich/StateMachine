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
				state = state.RunAndGetNextState(myVars);
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
