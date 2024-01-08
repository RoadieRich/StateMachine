namespace RoadieRichStateMachine
{
	public class StateMachine : IDisposable
	{
		private bool disposedValue;

		public State InitialState { get; set; } = ExitState;

		public static ExitState ExitState { get; } = new();

		public void Run()
		{
			var state = InitialState;
			var vars = new Dictionary<string, dynamic>();
			while (state != ExitState)
			{
				state = state.RunAndGetNextState(vars);
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
