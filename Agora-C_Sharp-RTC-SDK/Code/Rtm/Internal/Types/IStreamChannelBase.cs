using System;
namespace Agora.Rtm.Internal
{
    public class TopicOptions
    {
        public TopicOptions(Agora.Rtm.TopicOptions topicOptions)
        {
            users = topicOptions.users;
            userCount = users.Length;
        }

        public TopicOptions()
        {
        }

        public string[] users;

        public int userCount;
    };
}
