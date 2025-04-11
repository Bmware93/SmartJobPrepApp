using System;
namespace JobPrepAPI.DTOs
{
	public class JobDescriptionResponseDTO
	{
		public int JobDescriptionId { get; set; }

		public string Title { get; set; }

        public string DescriptionText { get; set; }

        public List<string> Questions { get; set; }
    }
}

