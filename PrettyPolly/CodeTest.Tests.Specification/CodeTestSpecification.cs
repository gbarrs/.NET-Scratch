using NUnit.Framework;

namespace CodeTest.Tests.Specification
{

    public class CodeTestSpecification
    {
        const string _text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we'll all have tea";

        [TestFixture]
        public class When_subtext_is_Polly
        {
            [Test]
            public void Then_the_output_should_be_1_26_51()
            {

                const string subtext = "Polly";
                var output = new[] { 1, 26, 51 };

                var textMatcher = new TextMatcher(_text, subtext);
                textMatcher.Match();

                var matches = textMatcher.GetMatches();
                matches.should_have_count(3);
                foreach (var match in matches)
                {
                    output.should_contain(match.StartPosition);
                }

            }
        }

        [TestFixture]
        public class When_subtext_is_polly
        {
            [Test]
            public void Then_the_output_should_be_1_26_51()
            {

                const string subtext = "polly";
                var output = new[] { 1, 26, 51 };

                var textMatcher = new TextMatcher(_text, subtext);
                textMatcher.Match();

                var matches = textMatcher.GetMatches();
                matches.should_have_count(3);
                foreach (var match in matches)
                {
                    output.should_contain(match.StartPosition);
                }

            }
        }

        [TestFixture]
        public class When_subtext_is_ll
        {
            [Test]
            public void Then_the_output_should_be_3_28_53_78_82()
            {

                const string subtext = "ll";
                var output = new[] { 3, 28, 53, 78, 82 };

                var textMatcher = new TextMatcher(_text, subtext);
                textMatcher.Match();

                var matches = textMatcher.GetMatches();
                matches.should_have_count(5);
                foreach (var match in matches)
                {
                    output.should_contain(match.StartPosition);
                }

            }
        }

        [TestFixture]
        public class When_subtext_is_Ll
        {
            [Test]
            public void Then_the_output_should_be_3_28_53_78_82()
            {

                const string subtext = "Ll";
                var output = new[] { 3, 28, 53, 78, 82 };

                var textMatcher = new TextMatcher(_text, subtext);
                textMatcher.Match();

                var matches = textMatcher.GetMatches();
                matches.should_have_count(5);
                foreach (var match in matches)
                {
                    output.should_contain(match.StartPosition);
                }

            }
        }

        [TestFixture]
        public class When_subtext_is_X
        {
            [Test]
            public void Then_there_should_be_no_matches()
            {

                const string subtext = "X";

                var textMatcher = new TextMatcher(_text, subtext);
                textMatcher.Match();

                var matches = textMatcher.GetMatches();
                matches.should_have_count(0);
            }
        }

        [TestFixture]
        public class When_subtext_is_PolX
        {
            [Test]
            public void Then_there_should_be_no_matches()
            {

                const string subtext = "PolX";

                var textMatcher = new TextMatcher(_text, subtext);
                textMatcher.Match();

                var matches = textMatcher.GetMatches();
                matches.should_have_count(0);
            }
        }

        [TestFixture]
        public class When_the_subtext_is_aaa
        {
            [Test]
            public void Then_there_should_be_no_matches()
            {

                const string subtext = "aaa";

                var textMatcher = new TextMatcher(_text, subtext);
                textMatcher.Match();

                var matches = textMatcher.GetMatches();
                matches.should_have_count(0);
            }
        }

    }
}
