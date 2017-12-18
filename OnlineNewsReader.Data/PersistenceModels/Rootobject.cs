namespace OnlineNewsReader.Data.PersistenceModels
{
	#region Classes

	public class Rootobject
	{
		public Article[] articles { get; set; }
		public string status { get; set; }
		public int totalResults { get; set; }
	}

	#endregion
}
