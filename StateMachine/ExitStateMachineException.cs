using System.Runtime.Serialization;

namespace RoadieRichStateMachine
{
	[Serializable]
	internal class ExitStateMachineException : Exception
	{
		public ExitStateMachineException()
		{
		}

		public ExitStateMachineException(string? message) : base(message)
		{
		}

		public ExitStateMachineException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected ExitStateMachineException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}