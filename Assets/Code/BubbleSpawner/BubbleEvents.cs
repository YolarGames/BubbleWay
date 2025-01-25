using System;

public static class BubbleEvents
{
	public static event Action OnBubbleStartBlow = delegate { };
	public static event Action OnBubbleEndBlow = delegate { };

	public static void InvokeOnBubbleBlow() =>
		OnBubbleStartBlow();

	public static void InvokeOnBubbleEndBlow() =>
		OnBubbleEndBlow();
}