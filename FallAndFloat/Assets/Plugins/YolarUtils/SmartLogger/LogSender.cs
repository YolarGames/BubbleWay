namespace YolarUtils.SmartLogger
{
	public struct LogSender
	{
		public readonly LogPlatform Platform;
		public readonly string Name;

		public LogSender(string name, LogPlatform platform = LogPlatform.All)
		{
			Platform = platform;
			Name = name;
		}
	}
}