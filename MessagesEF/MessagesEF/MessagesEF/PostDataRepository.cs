using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    internal class PostDataRepository
    {
        MessagesDB messagesDB = new MessagesDB();

        public List<Post> GetAllPosts()
        {
            return messagesDB.Posts.ToList();
        }
        public Post GetPost(int id)
        {
            return messagesDB.Posts.First(post => post.Id == id);
        }
        public List<Post> GetPostsFor(Author author)
        {
            return messagesDB.Posts.Where(post => post.Author_id == author.Id).ToList();
        }
        public void CreatePost(Author author, string title, string content)
        {
            Post post = new Post();
            post.Author_id = author.Id;
            post.Content = content;
            post.Title = title;
            post.Date = DateTime.Now;

            messagesDB.Posts.Add(post);
            messagesDB.SaveChanges();
        }
        public void UpdatePost(Post post)
        {
            Post postToUpdate = messagesDB.Posts.First(p => p.Id == post.Id);
            postToUpdate.Author_id = post.Author_id;
            postToUpdate.Date = post.Date;
            postToUpdate.Content = post.Content;
            postToUpdate.Title = post.Title;

            messagesDB.SaveChanges();
        }
        public void DeletePost(Post post)
        {
            Post postToDelete = messagesDB.Posts.First(p => p.Id == post.Id);
            messagesDB.Posts.Remove(postToDelete);
            messagesDB.SaveChanges();
        }
    }
}
