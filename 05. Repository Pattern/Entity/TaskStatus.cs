namespace RepositoryPattern.Entity
{
	// Not an IEntity because table isn't exposed to DbContext
	public enum TaskStatus
	{
		Open = 1,
		Completed = 2,
		Canceled = 3
	}
}
