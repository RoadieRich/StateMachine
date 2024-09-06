using NUnit.Framework;
using NUnit.Framework.Legacy;
using RoadieRichStateMachine;

namespace UnitTests
{
	[TestFixture]
	public class StateMachineUnitTests
	{
		[Test]
		public void StateMachineCanRun()
		{
			using var sm = new StateMachine();
			Assert.That(() => sm.Run(), Throws.Nothing);
		}

		[Test]
		public void VarsCanBePassedIn()
		{
			Dictionary<string, dynamic> vars = new() 
			{
				["x"] = 0
			};

			using var sm = new StateMachine();
			Assert.That(() => sm.Run(vars), Throws.Nothing);
		}

		[Test]
		public void VarsCanBeModified()
		{
			Dictionary<string, dynamic> vars = new()
			{
				["x"] = 0
			};

			var funcState = new FunctionState((vars) => vars["x"]++);
			funcState.AddTransitionTo(StateMachine.ExitState, null);

			using var sm = new StateMachine();
			sm.InitialState = funcState;
			sm.Run(vars);

			Assert.That(vars, Does.ContainKey("x").WithValue(1));
		}

		[Test]
		public void StartStateEventIsTriggered()
		{
			var state = new FunctionState("", (vars) => { });
			state.AlwaysTransitionTo(StateMachine.ExitState);

			using var sm = new StateMachine() { InitialState = state };
			int anInt = 0;
			sm.StateStarting += (sender, e) => anInt++;
			sm.Run();

			Assert.That(anInt, Is.EqualTo(1));
		}

		[Test]
		public void EndStateEventIsTriggered()
		{
			var state = new FunctionState("", (vars) => { });
			state.AlwaysTransitionTo(StateMachine.ExitState);

			using var sm = new StateMachine() { InitialState = state };
			int anInt = 0;
			sm.StateFinished += (sender, e) => anInt++;
			sm.Run();

			Assert.That(anInt, Is.EqualTo(1));
		}
	}
}