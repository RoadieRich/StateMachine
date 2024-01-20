using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoadieRichStateMachine;
namespace UnitTests
{
	[TestClass]
	public class StateUnitTests
	{
		[TestMethod]
		public void NameCanBePassedInConstrutor()
		{
			var state = new MyState("myState");
			Assert.AreEqual(expected: "myState", state.ToString());
		}

		[TestMethod]
		public void NameCanBeInferred()
		{
			var state = new MyState();
			Assert.IsNotNull(state.ToString());
		}

		[TestMethod]
		public void InferredNameDoesNotIncludeState()
		{
			var state = new MyState();
			Assert.AreEqual(expected: "My", state.ToString());
		}
		
		internal class MyState : State
		{
			public MyState(string? name = null) : base(name)
			{
			}

			protected override void Enter(IDictionary<string, dynamic> vars)
			{
			}

			protected override void Exit(IDictionary<string, dynamic> vars)
			{
			}

			protected override void Inner(IDictionary<string, dynamic> vars)
			{
			}
		}
	}
}