import { FC } from "react";
import { Card } from "react-bootstrap";
import { BookForVote } from "./types";

type BookProps = {
    index: number;
    book: BookForVote;
    selectBook: (index: number) => void;
}
export const BookForVoteDetail: FC<BookProps> = ({ index, book, selectBook }) => {
    if (book === null) return <></>;

    return (
        <Card className={"book mt-3" + (book.selected !== true ? '' : 'border border-3 border-primary rounded ')} style={{ width: '18rem' }} onClick={() => selectBook(index)}>
            <Card.Img variant="top" src={book.imageUrl} alt="Book cover" />
            <Card.Body>
                <Card.Title>{book.name}</Card.Title>
                <Card.Subtitle >{book.series}</Card.Subtitle>
                <Card.Subtitle className="mt-2" >{book.authors}</Card.Subtitle>
                <Card.Text className="mt-2 d-flex flex-column position-relative">
                    <dfn title={book.sinopsis}> <span className="text-ellipsis--3">{book.sinopsis}</span> </dfn>
                    <span><i>Added by {book.username}</i></span>
                    <p className="text-end">{book.rating}</p>
                </Card.Text>
                <a href={book.url} className="btn btn-secondary" rel="noreferrer" target="_blank">Go to book source</a>
            </Card.Body>
        </Card>
    );

}