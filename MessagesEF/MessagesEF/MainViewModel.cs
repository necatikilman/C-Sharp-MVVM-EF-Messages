using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Messages
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        AuthorDataRepository authorDataRepository = new AuthorDataRepository();
        PostDataRepository postDataRepository = new PostDataRepository();
        public Post SelectedPost { get; set; }
        private Author selectedAuthor;
        private List<Author> authors;
        private List<Post> posts;
        public List<Author> Authors
        {
            get => authors;
            set
            {
                authors = value;
                OnPropertyChanged();
            }
        }
        public List<Post> Posts
        {
            get => posts;
            set
            {
                posts = value;
                OnPropertyChanged();
            }
        }

        public Author SelectedAuthor
        {
            get => selectedAuthor;
            set
            {
                selectedAuthor = value;
                LoadPosts(selectedAuthor);
            }
        }

        public string Title { get; set; }
        public string Content { get; set; }

        public ActionCommand AddCommand { get; set; }
        public ActionCommand DeleteCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            AddCommand = new ActionCommand(AddCommandAction);
            DeleteCommand = new ActionCommand(DeleteCommandAction);

            Authors = authorDataRepository.GetAllAuthors();
        }

        private void DeleteCommandAction()
        {
            if (SelectedPost != null)
            {
                postDataRepository.DeletePost(SelectedPost);

                LoadPosts(SelectedAuthor);
            }
        }

        private void AddCommandAction()
        {
            if (SelectedAuthor != null)
            {
                Post post = new Post();
                post.Author = SelectedAuthor;
                post.Title = Title;
                post.Content = Content;
                post.Date = DateTime.Now;

                SelectedAuthor.Posts.Add(post);

                authorDataRepository.UpdateAuthor(SelectedAuthor);

                LoadPosts(SelectedAuthor);
            }
        }

        private void LoadPosts(Author selectedAuthor)
        {
            Posts = postDataRepository.GetPostsFor(selectedAuthor);
        }

        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
