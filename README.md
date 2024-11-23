# ShuffleShelf

## About
This is a very basic tool that fetches a random selection of books from World Of Books out of its catalogue of over 0.5m books.

I wanted to make a fun project to experiment with some frontend tech and refine some backend API skills.

Feel free to fork this and have fun with it, but be sensible. We love books, so keep an eye on your request rates.


## How it works

WOB currently uses Shopify as its main online catalogue, along with Algolia search on its frontend. 

This application leverages Algolia's impressive query structure to get a random selection of books for a given category and present them to the user to view and buy at their leisure.

WOB has no affiliate functionality, so this is purely for the joy of finding new books for your shelves and exploring the less-travelled side of WOB!


# TODO:
- [ ] Expand the Algolia service to handle user-provided filters (categories, price ranges, etc)
- [ ] Research limitations with Algolia queries. 500k books are available, but we can only reach the first 25 pages (40 books per page) on the WOB website. 1000 out of 500k books isn't a great selection!

Add React frontend with:
- [ ] Search filter(s)
- [ ] Search results
- [ ] Link(s) to relevant (UK/US) WOB product pages
- [ ] ???
- [ ] Profit


## Want to help?
This is a personal, but publicly available, passion project. You are free to fork and play with it to your heart's desire.

However, if you notice any major security problems or have some other suggestions or enhancements that might be relevant, feel free to create a pull request and I'll take a look.
