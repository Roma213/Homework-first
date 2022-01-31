using BLL.Managers.Interfaces;
using BLL.Services.Classes;
using Domain.Models;
using System;
using System.Collections.Generic;
using Domain.Enums;

namespace ComicsShop
{
    class Program
    {
        private static readonly ITagService _tagService;
        private static readonly IComicsService _comicsService;
        private static readonly IAuthorService _authorService;

        static Program()
        {
            _tagService = new TagService();
            _comicsService = new ComicsService();
            _authorService = new AuthorService();
        }

        static void Main(string[] args)
        {
            AddTwoAuthors();
            FirstComicsSearch();
        }

        private static void AddTwoAuthors()
        {
            _authorService.AddAuthor(new Author{ FirstName = "Howard", LastName = "Lovecraft" });
            _authorService.AddAuthor(new Author{ FirstName = "George", LastName = "Orwell" });
        }

        private static void AddTwoComicses()
        {
            _comicsService.AddComics(new Comics{ Name = "Joker" });
            _comicsService.AddComics(new Comics{ Name = "Avengers" });
        }

        private static void AddTwoTags()
        {
            _tagService.AddTag(new Tag{ Name = "Fantasy" });
            _tagService.AddTag(new Tag{ Name = "Noir" });
        }

        private static void DeleteElements()
        {
            _authorService.DeleteAuthor(0);
            _comicsService.DeleteComics(1);
            _tagService.DeleteTag(2);
        }

        private static void EditElements()
        {
            _authorService.EditAuthor(2, new Author { FirstName = "Steven", LastName = "King" });
            _comicsService.EditComics(5, new Comics { Name = "Batman", Order = 4, Pages = 12, PublishingHouse = PublishingHouse.DC});
            _tagService.EditTag(1, new Tag { Name = "Justice League" });
        }

        private static Author FirstAuthorSearch()
        {
            return _authorService.FindOneAuthor(a => a.FirstName == "Frank");
        }

        private static List<Author> SecondAuthorSearch()
        {
            return _authorService.FindManyAuthors(a => a.BirthDate < DateTime.Today);
        }

        private static List<Author> ThirdAuthorSearch()
        {
            return _authorService.FindManyAuthors(a => a.LastName != "Kirby");
        }

        private static Comics FirstComicsSearch()
        {
            return _comicsService.FindOneComics(c => c.Name == "Spider-man");
        }

        private static List<Comics> SecondComicsSearch()
        {
            return _comicsService.FindManyComicses(c => c.Pages < 50);
        }

        private static List<Comics> ThirdComicsSearch()
        {
            return _comicsService.FindManyComicses(c => c.PublishingHouse == PublishingHouse.Marvel);
        }

        private static Tag FirstTagSearch()
        {
            return _tagService.FindOneTag(t => t.Name == "Marvel");
        }

        private static List<Tag> SecondTagSearch()
        {
            return _tagService.FindManyTags(t => t.Name != "Joker");
        }

        private static List<Tag> ThirdTagSearch()
        {
            return _tagService.FindManyTags(t => t.CreationDate != DateTime.Today);
        }


    }
}
