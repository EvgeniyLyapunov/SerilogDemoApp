using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Eventing.Reader;

namespace SerilogDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("You requested Index page");

            try
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i == 56)
                        throw new Exception("My personality exception"); 
                    else
                        _logger.LogInformation("The value of i is {iValue}", i);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "This exception was in Index Get method");
            }
        }
    }
}
