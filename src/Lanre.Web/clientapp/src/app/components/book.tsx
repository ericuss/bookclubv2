import { FC, useEffect, useState } from "react";
// import { useBooks } from "../shared/hooks/useBooks.hook";
// import { BooksService, ImportBookRequest } from '../services/bookService'
import { Book } from "../shared/types/types";
import { Card } from "react-bootstrap";
import './index.scss';

type BookProps = {
    book: Book,
    selectBook?: (book: Book) => void,
    children?: JSX.Element,
    classes?: string,
}

export const BookComponent: FC<BookProps> = ({ book: bookRaw, selectBook: selectBookRaw, children, classes }) => {
    
    const [book, setBook ] = useState<Book>(bookRaw);
    // const [isImporting, setImporting] = useState(false);
    // const { loadBooks } = useBooks();

    function selectBook() {
        if(selectBookRaw != undefined) {
            book.selected = !!!book.selected;
            setBook({...book});
            selectBookRaw(book);
        }
    }

    // useEffect(() => {
    //     setBook({...bookRaw});
    // }, [bookRaw]);

    // async function importBook(e: any) {
    //     e.preventDefault()
    //     setImporting(true);
    //     try {
    //         const request: ImportBookRequest = {
    //             url: e.currentTarget.elements["book-url"].value,
    //         }

    //         if (!request.url) {
    //             console.log("Request has empty values");
    //         } else {
    //             await BooksService.import(request);
    //             await loadBooks();
    //         }

    //     } catch (error) {
    //         console.log(error);
    //     }

    //     setImporting(false);
    // }

    // async function markAsReaded(id: string) {
    //     try {
    //         await BooksService.readed(id);
    //         await loadBooks();

    //     } catch (error) {
    //         console.log(error);
    //     }
    // }

    // async function markAsUnreaded(id: string) {
    //     try {
    //         await BooksService.unreaded(id);
    //         await loadBooks();

    //     } catch (error) {
    //         console.log(error);
    //     }
    // }

    // function classes(){
    //     return `book p-2 mt-3 bg-dark-green ${book.selected === true ? 'book-selected': 'book-not-selected'}` ;
    // }

    // if(bookRaw == null || book == null) return <></>;

    return (<Card className={`book p-2 mt-3 bg-dark-green ${book?.selected === true ? 'book-selected': 'book-not-selected'} ${classes || ''} ` }  style={{ width: '18rem' }} onClick={() => selectBook()}>
            {/* {book.readed !== null && book.readed?.indexOf(user.iss) !== -1
                    ? <button className="btn btn-warning" onClick={() => markAsUnreaded(book.id)}>Mark as unreaded</button>
                    : <button className="btn btn-success" onClick={() => markAsReaded(book.id)}>Mark as readed</button>
                } */}
            <Card.Img variant="top" src={book.imageUrl} alt="Book cover" height={400} width={270}/>
            <Card.Body className="pt-1">
                <Card.Title>{book.name}{book.selected}</Card.Title>
                <Card.Subtitle >{book.series}</Card.Subtitle>
                <Card.Subtitle className="mt-2" >{book.authors}</Card.Subtitle>
                {/* style={{height: "100%"}} */}
                <Card.Text className="mt-2 d-flex flex-column position-relative" >
                    <dfn title={book.sinopsis}> <span className="text-ellipsis--3">{book.sinopsis}</span> </dfn>
                    <span><i>Added by {book.username}</i></span>
                    <span className="text-end">{book.rating}</span>
                    <span className="text-end">{book.pages}</span>
                </Card.Text>
                <a href={book.url} className="btn btn-secondary w-100" style={{marginTop: "auto",marginBottom: "0px"}} rel="noreferrer" target="_blank">Go to book source</a>
                <br/>
                {children}
            </Card.Body>
        </Card>);
}