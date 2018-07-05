using System;

namespace BookshelfApi.Models
{
    public class Book : IEquatable<Book>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public bool IsLoaned { get; set; }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && string.Equals(Title, other.Title) && string.Equals(Author, other.Author) && string.Equals(Isbn, other.Isbn) && IsLoaned == other.IsLoaned;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Book) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Author != null ? Author.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Isbn != null ? Isbn.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ IsLoaned.GetHashCode();
                return hashCode;
            }
        }
    }
}
