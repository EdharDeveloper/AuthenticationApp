namespace Authorization.Base.Controllers
{
    public class RequestHandler
    {
        private RequestDelegate _next;
        public RequestHandler(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Hello!");
            //conext do something
            context.Items.Add("user", "Edhar");
            await _next.Invoke(context);

        }
    }
}
