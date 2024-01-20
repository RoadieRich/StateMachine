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

			funcState.AlwaysTransitionTo(StateMachine.ExitState);

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

			funcState.AlwaysTransitionTo(StateMachine.ExitState);

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

			funcState.AlwaysTransitionTo(StateMachine.ExitState);

			using var sm = new StateMachine();

			sm.InitialState = funcState;
			sm.Run();

			Assert.IsTrue(aBool);
		}

		[TestMethod]
		public void InnerIsCalledRepeatedly()
		{
			var anInt = 0;

			var funcState = new FunctionState(() => anInt++);

			funcState.AddTransitionTo(StateMachine.ExitState, () => anInt > 10);

			using var sm = new StateMachine();

			sm.InitialState = funcState;
			sm.Run();

			Assert.AreNotEqual(notExpected: 0, actual: anInt);
		}

		[TestMethod]
		public void EnterIsOnlyCalledOnce()
		{
			var anInt = 0;
			var anotherInt = 0;

			var funcState = new FunctionState(() => anInt++, () => anotherInt++, null);

			funcState.AddTransitionTo(StateMachine.ExitState, () => anotherInt > 10);

			using var sm = new StateMachine();

			sm.InitialState = funcState;
			sm.Run();


			Assert.AreEqual(expected: 1, actual: anInt);
		}
		[TestMethod]
		public void ExitIsOnlyCalledOnce()
		{

			var anInt = 0;
			var anotherInt = 0;

			var funcState = new FunctionState(null, () => anotherInt++, () => anInt++);

			funcState.AddTransitionTo(StateMachine.ExitState, () => anotherInt > 10);

			using var sm = new StateMachine();

			sm.InitialState = funcState;
			sm.Run();

			Assert.AreEqual(expected: 1, actual: anInt);
		}
	}
}