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

			var funcState = new FunctionState((vars) => vars["x"]++);
			funcState.AddTransitionTo(StateMachine.ExitState, null);

			using var sm = new StateMachine();
			sm.InitialState = funcState;
			sm.Run(vars);

			Assert.AreEqual(expected: 1, actual: vars["x"]);
		}
	}
}