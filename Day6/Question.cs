namespace AoC2020
{
    public class Question
    {
        private string Text { get; set; }
        public int Count {get; set; }

        public Question(string text) {
            Text = text;
            Count = 1;
        }

        public void IncreaseCount() {
            Count++;
        }

        public override bool Equals(object obj)
        {
            Question q2 = (Question)obj;
            return this.Text.Equals(q2.Text) ? true: false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode()*42;
        }
    }
}