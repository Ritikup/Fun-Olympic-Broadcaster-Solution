using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fun_Olympic_Broadcaster.Models
{
    public class InputAdmin
    {

        [ValidateNever]
        public IEnumerable<SelectListItem> RoleList { get; set; }
    }
}
