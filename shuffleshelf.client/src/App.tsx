import { useEffect, useState } from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { CardGroup } from 'react-bootstrap';
import BookCard from '../components/BookCard';

export interface Book {
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
        ? <h2><em>Searching for hidden treasures...</em></h2>
        : <CardGroup>
            {books.map(book =>                 
                <BookCard key={book.id} book={book} />                
            )}            
        </CardGroup>;

    return (
        <div>
            <h1 id="tableLabel">A Random Selection of books from World Of Books!</h1>
            <p>What treasures will you find for your shelves today?</p>
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