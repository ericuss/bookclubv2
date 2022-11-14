
import { Awards, VoteList } from '@/app/shared/types/types';
import { Requests } from './serviceCore'

export interface CreateVoteList {
	name: string;
	numberOfVotes: number;
	books: string[];
}

export interface VoteVoteList {
	id: string;
	votedIds: string[];
	readedIds: string[];
	blockedIds: string[];
}

export const path = '/api/vote-lists';
export const VoteListsService = {
	get: (): Promise<VoteList[]> => Requests.get(path),
	getById: (id: string): Promise<VoteList> => Requests.get(`${path}/${id}`),
	getAward: (id: string): Promise<Awards> => Requests.get(`${path}/${id}/awards`),
	create: (o: CreateVoteList) => Requests.post(path, o),
	vote: (o: VoteVoteList) => Requests.post(`${path}/${o.id}/vote`, o),
};
