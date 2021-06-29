using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Presenter;

namespace WindowsFormsApp1.View
{
    public interface IUserView
    {
        List<string> Posts { get; set; }

        string UserLogin { get; set; }

        UserPresenter userPresenter { get; set; }
    }
}
