using NLog;
using OldSkoul.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldSkoul.Logic
{
    public class PageQueryHandler
    {

        ApplicationDbContext _applicationDbContext;
        Logger _logger;

        public PageQueryHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _logger = LogManager.GetCurrentClassLogger();
        }



        public void Handle(List<int> pages) {

            try {

                // get all of the page data. 
                var pageInfo = _applicationDbContext.Pages.Where(w => pages.Contains(w.Id));
            
            
            }
            catch(Exception ex)
            {   


            }


        
        }
    }
}
