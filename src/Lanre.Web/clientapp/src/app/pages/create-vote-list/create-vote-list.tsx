import { FC } from "react";
import { Button, Form } from "react-bootstrap";
import { useBooks } from "./useBooks.hook";
import { BookComponent } from '../../components/book';

import './index.css';
import { Book } from "@/app/shared/types/types";
import { BookForVote } from "../vote-list-detail/types";

export const CreateVoteList: FC = () => {
    const { state: books, setState: setBooks,createVoteList } = useBooks();

    function selectBook(bookRaw: Book) {
        
        console.log(bookRaw)
        // const book = books.find(x => x.id === bookRaw.id);
        // if (book != null) {
        //     console.log('selected')
        //     book.selected = !!!book.selected;
        // }
        books.forEach(book => {
            if (book.id === bookRaw.id) {
                console.log('selected')
                book.selected = !!!book.selected;
            }
        });
       
        setBooks([...books]);
        console.log(books)
    }

    async function createList(e: any) {
        e.preventDefault()
        await createVoteList(
            e.currentTarget.elements["vote-list-name"].value,
            e.currentTarget.elements["vote-list-number-of-votes"].value,
            books.filter(x => x.selected).map(x => x.id)
        )
        console.log(books.filter(x => x.selected))
    }

    return (
        <div className="create-vote-list">
            <h1>Create Vote List</h1>

            <Form onSubmit={createList} className="mt-3 p-3 text-center bg-dark-green">
                <Form.Group className="mb-3" controlId="vote-list-name">
                    <Form.Label>List name</Form.Label>
                    <Form.Control type="text" placeholder="Enter vote list name" />
                </Form.Group>
                <Form.Group className="mb-3" controlId="vote-list-number-of-votes">
                    <Form.Label>Number of votes</Form.Label>
                    <Form.Control type="number" placeholder="Enter the number of voters for users" />
                </Form.Group>
                <Button variant="primary" type="submit">
                    Create list
                </Button>
            </Form>
            <div className="book-list">
            {/* <BookComponent key={i} book={b} selectBook={(book) => selectBook(book)} /> */}
                {books.map((b, i) => 
                <BookComponent key={i} book={b} classes={b?.selected === true ? 'book-selected' : 'book-not-selected'}>
                <div className="d-flex flex-column">
                    <button onClick={() => selectBook(b)} className={"mt-2 btn btn-primary "}>
                        {b?.selected === true ? 'Selected' : 'Select'}
                    </button>
                </div>
            </BookComponent>
                
                
                )}
            </div>
        </div>
    );

}