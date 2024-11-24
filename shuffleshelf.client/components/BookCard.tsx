import React from 'react';
import { Button, Card } from 'react-bootstrap';
import { Book } from '../src/App';

interface Props {
    book: Book
}

const BookCard: React.FC<Props> = ({ book }) => {
    return (
        <Card style={{ backgroundColor: 'whitesmoke' }}>
            <a target="_blank"
                href={`https://www.worldofbooks.com/en-gb/products/${book.product_handle}`}>
                <Card.Img
                    variant="top"
                    src={book.image_url}
                    height="300px"
                    style={{ padding: "0.5rem"}}
                />
            </a>
            <Card.Body style={{ backgroundColor: 'white' }}>
                <Card.Title>{book.short_title}</Card.Title>
                <Card.Text>Author: {book.author}</Card.Text>
                <Card.Text>Published Date: {book.date_published}</Card.Text>
            </Card.Body>
            <Card.Footer>
                <Card.Text>
                    <Button variant="success"
                        target="_blank"
                        href={`https://www.worldofbooks.com/en-gb/products/${book.product_handle}`}>
                        Prices from {book.is_uk ? `\u00A3` : `\u0024`}
                        {book.from_price.toFixed(2)}
                    </Button>
                </Card.Text>
            </Card.Footer>
        </Card>
    );
};

export default BookCard;