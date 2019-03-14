namespace EnvOverrides.Models
{
	public class Settings
	{
		public string ConstantInAllEnvironments { get; set; }
		public string EnvironmentSpecific { get; set; }
		public string UserSpecific { get; set; } // great for connection strings and access keys
	}
}
