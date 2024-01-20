using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoadieRichStateMachine;

namespace UnitTests
{
	[TestClass]
	public class StateMachineUnitTests
	{
		[TestMethod]
		public void StateMachineCanRun()
		{
			using var sm = new StateMachine();
			sm.Run();
		}

		[TestMethod]
		public void VarsCanBePassedIn()
		{
			Dictionary<string, dynamic> vars = new() 
			{
				["x"] = 0
			};

			using var sm = new StateMachine();
			sm.Run(vars);
		}

		[TestMethod]
		public void VarsCanBeModified()
		{
			Dictionary<string, dynamic> vars = new()
			{
				["x"] = 0
			};

			var funcState = new FunctionState("func state", (vars) => vars["x"]++);
			funcState.AlwaysTransitionTo(StateMachine.ExitState);

			using var sm = new StateMachine();
			sm.InitialState = funcState;
			sm.Run(vars);

			Assert.AreEqual(expected: 1, actual: vars["x"]);
		}

		[TestMethod]
		public void StartStateEventIsTriggered()
		{
			var state = new FunctionState("", (vars) => { });
			state.AlwaysTransitionTo(StateMachine.ExitState);

			using var sm = new StateMachine() { InitialState = state };
			int anInt = 0;
			sm.StateStarting += (sender, e) => anInt++;
			sm.Run();

			Assert.AreEqual(expected: 1, actual: anInt);
		}

		[TestMethod]
		public void EndStateEventIsTriggered()
		{
			var state = new FunctionState("", (vars) => { });
			state.AlwaysTransitionTo(StateMachine.ExitState);

			using var sm = new StateMachine() { InitialState = state };
			int anInt = 0;
			sm.StateFinished += (sender, e) => anInt++;
			sm.Run();

			Assert.AreEqual(expected: 1, actual: anInt);
		}
	}
}