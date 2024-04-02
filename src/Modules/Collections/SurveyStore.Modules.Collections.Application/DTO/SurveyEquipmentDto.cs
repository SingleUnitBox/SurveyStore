using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Application.DTO
{
    public class SurveyEquipmentDto
	{
		public SurveyEquipmentDto()
		{
            public StoreId? StoreId { get; set; }
            public string SerialNumber { get; set; }
            public string Brand { get; set; }
            public string Model { get; set; }


        }
	}
}