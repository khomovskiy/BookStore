using BookStore.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ViewModel
{
    class ViewModuleClass
    {
        DataBaseControl DBControl;
        public List<Book> Store { get; set; }
        public ViewModuleClass()
        {
            DBControl = DataBaseControl.GetDataBaseControlInstance();
            Store = DBControl.Ctx.Books.Include(a=>a.Authors).ToList();
            
            ;
        }
    }
}
