namespace Core.Model
{
    public class DialogAction<SlotType>
    {
        public string type { get; set; }
        public string intentName { get; set; }
        public string slotToElicit { get; set; }
        public Message message { get; set; }
        public SlotType slots { get; set; }
    }
}