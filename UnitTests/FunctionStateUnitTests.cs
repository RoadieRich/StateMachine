using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoadieRichStateMachine;
using System.Runtime.CompilerServices;

namespace UnitTests
{
	[TestClass]
	public class FunctionStateUnitTests
	{
		[TestMethod]
		public void EmptyStateMachineCanRun()
		{
			using var sm = new StateMachine();
			sm.Run();
		}

		[TestMethod]
		public void FunctionStateRunsInnerFunctions()
		{
			var b = false;

			var funcState = new FunctionState(() => b = true);

			funcState.AddTransitionTo(StateMachine.ExitState);

			using var sm = new StateMachine();

			sm.InitialState = funcState;
			sm.Run();

			Assert.IsTrue(b);
		}

		[TestMethod]
		public void FunctionStateRunsEntryFunction()
		{
			var aBool = false;

			var funcState = new FunctionState(() => aBool = true, () => { }, null);

			funcState.AddTransitionTo(StateMachine.ExitState);

			using var sm = new StateMachine();

			sm.InitialState = funcState;
			sm.Run();

			Assert.IsTrue(aBool);
		}

		[TestMethod]
		public void FunctionStateRunsExitFunction()
		{
			var aBool = false;

			var funcState = new FunctionState(null, () => { }, () => aBool = true);

			funcState.AddTransitionTo(StateMachine.ExitState);

			using var sm = new StateMachine();

			sm.InitialState = funcState;
			sm.Run();

			Assert.IsTrue(aBool);
		}

		[TestMethod]
		public void EnterIsOnlyCalledOnce()
		{
			var anInt = 0;

			var funcState = new FunctionState(() => anInt++, () => { }, null);

			funcState.AddTransitionTo(StateMachine.ExitState);

			using var sm = new StateMachine();

			sm.InitialState = funcState;
			sm.Run();


			Assert.AreEqual(expected: 1, actual: anInt);
		}
		[TestMethod]
		public void ExitIsOnlyCalledOnce()
		{

			var anInt = 0;

			var funcState = new FunctionState(null, () => { }, () => anInt++);

			funcState.AddTransitionTo(StateMachine.ExitState);

			using var sm = new StateMachine();

			sm.InitialState = funcState;
			sm.Run();


			Assert.AreEqual(expected: 1, actual: anInt);
		}
	}
}