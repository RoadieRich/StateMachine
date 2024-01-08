using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoadieRichStateMachine;
using System.Runtime.CompilerServices;

namespace UnitTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void EmptyStateMachineCanRun()
		{
			var sm = new StateMachine();
			sm.Run();
		}

		[TestMethod]
		public void FunctionStateRunsInnerFunctions()
		{
			var b = false;

			var funcState = new FunctionState((vars) => b = true);

			funcState.AddTransitionTo(StateMachine.ExitState, null);

			var sm = new StateMachine();
			sm.InitialState = funcState;
			sm.Run();

			Assert.IsTrue(b);
		}

		[TestMethod]
		public void FunctionStateRunsEntryFunction()
		{
			var aBool = false;

			var funcState = new FunctionState((vars) => aBool = true, (vars) => { }, null);

			funcState.AddTransitionTo(StateMachine.ExitState, null);

			var sm = new StateMachine();
			sm.InitialState = funcState;
			sm.Run();

			Assert.IsTrue(aBool);
		}

		[TestMethod]
		public void FunctionStateRunsExitFunction()
		{
			var aBool = false;

			var funcState = new FunctionState(null, (vars) => { }, (vars) => aBool = true);

			funcState.AddTransitionTo(StateMachine.ExitState, null);

			var sm = new StateMachine();
			sm.InitialState = funcState;
			sm.Run();

			Assert.IsTrue(aBool);
		}

	}
}