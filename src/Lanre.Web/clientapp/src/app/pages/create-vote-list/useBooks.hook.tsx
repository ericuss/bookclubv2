
import { BookForVote } from './types';
import { useEffect, useState } from 'react';
import { BooksService } from '../../services/bookService'
import { CreateVoteList, VoteListsService } from '../../services/voteListsService'


export interface UseBooksType {
    state: BookForVote[];
    setState: React.Dispatch<React.SetStateAction<BookForVote[]>>;
    loadUnreadedBooks(): Promise<void>;
    createVoteList(name: string, numberOfVotes: number, books: string[]): Promise<void>;
}

export function useBooks(): UseBooksType {
    const [state, setState] = useState<BookForVote[]>([]);

    useEffect(() => {
        loadUnreadedBooks();
    }, []);

    async function loadUnreadedBooks() {
        try {
            const response = await BooksService.get();
            const books = response as BookForVote[] || [];
            books.forEach(x => x.selected = false)
            setState(books);

        } catch (error) {
            console.log(error);
        }
    }

    async function createVoteList(name: string, numberOfVotes: number, books: string[]) {
        try {
            const voteList: CreateVoteList = {
                name,
                numberOfVotes,
                books,
            }
            await VoteListsService.create(voteList);
        } catch (error) {
            console.log(error);
        }
    }

    return { state, setState, loadUnreadedBooks, createVoteList };
}
