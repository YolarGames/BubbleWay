namespace YolarUtils.SmartLogger
{
	public struct SLogger
	{
		public static LogBuilder Message(LogSender sender) =>
			new(sender);
	}
}