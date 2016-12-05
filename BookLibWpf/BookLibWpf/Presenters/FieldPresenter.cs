using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibWpf.Views;
using BookLibWpf.Models;
namespace BookLibWpf.Presenters
{
    class FieldPresenter
    {
        // t is either int or string (id or title of the book)
        public IService<Book> model;
        public IView<int> view;
       

        public FieldPresenter(IService<Book> model, IView<int> view)
        {
            this.model = model;
            this.view = view;

            this.view.ProcessInput += processInput_Click;
        }
        
        public void processInput_Click(object sender, int e)
        {
            Book temp = model.Select().First(i => i.Id == e);
            if (temp != null)
            {
                SubWindow1 view1 = new SubWindow1();
                ActorPresenter presenter = new ActorPresenter(model, view1, temp);
                view1.Show();
            }
        }
    }
}
