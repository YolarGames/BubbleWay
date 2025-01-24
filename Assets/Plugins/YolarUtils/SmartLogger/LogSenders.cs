namespace YolarUtils.SmartLogger
{
	public static class LogSenders
	{
		public static readonly LogSender Application = new(name: "[Application]".Green());
		public static readonly LogSender Assets = new(name: "[Assets]");
		public static readonly LogSender GameStateMachine = new(name: "[Game State Machine]");
		public static readonly LogSender SceneData = new(name: "[Scene Data]");
		public static readonly LogSender Postponer = new(name: "[Postponer]");
		public static readonly LogSender Localization = new(name: "[Localization]");
	}
}