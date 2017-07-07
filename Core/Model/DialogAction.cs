namespace Core.Model
{
    public class DialogAction<SlotType>
    {
        public string Type { get; set; }
        public string IntentName { get; set; }
        public string SlotToElict { get; set; }
        public Message Message { get; set; }
        public SlotType Slots { get; set; }
    }
}