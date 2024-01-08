namespace RoadieRichStateMachine
{
	public class Transition :IDisposable
	{
		private bool disposedValue;

		public Transition(State to, TransitionConditionDelegate? condition)
		{
			To = to;
			Condition = condition;
		}
		public State To { get; }
		public TransitionConditionDelegate? Condition { get; }
		public bool CheckCondition(Dictionary<string, dynamic> vars)
		{
			return Condition == null || Condition(vars);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				disposedValue = true;
				if (disposing)
				{
					((IDisposable)To).Dispose();
				}

				// TODO: free unmanaged resources (unmanaged objects) and override finalizer
				// TODO: set large fields to null
			}
		}

		// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
		// ~Transition()
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
