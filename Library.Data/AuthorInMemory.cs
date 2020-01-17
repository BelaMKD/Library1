using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Data
{
    public class AuthorInMemory : IAuthorInMemory
    {
        public List<Author> Authors { get; set; }
        public AuthorInMemory()
        {
            Authors = new List<Author>()
            {
                new Author
                {
                    Id=1,
                    FirstName="William",
                    LastName="Shakespeare",
                    NumberOfBooks=100,
                    Description="William Shakespeare (26 April 1564 – 23 April 1616) was an English poet, playwright, and actor, widely regarded as the greatest writer in the English language and the world's greatest dramatist. He is often called England's national poet and the Bard of Avon (or simply the Bard). His extant works, including collaborations, consist of some 39 plays, 154 sonnets, two long narrative poems, and a few other verses, some of uncertain authorship. His plays have been translated into every major living language and are performed more often than those of any other playwright.",
                    ImgPath="william.jpg"
                },
                new Author
                {
                    Id=2,
                    FirstName="Agatha",
                    LastName="Christie",
                    NumberOfBooks=91,
                    Description="Dame Agatha Mary Clarissa Christie, Lady Mallowan (15 September 1890 – 12 January 1976) was an English writer. She is known for her 66 detective novels and 14 short story collections, particularly those revolving around her fictional detectives Hercule Poirot and Miss Marple. Christie also wrote the world's longest-running play, a murder mystery, The Mousetrap, and, under the pen name Mary Westmacott, six romances. In 1971 she was appointed a Dame Commander of the Order of the British Empire (DBE) for her contribution to literature.",
                    ImgPath="agatha.png"
                },
                new Author
                {
                    Id=3,
                    FirstName="Harold",
                    LastName="Robbins",
                    NumberOfBooks=42,
                    Description="Harold Robbins (May 21, 1916 – October 14, 1997) was an American author of popular novels. One of the best-selling writers of all time, he penned over 25 best-sellers, selling over 750 million copies in 32 languages. Robbins was married three times. His first wife, Lillian Machnivitz, was his high school sweetheart. His second wife, Grace Palermo Robbins, whom he married in 1965 and divorced in the early 1990s, published an account of her life with Robbins in 2013. He subsequently married Jann Stapp in 1992, and they remained together until his death. He spent a great deal of time on the French Riviera and at Monte Carlo until his death from respiratory heart failure, at the age of 81 in Palm Springs, California.[5] His cremated remains are interred at Forest Lawn Cemetery in Cathedral City. Robbins has a star on the Hollywood Walk of Fame at 6743 Hollywood Boulevard.",
                    ImgPath="harold.jpg"
                }
            };
        }
        public IEnumerable<Author> GetAuthors()
        {
            return Authors;
        }

        public Author GetAuthor(int Id)
        {
            return Authors.FirstOrDefault(x => x.Id == Id);
        }

        public Author Update(Author author)
        {
            var tempAuthor = Authors.SingleOrDefault(x => x.Id == author.Id);
            if (tempAuthor!=null)
            {
                tempAuthor.FirstName = author.FirstName;
                tempAuthor.LastName = author.LastName;
                tempAuthor.NumberOfBooks = author.NumberOfBooks;
            }
            return tempAuthor;
        }

        public Author Create(Author author)
        {
            author.Id = Authors.Max(x => x.Id) + 1;
            Authors.Add(author);
            return author;
        }
    }
}
