namespace RoadieRichStateMachine
{
	public delegate void StateEventHandler(object sender, StateEventArgs e);
	public class StateEventArgs
	{
		State State { get; }

		public StateEventArgs(State state) {  State = state; }
	}
}