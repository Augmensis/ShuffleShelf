import { useEffect, useState } from 'react';
import './App.css';
import * as React from 'react';

interface Book {
    id: number,
    short_title: string,
    long_title: string,
    author: string,
    isbn_10: string,
    isbn_13: string,
    image_url: string,
    date_published: string,
    product_handle: string,
    is_uk: boolean,
    is_usa: boolean,
    is_low_stock: boolean,
    is_high_stock: boolean,
    is_used: boolean,
    is_new: boolean,
    from_price: number,
}

function App() {
    const [books, setBooks] = useState<Book[]>();

    useEffect(() => {
        getRandomBooks();
    }, []);

    const contents = books === undefined
        ? <p><em>Loading...</em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Title</th>
                    <th>Author</th>
                    <th>From Price</th>
                    <th>Date Published</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
                {books.map(book =>
                    <tr key={book.id}>
                        <td>{book.short_title}</td>
                        <td>{book.author}</td>
                        <td>{book.from_price}</td>
                        <td>{book.date_published}</td>
                        <td><a href={`https://www.worldofbooks.com/en-gb/products/${book.product_handle}`}>View Book</a></td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tableLabel">A Random Selection of books from World Of Books!</h1>
            <p>What will you find for your shelves today?</p>
            {contents}
        </div>
    );

    async function getRandomBooks() {
        const response = await fetch('/api/book/random/5');
        if (response.ok) {
            const data = await response.json();
            setBooks(data);
        }
    }
}

export default App;