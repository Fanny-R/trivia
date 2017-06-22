using Nancy;

namespace Trivia.WebAPI
{
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
            Get["/"] = _ => "Hello World!";
        }
    }
}