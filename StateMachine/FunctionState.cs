namespace RoadieRichStateMachine
{
	/// <summary>
	/// A <see cref="State"/> using 
	/// </summary>
	public sealed class FunctionState : State
	{
		private readonly FunctionStateFunctionDelegateWithVars? _enterFunc;
		private readonly FunctionStateFunctionDelegateWithVars? _exitFunc;
		private readonly FunctionStateFunctionDelegateWithVars _innerFunc;

		/// <summary>
		/// Create an instance of <see cref="FunctionState"/> with the passed <see cref="FunctionStateFunctionDelegate"/>.
		/// </summary>
		/// <param name="name">Name of the state</param>
		/// <param name="innerFunc"></param>
		public FunctionState(string name, FunctionStateFunctionDelegate innerFunc) : this(name, null, innerFunc, null) { }

		/// <summary>
		/// Create an instance of <see cref="FunctionState"/> with the passed <see cref="FunctionStateFunctionDelegate"/>.
		/// </summary>
		/// <param name="innerFunc">The function to call every cycle.</param>
		public FunctionState(FunctionStateFunctionDelegate innerFunc) : this("FunctionState", null, innerFunc, null) { }

		/// <summary>
		/// Creates an instance of <see cref="FunctionState"/> with name, entry, inner and exit <see cref="FunctionStateFunctionDelegate"/>.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="enterFunc">Function to be called when entering the state, or <c>null</c>.</param>
		/// <param name="innerFunc">Function to be called every cycle.</param>
		/// <param name="exitFunc">function to be called when exiting the state, or <c>null</c>.</param>
		public FunctionState(string name,
					   FunctionStateFunctionDelegate? enterFunc,
					   FunctionStateFunctionDelegate innerFunc,
					   FunctionStateFunctionDelegate? exitFunc) : this(name,
														enterFunc != null ? ((vars) => enterFunc()) : null,
														(vars) => innerFunc(),
														exitFunc != null ? ((vars) => exitFunc()) : null)
		{}


		/// <summary>
		/// Creates an instance of <see cref="FunctionState"/> with entry, inner and exit <see cref="FunctionStateFunctionDelegate"/>.
		/// </summary>
		/// <param name="enterFunc">Function to be called when entering the state, or <c>null</c>.</param>
		/// <param name="innerFunc">Function to be called every cycle.</param>
		/// <param name="exitFunc">Function to be called when exiting the state, or <c>null</c>.</param>
		public FunctionState(FunctionStateFunctionDelegate? enterFunc,
					   FunctionStateFunctionDelegate innerFunc,
					   FunctionStateFunctionDelegate? exitFunc) : this("FunctionState",
														enterFunc != null ? ((vars) => enterFunc()) : null,
														(vars) => innerFunc(),
														exitFunc != null ? ((vars) => exitFunc()) : null) { }

		/// <summary>
		/// Create an instance of <see cref="FunctionState"/> with the passed <see cref="FunctionStateFunctionDelegateWithVars"/>.
		/// </summary>
		/// <param name="name">Name of the state</param>
		/// <param name="innerFunc"></param>
		public FunctionState(string name, FunctionStateFunctionDelegateWithVars innerFunc) : this(name, null, innerFunc, null) { }

		/// <summary>
		/// Create an instance of <see cref="FunctionState"/> with the passed <see cref="FunctionStateFunctionDelegateWithVars"/>.
		/// </summary>
		/// <param name="innerFunc">The function to call every cycle.</param>
		public FunctionState(FunctionStateFunctionDelegateWithVars innerFunc) : this("FunctionState", null, innerFunc, null) { }

		/// <summary>
		/// Creates an instance of <see cref="FunctionState"/> with name, entry, inner and exit <see cref="FunctionStateFunctionDelegateWithVars"/>.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="enterFunc">Function to be called when entering the state, or <c>null</c>.</param>
		/// <param name="innerFunc">Function to be called every cycle.</param>
		/// <param name="exitFunc">function to be called when exiting the state, or <c>null</c>.</param>
		public FunctionState(string name,
					   FunctionStateFunctionDelegateWithVars? enterFunc,
					   FunctionStateFunctionDelegateWithVars innerFunc,
					   FunctionStateFunctionDelegateWithVars? exitFunc) : base(name)
		{
			_enterFunc = enterFunc;
			_exitFunc = exitFunc;
			_innerFunc = innerFunc;
		}

		protected sealed override void Enter(IDictionary<string, dynamic> vars)
		{
			_enterFunc?.Invoke(vars);
		}

		protected sealed override void Exit(IDictionary<string, dynamic> vars)
		{
			_exitFunc?.Invoke(vars);
		}

		protected sealed override void Inner(IDictionary<string, dynamic> vars)
		{
			_innerFunc(vars);
		}
	}
}
