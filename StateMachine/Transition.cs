namespace RoadieRichStateMachine
{
	internal class Transition : IDisposable
	{
		private bool _disposedValue;
		internal State To { get; }
		private readonly TransitionConditionDelegateWithVars? _condition;

		internal Transition(State to, TransitionConditionDelegateWithVars? condition)
		{
			To = to;
			_condition = condition;
		}
		internal Transition(State to, TransitionConditionDelegate? condition)
		{
			To = to;
			_condition = condition == null ? null : ((vars) => condition());
		}

		public Transition(State to)
		{
			To = to;
		}

		internal bool CheckCondition(Dictionary<string, dynamic> vars)
		{
			return _condition == null || _condition(vars);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposedValue)
			{
				_disposedValue = true; //moved here to prevent infinite loop
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
