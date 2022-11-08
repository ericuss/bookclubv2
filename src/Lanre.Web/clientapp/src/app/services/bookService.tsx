
import { Book } from '@/app/shared/types/types';
import { Requests } from './serviceCore'

export interface ImportBookRequest {
	url: string;
}

export const path = '/api/books';

export const BooksService = {
	get: (): Promise<Book[]> => Requests.get(path),
	getUnreaded: (): Promise<Book[]> => Requests.get(`${path}/unreaded`),
	import: (o: ImportBookRequest): Promise<void> => Requests.post(path, o),
	readed: (id: string): Promise<void> => Requests.put(`${path}/${id}/readed`, {}),
	unreaded: (id: string): Promise<void> => Requests.put(`${path}/${id}/unreaded`, {}),
};
