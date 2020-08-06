namespace Shared.Dtos {
    public static class EventDataExtensions {
		public static int GetDueDays(this EventDataReadDto data) {
			return (int)data.ExpirationTime.Subtract(data.StartTime).TotalDays;
		}

	}
}