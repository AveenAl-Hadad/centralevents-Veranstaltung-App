namespace CentralEvent.Business.Services
{
	using CentralEvent.Business.Contracts.Services;

	using CentralEvents.Commons.Singleton;

	public class SessionService : Singleton<ISessionService, SessionService>, ISessionService
	{
		public string Benutzername { get; set; }
	}
}