using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    internal class AuthorDataRepository
    {
        MessagesDB messagesDB = new MessagesDB();

        public List<Author> GetAllAuthors()
        {
            return messagesDB.Authors.ToList();
        }
        public Author GetAuthor(int id)
        {
            return messagesDB.Authors.First(author => author.Id == id);
        }
        public void CreateAuthor(string firstname, string lastname, DateTime birthdate, DateTime addedDate, string email)
        {
            Author author = new Author();
            author.First_name = firstname;
            author.Last_name = lastname;
            author.Birthdate = birthdate;
            author.Added = addedDate;
            author.Email = email;

            messagesDB.Authors.Add(author);
            messagesDB.SaveChanges();
        }
        public void UpdateAuthor(Author author)
        {
            Author authorToUpdate = messagesDB.Authors.First(a => a.Id == author.Id);
            authorToUpdate.First_name = author.First_name;
            authorToUpdate.Last_name = author.Last_name;
            authorToUpdate.Birthdate = author.Birthdate;
            authorToUpdate.Added = author.Added;
            authorToUpdate.Email = author.Email;
            authorToUpdate.Posts = author.Posts;

            messagesDB.SaveChanges();
        }
        public void DeleteAuthor(Author author)
        {
            Author authorToDelete = messagesDB.Authors.First(a => a.Id == author.Id);
            messagesDB.Authors.Remove(authorToDelete);
            messagesDB.SaveChanges();
        }
    }
}
