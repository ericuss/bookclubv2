import { FC, useState } from "react";
import { useBooks } from "./useBooks.hook";
import { BooksService, ImportBookRequest } from '../../services/bookService'
import { Button, Form } from "react-bootstrap";
import { BookComponent } from '../../components/book';

import './index.css';

export const BookList: FC = () => {
    const { state: books, loadBooks } = useBooks();
    const [isImporting, setImporting] = useState(false);

    async function importBook(e: any) {
        e.preventDefault()
        setImporting(true);
        try {
            const request: ImportBookRequest = {
                url: e.currentTarget.elements["book-url"].value,
            }

            if (!request.url) {
                console.log("Request has empty values");
            } else {
                await BooksService.import(request);
                await loadBooks();
            }

        } catch (error) {
            console.log(error);
        }

        setImporting(false);
    }

    return (
        <div className="books">
            <Form onSubmit={importBook} className="mt-3 p-3 text-center bg-dark-green">
                <Form.Group className="mb-3" controlId="book-url">
                    <Form.Label>Book link</Form.Label>
                    <Form.Control type="text" placeholder="Enter url of book" />
                </Form.Group>

                {/* <button class="btn btn-primary" type="button" disabled>
</button> */}
                <Button variant="primary" type="submit">
                    {isImporting ?
                        <>
                            <span className="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                            Importing ...
                        </>
                        : 'Import'}
                </Button>
            </Form>
            <div className="book-list">
                {books.map((b) => <BookComponent key={b.id}  book={b} selectBook={(book)=> {}} />)}
            </div>
        </div>
    );

}