using NUnit.Framework;
using NUnit.Framework.Legacy;
using RoadieRichStateMachine;
using System.Runtime.CompilerServices;

namespace UnitTests
{
	[TestFixture]
	public class FunctionStateUnitTests
	{
		[Test]
		public void EmptyStateMachineCanRun()
		{
			using var sm = new StateMachine();
			Assert.That(()=>sm.Run(), Throws.Nothing);
		}

		[Test]
		public void FunctionStateRunsInnerFunctions()
		{
			var b = false;

			var funcState = new FunctionState((vars) => b = true);

			funcState.AddTransitionTo(StateMachine.ExitState, null);

			using var sm = new StateMachine();

			sm.InitialState = funcState;
			sm.Run();

			Assert.That(b, Is.True);
		}

		[Test]
		public void FunctionStateRunsEntryFunction()
		{
			var aBool = false;

			var funcState = new FunctionState((vars) => aBool = true, (vars) => { }, null);

			funcState.AddTransitionTo(StateMachine.ExitState, null);

			using var sm = new StateMachine();

			sm.InitialState = funcState;
			sm.Run();

			Assert.That(aBool, Is.True);
		}

		[Test]
		public void FunctionStateRunsExitFunction()
		{
			var aBool = false;

			var funcState = new FunctionState(null, (vars) => { }, (vars) => aBool = true);

			funcState.AddTransitionTo(StateMachine.ExitState, null);

			using var sm = new StateMachine();

			sm.InitialState = funcState;
			sm.Run();

			Assert.That(aBool, Is.True);
		}

		[Test]
		public void InnerIsCalledRepeatedly()
		{
			var anInt = 0;

			var funcState = new FunctionState((vars) => anInt++);

			funcState.AddTransitionTo(StateMachine.ExitState, (vars) => anInt > 10);

			using var sm = new StateMachine();

			sm.InitialState = funcState;
			sm.Run();

			Assert.That(anInt, Is.GreaterThan(1));
		}

		[Test]
		public void EnterIsOnlyCalledOnce()
		{
			var anInt = 0;
			var anotherInt = 0;

			var funcState = new FunctionState((vars) => anInt++, (vars) => anotherInt++, null);

			funcState.AddTransitionTo(StateMachine.ExitState, (vars) => anotherInt > 10);

			using var sm = new StateMachine();

			sm.InitialState = funcState;
			sm.Run();


			Assert.That(anInt, Is.EqualTo(1));
		}
		[Test]
		public void ExitIsOnlyCalledOnce()
		{

			var anInt = 0;
			var anotherInt = 0;

			var funcState = new FunctionState(null, (vars) => anotherInt++, (vars) => anInt++);

			funcState.AddTransitionTo(StateMachine.ExitState, (vars) => anotherInt > 10);

			using var sm = new StateMachine();

			sm.InitialState = funcState;
			sm.Run();

			Assert.That(anInt, Is.EqualTo(1));
		}
	}
}