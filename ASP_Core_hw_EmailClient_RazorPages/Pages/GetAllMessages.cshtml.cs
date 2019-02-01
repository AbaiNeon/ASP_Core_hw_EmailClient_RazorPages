using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace ASP_Core_hw_EmailClient_RazorPages.Pages
{
    public class GetAllMessagesModel : PageModel
    {
        private readonly Context _db;
        public List<Message> Messages { get; set; }

        public GetAllMessagesModel(Context context)
        {
            _db = context;
        }

        public void OnGet()
        {
            Messages = _db.Messages.ToList();
        }
    }
}