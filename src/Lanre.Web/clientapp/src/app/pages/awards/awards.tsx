import moment from "moment";
import { FC } from "react";
import { useAwards } from "./useAwards.hook";
import { BookForVote } from "./types";
import { BookComponent } from '../../components/book';

import './index.css';

export const Awards: FC = () => {
    const { state: awards } = useAwards();

    return (
        <div className="awards">
            <h1> Awards {awards?.name}</h1>
            <div className="flex flex-column">
                <span>Number of votes: <i>{awards?.numberOfVotes}</i></span>
                <span>Number of books: <i>{awards?.numberOfBooks}</i></span>
                <span>Created at: <i>{moment(awards?.created).format('MMMM Do YYYY')}</i></span>
                <span>Created by: <i>{awards?.userId}</i></span>
            </div>
            <div className="vote-vote-list-books">
                {awards != null
                    && awards.books.filter(x => x != null).map((b: BookForVote, i) => (
                        <BookComponent key={i} book={b} classes={b?.selected === true ? 'book-selected' : 'book-not-selected'}>
                            <div className="d-flex flex-column">
                                <span>Voted: {awards.voted.filter(x => x === b.id).length }</span>
                                <span>Readed: {awards.readed.filter(x => x === b.id).length }</span>
                                <span>Blocked: {awards.blocked.filter(x => x === b.id).length }</span>
                            </div>
                        </BookComponent>
                    ))}
            </div>
        </div>
    );
}