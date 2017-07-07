namespace Core.Model
{
    public class DialogAction<SlotType>
    {
        public string type { get; set; }
        public string intentName { get; set; }
        public string slotToElicit { get; set; }

        private Message _message;
        public Message message
        {
            get
            {
                if(_message == null)
                {
                    _message = new Message();
                }
                return _message;
            }
        }

        public SlotType slots { get; set; }
    }
}