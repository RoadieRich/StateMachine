using RoadieRichStateMachine;
namespace UnitTests
{
	[TestFixture]
	public class StateUnitTests
	{
		[Test]
		public void NameCanBePassedInConstrutor()
		{
			var state = new MyState("myState");
			Assert.That(() => state.ToString(), Is.EqualTo("myState"));
		}

		[Test]
		public void NameCanBeInferred()
		{
			var state = new MyState();
			Assert.That(() => state.ToString(), Is.Not.Null);
		}

		[Test]
		public void InferredNameDoesNotIncludeState()
		{
			var state = new MyState();
			Assert.That(() => state.ToString(), Does.Not.Contain("State"));
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