namespace CodeTest.Views
{
    public class MainView
    {
        private readonly string _text;
        private readonly string _subtext;
        private readonly string _matches;

        public MainView(string text, string subtext, string matches)
        {
            _text = text;
            _subtext = subtext;
            _matches = matches;

        }

        public string Text
        {
            get { return _text; }
        }
        public string Subtext
        {
            get
            {
                return _subtext;
            }
        }
        public string Matches
        {
            get { return _matches; }
        }
    }
}
