namespace RoadieRichStateMachine
{
	/// <summary>
	/// A <see cref="State"/> using 
	/// </summary>
	public sealed class FunctionState : State
	{
		private readonly FunctionStateFunctionDelegate? _enterFunc;
		private readonly FunctionStateFunctionDelegate? _exitFunc;
		private readonly FunctionStateFunctionDelegate _innerFunc;

		/// <summary>
		/// Create an instance of <see cref="FunctionState"/> with the passed <see cref="State.Inner(Dictionary{string, dynamic})"/>.
		/// </summary>
		/// <param name="innerFunc">The function to call every cycle.</param>
		public FunctionState(FunctionStateFunctionDelegate innerFunc)
		{
			_innerFunc = innerFunc;
		}

		/// <summary>
		/// Creates an instance of <see cref="FunctionState"/> with entry, inner and exit states
		/// </summary>
		/// <param name="enterFunc">Function to be called when entering the state, or <c>null</c>.</param>
		/// <param name="innerFunc">Function to be called every cycle.</param>
		/// <param name="exitFunc">function to be called when exiting the state, or <c>null</c>.</param>
		public FunctionState(FunctionStateFunctionDelegate? enterFunc, FunctionStateFunctionDelegate innerFunc, FunctionStateFunctionDelegate? exitFunc)
		{
			_enterFunc = enterFunc;
			_exitFunc = exitFunc;
			_innerFunc = innerFunc;
		}


		protected sealed override void Enter(Dictionary<string, dynamic> vars)
		{
			_enterFunc?.Invoke(vars);
		}

		protected sealed override void Exit(Dictionary<string, dynamic> vars)
		{
			_exitFunc?.Invoke(vars);
		}

		protected sealed override void Inner(Dictionary<string, dynamic> vars)
		{
			_innerFunc(vars);
		}
	}
}
