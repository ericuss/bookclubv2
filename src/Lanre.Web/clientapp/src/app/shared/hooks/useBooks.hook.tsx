
import { Book } from '@/app/shared/types/types';
import { useEffect, useState } from 'react';
// import { BooksService } from '@/app/services/bookService'
import { BooksService } from '../../services/bookService'


export interface UseBooksType {
    state: Book[];
    loadBooks(): Promise<void>;
}

export function useBooks(): UseBooksType {
    const [state, setState] = useState<Book[]>([]);

    useEffect(() => {
        loadBooks();
    }, []);

    async function loadBooks() {
        try {
            const books = await BooksService.get();
            books.forEach(x => x.selected = false)

            setState(books || []);

        } catch (error) {
            console.log(error);
        }
    }

    return { state, loadBooks };
}
