using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibWpf.Models;
using BookLibWpf.Views;

namespace BookLibWpf.Presenters
{
    class ActorPresenter 
    {
        public IService<Book> model;
        public IView<ProjectEventArgs> view;
        
        public Book bookBag = null;

        public ActorPresenter(IService<Book> model, IView<ProjectEventArgs> view)
        {
            this.model = model;
            this.view = view;

            view.ProcessInput += processInsert_Click;
        }
        public ActorPresenter(IService<Book> model, IView<ProjectEventArgs> view, Book bookBag)
        {
            this.model = model;
            this.view = view;

            view.ProcessInput += processUpdate_Click;

            this.bookBag = bookBag;
        }

        public void processInsert_Click(object sender, ProjectEventArgs e)
        {
            model.Insert(e.Book);
        }

        private void processUpdate_Click(object sender, ProjectEventArgs e)
        {
            model.Update(bookBag, e.Book);
        }
    }
}
