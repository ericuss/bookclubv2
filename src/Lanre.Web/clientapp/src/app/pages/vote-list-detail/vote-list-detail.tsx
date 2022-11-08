import { FC, useEffect, useState } from "react";
import { useVoteList } from "./useVoteList.hook";
import { BookForVote } from "./types";
import { BookComponent } from '../../components/book';

import './index.css';
import React from "react";

export const VoteListDetail: FC = () => {
    const { state: voteList, submitVotes } = useVoteList();
    const [voted, setVoted] = useState<number>(0);
    const [isSubmitValid, setIsSubmitValid] = useState<boolean>(false);
    const [booksForVote, setBooksForVote] = useState<BookForVote[]>([]);


    useEffect(() => {
        setBooksForVote(voteList?.books.map((x) => ({
            ...x,
            selected: false,
            readedByMe: false,
            blocked: false,
        })) as BookForVote[] || [voteList]);
    }, [voteList]);

    useEffect(() => {
        if (voteList == null) return;

        setIsSubmitValid(voteList.numberOfVotes >= voted);
    }, [voteList, voted]);


    useEffect(() => {
        if (booksForVote == null) return;
        setVoted(booksForVote.filter(x => x?.selected === true).length);
    }, [booksForVote]);


    const selectBook = (bookRaw: BookForVote) => {
        if (voteList == null || booksForVote == null) return;
        const book = booksForVote.find(x => x.id === bookRaw.id);
        if (book != null) {
            book.selected = !book.selected;
        }
        setBooksForVote([...booksForVote])
        setVoted(booksForVote.filter(x => x?.selected === true).length);
    };

    async function submitAction(e: any) {
        if (voteList == null || booksForVote == null) return;
        e.preventDefault();
        const selectedBooks = booksForVote.filter(x => x.selected).map(x => x.id) || [];
        const readedBooks = booksForVote.filter(x => x.readedByMe).map(x => x.id) || [];
        const blockedBooks = booksForVote.filter(x => x.blocked).map(x => x.id) || [];
        submitVotes(voteList.id, selectedBooks, readedBooks, blockedBooks);
    }

    const markBookAsReaded = (bookRaw: BookForVote) => {
        const book = booksForVote.find(x => x.id === bookRaw.id);
        if (book != null) {
            book.readedByMe = !!!book.readedByMe;
        }

        setBooksForVote([...booksForVote])
    };

    const markBookAsBlocked = (bookRaw: BookForVote) => {
        const book = booksForVote.find(x => x.id === bookRaw.id);
        if (book != null) {
            book.blocked = !!!book.blocked;
        }
        setBooksForVote([...booksForVote])
    };

    return (
        <div className="vote-vote-list">
            <h1> Vote List {voteList?.name}</h1>
            <div className="d-flex justify-content-between p-3">

                <h5> Voted: {voted}/{voteList?.numberOfVotes}</h5>
                <button onClick={submitAction} className={"btn btn-primary " + (isSubmitValid ? "" : " disabled")}>Vote</button>
            </div>
            <div className="vote-vote-list-books">
                {booksForVote != null
                    && booksForVote.filter(x => x != null).map((b: BookForVote, i) => (
                        <BookComponent key={i} book={b} classes={b?.selected === true ? 'book-selected' : 'book-not-selected'}>
                            <div className="d-flex flex-column">
                                <button onClick={() => selectBook(b)} className={"mt-2 btn btn-primary "}>
                                    {b?.selected === true ? 'Voted' : 'Vote'}
                                </button>
                                <button onClick={() => markBookAsReaded(b)} className={"mt-2 btn btn-secondary " + (b?.readedByMe ? 'readed' : '')}>
                                    {b?.readedByMe === true ? 'Readed' : 'Mark as readed'}
                                </button>
                                <button onClick={() => markBookAsBlocked(b)} className={"mt-2 btn btn-secondary " + (b?.blocked ? 'bloqued' : '')}>
                                    {b?.blocked === true ? 'Bloqued' : 'Bloqued for me'}
                                </button>
                            </div>
                        </BookComponent>
                    ))}
            </div>
        </div>
    );

}