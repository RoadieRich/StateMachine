namespace RoadieRichStateMachine
{
	public class StateMachine
	{
		public State InitialState { get; set; } = ExitState;

		public static ExitState ExitState { get; } = new();

		public void Run()
		{
			var state = InitialState;
			var vars = new Dictionary<string, dynamic>();
			while (state != ExitState)
			{
				state = state.RunAndGetNextState(vars);
			}
		}
	}
}
