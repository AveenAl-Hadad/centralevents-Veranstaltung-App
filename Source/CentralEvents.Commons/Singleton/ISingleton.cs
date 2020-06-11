namespace CentralEvents.Commons.Singleton
{
	/// <summary>
	/// Simple Singleton container that supports testing.
	/// </summary>
	/// <typeparam name="TContract">The contract type of the singleton.</typeparam>
	/// <typeparam name="TImpl">The implementation type of the singleton.</typeparam>
	public class Singleton<TContract, TImpl>
		where TContract : class
		where TImpl : TContract, new()
	{
		private static readonly TImpl instance = new TImpl();
		private static TContract overrideInstance;

		/// <summary>
		/// Gets the singleton instance.
		/// </summary>
		public static TContract Instance
		{
			get { return overrideInstance ?? instance; }
		}

		/// <summary>
		/// Overrides the instance of the singleton for testing purposes.
		/// </summary>
		internal static void OverrideInstance(TContract value)
		{
			overrideInstance = value;
		}
	}
}